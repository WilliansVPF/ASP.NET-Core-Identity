using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ASP.NET.Core.Identity.Models;

namespace ASP.NET.Core.Identity.Controllers
{
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