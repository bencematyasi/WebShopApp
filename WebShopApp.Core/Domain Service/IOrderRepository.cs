
using System.Collections.Generic;
using System.Threading;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Domain_Service
{
    public interface IOrderRepository
    {    
        //CREATE
        Order CreateOrder(Order order);
        //READ
        IEnumerable<Order> ReadAllOrder(Filter filter);
        Order ReadOrderByIdIncludeProduct(int id);
        Order GetOrderById(int id);
        int Count();
        //UPDATE
        Order UpdateOrder(Order updateOrder);
        //DELETE
        Order DeleteOrder(int id);
        
    }
}