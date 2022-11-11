
---table for ‘phone book’
Create table Phonebook (
id int identity (1,1) primary key,
PhoneNumber int unique,
[Name] varchar (50) 
)

Select * from Phonebook;

Insert into Phonebook Values (11111111, 'Alex')
Insert into Phonebook Values (222222, 'Alex')

--table to store school schedule
Create table SchoolShedule(
id int identity (1,1) primary key,
LessonTitle varchar(50),
Classroom int,
[DayOfWeek] varchar(10),
StartTime Time,
EndTime Time
)

Select * from SchoolShedule

Alter table SchoolShedule alter column StartTime time (5)
Alter table SchoolShedule alter column EndTime time (5)

Select id, LessonTitle, Classroom, [DayOfWeek], CONVERT(varchar, StartTime, 108) as StartTime, CONVERT(varchar, EndTime, 108) as EndTime from SchoolShedule 
 


Insert into SchoolShedule (LessonTitle, Classroom, [DayOfWeek], StartTime, EndTime)
values('Chemistry', 102, 'Wednesday', '9:00:00', '10:00:00')

--table to store user’s login history

Create table LoginHistory(
id int identity (1,1) primary key,
UserName varchar(50),
LoginTime datetime
)

select * from LoginHistory

Insert into LoginHistory Values( 'Ivan', '10.11.2022 9:37')

--table to store bank accounts

Create table BankAccounts(
id int identity (1,1) primary key,
AccountNumber int,
FirstName varchar (50),
LastName varchar (50),
Balance money
)

Select * From BankAccounts

Insert into BankAccounts Values (493842, 'Jim', 'Raynor', 103659)
Insert into BankAccounts Values (493842, 'Sara', 'Kerigan', 13569.12)

--table to store bank transactions data

Create table BankTransactionsData(
id int identity (1,1) primary key,
AccountSender int,
AccountReceiver int,
TransactionDate datetime,
TransactionSum money,
)

Select * from BankTransactionsData

Insert into BankTransactionsData Values (45433, 666444, '18.11.2021 9:45', 5000.10)