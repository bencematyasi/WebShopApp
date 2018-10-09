using System.Collections.Generic;
using System.Linq;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Impl
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        //public Order FindOrderByIdIncludeProduct(int id)
        //{
        //    return _orderRepository.FindOrderByIdIncludeProduct(id);
        //}

        public List<Order> GetAllOrders()
        {
            return _orderRepository.ReadAllOrder().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public Order NewOrder(Order order)
        {
            return _orderRepository.CreateOrder(order);
        }

        public Order UpdateOrder(Order updateOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}