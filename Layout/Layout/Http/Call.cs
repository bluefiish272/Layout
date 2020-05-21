using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Layout.Http
{
    // 有一個草創class: HttpClientHelper，可以嘗試轉移
    public class Call
    {
        private readonly IConfiguration config;
        public Call(IConfiguration configuration)
        {
            this.config = configuration;
        }

        public List<Product> GetProducts() 
        {
            string baseUrl = config.GetValue<string>("ApiBaseUrl");
            var data = new List<Product>();
            using (var client = new HttpClient())
            {
                string url = baseUrl + "Product/Get";
                var task = client.GetAsync(url);
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var product = result.Content.ReadAsStringAsync().Result;
                    data = new SerializeHelper().ReadAsIEnumerable<Product>(product).ToList();
                }
            }
            return data;
        }

        public List<TemplateMap> GetTemplateMap()
        {
            string baseUrl = config.GetValue<string>("ApiBaseUrl");
            var data = new List<TemplateMap>();
            using (var client = new HttpClient())
            {
                string url = baseUrl + "Template/Get";
                var task = client.GetAsync(url);
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var product = result.Content.ReadAsStringAsync().Result;
                    data = new SerializeHelper().ReadAsIEnumerable<TemplateMap>(product).ToList();
                }
            }
            return data;
        }

        public List<Tabs> GetTabs()
        {
            string baseUrl = config.GetValue<string>("ApiBaseUrl");
            var data = new List<Tabs>();
            using (var client = new HttpClient())
            {
                string url = baseUrl + "Home/GetTabs";
                var task = client.GetAsync(url);
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var product = result.Content.ReadAsStringAsync().Result;
                    data = new SerializeHelper().ReadAsIEnumerable<Tabs>(product).ToList();
                }
            }
            return data;
        }

        public List<Core.Layout> GetLayouts(string location)
        {
            string baseUrl = config.GetValue<string>("ApiBaseUrl");
            var data = new List<Core.Layout>();
            using (var client = new HttpClient())
            {
                string url = baseUrl + "Setting/GetLayouts";
                UriBuilder uriBuilder = new UriBuilder(url);
                uriBuilder.Query = $"location={ location }";
                var task = client.GetAsync(uriBuilder.Uri);
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var layouts = result.Content.ReadAsStringAsync().Result;
                    data = new SerializeHelper().ReadAsIEnumerable<Core.Layout>(layouts).ToList();
                }
            }
            return data;
        }
    }
}
