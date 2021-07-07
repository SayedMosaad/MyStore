using Microsoft.EntityFrameworkCore;
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
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.ID == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public Category Find(int id)
        {
            return _db.Categories.Include(x=>x.Products).FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
