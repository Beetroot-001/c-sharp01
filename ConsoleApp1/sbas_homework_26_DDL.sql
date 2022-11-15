-- Create few tables schemas:

-- table for ‘phone book’
-- table to store school schedule
-- table to store user’s login history
-- table to store bank accounts
-- table to store bank transactions data

--Create new Database.
if(NOT EXISTS(SELECT*
    FROM sys.databases
    WHERE name = 'sbas/homework/26_DDL' )) -- Ключове слово name = 
BEGIN
    CREATE DATABASE sbas_homework_26_DDL
END

-- table for ‘phone book’
IF(NOT EXISTS(SELECT *
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo'
    AND TABLE_NAME = 'phone book' ))
BEGIN
    CREATE TABLE sbas_homework_26_DDL.dbo.phonebook
    (
        FirstName VARCHAR(20) NOT NULL,
        SecondName VARCHAR(20)NOT NULL,
        Phone int NOT NULL,
    )
END

ALTER TABLE phonebook ADD Adressa VARCHAR(100)

ALTER TABLE phonebook ADD [U_Column] varCHAR(666) not null UNIQUE

ALTER TABLE phonebook DROP [U_Column]

SELECT * FROM phonebook

-- table to store school schedule
IF(NOT EXISTS(SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
    AND TABLE_NAME = 'schoolschedule' ))
BEGIN
    CREATE TABLE sbas_homework_26_DDL.DBO.schoolschedule
    (
        NUMBEROFORDER INT IDENTITY(1, 1),
        LESONS VARCHAR(30)NOT NULL
    )
END 

ALTER TABLE schoolschedule ADD Rating int
ALTER TABLE schoolschedule ALTER COLUMN Rating TINYINT
alter TABLE schoolschedule Add [Day] DATA

EXEC sp_rename [Day] , [Day of week]

EXEC sp_rename schoolschedule , schoolschedules
SELECT * FROM schoolschedules

-- table to store user’s login history
IF(NOT EXISTS(SELECT*
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
    AND TABLE_NAME ='loginhistory'))
BEGIN
    CREATE TABLE sbas_homework_26_DDL.dbo.loginhistory
    (
        link VARCHAR(100)  CHECK (link ='http%s')
    )
END

ALTER TABLE loginhistory add CONSTRAINT link DEFAULT 'http' -- неможу додати NOT NULL

SELECT * FROM loginhistory

-- table to store bank accounts
IF(NOT EXISTS(SELECT*
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
    AND TABLE_NAME = 'storebankaccounts'))
BEGIN
    CREATE TABLE sbas_homework_26_DDL.DBO.storebankaccounts
    (
        ID INT IDENTITY(1, 1)
    )
END

SELECT * FROM storebankaccounts

-- table to store bank transactions data
IF(NOT EXISTS(SELECT*
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
    AND TABLE_NAME = 'banktransactionsdata')) 
BEGIN
    CREATE TABLE sbas_homework_26_DDL.dbo.banktransactionsdatas
    (
        ID REAL UNIQUE, 
        [Data] VARCHAR(50) NOT NULL
    )
END

SELECT * FROM banktransactionsdatas