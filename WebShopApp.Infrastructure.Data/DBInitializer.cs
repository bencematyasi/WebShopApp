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



        }
    }
}
