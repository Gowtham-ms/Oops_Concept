using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Repository.Services
{

    // low level class
    public class EmployeeServices : IEmployee
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee> {
           new Employee() { EmployeeID=1, EmployeeName ="James", Address="India"},
           new Employee() { EmployeeID=2, EmployeeName ="Alex", Address="USA"},
           new Employee() { EmployeeID=3, EmployeeName ="Mani", Address="USA"}
           };
        }
    }
}