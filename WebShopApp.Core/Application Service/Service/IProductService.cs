using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Service
{
    public interface IProductService
    {
        //create Product
        Product NewProduct(Product product);

        //read Product
        List<Product> GetAllProducts();
        Product GetProductById(int id);

        //update Product
        Product UpdateProduct(Order updateOrder);

        //delete Product
        void DeleteProduct(int id);
    }
}