using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core.WareHouse
{
    /// <summary>
    /// 倉庫管理中的庫存紀錄，存入、取出、調撥等紀錄
    /// </summary>
    public class InventoryLog
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 單號，異動的依據
        /// </summary>
        public string FormNo { get; set; }
        /// <summary>
        /// 料件的UID
        /// </summary>
        public Guid MaterialUid { get; set; }
        /// <summary>
        /// 異動的動作類型
        /// </summary>
        public Action Action { get; set; }
        /// <summary>
        /// 庫存數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum Action
    {
        /// <summary>
        /// 入庫
        /// </summary>
        StockIn,
        /// <summary>
        /// 出庫
        /// </summary>
        StockOut
    }

    public enum Transfer
    {
        /// <summary>
        /// 合成
        /// </summary>
        Composite,
        /// <summary>
        /// 分解
        /// </summary>
        BreakDown,
        /// <summary>
        /// 入倉
        /// </summary>
        StockIn,
        /// <summary>
        /// 出倉
        /// </summary>
        StockOut
    }
}
