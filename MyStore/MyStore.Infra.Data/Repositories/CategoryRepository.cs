using MyStore.Domain.Interfaces;
using MyStore.Domain.Models;
using MyStore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
