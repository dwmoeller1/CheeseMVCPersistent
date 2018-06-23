using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        public SelectList Categories { get; set; }
        public int SelectedCategoryId { get; set; }

        public AddCheeseViewModel(CheeseDbContext context) {
            this.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
        }

        public AddCheeseViewModel() { }

        public void CreateNew(CheeseDbContext context)
        {
            CheeseCategory category = context.Categories.Single(ctgry => ctgry.Id == SelectedCategoryId);
            Cheese cheese = new Cheese
            {
                Name = this.Name,
                Category = category,
                Description = this.Description
            };
            context.Cheeses.Add(cheese);
            context.SaveChanges();
        }
    }
}
