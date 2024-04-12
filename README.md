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

in programming you can say that you should be able to use any subclass of a class as a replacement for the parent class without breaking the program 
