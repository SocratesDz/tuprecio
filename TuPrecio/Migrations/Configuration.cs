namespace TuPrecio.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TuPrecio.Models.Contexts.TuPrecioDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TuPrecio.Models.Contexts.TuPrecioDbContext";

        }

        protected override void Seed(TuPrecio.Models.Contexts.TuPrecioDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var location = new Location
            {
                Name = "Súper Lama",
                Address = "Av. Charles de Gaulle, Esq. Aut. San Isidro",
                Latitude = "18.488745",
                Longitude = "-69.8259379"
            };
            

            var unitType = new UnitType {
                Name = "unidad"
            };
            
            var currency = new Currency
            {
                Name = "peso",
                Code = "DOP",
                Symbol = "$"
            };
            

            var locationList = new List<Location>();
            locationList.Add(location);

            var article1 = new Article
            {
                Name = "Aceite de Soya Crisol (128 oz.)",
                Price = 349.95M,
                InsertDate = new DateTime(2016, 1, 18),
                Location = locationList,
                Unit = unitType,
                Currency = currency,
                Comment = null
            };

            
            location.Articles = new List<Article>();
            location.Articles.Add(article1);

            context.UnitTypes.AddOrUpdate(u => u.Name, unitType);
            context.SaveChanges();

            context.Currencies.AddOrUpdate(c => c.Name, currency);
            context.SaveChanges();

            context.Locations.AddOrUpdate(l => l.Name, location);
            context.SaveChanges();

            context.Articles.AddOrUpdate(a => a.Name, article1);
            context.SaveChanges();

        }
    }
}
