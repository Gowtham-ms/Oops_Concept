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

// we can discuss this tomorrow
protected, -> same class and any class which inherits from the base class
internal, -> within the current assembly (project)
protected internal -> withn the assembly and any class which inherit from the base class
private protected -> within the class and any class which inherits from the same assembly


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

