using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using MyStore.Application.Services;
using MyStore.Domain.Models;
using MyStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;

namespace MyStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment hosting;
        private readonly IToastNotification _toastNotification;

        public CategoriesController(ICategoryService categoryService,IWebHostEnvironment hosting, IToastNotification toastNotification)
        {
            _categoryService = categoryService;
            this.hosting = hosting;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {

            
            if (ModelState.IsValid)
            {
                //var filename = UploadFile(model.Image) ?? string.Empty;
                //if (filename == string.Empty)
                //{
                //    ModelState.AddModelError("Image Error", "Please Select an Image");
                //    return View(model);
                //}
                //model.ImageUrl = filename;
                _categoryService.Create(model);
                _toastNotification.AddSuccessToastMessage("Category Inserted succesfuly");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Something Went wrong");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Category = _categoryService.Find(id);
            if(Category==null)
            {
                return NotFound();
            }
             var model = new CategoryViewModel()
             {
                 Id=Category.ID,
                 Name=Category.Name,
                 ImageUrl=Category.ImageUrl
             };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var fileName = UploadFile(model.Image, model.ImageUrl);
                model.ImageUrl = fileName;
                _categoryService.Edit(model);
                _toastNotification.AddSuccessToastMessage("Updated!");
                return RedirectToAction(nameof(Index));


            }
            _toastNotification.AddErrorToastMessage("Something Went wrong");
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }

        public ActionResult Upload(CategoryViewModel model)
        {
            var files = Request.Form.Files;
            var images = new List<string>();
            foreach (var file in files)
            {
                string FileDic = "images/categories";
                string filepath = Path.Combine(hosting.WebRootPath, FileDic);
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                var uniquefilename = Guid.NewGuid() + "_" + file.FileName;
                filepath = Path.Combine(filepath, uniquefilename);
                using FileStream fs = System.IO.File.Create(filepath);
                file.CopyTo(fs);
                images.Add("images/categories/" + uniquefilename);
            }
            return Json(images);
            
        }






        string UploadFile(IFormFile File)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/categories");
                string FileName = File.FileName;
                string uniqueFileName = Guid.NewGuid()+"_" + FileName;
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
                string Uploads = Path.Combine(hosting.WebRootPath, "images/categories");
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
