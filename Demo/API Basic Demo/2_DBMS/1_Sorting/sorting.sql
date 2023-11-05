-- Create Database

CREATE DATABASE 
	MyNewDatabase;
    
-- Using a particular Database

USE 
	MyNewDatabase;
    
-- Create Table

CREATE TABLE 
	MyFirstTable (
		Id int,
		FirstName varchar(255),
        LastName varchar(255)
    );

-- Enter Data into Table

INSERT INTO
	MyFirstTable 
VALUES (1001, "Yash", "Lathiya"),
	   (1001, "Prajval", "Gahine"),
       (1003, "Deep", "Patel"),
       (1002, "Krinsi", "Kyada");

-- Show Table Data

SELECT
	Id, FirstName, LastName
FROM 
	MyFirstTable;
    
-- Sorting of Data

-- Here data is sorted by ID then FirstName then LastName in ascending order

SELECT
	Id, FirstName, LastName
FROM 
	MyFirstTable
ORDER BY
	Id, FirstName, LastName ASC;

-- Here data is sorted by ID then FirstName then LastName in decending order

SELECT
	Id, FirstName, LastName
FROM 
	MyFirstTable
ORDER BY
	Id, FirstName, LastName DESC;
	