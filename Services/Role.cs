using Microsoft.AspNetCore.Identity;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SummerProgramDemo.Services
{
    public class Role : IRole
    {
        private readonly UserManager<SummerProgramDemoUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Role(UserManager<SummerProgramDemoUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
            return result;
        }
        //public async Task<IdentityResult> DeleteRole(string id)
        //{

        //        IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(id));
        //        return result;
        //}
    }
}
