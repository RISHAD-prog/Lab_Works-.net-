using BLL.DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Lab1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryService.AllCategory());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryDTO category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryService.Create(category);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {

                return View();
            }
        }
    }
}