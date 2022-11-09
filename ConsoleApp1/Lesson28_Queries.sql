GO
CREATE TABLE dbo.PhoneBook
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      FirstName VARCHAR(64) NOT NULL,
	  MiddleName VARCHAR(64) NULL,
      LastName VARCHAR(64) NULL,
	  phone VARCHAR NOT NULL,
	  created DATETIME DEFAULT(GETDATE()) not null,
	  updated DATETIME null
    );

GO
CREATE TABLE dbo.SchoolSchedule
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      ObjectName VARCHAR(64) NOT NULL,
      [start] DATETIME not null,
	  duration datetime not null,
	  created DATETIME DEFAULT(GETDATE())
    );

GO
CREATE TABLE dbo.UsersLoginHistory
	(
		Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		UserId INT NOT NULL,
		[login] DATETIME DEFAULT(GETDATE())
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
		fromAccount int NOT NULL,
		toAccount int NOT NULL,
		[value] float NOT NULL,
		comment varchar null,
		created DATETIME DEFAULT(GETDATE())
	);