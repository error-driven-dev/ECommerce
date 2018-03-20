using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class PaymentInfoViewModel
    {
        [Display(Name="Payment Method")]
        public PaymentMethods PaymentMethod { get; set; }
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$")]
        public string CardNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/YY}")]
        [UIHint("MM/YY")]
        public DateTime ExpireDate { get; set; }
        [Display(GroupName = "Billing Name and Address")]
        public AddressViewModel BillingAddress { get; set; }
    }

    public enum PaymentMethods
    {
        Discover,
        [Display(Name = "Master Card")]MasterCard,
        Visa,
    }
}
