using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Team
    {
        public string Category { get; set; } //隸屬的分類 (先保留)
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //要改成enum，因為狀態是固定的定義
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }

    public static class MyExtension 
    {
        private static List<Module> modules = new List<Module>()
        {
            new Module()
            {
                Category = "1",
                Uid = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
                ParentUid = null,
                Id = 0,
                Name = "文件管理",
                Description = "文件管理中心",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "1",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
                Id = 1,
                Name = "SA文件",
                Description = "SA文件",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "1",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
                Id = 2,
                Name = "SD文件",
                Description = "SD文件",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.Parse("AC761785-ED42-11CE-DACB-00BDD0057645"),
                ParentUid = null,
                Id = 0,
                Name = "庫存管理",
                Description = "庫存管理系統",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("AC761785-ED42-11CE-DACB-00BDD0057645"),
                Id = 1,
                Name = "調撥單",
                Description = "庫存管理系統子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("AC761785-ED42-11CE-DACB-00BDD0057645"),
                Id = 2,
                Name = "料號管理",
                Description = "庫存管理系統子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("AC761785-ED42-11CE-DACB-00BDD0057645"),
                Id = 3,
                Name = "庫存管理",
                Description = "庫存管理系統子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.Parse("0Y78F098-HY78-9ZD3-HH0Y-8PG35E2C0071"),
                ParentUid = null,
                Id = 4,
                Name = "團隊管理",
                Description = "團隊管理模組",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("0Y78F098-HY78-9ZD3-HH0Y-8PG35E2C0071"),
                Id = 5,
                Name = "團隊資料",
                Description = "團隊管理模組子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("0Y78F098-HY78-9ZD3-HH0Y-8PG35E2C0071"),
                Id = 6,
                Name = "人員管理",
                Description = "團隊管理模組子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Module()
            {
                Category = "0",
                Uid = Guid.NewGuid(),
                ParentUid = Guid.Parse("0Y78F098-HY78-9ZD3-HH0Y-8PG35E2C0071"),
                Id = 7,
                Name = "形象網頁",
                Description = "團隊管理模組子項目",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            }
        };

        public static List<Module> GetModule(this Team team)
        {
            // 這只是範例，到時候要用GUID之類的比較適當
            var teamId = team.Id.ToString();
            return modules.Where(m => m.Category == teamId).ToList();
        }
    }
}
