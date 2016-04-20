using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuPrecio.Models
{
    public class Location
    {
        public Location()
        {
            Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}