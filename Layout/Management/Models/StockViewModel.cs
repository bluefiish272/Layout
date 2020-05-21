using System;

namespace Management
{
    public class StockViewModel
    {
        public int ID { get; set; }
        /// <summary>
        /// 庫存的UID
        /// </summary>
        public Guid UID { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public Guid CategoryUid { get; set; }
        /// <summary>
        /// 料號
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 庫存數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 描述、備註
        /// </summary>
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
