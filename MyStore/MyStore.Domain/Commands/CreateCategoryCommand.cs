using MyStore.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Commands
{
    public class CreateCategoryCommand:CategoryCommand
    {
        public CreateCategoryCommand(string name,string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
