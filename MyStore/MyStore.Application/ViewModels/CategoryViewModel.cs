﻿using Microsoft.AspNetCore.Http;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        //public int Id { get; set; }
        //[Required]
        //public string Name { get; set; }

        //public string ImageUrl { get; set; }

        //[Display(Name ="Category Image")]
        //public IFormFile File { get; set; }
        
    }
    
}