using Microsoft.EntityFrameworkCore;
using WebShopApp.Core.Entity;

namespace WebShopApp.Infrastructure.Data
{
    public class WebShopAppContext : DbContext
    {
        public WebShopAppContext(DbContextOptions<WebShopAppContext> opt) 
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product);

                
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}