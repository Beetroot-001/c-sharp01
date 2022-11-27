--select all males

SELECT * FROM Persons
WHERE Gender = 'M';

--select all persons with age above 18

SELECT * FROM Persons
WHERE Age > 18;

--select all persons without address

SELECT * FROM Persons
WHERE [Address] IS NULL;

--update age of all persons, add 1 year

UPDATE Persons
SET Age += 1;

--delete all rows without address

DELETE FROM Persons
WHERE [Address] IS NULL;

--count number of rows in table

SELECT COUNT(*)
FROM Persons

--group persons by age and show how many persons with same age

SELECT Age, COUNT(1) FROM Persons
GROUP BY Age;
