using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Interfaces;
using SummerProgramDemo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SummerProgramDemo.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<SummerProgramDemoUser> userManager;
        private readonly IRole _role;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<SummerProgramDemoUser> userMrg, IRole role)
        {
            roleManager = roleMgr;
            userManager = userMrg;
            _role = role;
        }

        public ViewResult Index() => View(roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _role.CreateRole(name);/*await roleManager.CreateAsync(new IdentityRole(name));*/
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<SummerProgramDemoUser> members = new List<SummerProgramDemoUser>();
            List<SummerProgramDemoUser> nonMembers = new List<SummerProgramDemoUser>();
            foreach (SummerProgramDemoUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    SummerProgramDemoUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    SummerProgramDemoUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }
        private void Errors(IdentityResult result)
        {
            throw new NotImplementedException();
        }
    }
}