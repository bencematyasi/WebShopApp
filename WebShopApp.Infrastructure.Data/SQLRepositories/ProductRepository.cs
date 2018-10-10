using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;

namespace WebShopApp.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebShopAppContext _ctx;

        public ProductRepository(WebShopAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public Product CreateProduct(Product product)
        {
            _ctx.Attach(product).State = EntityState.Added;
            _ctx.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var prodRemoved = _ctx.Remove(new Product {Id = id}).Entity;
            _ctx.SaveChanges();
            return prodRemoved;
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> ReadAllProduct()
        {
            return _ctx.Products;
        }

        public Product UpdateProduct(Product updateProduct)
        {
            _ctx.Attach(updateProduct).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updateProduct;
        }
    }
}