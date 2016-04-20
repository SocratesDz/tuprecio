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
        public ActionResult Create(ArticleViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using(var db = new TuPrecioDbContext())
                    {
                        var newArticle = new Article();
                        newArticle.Comment = model.Comment;
                        newArticle.Currency = db.Currencies.FirstOrDefault();
                        newArticle.InsertDate = DateTime.Today;
                        newArticle.Name = model.Name;
                        newArticle.Price = Convert.ToDecimal(model.Price);
                        newArticle.Unit = db.UnitTypes.FirstOrDefault();

                        var newLocation = db.Locations.Where(l => l.Name == model.BusinnesName 
                                                                && l.Latitude == model.Latitude 
                                                                && l.Longitude == l.Longitude).FirstOrDefault();
                        if(newLocation == null)
                        {
                            newLocation = new Location();
                            newLocation.Name = model.BusinnesName;
                            newLocation.Latitude = model.Latitude;
                            newLocation.Longitude = model.Longitude;
                            newLocation.Address = model.Address;
                            newLocation.Articles = new List<Article> { newArticle };
                            db.Locations.Add(newLocation);
                        }

                        newArticle.Location = new List<Location> { newLocation };
                        db.Articles.Add(newArticle);
                        db.SaveChanges();
                    }

                    return RedirectToAction("Create", "Article");
                }
                
                return View(model);
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
