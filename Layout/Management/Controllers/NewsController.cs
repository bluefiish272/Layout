using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.Models;
using Core;

namespace Management.Controllers
{
    public class NewsController : BaseController
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        private static List<News> tempNews = new List<News>()
        {
            new News()
            {
                Uid = Guid.NewGuid(),
                Id = 0,
                Category = "A",
                Title = "【員工福利】3M相關系列產品大特價",
                Content = "3M相關系列產品大特價，地點：2樓202會議室，時間：2020/05/14-2020/05/25，有興趣的同仁可以前往參觀選購。",
                Creator = "總務大人",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new News()
            {
                Uid = Guid.NewGuid(),
                Id = 1,
                Category = "A",
                Title = "【OO專案】配合OO專案而採購的相關設備已入庫",
                Content = "OO專案的採購單<BUY20201111>的設備已經確認後存入倉庫",
                Creator = "總務大人",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new News()
            {
                Uid = Guid.NewGuid(),
                Id = 2,
                Category = "A",
                Title = "【好康道相報】OOO廠商帶來粽子數箱，放在301會議室",
                Content = "因應端午佳節，OOO廠商來訪，並帶來數箱粽子，放在301會議室，歡迎取用。",
                Creator = "康樂",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new News()
            {
                Uid = Guid.NewGuid(),
                Id = 3,
                Category = "A",
                Title = "【總務公告】第三季停車費繳納",
                Content = "已經進入第三季囉！請向總務繳交停車費用。",
                Creator = "總務大人",
                CreateDate = DateTime.Now.AddMonths(2).AddDays(3),
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new News()
            {
                Uid = Guid.NewGuid(),
                Id = 4,
                Category = "A",
                Title = "【失物招領】3樓女廁發現Apple手機一支，請同仁確認。",
                Content = "3樓女廁第二間，發現Apple手機一支(iPhoneXS)，請遺失的同仁到一樓櫃台領取，謝謝",
                Creator = "櫃台小弟",
                CreateDate = DateTime.Now.AddDays(2),
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            }
        };

        public IActionResult Index(int teamNo)
        {
            ViewData["MemberName"] = base.IsLogin ? "登入者" : null;
            return View(tempNews);
        }

        public IActionResult News(int id)
        { 
            ViewData["MemberName"] = base.IsLogin ? "登入者" : null;
            return View(tempNews.FirstOrDefault(n => n.Id == id));

        }
    }
}
