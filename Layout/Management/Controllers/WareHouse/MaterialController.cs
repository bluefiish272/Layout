using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.WareHouse;
using Core.Helper;

namespace Management.Controllers
{
    public class MaterialController : Controller
    {
        private static readonly string viewPath = "../Warehouse/Material/";
        private static readonly string index = $"{viewPath}Index";
        private static List<Material> materials = FakeDataHelper.GetMaterials();

        public IActionResult Index()
        {
            var categoryUids = materials.Select(m => m.CategoryUid).Distinct().ToList();
            Dictionary<Guid, string> categoryMap = FakeDataHelper.GetCategoryMap(categoryUids);
            return View(index, (materials, categoryMap));
        }

        public IActionResult Create()
        {
            return View(viewPath + "Create");
        }

        public IActionResult Edit(Guid uid) 
        {
            var category = materials.FirstOrDefault(c => c.UID == uid);
            return View(viewPath+"Edit", category);
        }

        public IActionResult Add(Material material)
        {
            FakeDataHelper.SetMaterial(material);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Material material)
        {
            FakeDataHelper.SetMaterial(material);
            var newMaterial = FakeDataHelper.GetMaterial(material.UID);
            return View(viewPath + "Edit", newMaterial);
        }
    }
}