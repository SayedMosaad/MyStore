using MyStore.Application.Interfaces;
using MyStore.Application.ViewModels;
using MyStore.Domain.Commands;
using MyStore.Domain.Core.Bus;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Models;

namespace MyStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _bus;

        public CategoryService(ICategoryRepository categoryRepository, IMediatorHandler bus )
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
        }
        public void Create(CategoryViewModel categoryViewModel)
        {
            var createCategoryCommand = new CreateCategoryCommand(
                categoryViewModel.Name,
                categoryViewModel.ImageUrl
                );
            _bus.SendCommand(createCategoryCommand);
        }

        public void Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public void Edit(CategoryViewModel categoryViewModel)
        {
            var EditCategoryCommand = new EditCategoryCommand(
                categoryViewModel.Id,
                categoryViewModel.Name,
                categoryViewModel.ImageUrl
                );
            _bus.SendCommand(EditCategoryCommand);
        }

        public Category Find(int id)
        {
            return _categoryRepository.Find(id);
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
