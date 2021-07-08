using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using MyStore.Application.ViewModels;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment hosting;
        private readonly IToastNotification _toastNotification;

        public ProductsController(IProductService productService,ICategoryService categoryService, IWebHostEnvironment hosting,IToastNotification toastNotification)
        {
            _productService = productService;
            _categoryService = categoryService;
            this.hosting = hosting;
            _toastNotification = toastNotification;
        }
        
        public IActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel
            {
                Categories = _categoryService.GetAllCategory().Categories.ToList()
            };
            return View(model);
        }

        public ActionResult Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var filename = UploadFile(model.Image) ?? string.Empty;
                if(filename==null)
                {
                    ModelState.AddModelError("", "Please Select image");
                    model.Categories = _categoryService.GetAllCategory().Categories.ToList();
                    return View(model);
                }
                model.ImageUrl = filename;
                _productService.Create(model);
                _toastNotification.AddSuccessToastMessage("Product inserted");
                return RedirectToAction(nameof(Index));
            }
            model.Categories = _categoryService.GetAllCategory().Categories.ToList();
            _toastNotification.AddErrorToastMessage("Something Went wrong");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productService.Find(id);
            if(product==null)
            {
                return NotFound();
            }
            var model = new ProductViewModel()
            {
                Id=product.ID,
                Name=product.Name,
                Description=product.Description,
                ImageUrl=product.ImageUrl,
                CategoryId=product.CategoryId,
                Categories=_categoryService.GetAllCategory().Categories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var filename = UploadFile(model.Image, model.ImageUrl);
                if(filename==null)
                {
                    ModelState.AddModelError("", "Please Select an Image");
                    return View(model);
                }
                model.ImageUrl = filename;
                _productService.Edit(model);
                _toastNotification.AddSuccessToastMessage("updated!");
                return RedirectToAction(nameof(Index));
            }
            model.Categories = _categoryService.GetAllCategory().Categories.ToList();
            _toastNotification.AddErrorToastMessage("Something Went wrong");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }


        string UploadFile(IFormFile File)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/products");
                string FileName = File.FileName;
                string uniqueFileName = Guid.NewGuid() + "_" + FileName;
                string FullPath = Path.Combine(Uploads, uniqueFileName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
                return uniqueFileName;
            }
            return null;
        }

        string UploadFile(IFormFile File, string ImageUrl)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/products");
                string FileName = File.FileName;
                string uniqueFileName = Guid.NewGuid() + "_" + FileName;
                string NewPath = Path.Combine(Uploads, uniqueFileName);
                string OldFileName = ImageUrl;
                string OldPath = Path.Combine(Uploads, OldFileName);
                if (NewPath != OldPath)
                {
                    System.IO.File.Delete(OldPath);
                    File.CopyTo(new FileStream(NewPath, FileMode.Create));
                }
                return uniqueFileName;
            }
            return ImageUrl;
        }
    }
}
