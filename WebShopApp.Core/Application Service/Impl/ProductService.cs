using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Impl
{
    public class ProductService : IProductService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public ProductService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public Product DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public Product CreateProduct(Product prod)
        {
            return _productRepository.CreateProduct(prod);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.ReadAllProduct().ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product NewProduct(string name, string category, double price, int stock, string description, int size)
        {
            var prod = new Product()
            {
                Name = name,
                Category = category,
                Price = price,
                Stock = stock,
                Description = description,
                Size = size
            };

            return prod;
        }

        public Product UpdateProduct(Product updateProduct)
        {
            return _productRepository.UpdateProduct(updateProduct);
        }
    }
}