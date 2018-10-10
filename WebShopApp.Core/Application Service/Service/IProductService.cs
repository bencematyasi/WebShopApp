using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Application_Service.Service
{
    public interface IProductService
    {
        //create Product
        Product NewProduct(string name, string category, double price, int stock, string description, int size, string image);
        Product CreateProduct(Product prod);
        //read Product
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        //update Product
        Product UpdateProduct(Product updateProduct);
        //delete Product
        Product DeleteProduct(int id);
    }
}