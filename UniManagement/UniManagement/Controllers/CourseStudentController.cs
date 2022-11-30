using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniManagement.Db;

namespace UniManagement.Controllers
{
    public class CourseStudentController : Controller
    {
        // GET: CourseStudent
        public ActionResult Index()
        {
           
            return View();
        }
        
        [HttpGet]
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(Student students)
        {
            UniversityEntities uni = new UniversityEntities();
             
            uni.Students.Add(students);
            uni.SaveChanges();
           
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public ActionResult Courses()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Courses(Cours courses)
        {
            UniversityEntities uni = new UniversityEntities();

            uni.Courses.Add(courses);
            uni.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}