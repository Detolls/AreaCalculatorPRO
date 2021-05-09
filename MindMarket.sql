USE master;
GO

IF EXISTS 
(
	SELECT * FROM sys.databases
	WHERE name = 'MindMarketDB'
)
BEGIN
	ALTER DATABASE MindMarketDB
	SET SINGLE_USER 
	WITH ROLLBACK IMMEDIATE;

	DROP DATABASE MindMarketDB;
END
GO

CREATE DATABASE MindMarketDB
GO

USE MindMarketDB
GO

DROP TABLE IF EXISTS Categories
GO

CREATE TABLE Categories
(
	Id		INT	IDENTITY (1, 1) NOT NULL,
	[Name]	NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Categories PRIMARY KEY NONCLUSTERED (Id)
);
GO

DROP TABLE IF EXISTS Products
GO

CREATE TABLE Products
(
	Id		INT IDENTITY (1, 1) NOT NULL,
	[Name]	NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY NONCLUSTERED (Id)
);
GO

DROP TABLE IF EXISTS ProductCategories
GO

CREATE TABLE ProductCategories
(
	ProductId		INT NOT NULL,
	CategoryId		INT NOT NULL,
	CONSTRAINT PK_ProductCategories PRIMARY KEY NONCLUSTERED (ProductId, CategoryId),
	CONSTRAINT FK_ProductCategories_Products FOREIGN KEY (ProductId)
    REFERENCES Products (Id),
	CONSTRAINT FK_ProductCategories_Categories FOREIGN KEY (CategoryId)
	REFERENCES Categories (Id)
);
GO

DECLARE @i int = 1, @j int = 1; 

WHILE @i <= 30 
BEGIN
	INSERT INTO Products (NAME) VALUES ('Product ' + CONVERT(NVARCHAR(50), @i))
    SET @i = @i + 1
END

SET IDENTITY_INSERT Products OFF; 

SET @i = 1;

WHILE @i <= 10
BEGIN
	INSERT INTO Categories (NAME) VALUES ('Category  ' + CONVERT(NVARCHAR(50), @i))
	SET @i = @i + 1
END

SET @i = 1;

WHILE @i < 20
BEGIN
	INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (@i, @j)
	IF (@i % 3 = 0)
		SET @j += 1
	SET @i = @i + 1
END
GO

SELECT P.[Name], C.[Name]
FROM Products P
LEFT JOIN ProductCategories PC ON PC.ProductId = P.Id
LEFT JOIN Categories C ON C.Id = PC.CategoryId


	











