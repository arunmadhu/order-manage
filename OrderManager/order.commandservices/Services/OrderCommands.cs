using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace order.commandservices.Services
{
    public class OrderCommands : IOrderCommands
    {
        private readonly commandDbContext commandContext;

        public OrderCommands(commandDbContext _context)
        {
            commandContext = _context;
        }

        public IList<Order> GetAllOrders()
        {
            return commandContext.Order.ToList();
        }
    }
}
