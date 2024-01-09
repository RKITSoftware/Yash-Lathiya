-- Create Database

CREATE DATABASE 
	LibraryDemo;
    
-- Using a LibraryDemo Database

USE 
	LibraryDemo;
    
-- Create table of Books

CREATE TABLE 
	BOO01(						-- Book01 Table 			 
		O01F01 INT PRIMARY KEY COMMENT "ISBN Number", 
		O01F02 VARCHAR(50) COMMENT "Book Name", 
		O01F03 VARCHAR(50) COMMENT "Author Name",
		O01F04 VARCHAR(50) COMMENT "Publisher Name",  
		O01F05 VARCHAR(50) COMMENT "Genre", 
        O01F06 INT COMMENT "Number of Pages",
        O01F07 INT COMMENT "Shelf Location",
        O01F08 BOOL DEFAULT TRUE COMMENT "Availability Status" 
);

CREATE TABLE 
	BOO02(						-- Book02 Table 			 
		O02F01 INT PRIMARY KEY COMMENT "ISBN Number", 
		O02F02 VARCHAR(50) COMMENT "Book Name", 
		O02F03 VARCHAR(50) COMMENT "Author Name",
		O02F04 VARCHAR(50) COMMENT "Publisher Name  ",
		O02F05 VARCHAR(50) COMMENT "Genre ",
        O02F06 INT COMMENT "Number of Pages",
        O02F07 INT COMMENT "Shelf Location",
        O02F08 BOOL DEFAULT TRUE COMMENT "Availability Status"
);

-- Create Reader Table 

CREATE TABLE 
	REA01 (
		A01F01 INT PRIMARY KEY COMMENT "Reader ID",
		A01F02 varchar(255) COMMENT "First Name", 
        A01F03 varchar(255) COMMENT "Last Name",
        A01F04 varchar(255)	COMMENT "Address"
    ) AUTO_INCREMENT = 1001;

-- Create Status Table 

CREATE TABLE 
	STA01 (
        A01F01 INT COMMENT "Reader ID",
		A01F02 INT COMMENT "Book ID",
        CONSTRAINT FK_ReaderID FOREIGN KEY (A01F01) REFERENCES REA01(A01F01),
        CONSTRAINT FK_BookID FOREIGN KEY (A01F02) REFERENCES BOO02(O02F01)
    );
    
-- Enter Data into Table

INSERT INTO
	BOO01 
VALUES (10011001, "Book1", "Author1", "Publisher1", "Genre1", 120, 1, TRUE),
	   (10011002, "Book2", "Author2", "Publisher1", "Genre1", 140, 2, TRUE),
       (10011003, "Book3", "Author3", "Publisher1", "Genre2", 160, 3, TRUE),
       (10011004, "Book4", "Author1", "Publisher2", "Genre3", 80, 1, TRUE),
       (10011005, "Book5", "Author1", "Publisher2", "Genre4", 1120, 1, TRUE),
	   (10011006, "Book6", "Author2", "Publisher3", "Genre5", 1000, 2, TRUE),
       (10011007, "Book7", "Author3", "Publisher2", "Genre6", 185, 4, TRUE),
       (10011008, "Book8", "Author4", "Publisher2", "Genre1", 192, 5, TRUE);
       
INSERT INTO
	BOO02 
VALUES (10011009, "Book9", "Author5", "Publisher1", "Genre1", 120, 1, TRUE),
	   (10011010, "Book10", "Author2", "Publisher1", "Genre1", 140, 2, TRUE),
       (10011011, "Book11", "Author6", "Publisher1", "Genre2", 160, 3, TRUE),
       (10011012, "Book12", "Author1", "Publisher2", "Genre3", 80, 1, TRUE),
       (10011013, "Book13", "Author7", "Publisher2", "Genre4", 1120, 1, TRUE),
	   (10011014, "Book14", "Author7", "Publisher3", "Genre5", 1000, 2, TRUE),
       (10011015, "Book15", "Author8", "Publisher2", "Genre6", 185, 4, FALSE),
       (10011016, "Book816", "Author4", "Publisher2", "Genre1", 192, 5, FALSE);
       
-- Reader Id will auto increment by starting 1001

INSERT INTO
	REA01 
    (A01F02, A01F03, A01F04)
VALUES 
	("Sachin", "Tendulkar", "Mumbai"),
    ("Mahindra", "Dhoni", "Ranchi"),
    ("Virat", "Kohli", "Jalandhar"),
    ("Surya", "Yadav", "Rajasthan"),
    ("Ravindra", "Jadeja", "Gujarat");
    
SELECT
	A01F01,
    A01F02
FROM
	REA01;
       
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

-- Alter

-- Add Columns

ALTER TABLE 
	REA01
ADD(
	A01F05 VARCHAR(50),	-- Remarks1
    A01F06 VARCHAR(50)	-- Remarks2
);

-- Drop Column A01F06

ALTER TABLE
	REA01
DROP COLUMN
	A01F06;
    
-- Modifiing Column 
-- Datatype is modifies to varchar(30)

ALTER TABLE
	REA01
MODIFY COLUMN
	A01F05 VARCHAR(30);

-- Truncate
-- Removes all data within database or table 

TRUNCATE TABLE 
	REA01;

-- Rename

-- Renaming Column Name

ALTER TABLE 
	REA01
RENAME COLUMN
	A01F05 TO A01F06;
    
ALTER TABLE 
	REA01
RENAME COLUMN
	A01F06 TO A01F05;
    
-- Renaming Table Name Reader to User USE01

ALTER TABLE 
	REA01
RENAME TO
	USE01;
    
ALTER TABLE 
	USE01
RENAME TO
	REA01;
    
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
	v_publisher1
AS 
(SELECT
	'BookTable1' AS Type,
    O01F01 AS BookId,
    O01F02 AS BookName
FROM 
	BOO01
WHERE
	O01F04 = 'Publisher1'
UNION 
SELECT
	'BookTable2' AS Type,
	O02F01,
    O02F02
FROM
	BOO02
WHERE
	O02F05 = 'Publisher1');
    
SELECT 
	*
FROM
	v_publisher1;

-- Explain Keyword

EXPLAIN SELECT 
	O01F01,
    O01F02
    O01F03
FROM
	BOO01
WHERE
	O01F04 = 'Publisher3';