using System;
using System.Collections.Generic;

namespace order.commandservices
{
    public partial class OrderAddress
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public Order Order { get; set; }
    }
}
