using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class OrderInfo
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public int TotalPrice { get; set; }

        public IList<AddressInfo> Addresses { get; set; }
    }
}
