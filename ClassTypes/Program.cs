using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassTypes.OuterClass;

namespace ClassTypes
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            int mark = 35;
            // instance for this class
            ConcreteClass obj = new ConcreteClass();
            obj.Name = "Test";
            obj.age = 8;
            obj.marks = 35;
            obj.ClassDetails(mark);

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
            obj1.ClassDetails(mark);
            mark = obj1.marks;
            Console.ReadLine();

           SealedClass obj2 = new SealedClass();
            obj2.Name = "Test";
            BankAccounts obj3 = new BankAccounts();
            obj3.yourmoney = 1000;

            OuterClass obj4 = new OuterClass();
            obj4.OuterValue = "Outer value";
            InsideClass obj5 = new InsideClass();
            obj5.OuterValue = "Inner Value";
        }
    }

}
