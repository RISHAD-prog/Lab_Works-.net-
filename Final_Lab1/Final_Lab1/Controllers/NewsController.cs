using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Final_Lab1.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View(NewsService.AllNews());
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.getCategory = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsDTO news)
        {
         
            try
            {
                if (ModelState.IsValid)
                {
                    NewsService.Create(new NewsDTO()
                    {
                        Id = news.Id,
                        CategoryId=news.Id,
                        Title=news.Title,
                        Date=news.Date,
                    });
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(NewsService.NewsId(id));
        }
        [HttpPost]
        public ActionResult Edit(NewsDTO news)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NewsService.Update(new NewsDTO()
                    {
                        Id = news.Id,
                        CategoryId = news.CategoryId,
                        Title = news.Title,
                        Date = news.Date,
                    }); 
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            NewsService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}