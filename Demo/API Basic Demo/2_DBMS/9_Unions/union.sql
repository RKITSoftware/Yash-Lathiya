-- Union

SELECT
	'Shipper' AS Type,
    ShipperID,
    ShipperName
FROM 
	Shippers
UNION 
SELECT
	'Supplier' AS Type,
	SupplierID,
    SupplierName
FROM
	Suppliers;

-- Union All 

SELECT
	'Shipper' AS Type,
    ShipperID,
    ShipperName
FROM 
	Shippers
UNION ALL
SELECT
	'Supplier' AS Type,
	SupplierID,
    SupplierName
FROM
	Suppliers;