-- Data Control Language

-- Grant

-- Granting previleges

GRANT
	SELECT,
    INSERT,
    DELETE,
    UPDATE
ON 
	EMP01
TO 
	'Yash'@'localhost';

-- Revoke

-- Revoking previleges

REVOKE
	SELECT,
    INSERT,
    DELETE,
    UPDATE
ON 
	EMP01
FROM 
	'Yash'@'localhost';