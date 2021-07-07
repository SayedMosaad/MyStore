using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Commands
{
    public class EditProductCommand:ProductCommand
    {
        public EditProductCommand(int id,string name,string description, string imageurl, double price, int categoryid)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageurl;
            Price = price;
            CategoryId = categoryid;
        }
    }
}
