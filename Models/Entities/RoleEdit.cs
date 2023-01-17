using Microsoft.AspNetCore.Identity;
using SummerProgramDemo.Areas.Identity.Data;

namespace SummerProgramDemo.Models.Entities
{
    public class RoleEdit
    {
        public IdentityRole? Role { get; set; }
        public IEnumerable<SummerProgramDemoUser>? Members { get; set; }
        public IEnumerable<SummerProgramDemoUser>? NonMembers { get; set; }
    }
}
