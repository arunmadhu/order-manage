using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order.commandservices.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IOrderCommands commandSerive;

        public orderController(IOrderCommands _commands)
        {
            commandSerive = _commands;
        }

        // GET: api/order
        [HttpGet]
        public IEnumerable<string> Get()
        {
           var result = commandSerive.GetAllOrders();

            return new string[] { "value1", "value2" };
        }

        // GET: api/order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/order
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
