
using System.Collections.Generic;

namespace order.commandservices.Services
{
    public interface IOrderCommands
    {
        IList<Order> GetAllOrders();
    }
}
