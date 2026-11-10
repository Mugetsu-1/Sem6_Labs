# Publishing to Azure App Service from Visual Studio (Full Process)

This guide shows the complete process of publishing `AzureProject` to Azure **using Visual Studio only** — no Azure CLI required.

---

## Step 0 — Prepare (one time)

1. **Have a Microsoft account + Azure subscription**
   - Students: [azure.microsoft.com/free/students](https://azure.microsoft.com/free/students) → $100 free credit, no credit card needed.
   - Everyone else: [azure.microsoft.com/free](https://azure.microsoft.com/free) → $200 credit for 30 days.
2. **Install Visual Studio 2022** with the **"ASP.NET and web development"** workload installed.
3. Open the project: **File → Open → Project/Solution** → select `AzureProject.slnx` (or the `.csproj`).
4. Test locally first: press **F5** (or Ctrl+F5). The app should open at `https://localhost:7167`. Stop it when done.

---

## Step 1 — Sign in to Azure from Visual Studio

1. Top-right corner of Visual Studio → click the **Sign in** button (or **Tools → Options → Azure Service Authentication**).
2. Sign in with the **same Microsoft account** that owns your Azure subscription.
3. Verify: **View → Server Explorer → Azure** node — your subscription should appear.

---

## Step 2 — Start the Publish wizard

1. In **Solution Explorer**, right-click the **AzureProject** project (not the solution).
2. Click **Publish…**
   - (Alternative: menu **Build → Publish AzureProject**.)

---

## Step 3 — Choose the publish target

1. On the **Publish** screen, target: choose **Azure**.
2. Specific target: choose **Azure App Service (Linux)** *(recommended — cheaper and the free tier is Linux)*.
   - "App Service (Windows)" also works; either is fine for the demo.
3. Click **Next**.

---

## Step 4 — Sign in / select subscription

1. If prompted, sign in with your Microsoft account.
2. Under **Subscription**, pick your subscription from the dropdown.

---

## Step 5 — Create the Azure resources (the wizard creates everything)

You now configure the two Azure resources your app needs:

1. **Resource Group** → click **New…**
   - Name: `rg-dotnet-demo`
   - Region/Location: `East US` (or the region closest to you)
   - Click **Create**.
2. **Hosting Plan (App Service Plan)** → click **New…**
   - Name: `dotnet-demo-plan`
   - **Size:** try **Free (F1)** first. **If you get an error on *every* region you pick** (e.g. *"this region has quota of 0 instances"*), the tier — not the region — is the problem: your subscription has no free quota. Switch **Size** to **Basic (B1)** (covered by student / free credit) and it will succeed. Delete it afterward (see Cleanup).
   - Location: same as the resource group.
   - Click **OK**.
3. Click **Create** / **Finish**.
4. Visual Studio now provisions the resources **directly inside Azure** (you can see them later at [portal.azure.com](https://portal.azure.com) under your resource group).

---

## Step 6 — Publish!

1. Review the summary screen — it shows the profile name, target App Service, and the destination URL:
   `https://<app-name>.azurewebsites.net`
2. Click **Publish**.
3. Watch the **Output** window → it shows:
   `dotnet publish` running → packaging → uploading → deployment complete.
4. When it finishes, the browser opens the site automatically:
   **https://\<app-name\>.azurewebsites.net** 🎉

---

## Step 7 — Verify the deployment

On the live page check:
- The **Environment** badge shows **Production** (Azure sets `ASPNETCORE_ENVIRONMENT=Production` automatically — local F5 shows `Development`).
- The **Server (Host) Name** shows an Azure machine name instead of your PC's name.
- The demo data table renders (Model → Controller → View working in the cloud).

---

## Step 8 — Re-deploying after code changes (one click!)

Once a publish profile exists:

1. Make a code change → save.
2. Solution Explorer → right-click project → **Publish**.
3. The publish summary page opens → click the **Publish** button (top).
4. Visual Studio rebuilds and re-uploads only what is needed. Done.

> The publish profile is stored in `Properties/PublishProfiles/*.pubxml` — you can keep it in source control (it contains no secrets by default).

---

## Optional — Useful things to show in a demo

| Where in Visual Studio / Azure | What it shows |
|---|---|
| **View → Cloud Explorer / Server Explorer → Azure → App Service** | Your live web app, right-click → *View in Browser*, *Attach Debugger*, *View Streaming Logs* |
| Right-click app → **View Streaming Logs** | Live application logs in the Output window |
| [portal.azure.com](https://portal.azure.com) → your Web App → **Deployment Center** | Deployment history (each Visual Studio publish is listed) |
| Web App → **Configuration → Application settings** | Add environment variables / secrets (they override `appsettings.json`) |
| Web App → **Log stream** | Live logs in the portal |
| Web App → **Metrics / Overview** | Requests, response time, CPU — shows why PaaS is useful |

---

## Troubleshooting

| Problem | Fix |
|---|---|
| "The app name is not available" | The App Service name is taken globally — go back and change it (name must be unique, it forms the URL) |
| Publish fails with 401/403 | Sign out of Visual Studio (top-right avatar → Sign out), sign back in, retry |
| Error on **every** region when creating the plan ("quota of 0 instances") | Not a region problem — your subscription has no **F1 (Free)** quota. Change **Size** to **Basic (B1)**. |
| Free (F1) tier not offered | Use **Basic (B1)**, or create resources in another region |
| Site shows error after deploy | Portal → Web App → **Log stream**, or Visual Studio → View Streaming Logs |
| HTTPS warning in browser | App Service certificates are trusted; if your localhost cert is the issue, it's only local — the Azure URL uses a valid certificate |

---

## Cleanup — IMPORTANT (don't burn your free credit)

1. Go to **[portal.azure.com](https://portal.azure.com)** → **Resource groups**.
2. Click `rg-dotnet-demo`.
3. Click **Delete resource group** → type the name to confirm → **Delete**.

This removes the plan + web app + everything inside it in one step.
