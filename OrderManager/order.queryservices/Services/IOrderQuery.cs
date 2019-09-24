using System;
using System.Collections.Generic;
using System.Text;

namespace order.queryservices.Services
{
    public interface IOrderQuery
    {
        IList<Order> GetAllOrders();

        IList<Address> GetAllAddresses();

        Order GetOrderById(int orderId);
    }
}
