using MyStore.Domain.Core.Commands;
using MyStore.Domain.Models;
using System.Collections.Generic;


namespace MyStore.Domain.Commands
{
    public class ProductCommand:Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
