using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTypes
{
    // you cannot create an object for static class
    // static class contains only static members and static methods
    // Extension method 
    // static class cannot be inherited
    public static class College
    {
        static string Name = "It is a Static Class";
        public static string Address { get; set; }
       public static int age = 20;
        public static void CollegeMethod()
        {
            Console.WriteLine("A static method inside the static class");
        }
        public static void AddingTransactionTime()
        {
            Console.WriteLine("");
        }
        // declaring a static constructor
        // constructor inside the static class will get called only once
        static College() {
            age++;
        }
    }
    public class SameLogic {
        public void AddingTransactionTime() { 
        }
    }
    public class BankAcount 
    {
        public void BankAccountLogic() {
            Console.WriteLine("Bank account logic");
            Console.WriteLine("Rewriting logic for adding a transaction time");
            College.AddingTransactionTime();
            Console.WriteLine("Write logic for adding a transaction id after every transaction with _");
            //100rs_1000004343;
        }
    }
}
