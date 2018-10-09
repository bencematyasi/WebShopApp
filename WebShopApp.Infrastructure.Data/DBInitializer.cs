using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(WebShopAppContext ctx)
        {
            ctx.Database.EnsureCreated();
            ctx.Database.EnsureCreated();
            throw new NotImplementedException();


        }
    }
}
