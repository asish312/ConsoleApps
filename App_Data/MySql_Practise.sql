CREATE DATABASE iAsish
USE iAsish

CREATE TABLE tbl_Employee(
ID INT,
Name varchar(15),
Phone varchar(15),
Address nvarchar(100)
)

INSERT INTO tbl_Employee values(1,'Asish',9606194182,'PKD')
INSERT INTO tbl_Employee values(2,'Panda',96063342,'PKD')
INSERT INTO tbl_Employee values(3,'Asish',9606194182,'PKD')
INSERT INTO tbl_Employee values(5,'Panda',96063342,'PKD')
INSERT INTO tbl_Employee values(1,'Asish',9606194182,'PKD')
INSERT INTO tbl_Employee values(2,'Panda',96063342,'PKD')
SELECT *FROM tbl_Employee WITH(NOLOCK)

-----------------------------------
CREATE TABLE TableA
(
 ID INT NOT NULL IDENTITY(1,1),
 Value INT,
 CONSTRAINT PK_ID PRIMARY KEY(ID)  
)


INSERT INTO TableA(Value)
VALUES(1),(2),(3),(4),(5),(5),(3),(5)

SELECT *
FROM TableA

SELECT Value, COUNT(*) AS DuplicatesCount
FROM TableA
GROUP BY Value



----- Finding duplicate values in a table with a unique index
--Solution 1
SELECT a.* 
FROM TableA a, (SELECT ID, (SELECT MAX(Value) FROM TableA i WHERE o.Value=i.Value GROUP BY Value HAVING o.ID < MAX(i.ID)) AS MaxValue FROM TableA o) b
WHERE a.ID=b.ID AND b.MaxValue IS NOT NULL

--Solution 2
SELECT a.* 
FROM TableA a, (SELECT ID, (SELECT MAX(Value) FROM TableA i WHERE o.Value=i.Value GROUP BY Value HAVING o.ID=MAX(i.ID)) AS MaxValue FROM TableA o) b
WHERE a.ID=b.ID AND b.MaxValue IS NULL

--Solution 3
SELECT a.*
FROM 
TableA a
INNER JOIN
(
 SELECT MAX(ID) AS ID, Value 
 FROM TableA
 GROUP BY Value 
 HAVING COUNT(Value) > 1
) b
ON a.ID < b.ID AND a.Value=b.Value

--Solution 4
SELECT a.* 
FROM TableA a 
WHERE ID < (SELECT MAX(ID) FROM TableA b WHERE a.Value=b.Value GROUP BY Value HAVING COUNT(*) > 1)

--Solution 5 
SELECT a.*
FROM TableA a
INNER JOIN
(SELECT ID, RANK() OVER(PARTITION BY Value ORDER BY ID DESC) AS rnk FROM TableA ) b 
ON a.ID=b.ID
WHERE b.rnk > 1

--Solution 6 
SELECT * FROM TableA 
WHERE ID NOT IN (SELECT MAX(ID) 
                 FROM TableA 
        GROUP BY Value)


----------------------------------------------------------------
SELECT username, email, COUNT(*)
FROM users
GROUP BY username, email
HAVING COUNT(*) > 1



SELECT * FROM
(
    SELECT Id, Name, Age, Comments, Row_Number() OVER(PARTITION BY Name, Age ORDER By Name)
        AS Rank 
        FROM Customers
) AS B WHERE Rank>1


WITH CTE (Col1, Col2, Col3, DuplicateCount)
AS
(
 SELECT Col1, Col2, Col3,
 ROW_NUMBER() OVER(PARTITION BY Col1, Col2,
      Col3 ORDER BY Col1) AS DuplicateCount
 FROM MyTable
) SELECT * from CTE Where DuplicateCount = 1



--Usin Self Join
SELECT emp_name, emp_address, sex, marital_status
from YourTable a
WHERE NOT EXISTS (select 1
        from YourTable b
        where b.emp_name = a.emp_name and
              b.emp_address = a.emp_address and
              b.sex = a.sex and
              b.create_date >= a.create_date