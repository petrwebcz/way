using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        { 
            return View();
        }

        [Route("/Web/Room/{inviteHash}")]
        public IActionResult Index(string inviteHash)
        {
            ViewBag.InviteUrl = String.Concat(Constants.BASE_INVITE_URL, inviteHash);
            ViewBag.InviteHash = inviteHash;
            return View();
        }
    }
}
