using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using order.queryservices;
using order.queryservices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unittests.Services
{
    public class OrderQueryTest
    {
        private IFixture fixture;
        private Mock<queryDbContext> dbContext;
        private OrderQuery orderQuery;

        [SetUp]
        public void OrderQueryTestSetup()
        {
            fixture = new Fixture();
            dbContext = new Mock<queryDbContext>();

            orderQuery = new OrderQuery(dbContext.Object);
        }

        [Test]
        public void GetAllAddressesTest()
        {
            var data = new List<Address>
            {
                new Address { AddressLine1 = "Test Line1"},
                new Address { AddressLine1 = "Test Line2" }
            }.AsQueryable();

            var addressMock = new Mock<DbSet<Address>>();
            addressMock.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(data.Provider);
            addressMock.As<IQueryable<Address>>().Setup(m => m.Expression).Returns(data.Expression);
            addressMock.As<IQueryable<Address>>().Setup(m => m.ElementType).Returns(data.ElementType);
            addressMock.As<IQueryable<Address>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            dbContext.Setup(x => x.Address).Returns(addressMock.Object);

            var result = orderQuery.GetAllAddresses();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test Line1", result[0].AddressLine1);
        }
    }
}
