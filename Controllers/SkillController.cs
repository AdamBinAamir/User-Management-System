using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SummerProgramDemo.Data;
using SummerProgramDemo.Models.Entities;

namespace SummerProgramDemo.Controllers
{
    public class SkillController : Controller
    {
        private readonly UserProfileDbContext _context;

        public SkillController(UserProfileDbContext context)
        {
            _context = context;
        }


        // GET: SkillController
        public async Task<IActionResult> Index()
        {
            var userProfileDbContext = _context.Skills
                .Include(u => u.SkillUsers)
                .ThenInclude(i => i.User);
            return View(await userProfileDbContext.ToListAsync());
        }

        // GET: SkillController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }
            var skill = await _context.Skills
                .Include(u => u.SkillUsers)
                .ThenInclude(i => i.Skill)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // GET: SkillController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Skillss")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: SkillController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var userNote = await _context.Skills.FindAsync(id);
            if (userNote == null)
            {
                return NotFound();
            }
            return View(userNote);
        }

        // POST: SkillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Skilss")] Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var eskill = _context.Skills.FirstOrDefault(i => i.Id == id);
                eskill.Id = skill.Id;
                eskill.Skillss = skill.Skillss;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: SkillController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _context.Skills
                .FirstOrDefault(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: SkillController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = _context.Skills
                .FirstOrDefault(m => m.Id == id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return (_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
