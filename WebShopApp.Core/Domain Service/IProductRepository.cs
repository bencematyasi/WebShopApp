using System.Collections;
using System.Collections.Generic;
using WebShopApp.Core.Entity;

namespace WebShopApp.Core.Domain_Service
{
    public interface IProductRepository
    {
        //CREATE
        Product CreatProduct(Product product);
        //READ
        IEnumerable<Product> ReadAllProduct();
        //UPDATE
        Product UpdateProduct(Product updateProduct);
        //DELETE
        Product DeleteProduct(Product deleteProduct);
        //Get the product by id
        Product GetProductById(int id);
    }
}