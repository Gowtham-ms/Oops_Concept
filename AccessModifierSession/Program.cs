using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingForAM;

namespace AccessModifierSession
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            login.AllowLogin("Username", "Password");
            //login.ValidatingUser("username", "password");

            BookingFunctions bookingFunctions = new BookingFunctions();
            bookingFunctions.Book();
            //bookingFunctions.PassengerDetails();
           

        }
    }
}
