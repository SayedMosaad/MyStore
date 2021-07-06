using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        public IActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }
    }
}
