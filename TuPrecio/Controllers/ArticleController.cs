using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuPrecio.Models;
using TuPrecio.Models.Contexts;
using TuPrecio.Models.ViewModels;

namespace TuPrecio.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(int id)
        {
            Article article = null;
            using(var db = new TuPrecioDbContext())
            {
                article = db.Articles.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(article);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            var model = new ArticleViewModel();
            return View(model);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult LocationsQuery(string query)
        {
            if(Request.IsAjaxRequest())
            {
                using(var db = new TuPrecioDbContext())
                {
                    var locations = db.Locations.Where(l => l.Name.Contains(query)).ToList();
                    var locObjs = locations
                        .Select(x => new { Id = x.Id, Name = x.Name });
                    return Json(locObjs, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
