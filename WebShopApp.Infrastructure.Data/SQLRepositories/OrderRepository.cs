using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            return _ctx.Orders.Include(p => p.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public int Count()
        {
            return _ctx.Orders.Count();
        }
        
        public IEnumerable<Order> ReadAllOrder(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Orders;
            }
            
            return _ctx.Orders
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Order ReadOrderByIdIncludeProduct(int id)
        {
            return _ctx.Orders
                .Include(o => o.Product)
                .FirstOrDefault(p => p.Id == id);
        }

        public Order UpdateOrder(Order updateOrder)
        {
            _ctx.Attach(updateOrder).State = EntityState.Modified;
            _ctx.Entry(updateOrder).Reference(o => o.Product).IsModified = true;
            _ctx.SaveChanges();
            return updateOrder;
        }

        public Order FindOrderByIdIncludeProduct(int id)
        {
            return _ctx.Orders.Where(o => o.Id == id).Include(o => o.Product).FirstOrDefault();
        }
    }
}    