-- Lab 7.1 - ADO.NET CRUD on Inventory (Company database)
-- Run this in SQL Server Management Studio (SSMS) FIRST,
-- then paste your connection string into appsettings.json.

-- 1. Create the database
CREATE DATABASE Company;
GO

USE Company;
GO

-- 2. Create the Inventory table
CREATE TABLE [dbo].[Inventory]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Price] MONEY NOT NULL,
    [Quantity] INT NOT NULL,
    [AddedOn] DATE NOT NULL DEFAULT GETDATE()
);
GO

-- 3. Create the ReadInventory stored procedure (used by Index to read all records)
CREATE PROCEDURE ReadInventory
AS
BEGIN
    SELECT *
    FROM Inventory;
END;
GO

-- 4. Insert sample data
INSERT INTO Inventory
VALUES ('Test', 100, 2, GETDATE());
GO

-- 5. Test the stored procedure
EXEC ReadInventory;
GO