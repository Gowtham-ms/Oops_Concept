using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Concepts
{
    //Class is a collection of objects
    //Ticket Booking Application
    internal class Program
    {
        // Ticket Booking Appl
        static void Main(string[] args)
        {
            TicketBooking _ticketBooking = new TicketBooking();
            _ticketBooking.AddPassengers("Gowtham");
            _ticketBooking.AddPassengers("Gowtham", "Passportnumber");
            // Using Parent class object for child class
            _ticketBooking = new BusTicketBooking();
            _ticketBooking.Booking();

            _ticketBooking = new AirLineBooking();
            _ticketBooking.Booking();
        }
    }
}
