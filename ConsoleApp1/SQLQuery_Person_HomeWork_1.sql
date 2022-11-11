--HomeWork SQL

-- Using the same person’s table as on the lesson do next: 

-- select all males
-- select all persons with age about 18
-- select all persons without address
-- update age of all persons, add 1 year
-- delete all rows without address
-- count number of rows in table
-- group persons by age and show how many persons with same age

use PersonsDB 

-- Add new element at table
INSERT INTO dbo.Persons (FirstName, LastName, Gender, Age, [Address])
VALUES
('Serhiy','Bas','M',26,'Chercasy'),
('Taras','Vorobkalo','M',36,'Lviv'),
('Anna','Cruk','F',21,null),
('Viktor','Scherbakov','M',32,'Kiyv'),
('Nadia','Scherbakov','F',32,'Kiyv'),
('Lesya','Ovod','F',23,'Chernigiv'),
('Zoriana','Burko','F',15,'Kiyv'),
('Oleh','Lin','M',27,'Odesa'),
('Nik','Tkach','M',34,'Odesa');

-- Table Display
SELECT * FROM dbo.Persons;
-- or
SELECT --?? SELECT - повертає нову таблицю, чи стару але те що ви вибрали??
Id AS 'ID Naumber',
LastName,
FirstName,
[Address]
FROM dbo.Persons AS Person --?? Це ми створюємо нову таблицю чи переіменовуємо стару?

-- select all males
SELECT * FROM dbo.Persons
WHERE Gender = 'M'

-- select all persons with age about 18 ( about це як? )
SELECT * FROM dbo.Persons
WHERE Age>=15 AND Age<=23;

-- select all persons without address
SELECT
FirstName,
LastName,
[Address]
FROM dbo.Persons
WHERE Address IS Null

-- update age of all persons, add 1 year
UPDATE dbo.Persons 
Set Age = Age+1

SELECT * FROM dbo.Persons;

-- delete all rows without address
DELETE FROM dbo.Persons
WHERE Address IS NULL

SELECT * FROM dbo.Persons;

-- count number of rows in table
SELECT COUNT(dbo.Persons.Id) As 'Count of rows'
From dbo.Persons -- виводить не правильно ( чому? )

-- group persons by age and show how many persons with same age
SELECT dbo.Persons.Age,COUNT(dbo.Persons.Age) AS 'Count same age' 
FROM DBO.Persons
GROUP BY Age 
HAVING COUNT(Age)>2 
