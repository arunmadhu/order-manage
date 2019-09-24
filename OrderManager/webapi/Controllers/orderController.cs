using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order.commandservices.Services;
using order.queryservices.Services;
using webapi.Model;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IOrderCommands commandSerive;
        private readonly IOrderQuery orderService;
        private readonly IMapper mapper;

        public orderController(IOrderCommands _commands, IOrderQuery _orders, IMapper _mapper)
        {
            commandSerive = _commands;
            orderService = _orders;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("getallorders")]
        public IActionResult GetOrders()
        {
            var model = mapper.Map<IList<OrderInfo>>(orderService.GetAllOrders());

            //commandSerive.UpdateOrder(new order.commandservices.Order());

            return Ok(model);
        }

        [HttpGet]
        [Route("getorder/{orderid}")]
        public IActionResult Get(int orderid)
        {
            var model = mapper.Map<OrderInfo>(orderService.GetOrderById(orderid));
            return Ok(model);
        }

        [HttpGet]
        [Route("getalladdress")]
        public IActionResult GetAddress()
        {
            var model = mapper.Map<IList<AddressInfo>>(orderService.GetAllAddresses());
            return Ok(model);
        }

        [HttpGet]
        [Route("getaddressbyorder/{orderid}")]
        public IActionResult GetAddressByOrder(int orderid)
        {
            var address = mapper.Map<IList<AddressInfo>>(orderService.GetAllAddresses());
            var orderAddress = orderService.GetOrderById(orderid).OrderAddress;

            foreach (var ad in address)
            {
                ad.InOrder = orderAddress.Count(od => od.AddressId == ad.AddressId) > 0;
            }
            return Ok(address);
        }

        [HttpPost]
        [Route("saveorderaddress")]
        public IActionResult SaveOrderAddress([FromBody]OrderAddress orderAddress)
        {
            commandSerive.UpdateOrder(orderAddress.OrderId, orderAddress.AddressIds);
            return Ok();
        }

        [HttpPost]
        [Route("saveorder")]
        public IActionResult SaveOrder([FromBody]OrderInfo newOrder)
        {
            commandSerive.SaveOrder(mapper.Map<order.commandservices.Order>(newOrder));
            return Ok();
        }

        [HttpPost]
        [Route("saveaddress")]
        public IActionResult SaveAddress([FromBody]AddressInfo newAddress)
        {
            commandSerive.SaveAddress(mapper.Map<order.commandservices.Address>(newAddress));
            return Ok();
        }
    }
}
