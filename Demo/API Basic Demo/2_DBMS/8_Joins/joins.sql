-- join

-- Inner Join
SELECT 
	Orders.OrderID,
    Customers.CustomerID,
    OrderDate
FROM
	Customers INNER JOIN Orders
ON
	Orders.CustomerID = Customers.CustomerID;

-- Left Join
SELECT 
	Orders.OrderID,
    Customers.CustomerID,
    OrderDate
FROM
	Customers
LEFT JOIN
	Orders
ON
	Orders.CustomerID = Customers.CustomerID;

-- Right Join
SELECT 
	Orders.OrderID,
    Customers.CustomerID,
    OrderDate
FROM
	Customers
RIGHT JOIN
	Orders
ON
	Orders.CustomerID = Customers.CustomerID;

-- Cross Join
SELECT 
	Orders.OrderID,
    Customers.CustomerID,
    OrderDate
FROM
	Customers
CROSS JOIN
	Orders
ON
	Orders.CustomerID = Customers.CustomerID;
