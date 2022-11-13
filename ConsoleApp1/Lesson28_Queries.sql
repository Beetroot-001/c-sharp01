GO
CREATE TABLE dbo.PhoneBook
    (
      Id INT IDENTITY(1, 1) NOT NULL,
      FirstName VARCHAR(64) NOT NULL,
	  MiddleName VARCHAR(64) NULL,
      LastName VARCHAR(64) NULL,
	  Phone VARCHAR NOT NULL PRIMARY KEY,
	  Created DATETIME DEFAULT(GETDATE()) not null,
	  Updated DATETIME null
    );

GO
CREATE TABLE dbo.SchoolSchedule
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      ObjectName VARCHAR(64) NOT NULL,
      [Start] DATETIME not null,
	  Duration datetime not null,
	  Created DATETIME DEFAULT(GETDATE())
    );

GO
CREATE TABLE dbo.UsersLoginHistory
	(
		Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		UserId INT NOT NULL,
		[Login] DATETIME DEFAULT(GETDATE())
	);


GO
CREATE SCHEMA Bank;

GO
CREATE TABLE Bank.Accounts
	(
		Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		ClientId int NOT NULL,
		Created DATETIME DEFAULT(GETDATE()),

		CONSTRAINT FK_Accounts_ClientId FOREIGN KEY ([ClientId]) REFERENCES Client.Person (id)
	);


GO
CREATE TABLE Bank.TransactionsData
	(
		Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		FromAccount int NOT NULL,
		ToAccount int NOT NULL,
		[Value] float NOT NULL,
		Comment varchar null,
		Created DATETIME DEFAULT(GETDATE())

		CONSTRAINT FK_TransactionsData_FromAccount FOREIGN KEY ([FromAccount]) REFERENCES Bank.Accounts (id),
		CONSTRAINT FK_TransactionsData_ToAccount FOREIGN KEY ([ToAccount]) REFERENCES Bank.Accounts (id),
	);

GO
CREATE SCHEMA Client;

GO
CREATE TABLE Client.Person
	(
		Id INT IDENTITY(1, 1) NOT NULL,
		FirstName NVARCHAR(64) NOT NULL, 
		MiddleName NVARCHAR(64) NULL,
		LastName NVARCHAR(64) NOT NULL,
		Age TINYINT NOT NULL,
		Phone NVARCHAR NOT NULL,
		GenderId INT NULL,
		AddressId INT NULL,
		IdentityCode NVARCHAR(64) NOT NULL,

		CONSTRAINT PK_History PRIMARY KEY (Phone, IdentityCode),
		CONSTRAINT FK_Person_AddressId FOREIGN KEY ([AddressId]) REFERENCES Client.Address (id),
		CONSTRAINT FK_Person_GenderId FOREIGN KEY ([ClientId]) REFERENCES Client.Genders (id)
	);

GO
CREATE TABLE Client.Genders
	(
		Id INT IDENTITY(1, 1) NOT NULL,
		Title  VARCHAR(64) NULL PRIMARY KEY
	);

GO
CREATE TABLE Client.Address
	(
		Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		CountryId INT NOT NULL,
		CityId INT NOT NULL,
		StreetId INT NOT NULL,
		BuildingNumber INT NOT NULL,

		CONSTRAINT PK_History PRIMARY KEY (CityId, StreetId, BuildingNumber)
		CONSTRAINT FK_Person_ClientId FOREIGN KEY ([ClientId]) REFERENCES Address.City (id),
		CONSTRAINT FK_Person_GenderId FOREIGN KEY ([ClientId]) REFERENCES Address.Street (id)
	);

GO
CREATE SCHEMA Address;

GO
CREATE TABLE Address.Country
	(
		Id INT IDENTITY(1, 1) NOT NULL,
		Title  VARCHAR(64) NULL PRIMARY KEY
	);
GO
CREATE TABLE Address.City
	(
		Id INT IDENTITY(1, 1) NOT NULL,
		Title  VARCHAR(64) NULL PRIMARY KEY
	);

GO
CREATE TABLE Address.Street
	(
		Id INT IDENTITY(1, 1) NOT NULL,
		Title  VARCHAR(64) NULL PRIMARY KEY
	);
