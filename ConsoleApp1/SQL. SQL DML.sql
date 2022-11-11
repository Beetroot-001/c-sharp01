Select * From dbo.Persons

Update dbo.Persons
Set Address = null
where Id = 6

-- select all males
Select * From dbo.Persons 
Where Gender = 'm'

--select all persons with age about 18
Select * From dbo.Persons 
Where Age > 18

--select all persons without address
Select * From dbo.Persons
where Address is null

--update age of all persons, add 1 year
Update dbo.Persons
Set Age = Age +1

--delete all rows without address
Delete From dbo.Persons
Where Address is null

--count number of rows in table
Select Count (Id) as 'Rows Number'
From dbo.Persons

--group persons by age and show how many persons with same age
Select Count (FirstName) as 'Same Age', Age
From dbo.Persons
Group by Age 
Order by [Same Age] Desc