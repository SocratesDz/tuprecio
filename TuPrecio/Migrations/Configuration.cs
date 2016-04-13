namespace TuPrecio.Migrations
{
    using Models;
    using System;
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
                Name = "S�per Lama",
                Address = "Av. Charles de Gaulle, Esq. Aut. San Isidro",
                Latitude = "18.488745",
                Longitude = "-69.8259379"
            };
            context.Locations.Add(location);
            context.SaveChanges();

            var unitType = new UnitType {
                Name = "unidad"
            };
            context.UnitTypes.Add(unitType);
            context.SaveChanges();

            var currency = new Currency
            {
                Name = "peso",
                Code = "DOP",
                Symbol = "$"
            };
            context.Currencies.Add(currency);
            context.SaveChanges();

            var article1 = new Article
            {
                Name = "Aceite de Soya Crisol (128 oz.)",
                Price = 349.95M,
                InsertDate = new DateTime(2016, 1, 18),
                Location = context.Locations.Single(l => l.Name == "S�per Lama"),
                Unit = context.UnitTypes.Single(u => u.Name == "unidad"),
                Currency = context.Currencies.Single(u => u.Symbol == "DOP"),
                Comment = null
            };

            context.Articles.Add(article1);
            context.SaveChanges();
        }
    }
}
