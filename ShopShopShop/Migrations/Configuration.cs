using ShopShopShop.Models;

namespace ShopShopShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopShopShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public DbSet<Product> Products { get; set; }

        protected override void Seed(ShopShopShop.Models.ApplicationDbContext context)
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

            context.Products.AddOrUpdate(
                p => p.Name,
                new Product() { Name = "Chocolate", Price = 4.50m },
                new Product() { Name = "Coffee", Price = 6m },
                new Product() { Name = "Ice Cream", Price = 10m },
                new Product() { Name = "Ham", Price = 7m },
                new Product() { Name = "Cheese", Price = 10m },
                new Product() { Name = "Eggs", Price = 3m },
                new Product() { Name = "Milk", Price = 5.50m },
                new Product() { Name = "Bread", Price = 3.50m },
                new Product() { Name = "Orange", Price = 2m },
                new Product() { Name = "Apple", Price = 1m }
                );

        }
    }
}
