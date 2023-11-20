USE
	w3schools;
    
-- Explain Keyword

EXPLAIN SELECT
	CustomerID,
    CustomerName,
    City
FROM
	Customers
WHERE
	CustomerID > 85;