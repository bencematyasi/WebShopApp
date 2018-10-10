using System.Collections.Generic;
using System.IO;
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
            if (prod == null)
            {
                throw new InvalidDataException("Input is null!");
            }
            if (prod.Id != 0)
            {
                throw new InvalidDataException("Cannot add a product with existing id!");
            }
            if (string.IsNullOrEmpty(prod.Name))
            {
                throw new InvalidDataException("Cannot add a product without name!");
            }
            if (string.IsNullOrEmpty(prod.Category))
            {
                throw new InvalidDataException("Cannot add a product without category");
            }
            if(string.IsNullOrEmpty(prod.Description))
            {
                throw new InvalidDataException("Cannot add a product without description");
            }
            if (string.IsNullOrEmpty(prod.Image))
            {
                throw new InvalidDataException("Cannot add a product without picture");
            }
            if(prod.Price == 0.0f)
            {
                throw new InvalidDataException("Cannot add a product without price");
            }
            if(prod.Stock < 0)
            {
                throw new InvalidDataException("Cannot add a product without stock");
            }

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

        public Product NewProduct(string name, string category, double price, int stock, string description, int size, string image)
        {

            var prod = new Product()
            {
                Name = name,
                Category = category,
                Price = price,
                Stock = stock,
                Description = description,
                Size = size,
                Image = image
            };

            return prod;
        }

        public Product UpdateProduct(Product updateProduct)
        {
            return _productRepository.UpdateProduct(updateProduct);
        }
    }
}