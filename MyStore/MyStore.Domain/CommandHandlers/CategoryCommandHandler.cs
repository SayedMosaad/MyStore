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
    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name=request.Name,
                ImageUrl=request.ImageUrl
            };
            _categoryRepository.AddCategory(category);
            return Task.FromResult(true);
        }
        
    }

    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<bool> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = _categoryRepository.Find(request.Id);
            category.ImageUrl = request.ImageUrl;
            category.Name = request.Name;
            _categoryRepository.EditCategory(category);
            return Task.FromResult(true);
        }

    }
}
