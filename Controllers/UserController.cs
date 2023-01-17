using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Info()
        {
            ViewData["firstName"] = "Adam";
            ViewData["lastName"] = "Bin Aamir";
            ViewData["gender"] = new List<string>
            {
                "Male",
                "Female",
                "Other"
            };
            ViewData["university"] = "Air University";
            ViewData["semester"] = new List<string>
            {
                "1st",
                "2nd",
                "3rd",
                "4th",
                "5th",
                "6th",
                "7th",
                "8th"
            };
            ViewData["Hobbies"] = new List<string>
            {
                "Biking",
                "Gaming",
                "Badminton"
            };
            return View();
        }
    }
}