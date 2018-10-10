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
        public ActionResult<Order> Post([FromBody] Order order)
        {
            if (string.IsNullOrEmpty(order.Address))
            {
                return BadRequest("An Address required for placing an order!");
            }
            if (string.IsNullOrEmpty(order.Country))
            {
                return BadRequest("A Country required for placing an order!");
            }
            if (string.IsNullOrEmpty(order.FirstName))
            {
                return BadRequest("Your First Name required for placing an order!");
            }
            if (string.IsNullOrEmpty(order.LastName))
            {
                return BadRequest("Your Last Name required for placing an order!");
            }
            if (order.ZipCode == 0)
            {
                return BadRequest("A Zipcode required for placing an order!");
            }
            if (order.Quantity == 0)
            {
                return BadRequest("Quantity must be greater then 0 (Obviously...)!");
            }
            return _orderService.CreateOrder(order);
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