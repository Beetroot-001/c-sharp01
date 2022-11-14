Create database Library

Create Table Authors (
id int identity (1,1) primary key,
FirstName varchar(50) not null,
LastName varchar(50) not null
)

Select * from Authors
Insert into Authors Values ('Ray', 'Bradbury');
Insert into Authors Values ('Dmytro', 'Gluhovskii')
Insert into Authors Values 
('Arkady and Boris', 'Strugatsky'),
('Howard Phillips', 'Lovecraft');


Create Table Books(
id int identity (1,1) primary key,
Title varchar (50) not null,
YearPublication int not null,
Author int FOREIGN KEY REFERENCES Authors (id),
Quantity int not null
)

Select * From Books;
Insert into Books Values ('Dagon', 1982, 4, 1) 
Insert into Books Values ('At the Mountains of Madness', 1997, 4,3),
('The Shadow over Innsmouth', 2002, 4, 2),
('Inhabited Island', 2009, 3, 4),
('Beetle in the Anthill', 2011, 3, 1),
('Post', 2019, 2, 1),
('Metro 2033', 2008, 2, 5),
('Fahrenheit 451', 1995, 1, 6),
('The Martian Chronicles', 1992, 1, 4)

Select * from Books

Select Books.Title, Authors.FirstName, Authors.LastName, Books.YearPublication, Books.Quantity from Books
Left join Authors on Authors.id = Books.Author
Order by Title 

Create table Customers(
id int identity (1,1) primary key,
FirstName varchar (50) not null,
LastName varchar (50) not null,
)

Select * From Customers
Insert Into Customers Values ('Petro','Mychaylenko'),
('Karl', 'Johnson'),
('Jane', 'Doe'),
('Silvester', 'Stalone')

Create table LibraryCard(
id int identity (1,1) primary key,
Customer int FOREIGN KEY REFERENCES Customers (id),
TakenBook int FOREIGN KEY REFERENCES Books (id),
DateOfTaken date not null
)

Insert into LibraryCard values (1, 3, '9.11.2022')
Insert into LibraryCard values (3, 9, '6.9.2022')
Insert into LibraryCard values (1, 1, '4.10.2022')
Insert into LibraryCard values (4, 4, '2.11.2022')

Select * from LibraryCard

Select 
Customers.id as 'Customer id',
Customers.FirstName as 'Customer First Name', 
Customers.LastName as 'Customer Last Name', 
Books.Title as 'Book Title', 
Authors.FirstName as 'Author First Name', 
Authors.LastName  as 'Author Last Name',
DateOfTaken 
from LibraryCard
Left Join Customers on LibraryCard.Customer = Customers.id
Left Join Books on LibraryCard.TakenBook = Books.Id
Left Join Authors on Authors.id = Books.Author
Order by Customers.id