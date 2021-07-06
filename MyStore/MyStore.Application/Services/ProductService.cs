using MyStore.Application.Interfaces;
using MyStore.Application.ViewModels;
using MyStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductViewModel GetAllProducts()
        {
            return new ProductViewModel
            {
                Products = _productRepository.GetProducts()
            };
        }
    }
}
