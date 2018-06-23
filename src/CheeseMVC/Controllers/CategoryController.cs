using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var model = context.Categories.ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.CreateNew(context);
            return Redirect("Index");
        }
    }
}