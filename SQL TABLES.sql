--1. Permenant table => whatever in your database we call it as permanent table 
--2. Derived tables => subquery , either AFTER from clause , or AFTER where clause
--3. Temp table => creating table temporarily in database , it will close automatically when you're closing the session
--4. Table variables
--5. CURSOR
-- Perm
Select * from Employee
-- derived table
SElect * from (select * from Employee) aliasname
select * from employee a
where a.EmployeeID in(select employeeid from employee)

-- Temp table 
-- 2 types of temp table 
-- Global temp table, Local temp table
-- Global Temp table we create by using ## for local temp table we create by using #
-- Global temp table lifetime exits until closing the connection , when we close this global table will drop automatically drop and you can access from any session until you close the connection
-- For local temp table after session it will not work because it will lose its scope it will work only in the particulcar session
-- Temp table will store in our database only 
--- Local Temp table it will use our disk space only and drop when close this session
Create table #TempTable(
EmpNo int,
EmpName varchar(100),
Salary int
)
insert into #TempTable values (1,'Gowtham',100)
select * from #TempTable
--- Global temp table it will use our disk space only but you can access in another session and it will automatically drop when you're closing the conection
Create table ##GlobalTemp(
Empno int,
empname varchar(100),
salary int)
insert into ##GlobalTemp values(1, 'Gowtham', 1000)
select * from ##GlobalTemp

-- Table Variables
-- Store in a in-memory temporarily for that we can use table variables
Declare @TableVariables Table
(
Empno int,
empname varchar(100),
salary int
)
insert into @TableVariables values(1,'Gowtham',100)
select * from @TableVariables
-- it will be destroyed once the in-memory erased
-- you can't assign indexes for table variables
-- but we can assign for temp table , it will behave like a permanent table
---if you want to insert 1000 records we can use table variables -> use ram memory in-memory
--- if you want to insert 1 crore records we can use temp table, 
-- for example I've 1000rs in my budget now I want to increment my employers by 10% 

-- CURSOR -- Nothing but looping ==> Looping our table row by row
--FOR(INT I=0; LENGHT>I;I++)
--{
--VAR INVAL= LIST[I]
--}


-- TABLE VARIABLES
DECLARE @EMPTABLE TABLE (ENO INT, ENAME NVARCHAR(100), SAL INT)
DECLARE @EMP INT, @ENAME NVARCHAR(100), @SALARY INT
Declare EmpCur Cursor FOR SELECT EmployeeID,EMPLOYEENAME,SALARY FROM Employee WHERE EMPLOYEEID NOT IN (11,12,13)
OPEN EMPCUR
FETCH NEXT FROM EMPCUR INTO @EMP, @ENAME, @SALARY
WHILE @@FETCH_STATUS=0 -- IT WILL CHECK WHETEHER THERE IS NEXT ROW OR NOT 
BEGIN
INSERT INTO @EMPTABLE 
SELECT @EMP, @ENAME, @SALARY*100
FETCH NEXT FROM EMPCUR INTO @EMP, @ENAME, @SALARY -- IN EACH LOOP WE NEED FETCH THE DATA AGAIN 
END
SELECT * FROM @EMPTABLE
CLOSE EMPCUR
DEALLOCATE EMPCUR


--CREATE TEMPTABLE 
--INSERT VALUE TO THE TEMP TABLE ONE BY ONE
--THEN YOU WANT TO CALCULATE
--INSERT INTO TEMPTABLE VALUES
--SELECT * FROM EMPLOYEE WHERE NOT IN (11,12,13) AND SALARY > 500 
-- INSERT ANOTHER ROWS FOR THE SAME EMPLOYEE AND SAY THIS YEAR ALSO YOU'RE GOING TO GET THE SAME SALARY BECAUSE A REACHED LIMIT
-- INSERT SALARYREACHED TABLE 
--IF ONE CONDTION YOU WANT TO SKIP THE EMPLOYEES THEIR SALARY IS GREATER THAN 500
---UPDATE THE TEMP TABLE 

DECLARE @DROPTABLE TABLE(STATEMENTS NVARCHAR(100))
DECLARE @TABLENAME NVARCHAR(100)
Declare DROPCURSOR Cursor FOR SELECT [NAME] FROM SYS.tables WHERE [NAME] NOT IN ('EMPLOYEE')
OPEN DROPCURSOR
FETCH NEXT FROM DROPCURSOR INTO @TABLENAME
WHILE @@FETCH_STATUS=0 -- IT WILL CHECK WHETEHER THERE IS NEXT ROW OR NOT 
BEGIN
INSERT INTO @DROPTABLE 
SELECT 'DROP TABLE' +' '+ @TABLENAME
FETCH NEXT FROM DROPCURSOR INTO @TABLENAME -- IN EACH LOOP WE NEED FETCH THE DATA AGAIN 
END
SELECT * FROM @DROPTABLE
CLOSE DROPCURSOR
DEALLOCATE DROPCURSOR