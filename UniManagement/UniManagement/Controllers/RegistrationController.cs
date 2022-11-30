using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniManagement.Db;

namespace UniManagement.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PreRegistration()
        {
            UniversityEntities uni = new UniversityEntities();
            var course=uni.Courses.ToList();
            
            return View(course);
        }
        [HttpPost]  
        public ActionResult PreRegistration(int[] course)
        {
            UniversityEntities university = new UniversityEntities();
            foreach (int courseId in course)
            { 
                university.CourseStudents.Add(new CourseStudent()
                {
                    StudentId= 3,
                    CourseId= courseId,
                    Status="Incomplete",
                    Grade="C",
                    Marks=70
                });

            }
            university.SaveChanges();
            return RedirectToAction("PreRegistration", "Registration");
        }
    }
}