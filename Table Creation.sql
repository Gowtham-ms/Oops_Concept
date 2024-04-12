Create table Orders
(
OrderID int primary key identity(1,1),
OrderName nvarchar(50),
CustomerID int
)
select * from orders
Insert into Orders
values ('Keyboard','2')
Insert into Orders
values ('Dummy Order','5')


Create Table Customers
(
CustomerID int primary key identity(1,1),
CustomerName nvarchar(50)
)

Insert into Customers
values ('Asha')

Insert into Customers
values ('Sandeep')

Insert into Customers
values ('Arun')

Insert into Customers
values ('Bala')
