using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Layout.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : Controller
    {
        private static List<TemplateMap> templateMaps = new List<TemplateMap>()
        {
            new TemplateMap()
            {
                Type = TemplateType.SpaceImageAndText,
                PartialViewName = "../Template/_Introduction_Space",
                Text = @"《鋼彈系列》為富野由悠季自1979年所製作機動戰士鋼彈一作所派生出來的一連串續作、外傳及其他系列的總稱。
                    ガンダム在中國大陸一般譯為高達或敢達、港澳譯為高達，臺灣譯為鋼彈。
                    這個由日本動畫公司日昇之下製作的系列SF動畫作品，對以日本為首的世界全球次文化界產生重大的影響。",
                ImagePath = "~/image/e36dfe617c5479e4c38ec416ec3f4a39.jpg"
            },
            new TemplateMap()
            {
                Type = TemplateType.FullImageAndText,
                PartialViewName = "../Template/_Introduction_Full",
                Text = "當愛情遺落成遺跡 用象形刻劃成回憶 想念幾個世紀 才是刻骨銘心",
                ImagePath = "~/image/9fdd8336895db58e54e6c066d6c3f68e.jpg"
            }
        };

        [HttpGet("Get")]
        public List<TemplateMap> Get(TemplateType? type = null)
        {
            return (type == null) ? templateMaps 
                                  : templateMaps.Where(p => p.Type == type).ToList();
        }
    }
}