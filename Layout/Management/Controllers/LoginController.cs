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
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        private static List<Member> validMembers = new List<Member>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string account, string password)
        {
            base.IsLogin = true;
            var validMember = validMembers.FirstOrDefault(m => m.Account == account && m.Password == password);
            return RedirectToAction("Index","Teams");
        }

        public IActionResult SignUp(Member member) 
        {
            validMembers.Add(member);
            return RedirectToAction("Index", "Login");
        }
    }
}
