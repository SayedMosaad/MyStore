using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        Product Find(int id);
        IEnumerable<Product> Getproducts(int id);
    }
}
