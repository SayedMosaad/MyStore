using MyStore.Application.ViewModels;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel GetAllCategory();
        void Create(CategoryViewModel categoryViewModel);
        void Delete(int id);
        Category Find(int id);
        void Edit(CategoryViewModel categoryViewModel);
    }
}
