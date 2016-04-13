﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TuPrecio.Models.Contexts
{
    public class TuPrecioDbContext : DbContext
    {
        public TuPrecioDbContext() 
            : base("AzureDatabaseTestConnection")
        {
            Database.SetInitializer<TuPrecioDbContext>(new TuPrecioInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}