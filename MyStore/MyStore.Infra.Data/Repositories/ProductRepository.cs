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
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.Include(x=>x.Category).ToList();
        }
    }
}
