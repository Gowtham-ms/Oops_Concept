ADO.NET (ActiveX Data Objects for .NET) is a set of classes included in the .NET Framework that facilitate communication between .NET applications and data sources, such as databases to insert update delete and read

1. ExecuteNonQuery() 
   is used to execute SQL commands against a database, where the command does not return any data. It is commonly used for executing SQL commands such as INSERT, UPDATE, DELETE, or DDL (Data Definition Language) statements like CREATE TABLE or ALTER TABLE.

2. DataAdapter (SqlDataAdapter)
   DataAdapter is a bridge between a dataset and a database. It retrieves data from the database, fills the dataset with data, and updates the database with changes made to the dataset. It consists of four main commands: `SelectCommand`, `InsertCommand`, `UpdateCommand`, and `DeleteCommand`.

3. DataTable   
DataTable represents one table of in-memory data. It consists of rows and columns and can be filled with data retrieved from a database using a DataAdapter.

4. ExecuteScalar()
   This method is used to execute a query that returns a single value (for example, an aggregate function like COUNT, SUM, etc.).

5. ExecuteReader()
   This method is used to execute a query that returns a forward-only, read-only stream of rows from a data source. It returns a `DataReader` object that provides a way to read data in a forward-only manner.

6. DataSet
   DataSet is an in-memory cache of data retrieved from a data source. It can contain multiple DataTables, relationships between DataTables, and constraints. It provides a disconnected data model, meaning it doesn't need an active connection to the database once data is retrieved.

7. SqlCommand
   represent SQL commands or stored procedures that are executed against a database. They are used to execute SQL queries, stored procedures, or other commands against the database.

8. SqlConnection
   represent connections to specific types of databases. They are used to establish connections to the database before executing commands and manage the connection's lifecycle.

9. DataReader
   DataReader provides a way to read data in a forward-only manner from a data source. It's typically used when you need to read large amounts of data efficiently and sequentially, without needing to store the data in memory.



OOPS Concept with real world examples
Class,
Objects,

Polymorphism, -> Many form -> Method Overloading (Compile Time Polymorphism) & Method Overriding (Run time polymorphism)


Inheritance, -> inherting the child class from the parent class -> Single Inhertiance, Multiple Inheritance , Multi Level Inheritance , Hierarchy Inheritance

Abstraction, -> Abstraction is nothing but hiding the base class and showing only what is necessary it will be acheived by Abstract class & Interface

Encapsulation, -> bundling of data and related operations into a single unit or object will be acheived by Access Modifiers

Abstract class -> Incomplete Class, It contains both abstract method and non abstract method, here in abstract method contain function definition
Interface ->



Access Modifiers in C#

public, -> no restrictions
private, -> within the same class 
protected, -> same class and any class which inherits from the base class
internal, -> within the current assembly (project)
protected internal -> withn the assembly and any class which inherit from the base class
private protected -> within the class and any class which inherits from the same assembly


Constructer -> syntax should be same as your class name , it will be used when you're creating an object



Booking -> Bus Ticket, Train , Flgiht
Instead of multiple inheritance C# will use interface logic to do the multiple inheritance

Hierarchical Inheritance

TicketBooking -> Base Class

AirLineBooking : TicketBooking -> First child
BusTicketbooking : TicketBooking -> Second Child 
TrainTicketbooking : TicketBooking -> Third Child

When to use abstract class and when to use interface
Abstract class -> Whenever you are sure that every abstract method will be utilized by child class then you can use abstract class
Interface -> An application running perfectly without any issues, now client want to implement a new method for the application so at that time we can use interface to acheive this 
without disturbing our old logic and implement a new logic



Tomorrow : 
1. DateTime 
2. Types of class -> Concrete class, Static class, Partial class , Abstract class , Sealed class, Nested Class (it is not in use in realtime)
3. Interview Questions -> Ado.net , C# 
4. framework and why we are using it and types
.Net Framework
 multiple languages => c#, MVC, F#, Vb.net 
.NetCore is platform which we use in .net framework => .net core has multiple functionalites => creating application to desktop, web application, windows, ios, 
=> .NET 
.Net is a framwork
asp.net is a web application framework and it is part of the .net ecosystem
Ado.net is nothing but a object relational mapper , it will interact with your database
Entity framework is orm tool 


1. Concrete Class :
 is a normal class we can create object for the class , and we can get and set properties inside our class

2. Static class : you can't create object 
i. Static class keyword is static 
ii. Static class cannot be instantiated you can not create object 
iii. only static method can be inside the static class 

3. Partial class : you can create object 
i. Splitting a single class to multiple class 
ii. Partial keyword
iii. for partial class we can create object

4. Sealed Class : you can create object 
i. If we are declaring a class as sealed , then it can't be inherited
ii. We can create object
iii. When there is a sealed method then you can't override that method
iv. Sealed keyword

5. Nested class : 
i. A class inside a class
ii. you can create object 
iii. you can create 2 property in same name one in outer class and other in inner class


We can Discuss about all previous class 
- we can start SQL SP , Functions , Indexes

Today : 10-04-2024
- Temp table 
- Table variable
- Cursor

11-04-2024

SOLID Principles

i. Tightly Coupled applications 

