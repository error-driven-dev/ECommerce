using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Infrastructure;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }


        public IActionResult AddToCart(int prodId)
        {
            Cart cartContents = GetCart();
            var lineItem = cartContents.LineItems.FirstOrDefault(p => p.Item.ProductId == prodId);
            if (lineItem == null)
            {
                var requestedProduct = _repository.Products.FirstOrDefault(p => p.ProductId == prodId);
                cartContents.LineItems.Add(new LineItem
                {
                    Item = requestedProduct,
                    Quantity = 1
                });
            }
            else
            {
                lineItem.Quantity++;
            }
            SaveCart(cartContents);
            
            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartContents = GetCart();
            
            return View("ShoppingCart", cartContents);
        }

        public IActionResult RemoveItem(int prodId)
        {

            Cart cartContents = GetCart();
            LineItem unwantedItem = cartContents.LineItems.FirstOrDefault(p => p.Item.ProductId == prodId);
            if (unwantedItem.Quantity > 1)
            {
                unwantedItem.Quantity--;}
            else
            {
                cartContents.LineItems.Remove(unwantedItem);
            }

            SaveCart(cartContents);
            return RedirectToAction("ViewCart");


        }

   
//        [HttpPost]
//        public IActionResult Checkout1GetCustAddress(ShippingAddress shipping)
//        {
            //save shipping address to DB and get ID
            
            //get cart contents and start staging order object
//            Cart cartContents = GetCart();
//            var newOrder = new Order()
//            {
//                
//                ShippingAddressId = shipaddressid,
//                OrderItems = cartContents.LineItems
//            };
//            //add Oder object to  DB table
//            //get order Id
//
//            //Show payment form
//         }

        public Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        public void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
