using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuPrecio.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public String Symbol { get; set; }
        public String Name { get; set; }
    }
}