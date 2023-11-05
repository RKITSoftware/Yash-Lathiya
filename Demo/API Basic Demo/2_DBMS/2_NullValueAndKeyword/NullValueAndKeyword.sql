-- Use MyNewDatabase

USE 
	MyNewDatabase;

-- Adding new column in MyFirstTable Table (MyNewDatabase)
-- which contains null value

ALTER TABLE 
	MyFirstTable
ADD 
	City varchar(255);

-- Adding new column in MyFirstTable Table (MyNewDatabase)
-- which contains not null value
-- If we're adding columns then it's showing empty values.

ALTER TABLE 
	MyFirstTable
ADD 
	Address varchar(255) NOT NULL;

-- Adding new column in MyFirstTable Table (MyNewDatabase)
-- which contains not null value
-- We can use default values too.

ALTER TABLE 
	MyFirstTable
ADD 
	Country varchar(255) NOT NULL DEFAULT "India";

-- Add row into table

INSERT INTO
	MyFirstTable
	(Id, FirstName, City, Address)
VALUES
	(1004, "Satyam", "Surat", "Varachha");

-- Show Table Data

SELECT
	Id, FirstName, LastName, City, Address, Country
FROM
	MyFirstTable;