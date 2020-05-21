using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WareHouse
{
    /// <summary>
    /// 倉庫管理中的分類
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 唯一值
        /// </summary>
        public Guid UID { get; set; }
        /// <summary>
        /// 編碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 啟用狀態
        /// </summary>
        public bool Activation { get; set; } 
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
