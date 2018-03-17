using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
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
        public IActionResult NewAddress()
        {
            return View();
        }

        }
    }

