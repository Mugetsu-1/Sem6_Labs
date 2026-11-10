# Lab 8.1 - Student (EF Core) - Database Setup

## 1. Prereq
- SQL Server `SAUGAT\SQLEXPRESS` running
- No SQL file to run - EF creates the DB

## 2. Connection string
Paste in `appsettings.json`:
```
Server=SAUGAT\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```
Note: `\\` in JSON = single `\` in real server name.

## 3. Create database (pick one)
Option A - auto (easiest):
```
dotnet run
```
`Program.cs` creates DB via `EnsureCreated()`.

Option B - migration:
```
dotnet tool restore
dotnet ef database update
```

## 4. Run
```
dotnet run
```
Test: `/Student`, `/Student/Create`

## If it fails
- Keep `TrustServerCertificate=True` (required by EF Core 10)
- Server name must match SSMS exactly
- For SQL login use `User Id=sa;Password=YOUR_PASSWORD;` instead of `Trusted_Connection=True`
