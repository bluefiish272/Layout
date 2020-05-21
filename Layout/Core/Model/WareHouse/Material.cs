using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WareHouse
{
    /// <summary>
    /// 倉庫管理中的料件
    /// </summary>
    public class Material
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 類別的UID
        /// </summary>
        public Guid CategoryUid { get; set; }
        /// <summary>
        /// 唯一值
        /// </summary>
        public Guid UID { get; set; }
        /// <summary>
        /// 料件屬性
        /// </summary>
        public Property Property { get; set; }
        /// <summary>
        /// 料號
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
