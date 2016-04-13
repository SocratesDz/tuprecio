using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TuPrecio.Models.Contexts
{
    public class TuPrecioInitializer : DropCreateDatabaseAlways<TuPrecioDbContext>
    {
        protected override void Seed(TuPrecioDbContext context)
        {
            base.Seed(context);
        }
    }
}