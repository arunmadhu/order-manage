using System;
using System.Collections.Generic;

namespace order.queryservices
{
    public partial class Address
    {
        public Address()
        {
            OrderAddress = new HashSet<OrderAddress>();
        }

        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }

        public ICollection<OrderAddress> OrderAddress { get; set; }
    }
}
