using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ASP.NET.Core.Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET.Core.Identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}