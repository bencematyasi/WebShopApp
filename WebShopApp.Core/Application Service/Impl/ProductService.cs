using System.Collections.Generic;
using System.Linq;
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


        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.ReadAllProduct().ToList();
        }

        public Product GetProductById(int id)
        {
            Product product = _productRepository.ReadAllProduct().FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Product NewProduct(Product product)
        {
            _productRepository.CreateProduct(product);
            return product;

        }

        public Product UpdateProduct(Order updateOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}