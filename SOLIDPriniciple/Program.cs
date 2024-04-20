using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPriniciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Child class object must be a substitute for parent class object and it should not give an incorrect output
            // here IGenerateReport is parent and HTML Report is child
            //IGenerateReport report = new HTMLReport();
            //report.GenerateReport();
            //ITemplateFormat template = new HTMLReport();
            //template.DesignTemplate();
            //report = new JSONReport();
            //report.GenerateReport();

            ////
            //Fruit objParent = new Apple();
            //objParent.GetColor();


            //Apple _objOrange = new Orange();
            //_objOrange.GetColor();

            PermenantEmployee permenantEmployee = new PermenantEmployee();
            Console.WriteLine("Salary of Perm employee :" + (permenantEmployee.BaseSalary() + permenantEmployee.VariablePay() + permenantEmployee.HRAAllowance()));

            ContractEmployee contractEmployee = new ContractEmployee();
            Console.WriteLine("Salary of ContractEmployee employee :" + (contractEmployee.BaseSalary()  + contractEmployee.HRAAllowance()));

            // DIP

            // here I'm creating an object of a low level method through abstraction and sending this object as a variable to my high level class
            ISendEmail sendEmail = new SendEmail();
            // high level class
            // I'm passing low level class to my high level class
            Organization _org = new Organization(sendEmail); // controller
            _org.AddEmployeeToOrganization();
            Console.ReadLine();

        }
    }
}
