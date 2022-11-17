
CREATE DATABASE Library;

CREATE TABLE Books 
(
	Id int NOT NULL,
	Title varchar(20) NOT NULL,
	Primary key(Id)
);

SELECT * FROM Books;

INSERT INTO Books VALUES 
(1, 'New me'),
(2, 'Happy New Year!');

INSERT INTO Books VALUES 
(3, 'Fire')
,(4, 'Silver Eyes')
,(5, 'Rasberry Wine')
,(6, 'Neverland');

CREATE TABLE Authors 
(
	Id int Primary key,
	Nickname varchar(50) NOT NULL,
);

INSERT INTO Authors VALUES 
(1, 'Tysyatky'),
(2, 'KaeyaLuc');

INSERT INTO Authors VALUES (3, 'Brant');

SELECT * FROM Authors;

CREATE TABLE BookCount
(
	Id int foreign key REFERENCES Books,
	[NumberOfBooks] int NOT NULL
);

INSERT INTO BookCount VALUES 
(1, 6)
,(2, 10);

INSERT INTO BookCount VALUES 
(3, 5)
,(4, 2)
,(5, 1)
,(6, 3);

--INSERT INTO BookCount VALUES (3, 4); checked foreign key

CREATE TABLE WrittenBy
(
	BookId int foreign key REFERENCES Books,
	AuthorId int foreign key REFERENCES Authors
);

INSERT INTO WrittenBy VALUES
(1, 1)
,(2, 1)
,(3,2)
,(4,3)
,(5,3)
,(6,3);

SELECT * FROM WrittenBy;

CREATE TABLE Customers
(
	Id int Primary Key,
	FirstName varchar(20),
	LastName varchar(20)
);

INSERT INTO Customers VALUES
(1,'Howkin', 'Aster')
,(3, 'Sup', 'Jor')
,(5, 'Light', 'Yagami')

SELECT * FROM Customers;

CREATE TABLE BorrowedBooks
(
	CustomerId int foreign key REFERENCES Customers,
	BookId int foreign key REFERENCES Books,
	[Date] datetime NOT NULL,
	[ToReturn] datetime NOT NULL
);

INSERT INTO BorrowedBooks VALUES 
(5, 1,'2022-10-10 11:05:24', '2022-11-10 18:00:00')
,(1, 5, '2022-10-15 15:00:52', '2022-11-15 18:00:00')
,(3, 6, '2022-10-20 18:10:00', '2022-11-20 18:00:00');

SELECT * FROM BorrowedBooks;