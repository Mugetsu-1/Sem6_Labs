# Publishing a .NET Application to Azure Cloud ☁️

This project is a small **ASP.NET Core MVC** application (`.NET 10`) designed to demonstrate how to **publish a .NET web application to Azure App Service** — one of the most common ways to host web apps in Microsoft Azure.

---

## 1. What is Azure App Service?

**Azure App Service** is Microsoft's *Platform-as-a-Service (PaaS)* offering for hosting web applications.

| You manage | Azure manages |
|---|---|
| Your application code | Servers, OS, patches |
| Application configuration | Load balancing, scaling |
| Deployment settings | Uptime / availability |

**Why it is ideal for this demo:**
- No server or VM to maintain — just deploy your code.
- Free tier (**F1**) exists, perfect for student / demo projects.
- Automatic HTTPS, custom domains, deployment slots, and logs out of the box.
- Supports .NET, Node.js, Python, Java, containers.

---

## 2. Key Azure Concepts (the "building blocks")

1. **Subscription** — your billing container for all Azure resources.
2. **Resource Group (`rg-`)** — a logical folder that groups related resources (web app, plan, database…) so you can create/delete them together.
3. **App Service Plan** — defines the *compute* your app runs on (OS, region, size, pricing tier: `F1` Free, `B1` Basic, `S1` Standard, `P1v3` Premium…). Scaling and pricing are set here.
4. **Web App** — the actual App Service instance that runs your code and gives you the public URL: `https://<app-name>.azurewebsites.net`.

> **Rule:** the app name must be **globally unique** — it becomes part of the public URL.

---

## 3. Ways to Publish a .NET App to Azure

| Method | Best for | Tools needed |
|---|---|---|
| **Visual Studio Publish (right-click → Publish)** | First-time users, quick demos | Visual Studio + Azure account |
| **Azure CLI + ZIP deploy** *(this project)* | Automation, learning what happens under the hood | `dotnet` CLI + `az` CLI |
| **GitHub Actions (CI/CD)** | Real projects — auto-deploy on every `git push` | GitHub repo |
| **`az webapp up`** | Absolute fastest one-command deploy | `az` CLI |

All methods do the same two things under the hood:

1. **`dotnet publish -c Release`** → compiles the app into a *deployable folder* (DLLs, `wwwroot`, config files) in `bin/Release/net10.0/publish`.
2. **Upload that output to App Service** → Azure runs it on its managed servers using its installed .NET runtime.

---

