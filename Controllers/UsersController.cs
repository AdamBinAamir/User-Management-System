using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerProgramDemo.Data;
using SummerProgramDemo.Models;
using SummerProgramDemo.Models.Entities;

namespace SummerProgramDemo.Controllers
{
    public class UsersController : Controller
    {
        private UserProfileDbContext _context { get; set; }
        public UsersController(UserProfileDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = _context.Users
                .Include(i => i.UserNotes)
                .ToList();
            return users != null ?
                        View(users) :
                        Problem("Entity set 'SummerProgramDemoContext.User'  is null.");

        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = _context.Users.FirstOrDefault(m => m.Id == id);
            var user = (from q in _context.Users
                         where q.Id == id
                         select q)
                         .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = _context.Users.FirstOrDefault(i => i.Id == id);
            var user = (from q in _context.Users
                        where q.Id == id
                        select q)
                         .FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //var euser = _context.Users.FirstOrDefault(i => i.Id == id);
                var euser = (from q in _context.Users
                             where q.Id == id
                             select q)
                         .FirstOrDefault(i => i.Id == id);
                euser.Email = user.Email;
                euser.Id = user.Id;
                euser.Name = user.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = _context.Users.FirstOrDefault(m => m.Id == id);
            var user = (from q in _context.Users
                        where q.Id == id
                        select q)
                         .FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var user = _context.Users.FirstOrDefault(m => m.Id == id);
            var user = (from q in _context.Users
                        where q.Id == id
                        select q)
                         .FirstOrDefault(m => m.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
