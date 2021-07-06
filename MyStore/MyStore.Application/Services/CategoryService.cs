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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(CategoryViewModel categoryViewModel)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel GetAllCategory()
        {
            return new CategoryViewModel
            {
                Categories=_categoryRepository.GetCategories()
            };
        }
    }
}
