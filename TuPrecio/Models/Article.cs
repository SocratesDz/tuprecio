using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuPrecio.Models
{
    public class Article
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public DateTime? InsertDate { get; set; }
        public String Comment { get; set; }

        public virtual Location Location { get; set; }
        public virtual UnitType Unit { get; set; }
        public virtual Currency Currency { get; set; }
    }
}