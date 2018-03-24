using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.ViewModels;

namespace ECommerce.Models
{

    public class Order
    {
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public Address ShippingInfo { get; set; }
        
        public List<Product> OrderItems { get; set; } = new List<Product>();
    }
}
