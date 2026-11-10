# Lab 10 - ASP.NET Core Identity - Database Setup

Unit 8 (Securing ASP.NET Core Application): ASP.NET Core Identity + EF Core + SQL Server.

Routes: `/Account/Register`, `/Account/Login`, `/Account/Logout`, `/Home/Secured` (`[Authorize]`).

## 1. Prereq
- SQL Server `SAUGAT\SQLEXPRESS` running
- .NET 10 SDK (`net10.0`)
- Packages already referenced in `Lab10.csproj` (all `10.0.12`):
  `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Design`, `Microsoft.EntityFrameworkCore.Tools`
- `dotnet-ef` CLI - only needed to re-generate the migration:
```
dotnet tool install --global dotnet-ef --version 10.0.12
```

## 2. Connection string
`appsettings.json` -> `ConnectionStrings:DefaultConnection`:
```
Server=SAUGAT\\SQLEXPRESS;Database=IdentityUserDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```
Note: `\\` in JSON = single `\` in the real server name.

## 3. Create the database
The migration is already generated in `Migrations/` (`20260918192145_InitialCreate`), so just run:
```
dotnet ef database update
```
If the `Migrations` folder is ever deleted, re-create it first:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
`InitialCreate` creates 8 tables: `AspNetUsers`, `AspNetRoles`, `AspNetUserClaims`, `AspNetRoleClaims`, `AspNetUserLogins`, `AspNetUserRoles`, `AspNetUserTokens`, `__EFMigrationsHistory`.

## 4. Run
```
dotnet run
```
or F5 in Visual Studio -> `https://localhost:7215` (http `http://localhost:5205`).

## 5. Test walkthrough (verified end-to-end)
| # | Do this | What you get |
| :-- | :-- | :-- |
| 1 | Open `/` | "You are not logged in..." + Register / Login buttons |
| 2 | Open `/Home/Secured` | 302 redirect to `/Account/Login?ReturnUrl=%2FHome%2FSecured` (blocked by `[Authorize]`) |
| 3 | Register: UserName `SauTest`, Email `sautest@test.com`, Password `Test@123`, ConfirmPassword `Test@123` | 302 redirect to `/Account/Login` |
| 4 | Login with that email + password | 302 redirect to `/`, nav bar shows `Logout (SauTest)` |
| 5 | Open `/Home/Secured` | `Hello SauTest` + a Logout button |
| 6 | Click Logout | 302 back to `/`, and `/Home/Secured` is protected again |
| 7 | Open `/Account/Login?returnUrl=https://evil.example.com` and log in | Redirected to `/` (the local-URL check in `AccountController` blocks the open redirect) |
| 8 | POST a form without the hidden token (e.g. save the Register page HTML, delete `__RequestVerificationToken`, submit) | HTTP 400 - `[ValidateAntiForgeryToken]` on `Register`/`Login` blocks CSRF |
| 9 | Open `/Account/Logout` while NOT logged in | Redirected to `/Account/Login` - the whole `AccountController` is `[Authorize]`, only `Register`/`Login` are `[AllowAnonymous]` |

Check the row that was created:
```sql
USE IdentityUserDB;
SELECT UserName, Email, LEN(PasswordHash) AS HashLength FROM dbo.AspNetUsers;
```
`PasswordHash` is a stored hash (84 chars), the password itself is never saved. Delete the test user when you are done:
```sql
DELETE FROM dbo.AspNetUsers WHERE Email = 'sautest@test.com';
```

## 6. Password rules (default Identity policy)
Errors shown by the Register form (verified live):
- Passwords must be at least 6 characters.
- Passwords must have at least one uppercase ('A'-'Z').
- Passwords must have at least one lowercase ('a'-'z').
- Passwords must have at least one digit ('0'-'9').
- Passwords must have at least one non alphanumeric character.
- `Password and Confirm Password do not match` (from `[Compare]` in `Models/Register.cs`)

So `Test@123` works, `abc` does not.

## 7. Mapping to the Unit 8 lab question (slide 70 of `Unit 8 Securing APP.pdf`)

| Lab question says | Where it is implemented |
| :-- | :-- |
| "user authentication and authorization using ASP.NET Core Identity" | `Program.cs` -> `AddIdentity<AppUser, IdentityRole>()`, `UseAuthentication()` / `UseAuthorization()` |
| "Configure Identity with Entity Framework Core and SQL Server" | Identity + EF Core SQL Server packages, `AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(...))` |
| "create a custom AppUser class by extending IdentityUser" | `Models/AppUser.cs` (`AppUser : IdentityUser`) - slide 13 |
| "configure an AppIdentityDbContext for storing Identity data" | `Models/AppIdentityDbContext.cs` (`IdentityDbContext<AppUser>`) - slide 14 |
| "Configure the Identity services in Program.cs" | `AddIdentity<...>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders()` - slide 17 |
| "create the required database using EF Core migrations" | `Migrations/Create.cs` (+ `Create.Designer.cs`) applied with `dotnet ef database update` -> 8 tables - slides 18-19 |
| "user registration with fields such as username, email, password, and confirm password" | `Models/Register.cs` + `Views/Account/Register.cshtml` + `AccountController.Register` |
| "implement login and logout functionality" | `Models/Login.cs` + `Views/Account/Login.cshtml` + `AccountController.Login` / `Logout` - slides 31-35 |
| "illustrate the Authentication and authorization using [Authorize] attribute in a secured resource ... only the registered user gets access" | `HomeController.Secured` (`[Authorize]`) + `Views/Home/Secured.cshtml` -> "Hello &lt;user&gt;"; anonymous visitors are redirected to the login page - slides 36-39 |

Extra patterns taken from the same slides:

- `[Authorize]` on the whole `AccountController`, `[AllowAnonymous]` on `Register`/`Login` (slide 32).
- `[ValidateAntiForgeryToken]` on both POST actions (slide 33) - also demonstrates the CSRF protection of section 8.3.3.
- Local-URL check before `Redirect(login.ReturnUrl)` - demonstrates the open-redirection protection of section 8.3.4.

Not required by the lab question (left out on purpose): the `AdminController` user CRUD of slides 20-29 and the Role/Claim/Policy authorization demos of section 8.2.

## 8. If the database is missing ("transient failure" error)

`InvalidOperationException: ... likely due to a transient failure. Consider enabling transient error resiliency by adding 'EnableRetryOnFailure'` is what EF Core prints when the **database does not exist**; `EnableRetryOnFailure` does not help. Check and fix:

```
sqlcmd -S SAUGAT\SQLEXPRESS -E -Q "SELECT name FROM sys.databases"     -- is IdentityUserDB listed?
dotnet ef database update                                              -- if not, this creates it (8 tables)
```

## If it fails
- Keep `TrustServerCertificate=True` (required by EF Core 10)
- `Login Failed: Invalid Email or password` -> the user must be registered first (`/Account/Register`), and the DB must exist
- `dotnet ef` not recognized -> install the tool (step 1) or run `dotnet tool restore`
- Deleting rows with `sqlcmd` needs `-I` (`SET QUOTED_IDENTIFIER ON`), otherwise you get "DELETE failed because the following SET options have incorrect settings: 'QUOTED_IDENTIFIER'"
- Database already exists with an older schema -> drop `IdentityUserDB` in SSMS and run `dotnet ef database update` again
