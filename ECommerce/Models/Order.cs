using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ShippingAddressId { get; set; }
        public ShippingAddress CustomerInfo { get; set; }
        public List<Product> OrderItems { get; set; } = new List<Product>();
    }
}
