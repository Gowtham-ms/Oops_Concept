using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPriniciple
{
    //SRP - Single responsibility principle
    // there will be only 1 reason to change that means when you're having in the particular class then you can change
    // you can't give another responsibility to that class
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeAge { get; set; }

        public void AddEmployee()
        {
            Console.WriteLine("Add Employee to database");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }

        public void RemoveEmployee()
        {
            Console.WriteLine("Removing employee");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }
        public void UpdateEmployee()
        {
            Console.WriteLine("Updating employee");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }
        public void DeleteEmp()
        {
            Console.WriteLine("Delete employee");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }


    }
    // not following solid priniciples
    public class Login
    {

        //method
        // validation the user if user has mail then I need to pass validation
        // if else if then I will do the work
        // add a mobile number for validation
        // sending mail to the user 
    }

    // it is tightly coupled
    public class GenerateReport
    {
        public string type { get; set; }
        public void GetEmployeeReport()
        {
            type = "JSON";
            if (type == "JSON")
            {
                Console.WriteLine("JSON report");
            }
            else if (type == "HTML")
            {
                Console.WriteLine("HTML report");
            }
            else if (type == "XML")
            {
                Console.WriteLine("XML report");
            }
            else if (type == "string") { }
            // 100s of conditions then you have to 
        }
    }


    // OCP - Open closed principle
    // open for extension and closed for modification
    // you can acheive this ocp by using Interface and abstract class
    // Follow SRP
    // LSP - Extension of OCP
    // Child class must have all the methods from the parent, but it should not throw not implemented exceptions
    // Child doesn't change the signature of the parent class
    public interface IGenerateReport
    {
        string GenerateReport();
    }
    public interface ITemplateFormat
    {
        void DesignTemplate();
        void FetchingHTMLTemplate();
    }

    public class HTMLReport : IGenerateReport, ITemplateFormat 
    {
        public void DesignTemplate()
        {
            Console.WriteLine("Implementing HTML design for HTML report");
        }
        public void FetchingHTMLTemplate() { 
        }
        public string GenerateReport()
        {
            Console.WriteLine("HTML Report");
            return "HTML report";
        }
    }
    public class JSONReport : IGenerateReport
    {
        public string GenerateReport()
        {
            Console.WriteLine("JSON Report");
            return "JSON report";
        }
    }
    public class XMLReport : IGenerateReport
    {
        public string GenerateReport()
        {
            return "XML report";
        }
    }
    public class StringReport : IGenerateReport
    {
        public string GenerateReport()
        {
            return "string report";
        }
    }

    public abstract class Fruit
    {
        public abstract void GetColor();
    }
    public class Apple : Fruit
    {
        public override void GetColor()
        {
            Console.WriteLine("Red Color");
        }
    }
    public class Orange : Fruit
    {
        public override void GetColor()
        {
            Console.WriteLine("Orange Color");
        }
    }


    // Interface Segregation Principle
    // A class must not have to implement any interface which is not required by the class 
    // you should not force the child class to implement parent class methods
    // segregating the interfaces 
    // permenant employee and contract employee
    // extension of LSP 
    interface ISalary
    {
        int BaseSalary();
        int HRAAllowance();
    }
    interface IVariablePay
    {
        int VariablePay();
    }
    // permanetn employee
    public class PermenantEmployee : ISalary, IVariablePay
    {
        public int BaseSalary()
        {
            return 10000;
        }

        public int HRAAllowance()
        {
            return 5000;
        }

        public int VariablePay()
        {
            return 2000;
        }
    }
    public class ContractEmployee : ISalary
    {
        public int BaseSalary()
        {
            return 8000;
        }

        public int HRAAllowance()
        {
            return 4000;
        }
    }
    // ISP should reduce the fat of the interace methods 


    // DIP -High level class doesn't depend on low level class and low level class doesn't depend on high level class and both should be depend on abstraction 
    // High level class
    /// <summary>
    ///  after saving the employee we need to send a mail to the organization
    ///  /// Here we're voilating the DIP
    /// </summary>
    public class Organization {
        // Constructor Injection
        // which means my class is depending on abstraction
        private ISendEmail _sendEmail;

        public Organization(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }
        // it doesn't follow SRP
        public void AddEmployeeToOrganization() {
            Console.WriteLine("Adding employees to Organization");

            _sendEmail.SendMail();
            _sendEmail.SMS();

        }

        public void UpdateEmployeeToOrganization()
        {
            Console.WriteLine("Adding employees to Organization");
            _sendEmail.SendMail();
            _sendEmail.SMS();

        }
        
    }

    public class Email {
        private ISendEmail _sendEmail;
        public Email(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public void SendingNotification() {
            Console.WriteLine("Tomorrow is holiday");
            _sendEmail.SendMail();
        }
    }
    // Abstraction => it has only definition not implementation which means no body 

}
