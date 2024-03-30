﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Concepts
{
    //Parent class
    public class TicketBooking
    {
        //Same Method/Fucntion name with differnet Parameters -> Method Overloading / Compile Time polymorphism
        //Bus ticket Booking
        public void AddPassengers(string name)
        {
            PassengerDetails();
            Console.WriteLine("Name has been saved db");
        }
        // Flight ticket booking
        public void AddPassengers(string name, string passportnumber)
        {
            PassengerDetails();
            Console.WriteLine("Name & Passport has been saved to db");
        }
        // Method overriding is nothing but having same name same signature but differnet implementation // Run time polymorphism
        public virtual void Booking()
        {
            Console.WriteLine("Ticket is Booked");
        }

        private void PassengerDetails()
        {
            Console.WriteLine("Passenger Details");
        }

        protected void ShowingTicket()
        {
            Console.WriteLine("Show ticket");
        }
    }
   

    // By using interface Multiple inheritance is resolved
    interface ISendTicket { 
        void SendTicket();
    }
    // Child class inherting the parent class -> Single inheritance
    class BusTicketBooking : TicketBooking, ISendTicket
    {

        // Overriding the parent class method 
        public override void Booking()
        {
            Console.WriteLine("Bus Ticket is Booked");
        }

        public void SendTicket()
        {
            Console.WriteLine("Bus ticket seat number & passenger detail and time");
        }
    }
    class AirLineBooking : TicketBooking , ISendTicket
    {
        //Overriding the parent class method
        public override void Booking()
        {
            Console.WriteLine("Airline ticket is booked");
        }
        // Here Implementation will be different 
        public void SendTicket()
        {
            Console.WriteLine("Air line");
        }
    }

    // Multi Level Inheritance -> inherting the child class which inhertis parent class 
    class ShowTicketCounter : BusTicketBooking
    { 

    }
    // Hierarchical Inhertiance - n number of 
    class TrianTicketBooking : TicketBooking
    { 
    }
   
}