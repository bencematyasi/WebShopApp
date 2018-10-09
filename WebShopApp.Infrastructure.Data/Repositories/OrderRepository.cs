using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;

namespace WebShopApp.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WebShopAppContext _ctx;

        public OrderRepository(WebShopAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public Order CreateOrder(Order order)
        {
            _ctx.Attach(order).State = EntityState.Added;
            _ctx.SaveChanges();
            return order;
        }

        public Order DeleteOrder(int id)
        {
            var removed = _ctx.Remove(new Order {Id = id}).Entity;
            _ctx.SaveChanges();
            return removed;
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders.Include(o => o.ProductId)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> ReadAllOrder()
        {
            return _ctx.Orders;
        }

        public Order UpdateOrder(Order updateOrder)
        {
            return null;
        }
    }
}