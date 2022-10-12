using Microsoft.Ajax.Utilities;
using newVaccineform.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newVaccineform.Controllers
{
    public class VaccineRegistrationController : Controller
    {
        // GET: Vaccine
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Registration_Form reg)
        {
            var db = new VaccineEntities3();
            var check=(from b in db.Registration_Form where b.Name==reg.Name && b.Password==reg.Password select b).SingleOrDefault();
            if(check!=null)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration_Form reg)
        {

            if (ModelState.IsValid)
            {
                var dbentity = new VaccineEntities3();

                dbentity.Registration_Form.Add(reg);
                dbentity.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Name = reg.Name;
                ViewBag.Email = reg.Email;
                ViewBag.Date = reg.Date;
                ViewBag.Password = reg.Password;
                ViewBag.Confirm_Password = reg.ConfirmPassword;
                ViewBag.Phone_No = reg.Phone_No;
                ViewBag.Blood_Group = reg.BG;
                ViewBag.Gender = reg.Gender;
                return View(reg);
            }
            
        }
    }
}