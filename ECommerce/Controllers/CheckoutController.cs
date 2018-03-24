using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Infrastructure;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using StackExchange.Redis;
using Order = ECommerce.Models.Order;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Controllers
{
    public class CheckoutController : Controller
    {


        //checkout --> render address form
        //submit address form and save to db, get address Id
        //retreive cart contents and shipping info --> build object. Render review page with payment form
        //submit payment -- get authorization and save to order:confirmed with payment id
        [HttpGet]
        public IActionResult ShipInfo()
        {
            return View("NewAddress");
        }

        [HttpPost]
        public IActionResult ShipInfo(AddressViewModel shipInfo)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("ShipInfo", shipInfo);
                return RedirectToAction("PaymentInfo");
            }
            return View("NewAddress", shipInfo);
        }

        public IActionResult EditShipInfo()
        {
            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo");
            return View("NewAddress", shipInfo);
        }

        [HttpGet]
        public IActionResult PaymentInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentInfo(PaymentInfoViewModel payInfo)
        {
            
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("PaymentInfo", payInfo);
                return RedirectToAction("ReviewOrder");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReviewOrder()
        {
            var cartContents = HttpContext.Session.GetJson<Cart>("Cart");
            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo");
            return View( new ReviewOrderViewModel(){Cart = cartContents, ShipInfo = shipInfo});
        }

        [HttpPost]
        public IActionResult SubmitOrder(Order order)
        {
            //get all the collected pieces and save to DB
            //clear cart 
            return View();
        }

    }
}

