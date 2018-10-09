using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Service
{
    public interface IOrderService
    {
        //create Order
        Order NewOrder(string FirstName, string LastName, string Adress, int ZipCode, string Country, Product Product, int Quantity);
        Order CreateOrder(Order order);
        
        //read Order
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
       // Order FindOrderByIdIncludeProduct(int id);

        //update Order
        Order UpdateOrder(Order updateOrder);

        //delete Order
        void DeleteOrder(int id);
    }
}