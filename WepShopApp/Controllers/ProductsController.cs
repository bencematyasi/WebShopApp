using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Entity;

namespace WepShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product.Price == 0)
            {
                return BadRequest("A Price is required for creating a product!");
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                return BadRequest("A Name is required for creating a product!");
            }
            if (product.Stock < 0)
            {
                return BadRequest("You need to have at least 1 item in stock to sell a product");
            }
            if (product.Size < 0 || product.Size >= 55)
            {
                return BadRequest("Size must be between 1 and 55!");
            }
            return _productService.CreateProduct(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put([FromBody] Product updateProduct)
        {
            if (updateProduct.Price == 0)
            {
                return BadRequest("A Price is required for updating a product!");
            }
            if (string.IsNullOrEmpty(updateProduct.Name))
            {
                return BadRequest("A Name is required for updating a product!");
            }
            if (updateProduct.Stock > 0)
            {
                return BadRequest("You need to have at least 1 item in stock to sell a product");
            }
            if (updateProduct.Size < 0 || updateProduct.Size >= 55)
            {
                return BadRequest("Size must be between 1 and 55!");
            }

            return _productService.UpdateProduct(updateProduct);
            

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                
            }
            catch
            {
                return BadRequest("You need to fulfill all orders with this product in order to delete it.");
            }
            return Ok($"Product with Id: {id} is Deleted");
        }
    }
}
