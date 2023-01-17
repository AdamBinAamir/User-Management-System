using Microsoft.AspNetCore.Identity;
using SummerProgramDemo.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace SummerProgramDemo.Interfaces
{
    public interface IRole
    {
        Task<IdentityResult> CreateRole(string name);
        //Task<IdentityResult> DeleteRole(string id);
    }
}
