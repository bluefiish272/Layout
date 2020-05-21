using Core.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Helper
{
    public static partial class FakeDataHelper
    {
        private static List<Category> categories =  new List<Category>()
        {
            new Category()
            {
                ID = 1,
                UID = Guid.Parse("2dbb3e64-b247-4508-8c69-7cc9d9786645"),
                Code = "Wire",
                Name = "線材",
                Activation = true,
                Description = "長長的線",
                CreateDate = DateTime.Now.AddMonths(-2),
                Creator = "麵包超人",
                ExpireDate = DateTime.Now.AddYears(10),
                LastUpdateDate = DateTime.Now,
                LastUpdator = "吐司超人"
            }
        };

        public static List<Category> GetCategories(List<Guid> uids = null)
        {
            return (uids == null) ? categories : categories.Where(c => uids.Contains(c.UID)).ToList();
        }

        public static Category GetCategory(Guid? uid = null)
        {
            return categories.FirstOrDefault(c => c.UID == uid);
        }

        public static Dictionary<Guid, string> GetCategoryMap(List<Guid> uids = null)
        {
            if (uids == null)
            {
                return categories.ToDictionary(c => c.UID, c => c.Code);
            }
            else
            {
                return categories.Where(c => uids.Contains(c.UID)).ToDictionary(c => c.UID, c => c.Code);
            }
        }

        public static void SetCategory(Category category)
        {
            if (categories.Exists(c => c.UID == category.UID))
            {
                var target = categories.FirstOrDefault(c => c.UID == category.UID);
                target.Code = category.Code;
                target.Name = category.Name;
                target.Description = category.Description;
                target.LastUpdateDate = DateTime.Now;
                target.LastUpdator = "鱷魚新之助(改)";
            }
            else
            {
                var id = categories.Max(c => c.ID);
                category.ID = id + 1;
                category.UID = Guid.NewGuid();
                category.Creator = "鱷魚新之助";
                category.CreateDate = DateTime.Now;
                category.LastUpdateDate = DateTime.Now;
                category.LastUpdator = "鱷魚新之助";
                categories.Add(category);
            }
        }

        private static List<Material> materials = new List<Material>()
        {
            new Material()
            {
                ID = 1,
                UID = Guid.NewGuid(),
                CategoryUid = Guid.Parse("2dbb3e64-b247-4508-8c69-7cc9d9786645"),
                Property = Property.Finished,
                Number = "W12345678",
                Name = "網路線",
                Specification = "10公尺",
                Description = "Cat6, 10公尺",
                CreateDate = DateTime.Now.AddMonths(-1),
                Creator = "麵包超人",
                ExpireDate = DateTime.Now.AddYears(10),
                LastUpdateDate = DateTime.Now,
                LastUpdator = "吐司超人"
            },
            new Material()
            {
                ID = 2,
                UID = Guid.NewGuid(),
                CategoryUid = Guid.Parse("2dbb3e64-b247-4508-8c69-7cc9d9786645"),
                Property = Property.Finished,
                Number = "W12345678",
                Name = "HDMI",
                Specification = "5公尺",
                Description = "Uptech, 鍍金頭, 5公尺",
                CreateDate = DateTime.Now.AddMonths(-1),
                Creator = "麵包超人",
                ExpireDate = DateTime.Now.AddYears(10),
                LastUpdateDate = DateTime.Now,
                LastUpdator = "吐司超人"
            }
        };

        public static List<Material> GetMaterials(List<Guid> uids = null)
        {
            return (uids == null) ? materials : materials.Where(c => uids.Contains(c.UID)).ToList();
        }

        public static List<Material> GetMaterialsByCategory(Guid categoryUid)
        {
            return materials.Where(c => c.CategoryUid == categoryUid).ToList();
        }

        public static void SetMaterial(Material material)
        {
            if (materials.Exists(m => m.UID == material.UID))
            {
                var target = materials.FirstOrDefault(c => c.UID == material.UID);
                target.CategoryUid = material.CategoryUid;
                target.Property = material.Property;
                target.Number = material.Number;
                target.Name = material.Name;
                target.Specification = material.Specification;
                target.Description = material.Description;
                target.LastUpdateDate = DateTime.Now;
                target.LastUpdator = "鱷魚新之助(改)";
            }
            else
            {
                var id = materials.Max(c => c.ID);
                material.ID = id + 1;
                material.UID = Guid.NewGuid();
                material.Creator = "鱷魚新之助";
                material.CreateDate = DateTime.Now;
                material.LastUpdateDate = DateTime.Now;
                material.LastUpdator = "鱷魚新之助";
                materials.Add(material);
            }
        }

        public static Material GetMaterial(Guid? uid = null)
        {
            return materials.FirstOrDefault(c => c.UID == uid);
        }

        private static List<Inventory> inventories = new List<Inventory>();

        private static List<Inventory> GetInventories(this Material material)
        {
            return new List<Inventory>()
            {
                new Inventory()
                {
                    ID = 1,
                    MaterialUid = material.UID,
                    Type = "庫存類型",
                    Quantity = 10,
                    Location = "中山路倉庫",
                    Description = material.Description,
                }
            };
        }
    }
}
