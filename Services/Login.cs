using Microsoft.AspNetCore.Identity;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Interfaces;

namespace SummerProgramDemo.Services
{
    public class Login : ILogIn
    {
        private readonly SignInManager<SummerProgramDemoUser> _signInManager;
        private readonly ILogIn _logIn;

        public Login(SignInManager<SummerProgramDemoUser> signInManager)

        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginUser(string email, string password, bool RememberMe, bool lockoutOnFailure)
        {
            var result1 = await _signInManager.PasswordSignInAsync(email, password, RememberMe, lockoutOnFailure: false);

            return result1;
        }

    }
}
