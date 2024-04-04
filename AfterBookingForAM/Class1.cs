using BookingForAM;
namespace AfterBookingForAM
{
    public class AfterBooking : TicketCopy
    {
        public void FetchTicket()
        { 
           ShowTicketCopy();
            //no one can able to access this mail
           //RedirectingUser("email");
        }
    }
}
