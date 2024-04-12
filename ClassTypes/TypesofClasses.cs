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
        static College()
        {
            age++;
        }
    }
    public class SameLogic
    {
        public void AddingTransactionTime()
        {
        }
    }
    public class BankAcount
    {
        public void BankAccountLogic()
        {
            Console.WriteLine("Bank account logic");
            Console.WriteLine("Rewriting logic for adding a transaction time");
            College.AddingTransactionTime();
            Console.WriteLine("Write logic for adding a transaction id after every transaction with _");
        }
    }


    //concrete class // normal class // class
    public class ConcreteClass
    {
        public ConcreteClass()
        {
            //marks = marks++;
        }
        // properties
        public string Name { get; set; }
        public int age { get; set; }
        public int marks { get; set; }
        // variable declaration
        public void ClassDetails(int marks)
        {
            string anotherString = Name;
            int _marks = marks;
        }
    }

    // partial class
    // spliting of a sinlge class to multiple class
    // class should be starts with partial keyword
    // if you working in a class and your colleague also wants to work in the same class so at that time you can use partial class
    // while in run time partial class will be considered as a sinlge class
    // Easily viewable more than 1 person can work in a class there will be no conflicts
    // you are creating a class called information in your class logic you are writing company information
    // your friend also working on the same class but with employee information logic

    partial class Information : ICompany
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }

        public void CompanyDetails()
        {
            throw new NotImplementedException();
        }
        public void GetCompanyDetails()
        {
            Console.WriteLine("Company Details");
        }

        public void GetInvoice()
        {
            throw new NotImplementedException();
        }
    }

    partial class Information : IEmployee
    {
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }

        public void EmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }

    interface ICompany
    {
        void CompanyDetails();
        void GetInvoice();
    }
    interface IEmployee
    {
        void EmployeeDetails();
    }

    // Sealed class
    //  If we are declaring a class as sealed , then it can't be inherited
    // When there is a sealed methoud then you can't override that method
    // we can create object and we can call their properties but you can't inherit
    sealed class SealedClass
    {
        public string Name { get; set; }
    }
    class Parent
    {
        public virtual void ParentProperty() { }
        public virtual void NewProperty() { }
    }
    class Son : Parent
    {
        sealed public override void ParentProperty()
        {

        }
        public override void NewProperty()
        {

        }
    }
    class GrandChild : Son
    {
        public override void ParentProperty()
        {
        }
        public override void NewProperty()
        {

        }
    }

    // bank example
    sealed class BankAccounts
    {
        public int yourmoney { get; set; }
    }
    public class Stranger : BankAccounts
    {
        public void SeeYourMoney()
        {

        }
    }

    // nested class
    // a class inside a class is called as a nested class 
    public class OuterClass {
        public string OuterValue { get; set; }

        public class InsideClass {
            public string OuterValue { get; set; }

        }
    }
}
