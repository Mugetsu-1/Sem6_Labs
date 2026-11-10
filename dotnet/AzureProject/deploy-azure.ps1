<#
.SYNOPSIS
    Deploy the ASP.NET Core (.NET 10) app to Azure App Service (Linux).

.DESCRIPTION
    Robust deployment script that automatically works around the most common
    blocker for student / free-trial subscriptions:

        "This region has quota of 0 instances for your subscription.
         Try selecting a different region or SKU."

    It tries your preferred pricing tier + region first, then falls back
    through a list of regions and (optionally) a paid tier until one has
    capacity. It also uses the correct .NET 10 Linux runtime string.

    Prerequisites:
      - Azure CLI installed  ->  https://aka.ms/installazurecliwindows
      - .NET 10 SDK
      - Signed in            ->  az login

.EXAMPLE
    ./deploy-azure.ps1 -AppName "dotnet-demo-<yourinitials>"

.EXAMPLE
    ./deploy-azure.ps1 -ResourceGroup "rg-dotnet-demo" -AppName "dotnet-demo-sg1" -Location "eastus" -Sku "F1"
#>

[CmdletBinding()]
param(
    # Must be globally unique - it becomes https://<AppName>.azurewebsites.net
    [Parameter(Mandatory = $true)]
    [string]$AppName,

    [string]$ResourceGroup = "rg-dotnet-demo",

    # Preferred region, tried first. Falls back to $FallbackLocations on quota errors.
    [string]$Location = "eastus",

    # Preferred pricing tier. F1 = Free. Falls back to $FallbackSku if quota is 0.
    [string]$Sku = "F1",

    # Paid tier used ONLY if the free tier has no quota. B1 ~ $13/mo,
    # covered by Azure-for-Students / free credit. Set to "" to disable.
    [string]$FallbackSku = "B1",

    [string[]]$FallbackLocations = @(
        "eastus", "eastus2", "westus2", "centralus",
        "westeurope", "northeurope", "uksouth",
        "southeastasia", "centralindia"
    ),

    [string]$ProjectPath = "./AzureProject.csproj",
    [string]$PublishFolder = "./publish",
    [string]$Runtime = "DOTNET:10.0"
)

$ErrorActionPreference = "Stop"

# ---------------------------------------------------------------------------
# 0. Preconditions: Azure CLI installed + logged in
# ---------------------------------------------------------------------------
if (-not (Get-Command az -ErrorAction SilentlyContinue)) {
    Write-Error "Azure CLI (az) is not installed. Install it from https://aka.ms/installazurecliwindows (or 'winget install Microsoft.AzureCLI'), open a new terminal, run 'az login', then re-run this script."
    exit 1
}

az account show *> $null
if ($LASTEXITCODE -ne 0) {
    Write-Host "Not logged in to Azure. Running 'az login'..." -ForegroundColor Yellow
    az login | Out-Null
    if ($LASTEXITCODE -ne 0) { Write-Error "az login failed."; exit 1 }
}

# ---------------------------------------------------------------------------
# 1. Build + publish (framework-dependent -> Azure supplies the .NET runtime)
# ---------------------------------------------------------------------------
Write-Host "Building and publishing (Release)..." -ForegroundColor Cyan
dotnet publish $ProjectPath -c Release -o $PublishFolder
if ($LASTEXITCODE -ne 0) { Write-Error "dotnet publish failed."; exit 1 }

# ---------------------------------------------------------------------------
# 2. Resource group (its location is only metadata - resources may live anywhere)
# ---------------------------------------------------------------------------
Write-Host "Ensuring resource group '$ResourceGroup'..." -ForegroundColor Cyan
az group create --name $ResourceGroup --location $Location | Out-Null
if ($LASTEXITCODE -ne 0) { Write-Error "Could not create resource group."; exit 1 }

# ---------------------------------------------------------------------------
# 3. App Service plan  ->  THE FIX for "region has quota of 0 instances".
#    Try (preferred SKU x preferred region) first, then walk regions, then
#    fall back to the paid SKU. First combination with capacity wins.
# ---------------------------------------------------------------------------
$planName    = "$AppName-plan"
$skusToTry   = @($Sku)
if ($FallbackSku -and $FallbackSku -ne $Sku) { $skusToTry += $FallbackSku }
$regionsToTry = @($Location) + ($FallbackLocations | Where-Object { $_ -ne $Location })

