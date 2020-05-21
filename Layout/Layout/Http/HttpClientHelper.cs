﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Core;

namespace Layout.Http
{
    /* 現在這個是嘗試實作，需要想辦法重新處理：
     * ref:在 ASP.NET Core 中使用 IHttpClientFactory 發出 HTTP 要求
     * https://docs.microsoft.com/zh-tw/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
     * https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.1#generated-clients 
     * https://medium.com/itsoktomakemistakes/net-core-%E6%8A%8A-httpclient-%E8%BD%89%E7%94%A8-ihttpclientfactory-%E5%B0%8F%E5%9C%B0%E9%9B%B7-89c05580319c
     */

    public class HttpClientHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private HttpClient Client { get; set; }

        public HttpClientHelper(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._clientFactory = clientFactory;
        }

        private void InitialClient()
        {
            Client = _clientFactory.CreateClient();
            Client.BaseAddress = new Uri($"{_configuration.GetValue<string>("ApiBaseUrl")}");
            //// GitHub API versioning
            //Client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //// GitHub requires a user-agent
            //Client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
        }


        public T GetAsync<T>(string url) where T : class
        {
            url = "/Product/Test";
            T data = default(T);

            InitialClient();
            var task = Client.GetAsync(url);
            var result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = result.Content.ReadAsStringAsync().Result;
                data = new SerializeHelper().Read<T>(json);
            }
            return data;
        }

        //public IEnumerable<T> GetAsync<T>(string url) where T : IEnumerable<T>
        //{
        //    url = "/Product/Get";

        //    IEnumerable<T> data = Enumerable.Empty<T>();

        //    InitialClient();
        //    var task = Client.GetAsync(url);
        //    var result = task.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var json = result.Content.ReadAsStringAsync().Result;
        //        data = new SerializeHelper().ReadAsIEnumerable<T>(json).ToList();
        //    }
        //    return data;
        //}
    }
}
