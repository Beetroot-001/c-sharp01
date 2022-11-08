/* 1 */
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [dbo].[Persons]
  where Gender = 'm'

  /* 2 */
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [dbo].[Persons]
  where Age > 18

  /* 3 */
    /****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [dbo].[Persons]
  where Address is null

  /* 4 */
    /****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [dbo].[Persons]
  where Age > 18

  /* 5 */
  USE [PersonsDB]
GO

UPDATE [dbo].[Persons]
   SET [Age] = age+1
GO

/* 6 */
  delete
   FROM [dbo].[Persons]
  where Address is null

  /* 7 */
  select count(*) from dbo.Persons

  /* 8 */
   select 
	Age
	,count(*) 
   from dbo.Persons p 
   group by p.Age