## 4. Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) (`az --version` to verify)
- An **Azure subscription** — students can get one free at [azure.microsoft.com/free/students](https://azure.microsoft.com/free/students) ($100 credit, no credit card)

## 5. Quick Deploy (script in this project)

```powershell
# 1. Log in to Azure from the terminal
az login

# 2. Run the deployment script
.\deploy-azure.ps1 -ResourceGroup "rg-dotnet-demo" -AppName "dotnet-demo-<yourinitials>" -Location "eastus"
```

**What the script does, step by step:**

| Step | Command | Purpose |
|---|---|---|
| 1 | `dotnet publish -c Release` | Build + package the app |
| 2 | `az group create` | Create the resource group |
| 3 | `az appservice plan create --is-linux` | Create the Linux plan — **auto-tries F1, then falls back through regions and to B1** if the subscription has no free quota |
| 4 | `az webapp create` | Create the Web App with the .NET 10 runtime |
| 5 | `Compress-Archive` + `az webapp deploy --type zip` | ZIP-deploy the publish output |
| 6 | Print the URL | Visit `https://<app-name>.azurewebsites.net` |

---

## ⚠️ Fixing "This region has quota of 0 instances" (region error)

If **every region** you pick fails when creating the App Service Plan — in the
Azure portal, the Visual Studio Publish wizard, or the CLI — with something like:

> *This region has quota of 0 instances for your subscription. Try selecting a different region or SKU.*

…the problem is **not the region**. It is the **pricing tier (SKU)**. Free-Trial,
Azure-for-Students, and some Pay-As-You-Go subscriptions have a **quota of 0 for
the Free `F1` tier**, so changing region never helps.

**Fixes (any one):**

| Fix | How |
|---|---|
| **Use `B1` instead of `F1`** *(recommended)* | Basic B1 ≈ $13/mo and is covered by student / free credit. In VS/portal pick **Basic B1**; with the script it happens automatically (see below). |
| **Let the script auto-fall-back** | `./deploy-azure.ps1 -AppName "myapp"` tries `F1` across regions, then `B1`. |
| **Request quota** | Portal → **Quotas** → App Service → request F1 in a region (slow). |
| **Delete an old free plan** | You may only have a limited number of `F1` plans; delete unused ones. |

> Remember to **delete the resource group afterwards** (section 11) if you used a paid tier, so you don't burn credit.

---

## 6. Manual Deploy (to understand every command)

```powershell
# A. Publish the app to a local folder
dotnet publish AzureProject.csproj -c Release -o ./publish

# B. Create the resource group (eastus = US East region)
az group create -n rg-dotnet-demo -l eastus

# C. Create the App Service plan (F1 = Free tier, Linux)
az appservice plan create -n dotnet-demo-plan -g rg-dotnet-demo --sku F1 --is-linux

# D. Create the Web App with the .NET 10 runtime
az webapp create -n dotnet-demo-app -g rg-dotnet-demo -p dotnet-demo-plan --runtime "DOTNET:10.0"

# E. Zip the publish output and deploy it
Compress-Archive -Path .\publish\* -DestinationPath .\deploy.zip -Force
az webapp deploy -n dotnet-demo-app -g rg-dotnet-demo --src-path .\deploy.zip --type zip
```

Then open **`https://dotnet-demo-app.azurewebsites.net`** 🎉

---

## 7. Publishing from Visual Studio (GUI alternative)

1. Right-click the project → **Publish…**
2. Target: **Azure** → **Azure App Service (Linux)**.
3. Sign in, then choose or create a **Resource Group** + **App Service Plan**.
4. Click **Publish**. Visual Studio builds, packages, and uploads the app for you.
5. The browser opens `https://<app-name>.azurewebsites.net`.

---

## 8. CI/CD with GitHub Actions (how real teams deploy)

```yaml
# .github/workflows/deploy.yml  (simplified)
on: push          # runs on every push
jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with: { dotnet-version: '10.0.x' }
      - run: dotnet publish -c Release -o publish
      - uses: azure/webapps-deploy@v3          # deploys the publish folder
        with:
          app-name: dotnet-demo-app
          publish-profile: ${{ secrets.AZURE_PUBLISH_PROFILE }}
```

Every `git push` now triggers: **build → publish → deploy**. This is *Continuous Deployment*.

---

## 9. Configuration in Azure (App Settings)

Never hard-code secrets in `appsettings.json` for production. Instead, store them as **App Service → Settings → Environment variables** — they override `appsettings.json` at runtime:

```
ASPNETCORE_ENVIRONMENT = Production
MyCustomSetting__ApiKey = <secret>      # double underscore maps to nested config
```

This is why the app's home page displays the **Environment** badge — on Azure it shows `Production` because App Service sets that environment variable for you.

---

## 10. Useful Commands After Deployment

```bash
# Stream live application logs (great for demos)
az webapp log tail -n <app-name> -g <resource-group>

# Restart / stop / start
az webapp restart -n <app-name> -g <resource-group>

# Show app settings
az webapp config appsettings list -n <app-name> -g <resource-group>
```

**Deployment Slots** (Standard tier and above): create a `staging` slot, deploy there first, then **swap** with production for zero-downtime releases.

---

## 11. Cleanup (avoid using free-tier quota)

```bash
az group delete -n rg-dotnet-demo --yes --no-wait
```

Deleting the resource group removes **everything** inside it (plan + web app).

---

## 12. Summary — The Publishing Pipeline

```
dotnet publish ──► publish/ folder ──► ZIP ──► Azure App Service ──► https://<app>.azurewebsites.net
   (build)          (deployable output)      (upload)     (managed hosting)
```

**Talking points for a presentation:**
- PaaS vs IaaS — App Service abstracts away the servers.
- Resource Group → App Service Plan → Web App hierarchy.
- `dotnet publish` produces the artifact; Azure just hosts it.
- Configuration via environment variables (12-factor app style).
- CI/CD automates the same steps on every commit.
