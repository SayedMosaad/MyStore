using MediatR;
using MyStore.Domain.Commands;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyStore.Domain.CommandHandlers
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description=request.Description,
                ImageUrl=request.ImageUrl,
                Price=request.Price,
                CategoryId=request.CategoryId

            };
            _productRepository.AddProduct(product);
            return Task.FromResult(true);
        }
    }

    public class EdirProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public EdirProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Find(request.Id);
            product.Name = request.Name;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            _productRepository.UpdateProduct(product);
            return Task.FromResult(true);
        }
    }
}
