--CREATE DATABASE BestShop

--CREATE DATABASE HomeWork

--table for ‘phone book’ (id, Name, Phone)

CREATE TABLE PhoneBook
(
	ID int NOT NULL Primary Key,
	[Name] varchar(30) NOT NULL,
	PhoneNumber char(13) NOT NULL
);

INSERT PhoneBook(ID, [Name], PhoneNumber) VALUES 
(2,'Nataliia Korshak', '+380965703265'),
(3, 'Sofia Kushneruk', '+380951236958'),
(4, 'Lina Shachmantzir', '+380685402396');

SELECT * FROM dbo.PhoneBook;

ALTER TABLE PhoneBook 
ADD CONSTRAINT U_Name UNIQUE ([Name]);

--table to store school schedule (id, subject, day, position, teacher, classroom)

CREATE TABLE SchoolSchedule 
(
	ID INT NOT NULL,
	SubjectCode char(2) NOT NULL,
	[Day] char(2) NOT NULL,
	Position int NOT NULL,
	Teacher varchar(20),
	ClassroomCode char(2)
);

ALTER TABLE SchoolSchedule
ADD CONSTRAINT PK_Schedule PRIMARY KEY (ID);

ALTER TABLE SchoolSchedule
ALTER COLUMN [Day] char(3);

ALTER TABLE SchoolSchedule
ADD CONSTRAINT PosDay_Schedule CHECK (Position > 0);


INSERT SchoolSchedule(ID, SubjectCode, [Day], Position, Teacher, ClassroomCode) VALUES
(1,'EN', 'MON', 2, 'Jonson', 'AB');

INSERT SchoolSchedule(ID, SubjectCode, [Day], Position, ClassroomCode) VALUES
(2,'MT', 'WED', 1,'AB');

INSERT SchoolSchedule(ID, SubjectCode, [Day], Position, Teacher) VALUES
(3,'CL', 'THU', 5, 'Jonson');

--table to store user’s login history (id, login, when, where)

CREATE TABLE LoginHistory
(
	ID INT NOT NULL,
	[Login] varchar (15) NOT NULL,
	[Date] smalldatetime NOT NULL,
	[Location] varchar(50) NOT NULL,
	[Log] varchar(100)
);

ALTER TABLE LoginHistory
ADD CONSTRAINT PK_History PRIMARY KEY (ID);

INSERT LoginHistory(ID, [Login], [Date], [Location]) VALUES
(1, 'Tysyatsky', '2002-12-10 8:40:00', 'www.birth.ua'),
(2, 'Tysyatsky', '2022-12-10 12:00:00', 'www.youtube.ua');

SELECT * FROM LoginHistory;

--table to store bank accounts (id, name, telephone, total, credit limit, address)

CREATE TABLE BankAcc
(
	ID INT NOT NULL,
	[Name] varchar(20) NOT NULL,
	PhoneNumber char(13) NOT NULL,
	Balance int NOT NULL,
	Credit int,
	[Address] varchar(50)
);

ALTER TABLE BankAcc
ADD CONSTRAINT PK_BankAcc PRIMARY KEY (ID);

ALTER TABLE BankAcc 
ADD CONSTRAINT U_Name UNIQUE ([Name]);

INSERT BankAcc(ID, [Name], PhoneNumber, Balance) VALUES
(1, 'Tysyatsky', '+380971573921', 1000),
(2, 'Hehe', '+380961573921', 456);

SELECT * FROM BankAcc;

--table to store bank transactions data (id, date, from, to, how much)

CREATE TABLE Transactions
(
	ID INT NOT NULL,
	[Date] smalldatetime NOT NULL,
	Sender varchar(20) NOT NULL,
	Recipient varchar(20) NOT NULL,
	Amount int NOT NULL,
	[Status] bit NOT NULL
);

DROP TABLE Transactions;

ALTER TABLE Transactions
ADD CONSTRAINT PK_Transactions PRIMARY KEY (ID);

INSERT Transactions (ID, [Date], [Sender], [Recipient], [Amount], [Status]) VALUES
(1, '2022-10-10 18:00:00', 'Tysyatsky', 'Doki', 1000, 1),
(2, '2022-10-10 22:00:00', 'Doki', 'Tysyatsky', 500, 1),
(3, '2022-10-10 5:00:00', 'Monti', 'Freddy', 45, 0),
(4, '2022-11-10 18:00:00', 'Memememe', 'Hehe', 2000, 0),
(5, '2022-12-10 18:00:00', 'Tysyatsky', 'John', 10, 1);

SELECT * FROM Transactions;