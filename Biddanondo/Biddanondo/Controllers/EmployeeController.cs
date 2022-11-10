using Biddanondo.Dbs;
using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Biddanondo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var product = Session["Login"].ToString();
            var json = new JavaScriptSerializer().Deserialize<List<EmployeeModel>>(product);
            ViewBag.Product = json;
            return View(ItemRepo.Get());
        }       
               
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepo.Create(employee);
                    TempData["msg"] = "User Added";
                    return View(employee);
                }
                else
                {

                    return View(employee);
                }
            }
            catch
            {
                return View(employee);

            }
        }
       
        [HttpGet]
        public ActionResult Order()
        {
            var product = Session["Login"].ToString();
            var json = new JavaScriptSerializer().Deserialize<List<EmployeeModel>>(product);
            
            var collect = Session["Collect"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(collect);
            ViewBag.collections = products;
            return View(json);
        }
        [HttpPost]
        public ActionResult Order(EmployeeModel employee)
        {                      
                var json = Session["Collect"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(json);                
                foreach (var item in products)
                {                   
                        ItemRepo.Create(new ItemModel()
                        {
                            RestaurantId = item.Id,
                            RestaurantName = item.RestaurantName,
                            Location = item.Location,
                            EmployeeId = employee.Id,
                            EmployeeName = employee.EmployeeName,

                        });                                       
                }
            Session["Collect"] = null;                
            TempData["msg"] = "Order Accepted";
            return RedirectToAction("Index");

        }
    }

    
}