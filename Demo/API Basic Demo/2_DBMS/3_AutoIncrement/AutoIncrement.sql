-- Use MyNewDatabase

USE 
	MyNewDatabase;

-- Create Table which contains one auto increment field
-- Auto Increment strats from 1001 with increment of 2
-- while both contains 1 as default values.
CREATE TABLE 
	Employee (
		Id int PRIMARY KEY AUTO_INCREMENT,
		FirstName varchar(255),
        LastName varchar(255),
        Organization varchar(255),
        Salary int
    ) AUTO_INCREMENT = 1001;

-- Enter Data into Table

INSERT INTO
	Employee 
    (FirstName, LastName, Organization, Salary)
VALUES 
	("Sachin", "Tendulkar", "ABCD", 1000000),
    ("Mahindra", "Dhoni", "ABCD", 1200000),
    ("Virat", "Kohli", "ABCD", 450000),
    ("Surya", "Yadav", "PQRS", 800000),
    ("Ravindra", "Jadeja", "MNPQ", 1000000);
    
-- Show Table Data

SELECT 
	Id, FirstName, LastName, Organization, Salary
FROM 
	Employee;