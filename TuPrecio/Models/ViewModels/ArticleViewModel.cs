using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuPrecio.Models.ViewModels
{
    public class ArticleViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string BusinnesName { get; set; }
    }
}