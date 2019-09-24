using AutoFixture;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using order.commandservices.Services;
using order.queryservices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webapi.Controllers;
using webapi.Mapper;
using webapi.Model;

namespace unittests.Controllers
{
    public class OrderControllerTest
    {
        private IFixture fixture;
        private Mock<IOrderCommands> orderCommand;
        private Mock<IOrderQuery> orderQuery;
        private orderController orderapiController;

        [SetUp]
        public void OrderControllerTestSetup()
        {
            fixture = new Fixture();

            orderCommand = new Mock<IOrderCommands>();
            orderQuery = new Mock<IOrderQuery>();

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<OrderProfile>();
            });
            var mapper = config.CreateMapper();

            orderapiController = new orderController(orderCommand.Object,orderQuery.Object,mapper);
        }

        [Test]
        public void GetOrdersTest()
        {
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var orders = fixture.Build<order.queryservices.Order>().CreateMany(2).ToList();
            orderQuery.Setup(x => x.GetAllOrders()).Returns(orders);

            var okResult = orderapiController.GetOrders() as OkObjectResult;
            var orderResult = okResult.Value as List<OrderInfo>;

            Assert.IsNotNull(okResult);
            Assert.IsTrue(orderResult.Count == 2);
        }
    }
}
