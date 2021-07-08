using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using MyStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        public IActionResult Getproducts(int id)
        {
            var products = _productService.Getproducts(id);
            return View(products);
        }



        public IActionResult ProductDetails(int id)
        {

            var product = _productService.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };
            
            return View("ProductDetails", model);
        }
    }
}
