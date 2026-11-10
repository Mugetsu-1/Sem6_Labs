# Lab 10 — Explanation of the Output

The screenshots show user **registration, login, logout** and a **secured resource** protected by the `[Authorize]` attribute. They demonstrate the two ideas of Unit 8: **authentication** — proving who the user is, done by the Identity cookie that `PasswordSignInAsync` creates at login — and **authorization** — `[Authorize]` deciding what that user is allowed to open.

1. **Home page (before login)** — *"You are not logged in…"* with Register/Login buttons; the user is anonymous.
2. **Register page** — the four fields: username, email, password, confirm password.
3. **Register with a weak password** — the Identity password-policy errors shown in the validation summary.
4. **Login page** — reached automatically after registration, because registering does not log the user in.
5. **Home page after login** — *"You are logged in as <user>"* → the authentication cookie has been issued.
6. **Secured page while NOT logged in** — opening `/Home/Secured` redirects to `/Account/Login?ReturnUrl=%2FHome%2FSecured` and only the **login form** is displayed. The secured page is never sent to the browser — this proves *other users are not allowed*.
7. **Secured page after login** — the same URL now returns the page: the heading **Secured**, the message **"Hello <user>"**, the line *"This page is decorated with the [Authorize] attribute, so only a registered (logged in) user can access it."* and the **Logout** button — this proves *only the registered user gets access*.
8. **After Logout** — the same URL is redirected to the login page again, because the cookie was deleted.
9. **SQL output** — the row in `AspNetUsers` (user name, email and the **hashed** password, never plain text) and the **8 Identity tables** created by the migration.

### Where you land after logging in (ReturnUrl)

The login page is reached in two different ways, and the `ReturnUrl` parameter decides where you go after a successful login:

- **Register → Login**: after a successful registration the app does `RedirectToAction("Login")`, so the Login page is opened with **no** `ReturnUrl`. After logging in you are taken to the **Home page** (`RedirectToAction("Index", "Home")`).
- **Secured tab (or typing `/Home/Secured`) → Login**: the `[Authorize]` redirect opens the Login page as `/Account/Login?ReturnUrl=%2FHome%2FSecured`. The view stores this value in a hidden field, the controller checks it with `Url.IsLocalUrl(...)` and redirects to it — so after logging in you go **directly to the Secured page** instead of the Home page.

Both cases were tested: logging in from the Register → Login flow lands on `/` (Home), while logging in after being bounced from the Secured tab lands on `/Home/Secured`.

### All the tables are created from the migration

All eight Identity tables — `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, `AspNetUserClaims`, `AspNetRoleClaims`, `AspNetUserLogins`, `AspNetUserTokens` and `__EFMigrationsHistory` — are created **from the EF Core migration**, not manually. The command `dotnet ef migrations add Create` generates `Migrations/Create.cs`, whose `Up()` method contains the `CreateTable(...)` calls for all eight tables, and `dotnet ef database update` applies it: EF Core first creates the **`IdentityUserDB`** database itself (if it does not already exist) and then executes the migration, which creates every table inside it. No table is created by hand in SSMS, and `EnsureCreated()` is not used here (that was the approach in Lab 8) — using migrations is exactly what the lab question asks for. After the migration runs, only `AspNetUsers` (the registered users) and `__EFMigrationsHistory` (the applied-migration record) contain rows, while the remaining six tables are created but remain empty because no roles, claims, external logins or tokens are used.

In short: the same page is **blocked before login** (the visitor sees the login form) and **opens after login** (the visitor sees "Hello <user>"), which is exactly the behaviour the `[Authorize]` attribute produces.

### Why 6 of the 8 Identity tables stay empty

`IdentityDbContext` creates all 8 Identity tables automatically, but each table is filled only by the Identity feature that uses it. In this application only two of them actually contain data: **`AspNetUsers`**, which is filled when a user registers (it holds our registered users — user name, e-mail and the hashed password), and **`__EFMigrationsHistory`**, which receives one row when a migration is applied to the database (it records the applied `Create` migration). The remaining six tables stay empty because the features that use them are not part of this application. **`AspNetRoles`** and **`AspNetUserRoles`** would be filled only if roles were created — for example with `roleManager.CreateAsync(new IdentityRole("Admin"))` — and users were assigned to those roles. **`AspNetUserClaims`** and **`AspNetRoleClaims`** would be filled only if claims were added to a user or a role with `userManager.AddClaimAsync(...)`. **`AspNetUserLogins`** is used only when an external login provider such as Google or Facebook is configured; it stores the provider's login data, not login times. Finally, **`AspNetUserTokens`** is used only when a token provider stores data, such as two-factor-authentication keys or e-mail-confirmation tokens. Since this lab only requires user registration, login/logout and the `[Authorize]` attribute on a secured resource, no roles, claims, external logins or tokens are used anywhere in the application — so the six empty tables simply confirm that the migration created the complete Identity schema, while only the user-related part of it is actually used by this application.
