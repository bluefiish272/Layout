using Core;
using Core.Helper;
using Management.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Management.Controllers
{
    public class SettingController : Controller
    {
        private readonly ILogger<SettingController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public SettingController(ILogger<SettingController> logger, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._clientFactory = clientFactory;
        }

        public static List<SelectListItem> layoutTemplates = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "輪播圖", Value = "Slide" },
                new SelectListItem() { Text = "圖文各半", Value = "Introduction" },
                new SelectListItem() { Text = "頁籤在上", Value = "TopTabs" },
                new SelectListItem() { Text = "頁籤在左", Value = "LeftTabs" },
                new SelectListItem() { Text = "三張圖", Value = "ThreeItems" },
                new SelectListItem() { Text = "九宮格", Value = "NineItems" },
                new SelectListItem() { Text = "商品展示", Value = "Production" },
                new SelectListItem() { Text = "聯絡頁", Value = "Contact" }
            };

        public IActionResult Index()
        {
            //var layouts = FakeDataHelper.GetLayouts();
            string url = "Setting/GetLayouts";
            var layouts = new HttpClientHelper(_clientFactory, _configuration).GetAsyncAsIEnumerable<Layout>(url).ToList();
            return View(layouts);
        }

        public IActionResult EditWebSetting(string location)
        {
            //var layouts = FakeDataHelper.GetLayouts(location);
            string url = "Setting/GetLayouts";
            var param = new Dictionary<string, string> { { "location", location } };
            var layouts = new HttpClientHelper(_clientFactory, _configuration).GetAsyncAsIEnumerable<Layout>(url, param.First()).ToList();
            Dictionary<string, string> formats = new Dictionary<string, string>();
            var templates = layouts.Select(l => l.Template).Distinct().ToList();
            foreach (var item in templates)
            {
                formats.Add(item, GetContentFormat(item));
            }
            return View((layouts, layoutTemplates, formats));
        }

        public IActionResult CreateWebSetting()
        {
            // 這邊先讓設定可以成功，如果可以的話，希望可以有多的說明去描述版面的優勢
            return View(layoutTemplates);
        }

        public IActionResult SetWebSetting(string location, List<Core.Layout> layouts)
        {
            int i = 0;
            foreach (var item in layouts)
            {
                item.Location = location;
                item.Order = i;
                i++;
            }
            string url = "Setting/SetLayouts";
            Dictionary<string, string> queryString = new Dictionary<string, string>() { { "location", location } };
            
            new HttpClientHelper(_clientFactory, _configuration).Post(url, queryString.First(), layouts );

            //FakeDataHelper.SetLayouts(location, layouts);
            return RedirectToAction("Index");
        }

        public string GetContentFormat(string template)
        {
            switch (template)
            {
                case "Introduction":
                    return "{\"Text\":\"內文\",\"ImagePath\":\"~/image/f3106968b6a2455e0409b3db5919fc8a.jpg\"}";
                case "TopTabs":
                case "LeftTabs":
                    return "[{\"Title\":\"頁籤標題一\",\"Content\":\"頁籤內容一\"},{\"Title\":\"頁籤標題二\",\"Content\":\"頁籤內容二\"},{\"Title\":\"頁籤標題三\",\"Content\":\"頁籤內容三\"},{\"Title\":\"頁籤標題四\",\"Content\":\"頁籤內容四\"},{\"Title\":\"頁籤標題五\",\"Content\":\"頁籤內容五\"}]";
                case "ThreeItems":
                    return "[{\"ID\":\"編號\",\"Name\":\"名稱\",\"Category\":\"分類\",\"Description\":\"描述(副標題)\",\"ImagePath\":\"~/image/dc2051aa1903397db7388c47d3a91316.jpg\"},{\"ID\":\"編號2\",\"Name\":\"名稱2\",\"Category\":\"分類\",\"Description\":\"描述2\",\"ImagePath\":\"~/image/9fdd8336895db58e54e6c066d6c3f68e.jpg\"},{\"ID\":\"編號3\",\"Name\":\"名稱3\",\"Category\":\"分類\",\"Description\":\"描述(副標)3\",\"ImagePath\":\"~/image/e36dfe617c5479e4c38ec416ec3f4a39.jpg\"}]";
                default:
                    return default(string);
            }
        }
    }
}