-- Use w3schools database

USE 
	w3schools;

-- Showing all records (Total 77 Records)

SELECT
	ProductID,
    ProductName,
    Price
FROM
	Products;
    
-- Limit

-- Only showing 50 records

SELECT
	ProductID,
    ProductName,
    Price
FROM
	Products
LIMIT 
	50;

-- Using Where Clause

SELECT
	ProductID,
    ProductName,
    Price
FROM
	Products
WHERE
	Price > 50
LIMIT 
	10;

-- Using Offset
-- I want to start list of records from 11 ProductID

SELECT
	ProductID,
    ProductName,
    Price
FROM
	Products
LIMIT 
	50
OFFSET		-- Neglecting firxt 10 records
	10; 
    


