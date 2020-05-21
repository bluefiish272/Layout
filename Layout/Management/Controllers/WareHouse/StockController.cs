using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.WareHouse;
using Core.Helper;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Management.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public StockController(ILogger<StockController> logger, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._clientFactory = clientFactory;
        }

        private static readonly string viewPath = "../Warehouse/Stock/";
        private static readonly string index = $"{viewPath}Index";
        private static readonly string edit = $"{viewPath}Edit";
        private static List<StockViewModel> stocks = StockHandler.GetStocks();

        public IActionResult Index()
        {
            return View(index, stocks);
        }

        public IActionResult Index2()
        {
            return View($"{viewPath}Index2", stocks);
        }

        public IActionResult Create()
        {
            return View(viewPath + "Create");
        }

        public IActionResult Edit(int id) 
        {
            var stock = stocks.FirstOrDefault(s => s.ID == id);
            return View(edit, stock);
        }

        public IActionResult Add(StockViewModel stock)
        {
            //FakeDataHelper.SetMaterial(stock);
            new StockHandler(_clientFactory, _configuration).SetStocks(stock);
            return RedirectToAction("Index");
        }

        public IActionResult Update(StockViewModel stock)
        {
            //FakeDataHelper.SetMaterial(material);
            //var newMaterial = FakeDataHelper.GetMaterial(material.UID);
            new StockHandler(_clientFactory, _configuration).SetStocks(stock);
            var newStock = StockHandler.GetStocks().First(s => s.ID == stock.ID);
            return View(edit, newStock);
        }
    }
}