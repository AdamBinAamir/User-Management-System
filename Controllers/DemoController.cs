using Microsoft.AspNetCore.Mvc;

namespace SummerProgramDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
