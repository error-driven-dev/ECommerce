using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Components
{
    public class NavViewComponent: ViewComponent
    {
        private IProductRepository _repository;

        public NavViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repository.Products.Select(p => p.Category).Distinct().OrderBy(s =>s));
        }

    }
}
