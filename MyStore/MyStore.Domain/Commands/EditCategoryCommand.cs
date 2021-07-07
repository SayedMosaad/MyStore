using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Commands
{
    public class EditCategoryCommand:CategoryCommand
    {
        public EditCategoryCommand(int id,string name,string imageurl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageurl;
        }
    }
}
