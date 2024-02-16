using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult Get()
        {
            List<OrderModel> result = OrderService.GetOrders().Result;
            return new JsonResult(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = OrderService.GetById(id);
            return new JsonResult(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderModel order)
        {
            var result = OrderService.Add(order);
            return new JsonResult(result);
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public ActionResult Put([FromBody] OrderModel order)
        {
            var result = OrderService.Update(order);
            return new JsonResult(result);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = OrderService.Delete(id);
            return new JsonResult(result);
        }
    }
}
