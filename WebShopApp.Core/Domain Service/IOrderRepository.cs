using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Domain_Service
{
    public interface IOrderRepository
    {    
        //CREATE
        Order CreatProduct(Order order);
        //READ
        IEnumerable<Order> ReadAllProduct();
        //UPDATE
        Order UpdateProduct(Order updateOrder);
        //DELETE
        Order DeleteProduct(Order deleteOrder);
        //Get the product by id
        Order GetOrderById(int id);
    }
}