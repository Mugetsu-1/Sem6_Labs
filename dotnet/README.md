# dotnet

C# practice solutions for .NET assignments.

## Projects

- **Unit1CH1.2** - Practice questions for Unit 1, Chapter 1.2 covering basic C# concepts: data types, operators, control flow, loops, arrays, and algorithms.
- **Unit1CH1.3** - Practice questions for Unit 1, Chapter 1.3 covering OOP fundamentals: classes, objects, constructors, destructors, method overloading, arrays, and string manipulation.
- **Unit1CH1.6** - Practice questions for Unit 1, Chapter 1.6 covering delegates, events, collections (generic and non-generic), and File I/O operations.
- **Lab1** - Lab assignments covering Unit 1 Chapters 1.4 and 1.5: inheritance, polymorphism, interfaces, abstraction, exception handling, partial classes, and advanced OOP concepts.
- **Lab2** - Lab assignments covering delegates, multicast delegates, events, multicast events, custom events, non-generic and generic collections, File I/O, serialization/deserialization, async/await programming, LINQ query and method syntax, and built-in/custom attributes.
- **Lab3.1** - ASP.NET Core starter app with static content and basic hosting setup.
- **Lab3.2** - ASP.NET Core MVC app for student data and controller/view practice.
- **Lab3.3** - ASP.NET Core MVC app for employee management with repository-style models and views.
- **StdMVCDetail** - ASP.NET Core MVC app for student data management with repository-style models and full CRUD views (list, details, create, edit, delete).
- **StdFormMVC** - ASP.NET Core MVC app with a student detail form (name, roll no, age, department, address, GPA) using a table-style form layout, in-memory list storage, and validation.
- **Lab4** - ASP.NET Core MVC app focusing on Controllers, Actions, Action results and Action Selectors.
- **Lab5** - ASP.NET Core MVC app on Razor Views.
- **Lab6** - ASP.NET core MVC app on TagHelepr, Routing and Models.
- **Lab7** - ASP.NET Core MVC app for Unit 5.1 (Working with Database using ADO.NET).
- **Lab8** - ASP.NET Core MVC app for Unit 5.2 (Working with Database using Entity Framework).
- **Lab9** - ASP.NET Core MVC app for Unit 6 (State Management): Session state, TempData, Cookies, Query Strings and Hidden Fields.
- **Lab10** - ASP.NET Core MVC app for Unit 8 (Securing ASP.NET Core Application): ASP.NET Core Identity with EF Core and SQL Server, custom `AppUser`, user registration (username, email, password, confirm password), login/logout, and `[Authorize]` secured resources.

## Database Setup

Labs that use SQL Server (`SAUGAT\SQLEXPRESS`) create their database as follows:

| Lab | Database | How it is created |
| :-- | :-- | :-- |
| Lab7.1 | `Company` | Run `SQLSetup.sql` in SSMS (see `Lab7\Lab7.1\README.md`) |
| Lab7.2 | `EmployeeDB` | Run `SQLSetup.sql` in SSMS (see `Lab7\Lab7.2\README.md`) |
| Lab8.1 | `StudentDB` | EF Core `EnsureCreated()` on first run (see `Lab8\Lab8.1\README.md`) |
| Lab8.2 | `SchoolDB` | EF Core `EnsureCreated()` on first run |
| Lab10 | `IdentityUserDB` | EF Core migration: `dotnet ef database update` (see `Lab10\README.md`) |

Labs that use SQL Server (`SAUGAT\\SQLEXPRESS`) create their database as follows:

| Lab | Database | How it is created |
| --- | --- | --- |
| Lab7.1 | `Company` | Run `SQLSetup.sql` in SSMS (see `Lab7\\Lab7.1\\README.md`) |
| Lab7.2 | `EmployeeDB` | Run `SQLSetup.sql` in SSMS (see `Lab7\\Lab7.2\\README.md`) |
| Lab8.1 | `StudentDB` | EF Core `EnsureCreated()` on first run (see `Lab8\\Lab8.1\\README.md`) |
| Lab8.2 | `SchoolDB` | EF Core `EnsureCreated()` on first run |
| Lab10 | `IdentityUserDB` | EF Core migration: `dotnet ef database update` (see `Lab10\\README.md`) |

Labs that use SQL Server (`SAUGAT\SQLEXPRESS`) create their database as follows:

| Lab | Database | How it is created |
| :-- | :-- | :-- |
| Lab7.1 | `Company` | Run `SQLSetup.sql` in SSMS (see `Lab7\Lab7.1\README.md`) |
| Lab7.2 | `EmployeeDB` | Run `SQLSetup.sql` in SSMS (see `Lab7\Lab7.2\README.md`) |
| Lab8.1 | `StudentDB` | EF Core `EnsureCreated()` on first run (see `Lab8\Lab8.1\README.md`) |
| Lab8.2 | `SchoolDB` | EF Core `EnsureCreated()` on first run |
| Lab10 | `IdentityUserDB` | EF Core migration: `dotnet ef database update` (see `Lab10\README.md`) |


