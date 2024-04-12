--What is Joins and its types 
-- To combine two or more table rows based on the columns between the two or more tables
-- Inner Join
-- Left Join or Left Outer Join
-- Right Join or Right Outer join
-- Full Join or Full Outer Join
-- Cross Join
-- Self Join (this will not be mostly used in real time examples)

--select * from orders -- order id is primary key for orders table Customer id is foreign key for customer table 

--select * from customers -- customer id is primary key for customer table

-- INNER JOIN
-- I want to return the rows that have matching values in both tables 
-- I want to see the customer whoever ordered my products
Select OrderID,O.CustomerID,CustomerName from orders O
inner join Customers C
On
O.CustomerID = C.CustomerID

-- LEFT JOIN or LEFT OUTER JOIN
-- I want to return from the order table and matched rows in the customer table , if there is no matching rows in the customer table 
-- you have to return null values 
Select * from Customers C
Left OUTER join Orders O
on
C.CustomerID = O.CustomerID

-- RIGHT JOIN or RIGHT OUTER JOIN
-- I want to return from the customer table and matched rows in the orders table , if there is no matching rows in the orders table 
-- you have to return null values 

Select * from Customers C
Right Join 
Orders O
on 
O.CustomerID = c.Customerid

-- FULL JOIN or FULL OUTER JOIN
-- I want to return all rows from both tables, whether it matches or not 
-- if there is no match I need to return null values 
select * from Customers C 
FULL JOIN Orders O
on C.CustomerID = O.CustomerID

-- CROSS JOINS 
-- will return all possible values of rows from both tables 
-- and in this condition you won't require any matching columns

Select * from Customers
Cross join Orders

-- SELF Join 
---- Employee Table and Manager Table
--Create Table Employees
--(
--ID int primary key identity(1,1),
--EmployeeName nvarchar(40),
--ManagerID int
--)
-- whenever you want to join the same table, where a table is joined with itself

select EID.EmployeeName,MID.EmployeeName,EID.Salary,MID.Salary as ManagerName from Employee EID
join Employee MID
on 
EID.EmployeeID = MID.ManagerID


--update employee
--set salary = 50
--where employeeid = 2
-- SELF JOIN
-- You want to get salary of employee whoever 

select * from orders
select * from customers
--Subquery
select * from Orders where OrderID in (select customerID from orders )
-- Self join
select O.OrderId,O.OrderName,O.CustomerID from Orders O
Join 
Orders C
on O.OrderID = C.CustomerID
group by O.OrderID,O.CustomerID,O.OrderName


-- Group By -- 
-- Order By
-- Having
-- Between
-- Min Max Count Avg