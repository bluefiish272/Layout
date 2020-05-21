using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.WareHouse;
using Core.Helper;

namespace Management.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly string viewPath = "../Warehouse/Category/";
        private static readonly string index = $"{viewPath}Index";

        public static List<Category> categories = FakeDataHelper.GetCategories();

        public IActionResult Index()
        {
            return View(index, categories);
        }

        public IActionResult Create()
        {
            return View(viewPath + "Create");
        }

        public IActionResult Edit(Guid uid) 
        {
            var category = categories.FirstOrDefault(c => c.UID == uid);
            return View(viewPath+"Edit", category);
        }

        public IActionResult Add(Category category)
        {
            FakeDataHelper.SetCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Category category)
        {
            FakeDataHelper.SetCategory(category);
            var newCategory = FakeDataHelper.GetCategory(category.UID);
            return View(viewPath + "Edit", newCategory);
        }

        public IActionResult Deactivate(Guid uid)
        {
            var category = FakeDataHelper.GetCategory(uid);
            category.Activation = false;
            FakeDataHelper.SetCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Activate(Guid uid)
        {
            var category = FakeDataHelper.GetCategory(uid);
            category.Activation = true;
            FakeDataHelper.SetCategory(category);
            return RedirectToAction("Index");
        }
    }
}