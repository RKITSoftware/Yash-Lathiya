-- view
-- view is a virtual table which is based on sql statements and conditions.
-- view has rows and columns as real tables which can be initialized or created as well as updated and dropped

-- use wschoools database

USE 
	w3schools;
    
-- create view
-- France Customers 

CREATE VIEW
	v_franceCustomers
AS 
SELECT
	CustomerID,
    CustomerName,
    City
FROM
	Customers
WHERE
	Country = 'France';
    
-- How to use view

SELECT
	CustomerID,
    CustomerName,
    City
FROM
	v_franceCustomers;

-- UPDATE VIEW

CREATE OR REPLACE VIEW
	v_franceCustomers
AS 
SELECT
	CustomerID,
    CustomerName,
    City,
    Address
FROM
	Customers
WHERE
	Country = 'France';

SELECT
	CustomerID,
    CustomerName,
    City,
    Address
FROM
	v_franceCustomers;
    
-- Drop(Discard) View

DROP VIEW
	v_franceCustomers;

