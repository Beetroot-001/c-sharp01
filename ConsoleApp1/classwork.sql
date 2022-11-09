USE PersonsDB


-- insert
InSerT INTO dbo.Persons (FirstName, LastName, Gender, Age, [Address])
VALUES 
('Mykola', 'Test', 'M', 16, NULL),
('Olena', 'Pchilka', 'F', 22, 'Kyiv'),
('Taras', 'Shevchenko', 'M', 30, 'Kaniv'),
('Lina', 'Kostenko', 'F', 60, 'Lviv')

-- select all implicitly
SELECT * FROM dbo.Persons

-- select all explicitly
SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
WHERE p.Age != 30 -- > < >= <=

-- select all explicitly
SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
WHERE p.Age IN (20, 22, 30)

SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
WHERE p.FirstName LIKE 'a%' 

-- combined filters
SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
WHERE p.Age IN (20, 22, 30) AND p.Gender = 'F' OR Id < 4

-- sorting
SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
ORDER BY p.LastName ASC, p.FirstName ASC

-- update
UPDATE dbo.Persons
SET FirstName = 'Natalia'
WHERE Id = 6

-- delete
DELETE FROM dbo.Persons
WHERE LastName = 'Ivanenko'

-- NULL 
SELECT 
	p.Id AS Testid, 
	p.LastName AS 'Last Name', 
	p.Age, 
	p.FirstName, 
	p.Gender, 
	p.[Address]
FROM dbo.Persons AS p
WHERE p.Address IS NOT NULL

-- HAVING
SELECT p.Gender, COUNT(p.Gender) AS 'Elements Count'
FROM dbo.Persons AS p
GROUP BY p.Gender
HAVING COUNT(p.Gender) > 4

SELECT AVG(p.Age) AS 'Avarage Age' FROM dbo.Persons AS p
SELECT MAX(p.Age) AS 'Max Age' FROM dbo.Persons AS p
SELECT Min(p.Age) AS 'Min Age' FROM dbo.Persons AS p
SELECT SUM(p.Age) AS 'SUM Age' FROM dbo.Persons AS p


-----------------------HOMEWORK------------------------
--select all males
SELECT Id AS TestId, 
	   FirstName AS 'First Name',
	   LastName AS 'Last Name',
	   Age,
	   Gender,
	   Address 
FROM dbo.Persons AS p
WHERE p.Gender = 'M'


--select all persons with age about 18
SELECT Id AS TestId, 
	   FirstName AS 'First Name',
	   LastName AS 'Last Name',
	   Age,
	   Gender,
	   Address 
FROM dbo.Persons AS p
WHERE p.Age > 18


--select all persons without address
SELECT Id AS TestId, 
	   FirstName AS 'First Name',
	   LastName AS 'Last Name',
	   Age,
	   Gender,
	   Address 
FROM dbo.Persons AS p
WHERE p.Address IS NULL


--update age of all persons, add 1 year
UPDATE dbo.Persons 
SET Age = Age + 1


--delete all rows without address
DELETE FROM dbo.Persons 
WHERE Address IS NULL


--count number of rows in table
SELECT COUNT(1) FROM dbo.Persons 


--group persons by age and show how many persons with same age
SELECT Age, COUNT(p.Age)
FROM dbo.Persons AS p
GROUP BY p.Age


