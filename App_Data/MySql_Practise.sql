/*                                       
==============================================================================================================
AUTHOR		  :    Asish Kumar Panda                                     
CREATE DATE	  :    2019-09-12 23:54:42.897                                 
--------------------------------------------------------------------------------------------------------------     
PURPOSE		  :	   My personal practise 
--------------------------------------------------------------------------------------------------------------     
NOTES		  :                                 
--------------------------------------------------------------------------------------------------------------   
CHANGE LOG	  :                                                       
==============================================================================================================     
*/   
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'iAsish')
    CREATE DATABASE iAsish
	
--Use iAsish
USE iAsish

--Create Table and Insert Data
CREATE TABLE tbl_Employee(
ID INT,
Name varchar(15),
Phone varchar(15),
Address nvarchar(100),
Sal float
)

INSERT INTO tbl_Employee values(1,'Asish',9606194182,'PKD',2000)
INSERT INTO tbl_Employee values(2,'Panda',96063342,'PKD',6000)
INSERT INTO tbl_Employee values(3,'Rocky',9606194182,'PKD',4500)
INSERT INTO tbl_Employee values(4,'Asheem',96063342,'PKD',90000)
INSERT INTO tbl_Employee values(5,'Asish',9606194182,'PKD',4000)
INSERT INTO tbl_Employee values(6,'Ansuman',96063342,'PKD',6000)

SELECT *FROM tbl_Employee WITH(NOLOCK)

--Some miscellaneous Queries
Select * from tbl_Employee order by 5  --Retuns sort on 5th column
Select * from tbl_Employee  where 1=1  --Retuns all the data

--Nested Selected Query
SELECT *
FROM (
  SELECT *
  FROM tbl_Employee
) t

SELECT *
FROM (
  VALUES(1),(2),(3)
) t(a)

SELECT *
FROM substring('abcde', 2, 3)



-- Table variables
WITH
  t1(v1, v2) AS (SELECT 1, 2),
  t2(w1, w2) AS (
    SELECT v1 * 2, v2 * 2
    FROM t1
  )
SELECT *
FROM t1, t2



---Generating Factorial
;with fact as (
    select 1 as fac, 1 as num
    union all
    select fac*(num+1), num+1
    from fact
    where num<12)
select fac
from fact
where num=5

--finonaic series
;with fibo as (
    select 0 as fibA, 0 as fibB, 1 as seed, 1 as  num
    union all
    select seed+fibA, fibA+fibB, fibA, num+1
    from fibo
    where num<12)
select fibA
from fibo



-- find row-wise maximum value and column name
 CREATE TABLE ROW_MAX (
                 id1 INT IDENTITY(1, 1)
                 ,Col1 INT
                 ,col2 INT
                 ,Col3 INT
                 ,Col4 INT
                )

--Script for Data insertion:-
                    insert into Row_max
                     select 1,2,3,4
                      union
                     select 2,22,3,4
                       union
                     select 4,2,1,1
                       union
                     select 5,4,3,2 

Select *from ROW_MAX
Create PROC Get_Pagination_Data (
                                     @No_Of_Records INT
                                     ,@Page_Number INT
                                     ,@ID_Grt_Than INT
                                    )
AS
BEGIN
    ;WITH CTE
           AS (
                    SELECT TOP (@No_Of_Records*@Page_Number)
                                     ((
                                       ROW_NUMBER() OVER (
                                                              ORDER BY id
                                                                                   ) - 1
                                                                         ) / @No_Of_Records)+1 Page_number
                                                                     ,   *
                                                                    ,COUNT(*) OVER () Total_Record
                        FROM Pagination_test
                       WHERE ID > @ID_Grt_Than
                      )
           SELECT Id
                          ,First_name
                          ,Total_Record
            FROM cte
            WHERE page_number = @Page_Number
END 

Exec Get_Pagination_Data 50,1,500

SELECT *
                ,COUNT(*) OVER () Total_Record
FROM Pagination_test

WHERE id < 500

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



------------------------------
 
--2nd Highest Sal
--Using DenseRank

SELECT  t.* 
FROM (
      SELECT Sal,
          DENSE_RANK() OVER (ORDER BY Sal DESC) AS DENSE_RANK 
      FROM tbl_Employee
      ) as t  --- this alias is missing
WHERE t.dense_rank = 2


--SubQuery 
Select top 1 * from (Select distinct top 2 Sal from tbl_Employee order by Sal Desc )t order by sal

Select max(sal) from tbl_Employee where sal not in(select max(sal) from tbl_Employee)
 --Highist Sal
select *from(select *,Dense_Rank()over(order by sal desc) as t
 from tbl_Employee) temp
 where temp.t=2

 --Duplicate Value Check
 Select *from tbl_Employee order by sal desc
select *from(select *,Row_Number()over(partition by Sal order by sal desc) as t
 from tbl_Employee) temp
 where temp.t=2


