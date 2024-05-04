using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly MySchoolEntities db = new MySchoolEntities();
        // GET: Teacher

        [HttpGet]
        public ActionResult ShowTeacher()
        {
            // Database table values from models
            var TeachersList = db.Teachers.ToList();
            // Passing this controller values we got from models to view
            return View(TeachersList);
        }

        [HttpGet]
        // Create New Record
        public ActionResult Create()
        {
            return View();
        }

        // to insert in database
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();
            string Message = "Teacher created successfully";
            ViewBag.Message = Message;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Entry(teacher).State = EntityState.Deleted;
            db.SaveChanges();
            //db.Teachers.Remove(teacher);
            //db.SaveChanges();
            return View("ShowTeacher");
        }
    }
}