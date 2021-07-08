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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public Product Find(int id)
        {
            return _db.Products.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products.Include(x=>x.Category).ToList();
        }

        public IEnumerable<Product> Getproducts(int id)
        {
            return _db.Products.Where(x => x.CategoryId == id);
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
