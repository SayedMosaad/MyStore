using MyStore.Application.ViewModels;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetAllProducts();

        void Create(ProductViewModel model);
        void Edit(ProductViewModel model);
        void Delete(int id);
        Product Find(int id);
        ProductViewModel Getproducts(int id);




    }
}
