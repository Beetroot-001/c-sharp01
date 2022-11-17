-- Create normalized tables for the library domain. it should include:

-- books
-- authors
-- count of each book
-- customers
-- history which book was taken by whom and when

-- Create DataBase
IF(not exists(SELECT *
FROM sys.databases
WHERE name = 'sbas_homework_27'
))
BEGIN
    CREATE DATABASE sbas_homework_27
END

USE sbas_homework_27


CREATE TABLE Books
(
    Id int PRIMARY KEY IDENTITY(1,1),
    Taitl VARCHAR(100),
    AuthorsId int FOREIGN KEY REFERENCES Authors (Id) NOT NULL,
    [Year of release ] DATETIME
);

CREATE TABLE Authors
(
    Id int PRIMARY KEY IDENTITY(1,1),
    [First Name] VARCHAR (50) NOT NULL,
    [Second Name] VARCHAR (50),
)

CREATE TABLE Customers
(
    Id INT PRIMARY KEY  IDENTITY(1,1),
    [First Name] VARCHAR (50) NOT NULL,
    [Second Name] VARCHAR (50) NOT NULL,
    [Phone Naumber] INT,
    [E-mail] VARCHAR (100) NOT NULL CHECK ([E-mail] = '%@%.%')
)

CREATE TABLE ReaderCard
(
    CustomersId int FOREIGN KEY REFERENCES Customers(id), 
    BookId int FOREIGN KEY REFERENCES Books(Id), 

    PRIMARY KEY(CustomersId,BookId) 
)

