using System.ComponentModel.DataAnnotations;

namespace Core.WareHouse
{
    /// <summary>
    /// 料件屬性
    /// </summary>
    public enum Property
    {
        // 原料、物料、半成品、成品，
        /// <summary>
        /// 原料
        /// </summary>
        [Display(Name = "原料", Description = "直接材料")]
        RawMaterial,
        /// <summary>
        /// 物料
        /// </summary>
        [Display(Name = "物料", Description = "間接材料")]
        Material,
        /// <summary>
        /// 半成品
        /// </summary>
        [Display(Name = "半成品", Description = "做一半的成品")]
        SemiFinished,
        /// <summary>
        /// 成品
        /// </summary>
        [Display(Name = "成品", Description = "做好的成品")]
        Finished
    }
}
