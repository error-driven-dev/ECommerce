using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ReviewOrderViewModel
    {
        public Cart Cart { get; set; }
        public AddressViewModel ShipInfo { get; set; }
    }
}
