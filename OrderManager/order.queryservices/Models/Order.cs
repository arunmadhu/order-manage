using System;
using System.Collections.Generic;

namespace order.queryservices
{
    public partial class Order
    {
        public Order()
        {
            OrderAddress = new HashSet<OrderAddress>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public int TotalPrice { get; set; }

        public ICollection<OrderAddress> OrderAddress { get; set; }
    }
}
