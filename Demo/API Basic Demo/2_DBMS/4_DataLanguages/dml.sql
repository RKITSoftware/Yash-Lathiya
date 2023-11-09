-- Data Manupalation Language

-- Insert

INSERT INTO
	EMP01
VALUES (1001, "Yash", "India", 21, 70, 50000),
	   (1002, "Yash", "India", 21, 70, 50000),
       (1003, "Yash", "India", 21, 70, 50000),
	   (1004, "Yash", "India", 21, 70, 50000);

-- Update

UPDATE 
	EMP01
SET 
	P01F02 = 'Sachin'
WHERE
	P01F01 = 1002;

-- Delete

DELETE FROM
	EMP01
WHERE 
	P01F01 = 1003;