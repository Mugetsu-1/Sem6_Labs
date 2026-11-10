-- Lab 7.2 - ADO.NET CRUD on Employee (EmployeeDB database)
-- Run this in SQL Server Management Studio (SSMS) FIRST,
-- then paste your connection string into appsettings.json.

-- 1. Create the database
CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

-- 2. Create the Employee table
CREATE TABLE [dbo].[Employee]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Department] VARCHAR(50) NOT NULL,
    [Salary] MONEY NOT NULL,
    [City] VARCHAR(50) NOT NULL,
    [JoinedOn] DATE NOT NULL DEFAULT GETDATE()
);
GO

-- 3. Create the DeleteEmployee stored procedure (used by the repository for delete)
CREATE PROCEDURE DeleteEmployee
    @Id INT
AS
BEGIN
    DELETE FROM Employee WHERE Id = @Id;
END;
GO

-- 4. Insert sample data
INSERT INTO Employee (Name, Department, Salary, City)
VALUES ('Test', 'IT', 50000, 'Kathmandu');
GO

-- 5. Test the stored procedure
EXEC DeleteEmployee @Id = 1;
GO