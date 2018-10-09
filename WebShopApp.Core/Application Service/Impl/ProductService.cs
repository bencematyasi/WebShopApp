using System.Collections.Generic;
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

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
           return _
        }

        public Product GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product NewProduct(Product order)
        {
            throw new System.NotImplementedException();
        }

        public Product UpdateProduct(Order updateOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}