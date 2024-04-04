using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instance for this class
            ConcreteClass obj = new ConcreteClass();
            obj.Name = "Test";
            obj.age = 8;
            obj.ClassDetails();
            // trying to create an object for static class
            // directly access the static class just by adding a .
            College.Address = "College address";
            College.CollegeMethod();
            int value1 = College.age;
            int value2 = College.age;
            int value3 = College.age;
            Console.WriteLine(value1);
            Console.WriteLine(value2);
            Console.WriteLine(value3);
            // here i am creating another object for concrete class
            ConcreteClass obj1 = new ConcreteClass();
            obj1.ClassDetails();
            Console.ReadLine();
        }
    }
    //concrete class // normal class // class
    public class ConcreteClass
    {
        public ConcreteClass() {
           
            marks++;
        }
        int marks = 35;
        // properties
        public string Name { get; set; }
        public int age { get; set; }
        // variable declaration
       
        public void ClassDetails() {
            string anotherString = Name;
            int _marks = marks;
           
        }
    }
}
