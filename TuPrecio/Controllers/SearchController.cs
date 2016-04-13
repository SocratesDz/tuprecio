using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuPrecio.Models;
using TuPrecio.Models.Contexts;

namespace TuPrecio.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string criteria)
        {
            List<Article> articles = new List<Article>();
            using (var db = new TuPrecioDbContext()) {
                articles = db.Articles.Where(a => a.Name.Contains(criteria)).ToList();
            }
            return View(articles);
        }
    }
}