$planCreated = $false
$chosenSku = $null

foreach ($sku in $skusToTry) {
    if ($sku -eq $FallbackSku -and $sku -ne $Sku) {
        Write-Warning "Free tier '$Sku' had no quota in any region. Falling back to PAID tier '$FallbackSku' (~costs credit). Ctrl+C to abort."
    }
    foreach ($region in $regionsToTry) {
        Write-Host "  trying plan: sku=$sku region=$region ..." -ForegroundColor DarkCyan
        $out = az appservice plan create --name $planName --resource-group $ResourceGroup `
                   --location $region --sku $sku --is-linux 2>&1
        if ($LASTEXITCODE -eq 0) {
            $planCreated = $true; $chosenSku = $sku
            Write-Host "App Service plan created: sku=$sku region=$region" -ForegroundColor Green
            break
        }
        $reason = ($out | Select-String -Pattern 'quota|capacity|not available|SubscriptionIsOverQuota|NotAvailableForSubscription' | Select-Object -First 1)
        Write-Warning "  no capacity (sku=$sku region=$region): $reason"
    }
    if ($planCreated) { break }
}

if (-not $planCreated) {
    Write-Error "No region/SKU had capacity. Request a quota increase in the Azure portal, or pass a different -Sku / -FallbackSku."
    exit 1
}

# ---------------------------------------------------------------------------
# 4. Web App (inherits the plan's region). Resolve the correct .NET 10 Linux
#    runtime moniker from Azure itself (avoids DOTNET vs DOTNETCORE guesswork).
# ---------------------------------------------------------------------------
Write-Host "Resolving .NET 10 Linux runtime..." -ForegroundColor Cyan
$detected = az webapp list-runtimes --os linux -o tsv 2>$null |
            Where-Object { $_ -match '(?i)dotnet.*[:|]\s*10\.0' } |
            Select-Object -First 1
if ($detected) {
    $Runtime = $detected.Trim()
    Write-Host "  using runtime '$Runtime'" -ForegroundColor DarkCyan
} else {
    Write-Warning "  could not auto-detect; using '$Runtime'. If create fails, run: az webapp list-runtimes --os linux"
}

Write-Host "Creating Web App '$AppName'..." -ForegroundColor Cyan
$webOut = az webapp create --name $AppName --resource-group $ResourceGroup `
              --plan $planName --runtime $Runtime 2>&1
if ($LASTEXITCODE -ne 0) {
    if ($webOut -match 'already exists|Conflict|not available') {
        Write-Error "Web App name '$AppName' is taken or invalid. It must be globally unique - pick another -AppName."
    } else {
        Write-Error "az webapp create failed: $webOut"
    }
    exit 1
}

# ---------------------------------------------------------------------------
# 5. Configuration: force Production + HTTPS-only (12-factor style)
# ---------------------------------------------------------------------------
Write-Host "Applying app settings..." -ForegroundColor Cyan
az webapp config appsettings set --name $AppName --resource-group $ResourceGroup `
    --settings ASPNETCORE_ENVIRONMENT=Production | Out-Null
az webapp update --name $AppName --resource-group $ResourceGroup --https-only true | Out-Null

# ---------------------------------------------------------------------------
# 6. ZIP deploy the publish output
# ---------------------------------------------------------------------------
Write-Host "Deploying package..." -ForegroundColor Cyan
$zip = "deploy.zip"
Compress-Archive -Path "$PublishFolder/*" -DestinationPath $zip -Force
az webapp deploy --name $AppName --resource-group $ResourceGroup --src-path $zip --type zip | Out-Null
$deployExit = $LASTEXITCODE

# ---------------------------------------------------------------------------
# 7. Cleanup local artifacts
# ---------------------------------------------------------------------------
Remove-Item $zip -Force -ErrorAction SilentlyContinue
Remove-Item $PublishFolder -Recurse -Force -ErrorAction SilentlyContinue

if ($deployExit -ne 0) { Write-Error "Deployment upload failed."; exit 1 }

Write-Host ""
Write-Host "Deployment complete!  (tier=$chosenSku)" -ForegroundColor Green
Write-Host "URL: https://$AppName.azurewebsites.net" -ForegroundColor Green
Write-Host "Logs: az webapp log tail -n $AppName -g $ResourceGroup" -ForegroundColor DarkGray
