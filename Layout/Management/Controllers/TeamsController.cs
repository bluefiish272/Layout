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
    public class TeamsController : BaseController
    {
        private readonly ILogger<TeamsController> _logger;

        public TeamsController(ILogger<TeamsController> logger)
        {
            _logger = logger;
        }

        private static List<Team> tempTeams = new List<Team>()
        {
            new Team()
            {
                Category = "A",
                Uid = Guid.NewGuid(),
                Id = 0,
                Name = "動物之森",
                Description = "一起來當島主吧!",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Team()
            {
                Category = "B",
                Uid = Guid.NewGuid(),
                Id = 1,
                Name = "肝肝工程師",
                Description = "十萬青年十萬肝",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Team()
            {
                Category = "A",
                Uid = Guid.NewGuid(),
                Id = 2,
                Name = "太空戰士七",
                Description = "你是蒂法派，還是艾莉絲派呢?",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Team()
            {
                Category = "B",
                Uid = Guid.NewGuid(),
                Id = 3,
                Name = "業務",
                Description = "百萬年薪不是夢",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            },
            new Team()
            {
                Category = "C",
                Uid = Guid.NewGuid(),
                Id = 4,
                Name = "登山露營",
                Description = "擁抱大自然，我最帥",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            }
            ,
            new Team()
            {
                Category = "C",
                Uid = Guid.NewGuid(),
                Id = 5,
                Name = "自行車",
                Description = "一騎上武嶺",
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                LastUpdateDate = DateTime.Now,
                Status = "A"
            }
        };

        public IActionResult Index(int teamNo)
        {
            ViewData["MemberName"] = base.IsLogin ? "登入者" : null;
            var teams = tempTeams.Take(teamNo).ToList();
            return View(teams);
        }

        public IActionResult Team(int id)
        { 
            var team = tempTeams.FirstOrDefault(t => t.Id == id);
            return View(team);
        }

        public IActionResult AddTeam()
        {
            return RedirectToAction("Index", new { teamNo = 1 });
        }
    }
}
