using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        
        //Products in a specific category 
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);

        }

        ////Specific product details
        //[HttpGet("{id}")]
        //public ActionResult<IEnumerable<Product>> GetProducts(int id)
        //{
        //    return Ok(_productRepository.GetProducts(id));
        //}

        //[HttpGet("GetProductById/{Id}")]
        //public ActionResult<Product> GetProductById(int id)
        //{
        //    return Ok(_productRepository.FindById(id));
        //}

    }
}
