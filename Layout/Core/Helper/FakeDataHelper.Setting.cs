using Core.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Helper
{
    public static partial class FakeDataHelper
    {
        // 實際上處理應該有點複雜喔
        // 
        private static List<Layout> layouts = new List<Layout>()
        { 
            new Layout()
            {
                Location = "Index",
                Order = 0,
                Template = "TopTabs",
                Content = "[{\"Title\":\"狼人\",\"Content\":\"每晚將殺死一個平民。可以選擇不殺人，當晚為平安夜。狼人可以在白天的任何時候選擇自爆，自爆後該名狼人離場，沒有遺言，其他玩家立即結束髮言，遊戲跳過投票階段，直接進入黑夜。\"},{\"Title\":\"騎士\",\"Content\":\"可在白天自身發言時，查驗任何一位玩家的所屬陣營。若查驗到該玩家為邪惡陣營，該玩家即遭到淘汰並進入夜晚；若查驗到該玩家為正義聯盟，騎士則需以死謝罪並維持原本白天狀態，下位玩家繼續發言或進行投票。騎士使用技能時必須公布底牌。不論查驗結果為何，技能僅可在整局使用一次。\"},{\"Title\":\"女巫\",\"Content\":\"可在夜晚睜眼時，拯救被邪惡陣營殺死的玩家，或毒殺任何一位玩家，可以選擇該輪不救或不毒。女巫僅在尚未使用解藥時才看得到該晚邪惡陣營殺人資訊；拯救與毒殺僅各有一次機會，且不可同時使用；女巫只有第一晚可以自救。\"},{\"Title\":\"預言家\",\"Content\":\"可在夜晚睜眼時，查驗任何一位玩家的所屬陣營，但不可查驗已死的玩家，也可以選擇該晚不發動技能，即該晚不查驗任何人。\"},{\"Title\":\"獵人\",\"Content\":\"可在死亡時帶走（射殺）任何一位玩家（被女巫毒殺以及與狼美人殉情時除外），可選擇不發動技能；但在獵人局中，獵人則不可不發動技能。\"}]"
            },
            new Layout()
            {
                Location = "Index",
                Order = 1,
                Template = "Introduction",
                Content = "{\"Text\":\"《鋼彈系列》為富野由悠季自1979年所製作機動戰士鋼彈一作所派生出來的一連串續作、外傳及其他系列的總稱。\\r\\n                    ガンダム在中國大陸一般譯為高達或敢達、港澳譯為高達，臺灣譯為鋼彈。\\r\\n                    這個由日本動畫公司日昇之下製作的系列SF動畫作品，對以日本為首的世界全球次文化界產生重大的影響。\",\"ImagePath\":\"~/image/f3106968b6a2455e0409b3db5919fc8a.jpg\"}"
            },
            new Layout()
            {
                Location = "Index",
                Order = 2,
                Template = "ThreeItems",
                Content = "[{\"ID\":\"AB12345\",\"Name\":\"鋼彈一號\",\"Category\":\"A\",\"Description\":\"要不要買阿!\",\"ImagePath\":\"~/image/dc2051aa1903397db7388c47d3a91316.jpg\"},{\"ID\":\"AB10523\",\"Name\":\"沙漠用薩克\",\"Category\":\"C\",\"Description\":\"督嚕督嚕督嚕!\",\"ImagePath\":\"~/image/9fdd8336895db58e54e6c066d6c3f68e.jpg\"},{\"ID\":\"AB31522\",\"Name\":\"鋼彈三號\",\"Category\":\"B\",\"Description\":\"帥嗎? 點我購買\",\"ImagePath\":\"~/image/e36dfe617c5479e4c38ec416ec3f4a39.jpg\"}]"
            }
        };

        public static void SetLayouts(string location, List<Layout> addItems)
        {
            layouts.RemoveAll(l => l.Location == location);
            layouts.AddRange(addItems);
        }

        public static List<Layout> GetLayouts(string location = null)
        {
            return string.IsNullOrEmpty(location) ? layouts : layouts.Where(l => l.Location == location).ToList();
        }

        public static dynamic GetModel(string templateName, string content)
        {
            switch (templateName)
            {
                case "TopTabs":
                    return new SerializeHelper().ReadAsIEnumerable<Tabs>(content);
                case "ThreeItems":
                    return new SerializeHelper().ReadAsIEnumerable<Product>(content);
                case "Introduction":
                    return new SerializeHelper().Read<TemplateMap>(content);
                default:
                    return null;
            }
        }
    }
}
