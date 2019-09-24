using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class OrderAddress
    {
        public int OrderId { get; set; }

        public List<string> AddressIds { get; set; }
    }
}
