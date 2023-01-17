using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SummerProgramDemo.Data;
using SummerProgramDemo.Models;
using SummerProgramDemo.Models.Entities;

namespace SummerProgramDemo.Controllers
{
    public class UserAddressController : Controller
    {
        private UserProfileDbContext _context { get; set; }
        public UserAddressController(UserProfileDbContext context)
            {
                _context = context;
            }

        // GET: UserAddressController
        public ActionResult Index()
        {
            var useraddresses = _context.UserAddresses.ToList();
            return useraddresses != null ?
                View(useraddresses) :
                Problem("Entity set 'SummerProgramDemoContext.User'  is null.");
        }

        // GET: UserAddressController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.UserAddresses.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserAddressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Address,City,Country,UserId")] UserAddress user2)
        {
            if (ModelState.IsValid)
            {
                _context.UserAddresses.Add(user2);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user2);
        }

        // GET: UserAddressController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.UserAddresses.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserAddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Address,City,Country,UserId")] UserAddress user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var auser = _context.UserAddresses.FirstOrDefault(i => i.Id == id);
                auser.Address = user.Address;
                auser.Id = user.Id;
                auser.City = user.City;
                auser.Country = user.Country;
                auser.UserId = user.UserId;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: UserAddressController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.UserAddresses.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserAddressController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAddresses == null)
            {
                return Problem("Entity set 'SummerProgramDemoContext.User'  is null.");
            }
            var user = _context.UserAddresses.FirstOrDefault(m => m.Id == id);
            if (user != null)
            {
                _context.UserAddresses.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.UserAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
