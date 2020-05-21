using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Layout.Models;
using Microsoft.Extensions.Configuration;
using Layout.Http;
using Core.Helper;

namespace Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            var data = new Call(_config).GetLayouts("Index");
            //var data = FakeDataHelper.GetLayouts("Index");
            return View(data);
        }

        public IActionResult Introduction()
        {
            // 可以透過PatialView提供多種板。
            var data =  new Call(_config).GetTemplateMap();
            return View(data);
        }

        public IActionResult Tabs(string type, int item = 5)
        {
            string viewName = "TopTabs";
            switch (type)
            {
                case "top":
                    viewName = "TopTabs";
                    break;
                case "left":
                    viewName = "LeftTabs";
                    break;
            }
            return View(viewName, new Call(_config).GetTabs());
        }
        public IActionResult Pictures()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Accordion()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
