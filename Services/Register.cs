using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.FileProviders;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Interfaces;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;

namespace SummerProgramDemo.Services
{
    public class Register : IRegister
    {

        private readonly IUserStore<SummerProgramDemoUser> _userStore;
        private readonly IUserEmailStore<SummerProgramDemoUser> _emailStore;
        private readonly UserManager<SummerProgramDemoUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly EmbeddedFileProvider _embeddedFileProvider;

        public Register(
            UserManager<SummerProgramDemoUser> userManager,
            IUserStore<SummerProgramDemoUser> userStore,
            SignInManager<SummerProgramDemoUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
            _embeddedFileProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
        }

        private IUserEmailStore<SummerProgramDemoUser>? GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<SummerProgramDemoUser>)_userStore;
        }

        public async Task<IdentityResult> RegisterUser(SummerProgramDemoUser user, string email, string password)
        {
            await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task SendConfirmationEmail(SummerProgramDemoUser user, string email, string returnUrl, string protocol, string callbackUrl)
        {
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            string FilePath = "wwwroot\\Templates\\RegisterTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string emailBody = str.ReadToEnd();
            str.Close();
            emailBody = emailBody.Replace("##ConfirmationURL##", HtmlEncoder.Default.Encode(callbackUrl));
            await _emailSender.SendEmailAsync(email, "Confirm your email", emailBody);
        }
    }
}
