using Biddanondo.Dbs;
using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Biddanondo.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View(ItemRepo.Get());
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            
                var product = Session["Collect"].ToString();
                var json = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(product);
                ViewBag.session_item = json;
                ViewBag.allemployee = EmployeeRepo.Get();
                return View();
           
        }
        [HttpPost]
        public ActionResult AddEmployee(ItemModel items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemRepo.Create(items);
                    TempData["msg"] = "Employee assigned";
                    return RedirectToAction("Index"); 
                }
                var product = Session["Collect"].ToString();
                var json = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(product);
                ViewBag.session_item = json;
                ViewBag.allemployee = EmployeeRepo.Get();
                return View(items);
            }
            catch
            {
                var product = Session["Collect"].ToString();
                var json = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(product);
                ViewBag.session_item = json;
                ViewBag.allemployee = EmployeeRepo.Get();
                return View(items);

            }
        }
    }
}