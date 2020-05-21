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
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ID = "AB12345",
                    Name = "鋼彈一號",
                    Category = "A",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/dc2051aa1903397db7388c47d3a91316.jpg"
                },
                new Product()
                {
                    ID = "AB10523",
                    Name = "鋼彈二號",
                    Category = "A",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/dc2051aa1903397db7388c47d3a91316.jpg"
                },
                 new Product()
                {
                    ID = "AB31522",
                    Name = "鋼彈三號",
                    Category = "B",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/dc2051aa1903397db7388c47d3a91316.jpg"
                },
                  new Product()
                {
                    ID = "TH02665",
                    Name = "鋼彈四號",
                    Category = "B",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/efeb07cc2a66726f3fe8353797b0c1a3.jpg"
                },
                  new Product()
                {
                    ID = "EI102337",
                    Name = "鋼彈P號",
                    Category = "C",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/efeb07cc2a66726f3fe8353797b0c1a3.jpg"
                },
                 new Product()
                {
                    ID = "TR03522",
                    Name = "鋼彈AA號",
                    Category = "B",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/e36dfe617c5479e4c38ec416ec3f4a39.jpg"
                },
                  new Product()
                {
                    ID = "TH88552",
                    Name = "鋼彈OO號",
                    Category = "B",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/efeb07cc2a66726f3fe8353797b0c1a3.jpg"
                },
                  new Product()
                {
                    ID = "TH02665",
                    Name = "鋼彈四號",
                    Category = "C",
                    Description = "這支鋼彈很帥唷!",
                    ImagePath = "~/image/efeb07cc2a66726f3fe8353797b0c1a3.jpg"
                }
            };

        [HttpGet("Get")]
        public List<Product> Get(string category = null)
        {
            new SerializeHelper().ToJsonString(products);

            if (string.IsNullOrEmpty(category))
            {
                return products;
            }
            return products.Where(p => p.Category == category).ToList();
        }
    }
}