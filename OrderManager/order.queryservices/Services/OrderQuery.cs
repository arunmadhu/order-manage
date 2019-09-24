using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace order.queryservices.Services
{
    public class OrderQuery : IOrderQuery
    {
        private readonly queryDbContext queryContext;

        public OrderQuery(queryDbContext _context)
        {
            queryContext = _context;
        }

        public IList<Address> GetAllAddresses()
        {
            return queryContext.Address.ToList();
        }

        public IList<Order> GetAllOrders()
        {
            return queryContext.Order.Include(od => od.OrderAddress).ThenInclude(x => x.Address).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return queryContext.Order.Include(od => od.OrderAddress).ThenInclude(x => x.Address).FirstOrDefault(od => od.Id == orderId);
        }
    }
}