100s aplication
Class A --> Class B 
Class B ---> Class A 
If we have any future requirement for tightly application then you need to change the whole code 
Just assume when ur class is depended with other class then it is tightly coupled

Class A 
we have 1 functionality here 

Class B
functionality will return the functionality for class A 


ii. Loosely coupled applications
When you develop an application using this SOLID prinicple is loosely coupled
We can also reuse the code and enhance the code , then we have lot of advantage

Base Class A
Changing Base Class A 
Method has values for child B

Child Class B : A 

if we inherit that method we can easily get the values of class A 

------ SOLID Principles -------
SOLID principle is nothing but design principle for software problems, we definitely have to use this principle to make our code loosely coupled
S single responsibility priniciple SRP
O open closed principle OCP 
L liskov substitution principle LSP
I Interface segregation principle ISP
D dependency inversion priniciple DIP


1. Single responisibity prinicple : Each and every class or module should have only 1 reason to change 
2. Open Closed Principle : Open for extension and closed for modification

3. Liskov substituion principle : 

bunch of toys like cars, trucks and airplanes
is like saying that if you have a toy box, you can swap any toy with another one as long as they both do the same things
if you can play with a car, you should also able to play with a truck or airplanes without any problems

in programming you can say that you should be able to use any child of a class as a replacement for the parent class without breaking the program 

Introduced by Barbara Liskov

If "S" is a subtype of "T" then the object of type "T" maybe replaced with object of type "S"


For Example if we have 2 class 1 is parent and other is child
A - Parent
B - Child

A objA = new A();
B objB = new B();

in LSP
we need to substitute A with B 
A objA = new B();

Replace A with B

we have 3 rules in LSP we need to follow these rules to make our code loosely coupled
1. Child class object must be a substitute for parent class object and it should not give an incorrect output
2. Child class must have all the methods from the parent,, it should not throw not implemented exceptions
if a parent class has 4 methods then child class also have 4 methods 
3. Child doesn't change the signature of the parent class
if A has 2 methods and 2 parameters then child B also have 2 methods and 2 parementers 

LSP is extension of OCP

4. ISP - Interface segregation Principle

A class must not have to implement any interface which is not required by the class 

5. DIP - Dependency Inversion Principle

High level class doesn't depend on low level class and low level class doesn't depend on high level class and both should be depend on abstraction 

we can acheive abstraction using Interface or Abstract class , but in real world people will use Interface



--- Dependency Injection in MVC ---

1. Injecting the Dependency during runtime
2. A class doesn't create an object/instance of another class , but instead it will ask other class to create
3. Loosely coupled

Instead of we doing our work asking someone to do our work

1. Nuget package from npm -> unit config.mvc
2. Register it globally -> global.asax
3. Interface -> Repository
4. Service and inherit the interface // low level class depending on abstraction
5. Register the repository into unityconfig.cs
6. Whenever we inject the interface in contructor parameter at that time it will map the repository class and get the object
7. After that it will help us to acheive the DI. Class doesn't creating any object of any class inside the high level class instead our UnityMVC will do that work
8. We will get the values by not depending on any class


I want an application to get the students and whoever is teacher of that particular student

Gowhtma -> James 

ID Student Teacher
1. Gowtham James



MVC - an architecture in .net framework

Model , View, Controller


Model - Will take care of database access related stuffs
View - What ever user see in his screen are all view which is UI part
Controller - It will manipulate the model and also update view based on the manipulation


All 4 are used to pass data but each has unique features
ViewBag -> Pass data from controller to view
ViewData -> Pass data from controller to view 
TempData -> Pass data from one controller to another controller (one action to another action)
Session -> We can pass data everywhere within the application , but it will maintain only for 20 minutes but we can change

Tomorrow

Real time CRUD application using Entity Framework MVC application


Entity Framework is ORM tool => Object Relational Mapper
Which will connect our database automatically

Tomorrow
From the scratch 
Angular as front and Dotnet core as backend


Steps to create angular application
1. We need to download node.js from the node website 
2. We need to install angular cli npm install
3. we need to create an angular application using --> ng new ApplicationName --no-standalone => Angular 17
4. So after that we can open our angular application using --> code .
5. run the application using ng serve --o
6. Adding service to connect our api from angular --> this service will use angular library HttpClientModule
7. for connecting our web api to angular we're creating a service : ng g s Employee
to call the api from angular we have one thing called "httpclientmodule"
we have 2 things in angular : observables and subscribe
Observables : it will give values from api , using subscribe we need to get values from the observables


i.  Angular from basics
ii. Web application hosting in IIS

Create component in 2 ways :
1. manual and 2. angular cli


string interpolation

Data Binding in angular 
one way data binding => how to pass values from view to component in Event Binding 
two way data binding => [(ngModel)]




Property Binding 
= Binding html property inside the html tag is property binding

Event Binding
==> Whatever we are doing in the browser which will consider it as event (keyboard events and mouse events)
we can handle the event by using $event function

Directives 
Is used to change the behavior, appearance or layout of the elements

3 types of directives
1. Component Directives
2. Structural Directives
3. Attribute Directives


directivese : ngFor ngIf ngSwitch , ngElse


Tomorrow : 
Pipes : Date
Routing , 
Direct routing
Parameter routing


linq query to select , join tables 
How to deploy in iis server


Linq : Language Integrated Query

Query syntax integrated to our application

