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
    public class HomeController : Controller
    {
        private static List<Tabs> tabs = new List<Tabs>()
        {
            new Tabs()
            {
                Title = "狼人",
                Content = "每晚將殺死一個平民。可以選擇不殺人，當晚為平安夜。狼人可以在白天的任何時候選擇自爆，自爆後該名狼人離場，沒有遺言，其他玩家立即結束髮言，遊戲跳過投票階段，直接進入黑夜。"
            },
            new Tabs()
            {
               Title = "騎士",
                Content = "可在白天自身發言時，查驗任何一位玩家的所屬陣營。若查驗到該玩家為邪惡陣營，該玩家即遭到淘汰並進入夜晚；若查驗到該玩家為正義聯盟，騎士則需以死謝罪並維持原本白天狀態，下位玩家繼續發言或進行投票。騎士使用技能時必須公布底牌。不論查驗結果為何，技能僅可在整局使用一次。"
            }
            ,
            new Tabs()
            {
               Title = "女巫",
                Content = "可在夜晚睜眼時，拯救被邪惡陣營殺死的玩家，或毒殺任何一位玩家，可以選擇該輪不救或不毒。女巫僅在尚未使用解藥時才看得到該晚邪惡陣營殺人資訊；拯救與毒殺僅各有一次機會，且不可同時使用；女巫只有第一晚可以自救。"
            }
            ,
            new Tabs()
            {
               Title = "預言家",
                Content = "可在夜晚睜眼時，查驗任何一位玩家的所屬陣營，但不可查驗已死的玩家，也可以選擇該晚不發動技能，即該晚不查驗任何人。"
            }
            ,
            new Tabs()
            {
               Title = "獵人",
                Content = "可在死亡時帶走（射殺）任何一位玩家（被女巫毒殺以及與狼美人殉情時除外），可選擇不發動技能；但在獵人局中，獵人則不可不發動技能。"
            }
        };

        [HttpGet("GetTabs")]
        public List<Tabs> GetTabs()
        {
            return tabs;
        }
    }
}