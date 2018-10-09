using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Impl
{
    public class ProductService : IProductService
    {

        private readonly IOrderService _orderService;
        private readonly IProductService _productRepository;

        public ProductService(IOrderService orderService, IProductService productRepository)
        {
            _orderService = orderService;
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
            return _productRepository.GetAllProducts().ToList();
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

        public Product UpdateProduct(Order updateOrder)
        {
            return _productRepository.UpdateProduct(updateOrder);
        }
    }
}