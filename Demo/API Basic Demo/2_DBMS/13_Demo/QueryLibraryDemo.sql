-- Sorting of the data
-- Books are sorted as per the genre -> AUthor -> Publisher

SELECT
	O01F01,
    O01F02,
    O01F03,
    O01F04,
    O01F05
FROM
	BOO01
ORDER BY
	O01F05, O01F03, O01F02;
    
-- Create table of Books by using another Books table
-- Table of Genre 1 Books 

CREATE TABLE 
	BOO03 						
AS SELECT
	O01F01,
    O01F02,
    O01F03
FROM
	BOO01
WHERE
	O01F05 = "Genre1";
    
SELECT 
	*
FROM 
	BOO03;
    

-- Drop                                        
-- Delete BOO03 Table

DROP TABLE
	BOO03;

   
-- Update

UPDATE 
	REA01
SET 
	A01F02 = 'Yash'
WHERE
	A01F01 = 1001;

-- Delete

DELETE FROM
	REA01
WHERE 
	A01F01 = 1005;

SELECT 
	A01F01,
    A01F02
FROM 
	REA01;

 
-- Limit

-- Using Where Clause || Select books which pages are less than 200

SELECT
	O01F01,
    O01F02,
    O01F03
FROM
	BOO01
WHERE
	O01F06 < 200
LIMIT 
	10;

-- Using Offset

SELECT
	O01F01,
    O01F02,
    O01F03
FROM
	BOO01
LIMIT 
	10
OFFSET		-- Neglecting first 3 records
	3;
    
-- Count || Number of books in BOO01 Table

SELECT 
	COUNT(O01F01)
FROM 
	BOO01;
    
-- Sum || Total Pages in B001 Table

SELECT 
	SUM(O01F06)
FROM 
	BOO01;

-- Average || Avg pages in BOO01 Table

SELECT 
	AVG(O01F06)
FROM 
	BOO01;

-- Minimum || Book with minimum pages in BOO01 Table

SELECT 
	MIN(O01F06)
FROM 
	BOO01;

-- Maximum || Book with maximum pages in BOO01 Table

SELECT 
	MAX(O01F06)
FROM 
	BOO01;
    
-- Sub Queries

-- Show book deatails in shelf 4 for table 1

SELECT 
	O01F01,
    O01F02,
    O01F03
FROM 
	BOO01
WHERE
	O01F07
IN
	(SELECT 
		O01F07
	FROM
		BOO01
	WHERE
		O01F07 = 4
    );

-- Find details of books whose pages are more than avg. pages per book in library

SELECT 
	O01F01,
    O01F02,
    O01F03
FROM
	BOO01
WHERE
	O01F06
IN 
	(SELECT 
		O01F06
     FROM
		BOO01
	 WHERE
		O01F06 > (SELECT AVG(O01F06) FROM BOO01)
	);
    
-- Corelated Subqueries with alias name

SELECT 
	O01F01,
    O01F02,
    O01F03
FROM 
	BOO01 v_book_more_pages 
WHERE 
	O01F06 > (SELECT 
				AVG(O01F06)
			FROM
				BOO01
    );

-- join
-- Books which has same number in pages but are in different table

SELECT 
	BOO01.O01F01,
    BOO01.O01F02,
    BOO01.O01F06,
    BOO02.O02F01,
    BOO02.O02F02,
    BOO02.O02F06
FROM
	BOO01 JOIN BOO02
ON
	BOO01.O01F06 = BOO02.O02F06;

-- Union
-- All books of Genre 1

SELECT
	'BookTable1' AS Type,
    O01F01 AS BookId,
    O01F02 AS BookName
FROM 
	BOO01
WHERE
	O01F05 = 'Genre1'
UNION 
SELECT
	'BookTable2' AS Type,
	O02F01,
    O02F02
FROM
	BOO02
WHERE
	O02F05 = 'Genre1';
    
-- View

-- Virtual Table for books of publisher1

CREATE OR REPLACE VIEW
	vws_boo01_boo02_publisher1
AS 
(SELECT
    O01F01 AS BookId,
    O01F02 AS BookName
FROM 
	BOO01
WHERE
	O01F04 = 'Publisher1'
UNION 
SELECT
	O02F01,
    O02F02
FROM
	BOO02
WHERE
	O02F05 = 'Publisher1');
    
SELECT 
	*
FROM
	vws_boo01_boo02_publisher1;

-- Explain Keyword

EXPLAIN SELECT 
	O01F01,
    O01F02
    O01F03
FROM
	BOO01
WHERE
	O01F04 = 'Publisher3';
    