namespace ProiectII.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProiectII.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProiectII.Models.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProiectII.Models.ShopDBContext";
        }

        protected override void Seed(ProiectII.Models.ShopDBContext context)
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

            context.Products.AddOrUpdate(x => x.Id,
                new Product { Id = 1, Name = "Iphone", Description = "256Gb", Price = 3200, Stock = 123, Image = "lol" }
            );
        }
    }
}
