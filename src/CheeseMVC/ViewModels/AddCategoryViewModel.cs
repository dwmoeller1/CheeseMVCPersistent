using CheeseMVC.Data;
using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCategoryViewModel
    {
        [Display(Name="Category Name")]
        [Required]
        public string Name { get; set; }

        public void CreateNew(CheeseDbContext context)
        {
            CheeseCategory newCategory = new CheeseCategory { Name = Name };
            context.Categories.Add(newCategory);
            context.SaveChanges();
        }
    }
}
