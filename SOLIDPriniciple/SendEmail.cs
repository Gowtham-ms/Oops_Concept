using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPriniciple
{
    // low level class
    // So low level class is inherting with interface now we solved the low level class
    public class SendEmail : ISendEmail
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public void SendMailToOrg() {
            Console.WriteLine("Added employee notification sent to organization from SendMailToOrg method");
        }
        void ISendEmail.SendMail()
        {
            Console.WriteLine("Added employee notification sent to organization");
        }
        void ISendEmail.SMS() {
            Console.WriteLine("Added employee notification sent to organization");
        }
    }

    public interface ISendEmail
    {
        void SendMail();
        void SMS();
    }

    // we've acheived dependency inversion principle by abstraction

}
