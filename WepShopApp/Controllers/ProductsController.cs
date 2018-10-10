using System;
using System.Collections.Generic;
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
        public void Post([FromBody] Product product)
        {
            _productService.CreateProduct(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] Product updateProduct)
        {
            _productService.UpdateProduct(updateProduct);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
