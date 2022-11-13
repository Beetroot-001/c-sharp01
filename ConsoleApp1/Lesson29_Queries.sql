GO
CREATE SCHEMA Library;

GO
CREATE TABLE Library.History(
	 Id INT IDENTITY(1, 1) PRIMARY KEY, 
	 CustomerId int NOT NULL,
	 BookId int NOT NULL,
	 Prolong bit DEFAULT(0) not null,
	 [GetDate] DATETIME DEFAULT(GETDATE()) not null,
	 [ReturnDate] DATETIME null,
	 Updated DATETIME null,
	 
	 CONSTRAINT PK_History PRIMARY KEY (id)
);

GO
CREATE TABLE Library.Customers(
	 Id INT IDENTITY(1, 1) PRIMARY KEY,
	 FirstName VARCHAR(64) NOT NULL,
	 MiddleName VARCHAR(64) NULL,
     LastName VARCHAR(64) NULL, 
	 Created DATETIME DEFAULT(GETDATE()) not null,
	 Updated DATETIME null

	 CONSTRAINT PK_Customers PRIMARY KEY (id)
);

GO
CREATE TABLE Library.Authors
(
	 Id INT IDENTITY(1, 1) PRIMARY KEY,
	 FirstName VARCHAR(64) NOT NULL,
	 MiddleName VARCHAR(64) NULL,
     LastName VARCHAR(64) NULL,	 
     Description VARCHAR(MAX) NULL,
	 Created DATETIME DEFAULT(GETDATE()) not null,
	 Updated DATETIME null
	 
	 CONSTRAINT PK_Authors PRIMARY KEY (id)
);

GO
CREATE TABLE Library.Books
(
      Id INT IDENTITY(1, 1),
      Titile VARCHAR(128) NOT NULL,
      Description VARCHAR(MAX) NULL,
	  Quantity int NOT NULL DEFAULT(1),
	  Created DATETIME DEFAULT(GETDATE()) not null,
	  Updated DATETIME null

	  CONSTRAINT PK_Books PRIMARY KEY (id)
);

GO
CREATE TABLE Library.BooksAuthors
(
      Id INT IDENTITY(1, 1),
      BookId int NOT NULL,
	  AuthorId int NOT NULL,      
	  Created DATETIME DEFAULT(GETDATE()) not null,
	  Updated DATETIME null

	  CONSTRAINT PK_Books PRIMARY KEY (Id),
	  CONSTRAINT FK_BooksAuthors_BookId FOREIGN KEY ([BookId]) REFERENCES dbo.[Books] (id),
	  CONSTRAINT FK_BooksAuthors_AuthorId FOREIGN KEY ([AuthorId]) REFERENCES dbo.[Authors] (id)
);