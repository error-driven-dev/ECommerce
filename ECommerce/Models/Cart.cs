using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Models
{
    public class Cart
    {
        public List<LineItem> LineItems = new List<LineItem>();




    }

    public class LineItem
    {
        public int LineItemId { get; set; }
        public Product Item { get; set; }
        public int? Quantity { get; set; }
  
    }
}
