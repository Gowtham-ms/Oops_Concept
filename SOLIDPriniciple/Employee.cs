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

        public void AddEmployee() {
            Console.WriteLine("Add Employee to database");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }

        public void RemoveEmployee() { Console.WriteLine("Removing employee");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }
        public void UpdateEmployee() { 
            Console.WriteLine("Updating employee");
            GenerateReport gr = new GenerateReport();
            gr.GetEmployeeReport();
        }
        public void DeleteEmp() { 
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
    public interface IGenerateReport {
        string GenerateReport();
    }
    public class HTMLReport : IGenerateReport
    {
        public string GenerateReport()
        {
            return "HTML report";
        }
    }
    public class JSONReport : IGenerateReport
    {
        public string GenerateReport()
        {
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

}
