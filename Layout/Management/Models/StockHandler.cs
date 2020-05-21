using Core.WareHouse;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management
{
    public class StockHandler
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        public StockHandler(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._clientFactory = clientFactory;
        }
        public static List<StockViewModel> GetStocks() => stocks;

        public static List<StockViewModel> GetStocks(bool temp)
        {
            // 未來要用的，從API查，然後再轉成StockViewModel
            /* 1. 查API，取得DataModel
             * 2. 將DataModel轉成ViewModel
             */
            var inventoryInfos = GetInventoryInfos();
            var stocks = TransModel(inventoryInfos);
            return stocks;
        }

        public static InventoryInfo TransModel(StockViewModel stock)
        {
            return new InventoryInfo();
        }

        public static List<StockViewModel> TransModel(List<InventoryInfo> inventoryInfo)
        {
            var stock = new List<StockViewModel>();
            return stock;
        }

        private static List<InventoryInfo> GetInventoryInfos(List<Guid> materialsUids = null)
        {
            // 從API/WareHouseController查資料
            return new List<InventoryInfo>();
        }

        public void SetStocks(StockViewModel stock)
        {
            if (stock.ID > 0)
            {
                var old = stocks.FirstOrDefault(s => s.ID == stock.ID);
                old.Category = stock.Category;
                old.Number = stock.Number;
                old.Name = stock.Name;
                old.Specification = stock.Specification;
                old.Location = stock.Location;
                old.Description = stock.Description;
                old.Quantity = stock.Quantity;
                old.LastUpdateDate = DateTime.Now;
                old.LastUpdator = old.LastUpdator + "改";
            }
            else
            {
                var maxId = stocks.Max(s => s.ID);
                stock.ID = maxId + 1;
                stock.Creator = "建立人";
                stock.CreateDate = DateTime.Now;
                stock.LastUpdator = "建立人";
                stock.LastUpdateDate = DateTime.Now;
                stock.ExpireDate = DateTime.Now.AddMonths(1);
                stocks.Add(stock);
            }
        }

        private static List<StockViewModel> stocks = new List<StockViewModel>()
        {
            new StockViewModel()
            {
                ID=1,
                Category="蔬菜",
                Number="OOX",
                Name="青花椰",
                Specification = "小朵",
                Location="冰箱",
                Description="5/16買的",
                Quantity = 2,
                Creator = "建立人",
                CreateDate = DateTime.Now,
                LastUpdator = "建立人",
                LastUpdateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1)
            },
            new StockViewModel()
            {
                ID=2,
                Category="蔬菜",
                Number="O1OX",
                Name="芹菜",
                Specification = "小把",
                Location="冰箱",
                Description="5/16買的",
                Quantity = 2,
                Creator = "建立人",
                CreateDate = DateTime.Now,
                LastUpdator = "建立人",
                LastUpdateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1)
            },
            new StockViewModel()
            {
                ID=3,
                Category="豆製品",
                Number="OOX2",
                Name="五香豆干",
                Specification = "厚的",
                Location="冰箱",
                Description="5/12買的",
                Quantity = 20,
                Creator = "建立人",
                CreateDate = DateTime.Now,
                LastUpdator = "建立人",
                LastUpdateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1)
            },
            new StockViewModel()
            {
                ID=4,
                Category="豆製品",
                Number="OO21",
                Name="五香豆干",
                Specification = "薄的",
                Location="冰箱",
                Description="5/12買的",
                Quantity = 10,
                Creator = "建立人",
                CreateDate = DateTime.Now,
                LastUpdator = "建立人",
                LastUpdateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1)
            },
            new StockViewModel()
            {
                ID=4,
                Category="藥品",
                Number="9527",
                Name="痠痛貼布",
                Specification = "綠色的",
                Location="三層櫃上層",
                Description="4/17購入",
                Quantity = 10,
                Creator = "建立人",
                CreateDate = DateTime.Now,
                LastUpdator = "建立人",
                LastUpdateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1)
            }
        };
    }
}
