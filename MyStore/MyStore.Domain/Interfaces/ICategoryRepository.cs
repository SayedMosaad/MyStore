using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        Category Find(int id);
    }
}
