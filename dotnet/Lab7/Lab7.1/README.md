# Lab 7.1 - Inventory (ADO.NET) - Database Setup

## 1. Prereq
- SQL Server `SAUGAT\SQLEXPRESS` running
- SSMS installed

## 2. Create database
1. Open `SQLSetup.sql` (in this folder) in SSMS
2. Press Execute (F5)
- Creates `Company` DB, `Inventory` table, `ReadInventory` proc, 1 sample row

## 3. Connection string
Paste in `appsettings.json`:
```
Data Source=SAUGAT\\SQLEXPRESS; Database=Company; Trusted_Connection=True; MultipleActiveResultSets=true
```
Note: `\\` in JSON = single `\` in real server name.

## 4. Run
```
dotnet run
```
Test: `/` (list), `/Home/Create`, `/Home/Update/1`

## If it fails
- Server name must match SSMS exactly
- For SQL login use `User Id=sa;Password=YOUR_PASSWORD;` instead of `Trusted_Connection=True`
