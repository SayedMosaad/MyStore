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
        IEnumerable<Product> GetProducts();
    }
}
