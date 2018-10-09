using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Domain_Service
{
    public interface IOrderRepository
    {    
        //CREATE
        Order CreateOrder(Order order);
        //READ
        IEnumerable<Order> ReadAllOrder();
        Order ReadOrderByIdIncludeProduct(int id);
        Order GetOrderById(int id);
        //UPDATE
        Order UpdateOrder(Order updateOrder);
        //DELETE
        Order DeleteOrder(int id);
        
    }
}