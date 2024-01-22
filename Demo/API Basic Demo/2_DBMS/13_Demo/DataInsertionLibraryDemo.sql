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
    