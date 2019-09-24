
using System.Collections.Generic;

namespace order.commandservices.Services
{
    public interface IOrderCommands
    {
        void UpdateOrder(int orderId, List<string> addressIds);
        void SaveOrder(Order order);
        void SaveAddress(Address address);
    }
}
