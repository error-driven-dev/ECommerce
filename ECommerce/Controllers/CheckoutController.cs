using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Prerendering;

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
        public IActionResult CustInfo()
        {
            return View("NewAddress");
        }

        [HttpPost]
        public IActionResult CustInfo(AddressViewModel custInfo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PaymentInfo");
            }
            return View("NewAddress");
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
                return RedirectToAction("ReviewOrder");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReviewOrder()
        {
            return View();
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

