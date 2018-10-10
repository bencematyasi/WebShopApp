using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;
using WebShopApp.Infrastructure.Data.Repositories;

namespace WepShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAllOrders();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
           return _orderService.FindOrderByIdIncludeProduct(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderService.CreateOrder(order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}