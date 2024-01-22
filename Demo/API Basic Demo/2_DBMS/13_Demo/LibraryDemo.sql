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
		A01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT "Reader ID",
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
