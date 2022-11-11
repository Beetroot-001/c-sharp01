-- CREATE TABLE Test (
--     Id INT,
--     [Name] VARCHAR(50)
-- )

-- INSERT INTO Test VALUES
-- (1, 'a'), (34, 'av'), (5, 'v'),(192, 'as'),(21, 'vs'),(2, 'ac')

-- SELECT * FROM Test

-- CREATE CLUSTERED INDEX IX_Name ON Test(NAME)

-- DROP INDEX IX_Id ON Test

-- INSERT INTO Test VALUES
-- (3, 'qq')

-- CREATE TABLE Employee
-- (
--     CompanyId INT,
--     EmployeeId INT,
--     EmployeeName VARCHAR(50),
--     EmployeePhoneNumber VARCHAR(50)
--     PRIMARY KEY (CompanyId, EmployeeId)
-- )

CREATE TABLE Customers
(
    Id INT PRIMARY KEY,
    Title VARCHAR(50)
)

CREATE TABLE Sellers
(
    Id INT PRIMARY KEY,
    Title VARCHAR(50)
);

CREATE TABLE Orders
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
    SellerId INT FOREIGN KEY REFERENCES Sellers(Id),
    CreateOn DATETIME NOT NULL
);

CREATE TABLE Products
(
    Id INT IDENTITY(1,1),
    ProductName NVARCHAR(100),
    UnitPrice DECIMAL(7,2) NOT NULL,
    Quantity INT NOT NULL,
    Description NVARCHAR(250) NULL,
    CONSTRAINT PK_ID PRIMARY KEY Id
);

Create table OrderProducts
(
    OrderId INT,
    ProductId INT,

    PRIMARY KEY (OrderId, ProductId),
    FOREIGN KEY OrderId REFERENCES Orders(Id),
    FOREIGN KEY ProduktId REFERENCES Products(Id),
)   
