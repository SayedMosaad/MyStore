using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Commands
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(string name, string description, string imageurl,double price, int categoryid)
        {
            Name = name;
            Description = description;
            ImageUrl = imageurl;
            Price = price;
            CategoryId = categoryid;
        }
    }
}
