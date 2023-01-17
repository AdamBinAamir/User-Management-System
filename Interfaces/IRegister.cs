using Microsoft.AspNetCore.Identity;
using SummerProgramDemo.Areas.Identity.Data;

namespace SummerProgramDemo.Interfaces
{
    public interface IRegister
    {
        Task<IdentityResult> RegisterUser(SummerProgramDemoUser user, string email, string password);
        Task SendConfirmationEmail(SummerProgramDemoUser user, string email, string returnUrl, string protocol, string callbackUrl);
    }
}
