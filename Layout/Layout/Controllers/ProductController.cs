using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Layout.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Core;

namespace Layout.Controllers
{
   
    public class ProductController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string category = null)
        {
            if (string.IsNullOrEmpty(category))
            {
                return View(GetProducts());
            }
            return View(GetProducts().Where(p => p.Category == category).ToList());
        }

        private List<Product> GetProducts()
        {
            return new Call(_config).GetProducts();
            //return _httpService.Call<List<Product>>("/Product/Get");
        }
    }
}