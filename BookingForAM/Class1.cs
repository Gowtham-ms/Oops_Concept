using System;
using System.Collections.Generic;


namespace BookingForAM
{
    public class Login : TicketCopy
    {
        public void AllowLogin(string username, string password)
        {

           bool validated = ValidatingUser(username, password);
            if (validated)
                Console.WriteLine("Logged in successfully");
        }
        private bool ValidatingUser(string username, string password)
        {
            Console.WriteLine("User is valid ");
            return true;
        }

    }

    public class BookingFunctions
    {
        public virtual void Book()
        {
            Console.WriteLine("Book Tickets here ");
        }
        protected void PassengerDetails()
        {
            Console.WriteLine("Passenger Details");
        }
    }

    public class BusBooking : BookingFunctions
    {
        public override void Book()
        {

            Console.WriteLine("Bus Booked");
            PassengerDetails();
            TicketCopy ticketCopy = new TicketCopy();
            ticketCopy.ShowTicketCopy();
        }
    }
    public class AirlineBooking : BookingFunctions
    {
        public override void Book()
        {
            Console.WriteLine("Airline booked");
            PassengerDetails();
            TicketCopy ticketCopy = new TicketCopy();
            ticketCopy.ShowTicketCopy();
        }
    }

    public class TicketCopy
    {
        protected internal void ShowTicketCopy()
        {
            Console.WriteLine("This is your ticket copy ");
        }
        private protected void RedirectingUser(string email)
        {
            Console.WriteLine("Redirecting the user with booking emailid");
        }
    }

    public class RedirectUser : TicketCopy
    {
        public void RedirectingUser()
        {
            RedirectingUser("email");
        }
    }

}
