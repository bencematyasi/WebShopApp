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
                .HasOne(p => p.ProductId);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}