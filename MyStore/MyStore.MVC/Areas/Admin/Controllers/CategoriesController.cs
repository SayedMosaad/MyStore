using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }
    }
}
