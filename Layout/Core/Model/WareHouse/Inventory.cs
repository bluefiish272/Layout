using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WareHouse
{
    /// <summary>
    /// 倉庫管理中的庫存
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 料件的UID
        /// </summary>
        public Guid MaterialUid { get; set; }
        /// <summary>
        /// 庫存的類型(先保留)，安全庫存、週期庫存...等那種分類
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 庫存數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
