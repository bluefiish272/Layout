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
    public class BaseController : Controller
    {
        public bool IsLogin { get; set; }
    }
}
