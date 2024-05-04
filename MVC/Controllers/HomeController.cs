using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Name , Address, Age
            // Pass values from controller to view 
            ViewBag.KeyName = "ViewBag Value";
            //dynamic object and you can change based on your database logic

            //Both view data and view bag is temporary and exists only for the current request 

            // Pass values from controller to view 
            ViewData["Message"] = "Gowtham";
            // it is used to convey the information to the user

            // if my message is string and I can use viewbag.message ="value" this string value will be taken as key
            // viewdata it will take that string message as value 

            // send values from controller to another contoller and also to your view 
            TempData["Message"] = "Temp Data from Index action";
            // Pass values from one action to another action


            // We can use anywhere in our application
            Session["UserID"] = "Session value from Index action";
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}