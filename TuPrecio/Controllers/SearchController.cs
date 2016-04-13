using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuPrecio.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string criteria)
        {
            
            return View();
        }
    }
}