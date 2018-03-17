using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ProductDirectory(string category, int pageNum = 1)
        {
            var dataset = _repository.Products.Where(p=> category == null || p.Category == category);
            var numpages = dataset.Count() / PageSize;
             var products = dataset.OrderBy(p => p.ProductId).Skip((pageNum - 1) * PageSize).Take(PageSize);
            
            return View(new ProductViewModel
            {
                Products = products,
                NumPages = numpages
            });

        }


        
    }


}
