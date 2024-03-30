using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass_InterfaceSession

{
    //Class, Abstract class, Interface

    // Abstract Class
    //public class Office
    //{
    //    public void EmployeeDetails()
    //    {
    //        Console.WriteLine("Save and fetching the employee details");
    //    }
    //    public void Information()
    //    {
    //        Console.WriteLine("Intime and outtime , DOB, Address");
    //    }
    //}
    public class Trainee : AbstractOffice
    {
        public override void Salary()
        {
            Console.WriteLine("");
        }

        public override void Work()
        {
            throw new NotImplementedException();
        }
    }
    public class TL : AbstractOffice
    {

        public override void Salary()
        {
            throw new NotImplementedException();
        }

        public override void Work()
        {
            throw new NotImplementedException();
        }

    }
    public class Manager : AbstractOffice, IFireoptions
    {
        public override void Salary()
        {
            throw new NotImplementedException();
        }

        public override void Work()
        {
            throw new NotImplementedException();
        }
        public void FireEmployee()
        {
            Console.WriteLine("Fire The Trainee");
        }
    }

    // When to use Abstract class -> In complete class
    public abstract class AbstractOffice
    {
        //Non abstract methods 
        public void EmployeeDetails()
        {
            Console.WriteLine("Save and fetching the employee details");
        }
        public void Information()
        {
            Console.WriteLine("Intime and outtime , DOB, Address");
        }
        //Abstract methods
        public abstract void Salary();
        public abstract void Work();

    }
    interface IFireoptions
    {
        void FireEmployee();
    }
}
// Fire an employee 
// Class and Interface
// Interface
