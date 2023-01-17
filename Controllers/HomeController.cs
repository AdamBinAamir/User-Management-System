using Microsoft.AspNetCore.Mvc;
using SummerProgramDemo.Models;
using System.Diagnostics;
using SummerProgramDemo.Models.Entities;
using SummerProgramDemo.Areas.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SummerProgramDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            var test = new Skill();
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            //ViewData["MyName"] = "My Name is Ayesha";
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}