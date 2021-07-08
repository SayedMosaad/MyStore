using MyStore.Application.Interfaces;
using MyStore.Application.ViewModels;
using MyStore.Domain.Commands;
using MyStore.Domain.Core.Bus;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Models;
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
        private readonly IMediatorHandler _bus;

        public ProductService(IProductRepository productRepository, IMediatorHandler bus)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Create(ProductViewModel model)
        {
            var CreateProductCommand = new CreateProductCommand(model.Name, model.Description, model.ImageUrl, model.Price, model.CategoryId);
            _bus.SendCommand(CreateProductCommand);
        }

        public void Delete(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public void Edit(ProductViewModel model)
        {
            var EditCommand = new EditProductCommand(model.Id,model.Name, model.Description, model.ImageUrl, model.Price, model.CategoryId);
            _bus.SendCommand(EditCommand);
        }

        public Product Find(int id)
        {
            return _productRepository.Find(id);
        }

        public ProductViewModel GetAllProducts()
        {
            return new ProductViewModel
            {
                Products = _productRepository.GetAllProducts()
            };
        }

        public ProductViewModel Getproducts(int id)
        {
            return new ProductViewModel
            {
                Products = _productRepository.Getproducts(id)
            };
        }
    }
}
