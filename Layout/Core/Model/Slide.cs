using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Slide
    {
        /// <summary>
        /// 圖片版還是文字版
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 圖片，若有圖片則忽略Content的文字
        /// </summary>
        public string ImagePath { get; set; }
        public string ColorStyle { get; set; }
        /// <summary>
        /// <para> white 或 #ffffff</para>
        /// <para> rgba(red值, green值, blue值, alpha值) => rgba(255, 0, 0, 0.6) → 不透明度 60% 紅色</para>
        /// <para> hsla(hue值, saturation值, lightness值, alpha值) => hsla(240, 0%, 50%, 0.6) → 不透明度 60% 中亮灰色</para>
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// 客製化顯示的文字
        /// </summary>
        public string Text { get; set; }
    }
}
