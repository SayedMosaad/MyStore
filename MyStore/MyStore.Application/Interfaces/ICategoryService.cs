using MyStore.Application.ViewModels;
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
    }
}
