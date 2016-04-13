using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuPrecio.Models;
using TuPrecio.Models.Contexts;

namespace TuPrecio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var db = new TuPrecioDbContext())
            {
                var location = new Location
                {
                    Id = 1,
                    Name = "Súper Lama",
                    Address = "Av. Charles de Gaulle, Esq. Aut. San Isidro",
                    Latitude = "18.488745",
                    Longitude = "-69.8259379"
                };

                db.Locations.Add(location);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}