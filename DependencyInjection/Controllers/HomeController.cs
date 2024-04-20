using DependencyInjection.Models;
using DependencyInjection.Repository;
using DependencyInjection.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjection.Controllers
{
    // high level class
    public class HomeController : Controller
    {
        private IEmployee _IEmployee;
        public HomeController(IEmployee IEmployee) //new EmployeeServices(); // we are injecting our dependency in constructor parameter
        {
            _IEmployee = IEmployee;
        }
        public ActionResult Login() { 
            return View();
        }
        public ActionResult Employee()
        {
            List<Employee> listEmployees = new List<Employee>();
            listEmployees = _IEmployee.GetEmployees();
            return View(listEmployees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}