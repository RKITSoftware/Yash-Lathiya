-- Data Defination Languguage

USE MyNewDatabase;

-- Create

-- Create table of Employee

CREATE TABLE 
	EMP01(						-- Employee
		P01F01 INT PRIMARY KEY, -- CustomerId
		P01F02 VARCHAR(50),		-- CustomerName
		P01F03 VARCHAR(50),		-- Country
		P01F04 INT(2),			-- Age
		P01F05 INT(10)			-- MobileNumber
);

-- Create table of employee by using another employee table

CREATE TABLE 
	EMP02 						-- Employee
AS SELECT
	Id,
    FirstName,
    Organization
FROM
	Employee;
	
-- Drop
-- Used to delete whole database or table

DROP TABLE
	EMP02;

-- Alter
-- Used to add, remove or modify columns in existing table

-- Add Columns

ALTER TABLE 
	EMP01
ADD(
	P01F06 INT,			-- Salary
    P01F07 VARCHAR(50)	-- Remarks
);

-- Drop Column

ALTER TABLE
	EMP01
DROP COLUMN
	P01F07;
    
-- Modifiing Column 
-- Datatype is modifies to varchar(30)

ALTER TABLE
	EMP01
MODIFY COLUMN
	P01F07 VARCHAR(30);

-- Truncate
-- Removes all data within database or table

TRUNCATE TABLE 
	employee;

-- Rename

-- Renaming Column Name

ALTER TABLE 
	Employee
RENAME COLUMN
	Id TO E01F01;
    
-- Renaming Table Name

ALTER TABLE 
	Employee
RENAME TO
	EMP03;