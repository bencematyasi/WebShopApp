using System;
using System.Collections.Generic;
using System.Text;
using WebShopApp.Core.Entity;

namespace WebShopApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(WebShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var product1 = ctx.Products.Add(new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                Stock = 110
            }).Entity;

            var product2 = ctx.Products.Add(new Product()
            {
                Name = "Brown Sock",
                Category = "Men Socks",
                Description = "It's a brown sock, for men.",
                Price = 10,
                Size = 42,
                Stock = 190
            }).Entity;

            var order1 = ctx.Orders.Add(new Order()
            {
                FirstName = "Danny",
                LastName = "Bubu",
                Address = "TestAddress 123A",
                ZipCode = 6700,
                Country = "Bubuland",
                Quantity = 2
            }).Entity;

            //var order2 = ctx.Orders.Add(new Order()
            //{
            //    FirstName = "test",
            //    LastName = "Test",
            //    Address = "TestAddress 41C",
            //    ZipCode = 6750,
            //    Country = "Buumland",
            //    Product =
            //    {
            //        Id = 2
            //    },
            //    Quantity = 21
            //});

            ctx.SaveChanges();
        }
    }
}
