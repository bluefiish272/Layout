using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core;
using Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Layout.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : Controller
    {
        private static string setting = "";

        [HttpGet("Get")]
        public string Get()
        {
            return setting;
        }

        [HttpGet("GetLayouts")]
        public List<Core.Layout> GetLayouts(string location)
        {
            return FakeDataHelper.GetLayouts(location);
        }

        [HttpPost("SetLayouts")]
        public HttpStatusCode SetLayouts([FromQuery]string location, [FromBody]List<Core.Layout> layouts)
        {
            try
            {
                FakeDataHelper.SetLayouts(location, layouts);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // 記得寫LOG
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}