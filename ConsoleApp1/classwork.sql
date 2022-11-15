-- create db
CREATE DATABASE GoodShop;

-- create table
CREATE TABLE Product
(
    Id INT NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    Price DECIMAL(7,2) NOT NULL,
    Category VARCHAR(50) NOT NULL
);

ALTER TABLE Product ADD TotalCount INT;
ALTER TABLE Product ADD RemainedCount INT;

INSERT INTO Product
    (Id, [Name], Price, Category, TotalCount, RemainedCount)
VALUES
    (1, 'Banana', 10 , 'Food', 20, 15),
    (2, 'Apple', 4, 'Food', 6, 6),
    (3, 'Hammer', 40, 'Tools', 10, 2),
    (4, 'Notebook', 1300, 'Devices', 1, 1),
    (5, 'Powerbank', 5, 'devices', 12, 6),
    (6, 'Table', 4, 'Furniture', 3, 2),
    (7, 'Pen', 1, 'Other', 100, 0);

ALTER TABLE Product ADD Comment NVARCHAR(MAX);

-- rename column
EXEC sp_rename 'Product.Comment', 'Comment2';

-- rename  
ALTER TABLE Product DROP COLUMN Comment2

-- rename table
EXEC sp_rename 'Product', 'Products';


ALTER TABLE Products ADD Price2  MONEY NULL;

-- UPDATE Products
-- SET Price2 = $123
-- WHERE Id = 1

-- add unique constraint
ALTER TABLE Products
ADD CONSTRAINT U_Name UNIQUE ([Name]);

INSERT INTO Products
    (Id, [Name], Price, Category, TotalCount, RemainedCount)
VALUES
    (1, 'Banana', 10 , 'Food', 20, 15)

-- add check
ALTER TABLE Products
ADD CONSTRAINT CHK_Price CHECK (Price > 0);

INSERT INTO Products
    (Id, [Name], Price, Category, TotalCount, RemainedCount)
VALUES
    (1, 'Banana1', -1 , 'Food', 20, 15);

ALTER TABLE Products ADD CreatedOn  DATETIME DEFAULT GETDATE();

select *
from Products


UPDATE Products
SET CreatedOn = GETUTCDATE()


INSERT INTO Products
    (Id, [Name], Price, Category, TotalCount, RemainedCount)
VALUES
    (1, 'Orange', 12 , 'Food', 17, 4)

-- group products by category and show category count
SELECT Category, COUNT(Category) AS 'Category product count'
FROM Products
GROUP BY CAtegory

-- group products by category and show category products price
SELECT Category, SUM(Price * TotalCount) AS 'Category product count'
FROM Products
GROUP BY CAtegory

--
SELECT [Name], Price * TotalCount AS 'product total price'
FROM Products

SELECT [Name], Price * RemainedCount AS 'Max profit'
FROM Products
ORDER BY Price * RemainedCount DESC

DECLARE @rait DECIMAL(3,2) =  1.1;

UPDATE Products
SET Price = Price * @rait

SELECT * FROM Products

SELECT * from Products
ORDER BY Name

SELECT * FROM Products
ORDER BY [Name]
OFFSET 3 ROWS FETCH NEXT 2 ROWS ONLY

DECLARE @priceLimit DECIMAL(7,2) = 30;

SELECT 
    Name,
    Price,
    IIF(Price > @priceLimit, 'Product is expensive', 'Product is cheap' )
FROM Products

DECLARE @priceLimit DECIMAL(7,2) = 30;

SELECT 
    Name,
    Price,
    CASE
        WHEN Price > @priceLimit THEN 'Product is expensive'
        WHEN Price < @priceLimit THEN'Product is cheap'
    END 
FROM Products

DROP TABLE Products
SELECT * FROM Products

USE master
DROP DATABASE GoodShop










