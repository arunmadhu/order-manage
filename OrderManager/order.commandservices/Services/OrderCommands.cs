using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace order.commandservices.Services
{
    public class OrderCommands : IOrderCommands
    {
        private readonly commandDbContext commandContext;

        public OrderCommands(commandDbContext _context)
        {
            commandContext = _context;
        }

        public void UpdateOrder(int orderId, List<string> addressIds)
        {
            var order = commandContext.Order.Where(od => od.Id == orderId).Include(od => od.OrderAddress).FirstOrDefault();

            //Delete all the addresses mapped to this order first.

            commandContext.OrderAddress.RemoveRange(order.OrderAddress);
            commandContext.SaveChanges();

            foreach (string ad in addressIds)
            {
                if(!string.IsNullOrEmpty(ad))
                     order.OrderAddress.Add(new OrderAddress { OrderId = orderId, AddressId = Convert.ToInt32(ad) });
            }

            commandContext.Order.Update(order);
            commandContext.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            commandContext.Order.Add(order);
            commandContext.SaveChanges();
        }

        public void SaveAddress(Address address)
        {
            commandContext.Address.Add(address);
            commandContext.SaveChanges();
        }
    }
}
