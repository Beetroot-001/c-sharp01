USE PersonsDB


-- insert
InSerT INTO dbo.Persons (FirstName, LastName, Gender, Age, [Address])
VALUES 
('Mykola', 'Test', 'M', 16, NULL),
('Olena', 'Pchilka', 'F', 22, 'Kyiv'),
('Taras', 'Shevchenko', 'M', 30, 'Kaniv'),
('Lina', 'Kostenko', 'F', 60, 'Lviv')


SELECT 
	Id AS Testid, 
	LastName AS 'Last Name', 
	Age, 
	FirstName, 
	Gender, 
	[Address]
FROM dbo.Persons
WHERE Gender = 'M'

SELECT 
	Id AS Testid, 
	LastName AS 'Last Name', 
	Age, 
	FirstName, 
	Gender, 
	[Address]
FROM dbo.Persons
WHERE Age IN (17, 18, 19) -- BETWEEN 17 AND 19

SELECT 
	Id AS Testid, 
	LastName AS 'Last Name', 
	Age, 
	FirstName, 
	Gender, 
	[Address]
FROM dbo.Persons
WHERE [Address] IS NULL 

UPDATE dbo.Persons
SET Age = Age + 1

SELECT * FROM dbo.Persons

DELETE FROM dbo.Persons
WHERE [Address] IS NULL

SELECT * FROM dbo.Persons

SELECT COUNT(*)
FROM dbo.Persons

SELECT * FROM dbo.Persons

SELECT
	Age,
	COUNT(1)
FROM dbo.Persons
GROUP BY Age