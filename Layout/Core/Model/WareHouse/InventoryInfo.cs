using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WareHouse
{
    /// <summary>
    /// 倉庫管理中的庫存資訊
    /// </summary>
    public class InventoryInfo
    {
        public Category Category { get; set; }

        public Material Material { get; set; }

        public Inventory Inventory { get; set; }

        public List<InventoryLog> InventoryLogs { get; set; }
    }
}
