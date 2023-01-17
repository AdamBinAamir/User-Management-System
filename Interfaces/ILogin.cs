using Microsoft.AspNetCore.Identity;

namespace SummerProgramDemo.Interfaces
{
    public interface ILogIn
    {
        Task<SignInResult> LoginUser(string email, string password, bool RememberMe, bool lockoutOnFailure);
    }
}
