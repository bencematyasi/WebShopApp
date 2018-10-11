using System.Collections.Generic;
using System.IO;
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

        public Order CreateOrder(Order order)
        {
            return _orderRepository.CreateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public Order FindOrderByIdIncludeProduct(int id)
        {
            var order = _orderRepository.ReadOrderByIdIncludeProduct(id);
            return order;
        }

        public List<Order> GetFilteredOrders(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage Must zero or more");
            }
            if(((filter.CurrentPage - 1) * filter.ItemsPrPage) >= _orderRepository.Count())
            {
                throw new InvalidDataException("Index out bounds, CurrentPage is to high");
            }

            return _orderRepository.ReadAllOrder(filter).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.ReadAllOrder(null).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public Order NewOrder(string firstName, string lastName, string address, int zipCode, string country, Product product, int quantity)
        {
            var order = new Order()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                ZipCode = zipCode,
                Country = country,
                Product = product,
                Quantity = quantity
            };

            return order;
        }

        public Order UpdateOrder(Order updateOrder)
        {
            return _orderRepository.UpdateOrder(updateOrder);
        }
    }
}