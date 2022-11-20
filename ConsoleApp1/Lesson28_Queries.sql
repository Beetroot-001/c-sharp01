GO
CREATE TABLE dbo.PhoneBook
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      FirstName VARCHAR(64) NOT NULL,
	  MiddleName VARCHAR(64) NULL,
      LastName VARCHAR(64) NULL,
	  Phone VARCHAR NOT NULL,
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
		FirstName VARCHAR(64) NOT NULL, 
		MiddleName VARCHAR(64) NULL,
		LastName VARCHAR(64) NOT NULL,
		Age TINYINT NOT NULL,
		Gender VARCHAR(1) NOT NULL,
		Address VARCHAR(255)
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
	);