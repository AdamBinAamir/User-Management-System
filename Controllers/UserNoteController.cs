using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SummerProgramDemo.Data;
using SummerProgramDemo.Models.Entities;

namespace SummerProgramDemo.Controllers
{
    public class UserNoteController : Controller
    {
        private readonly UserProfileDbContext _context;

        public UserNoteController(UserProfileDbContext context)
        {
            _context = context;
        }

        // GET: UserNotes
        public async Task<IActionResult> Index()
        {
            var userProfileDbContext = _context.UserNotes.Include(u => u.User);
            return View(await userProfileDbContext.ToListAsync());
        }

        // GET: UserNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserNotes == null)
            {
                return NotFound();
            }

            var userNote = await _context.UserNotes
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userNote == null)
            {
                return NotFound();
            }

            return View(userNote);
        }

        // GET: UserNotes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UserNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Note,UserId")] UserNote userNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userNote.UserId);
            return View(userNote);
        }

        // GET: UserNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserNotes == null)
            {
                return NotFound();
            }

            var userNote = await _context.UserNotes.FindAsync(id);
            if (userNote == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userNote.UserId);
            return View(userNote);
        }

        // POST: UserNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Note,UserId")] UserNote userNote)
        {
            if (id != userNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserNoteExists(userNote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userNote.UserId);
            return View(userNote);
        }

        // GET: UserNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserNotes == null)
            {
                return NotFound();
            }

            var userNote = await _context.UserNotes
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userNote == null)
            {
                return NotFound();
            }

            return View(userNote);
        }

        // POST: UserNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserNotes == null)
            {
                return Problem("Entity set 'UserProfileDbContext.userNote'  is null.");
            }
            var userNote = await _context.UserNotes.FindAsync(id);
            if (userNote != null)
            {
                _context.UserNotes.Remove(userNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserNoteExists(int id)
        {
            return (_context.UserNotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

