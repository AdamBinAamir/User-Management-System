using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace SummerProgramDemo.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("internshipsummer0@gmail.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = htmlMessage;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(email));

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("internshipsummer0@gmail.com", "yncaszqjpaguuvjv"),
                        Timeout = 20000,

                    };
                    smtp.Send(mailMessage);
                }

            }
            catch (Exception ex)
            {

            }
            return Task.CompletedTask;
        }
    }
}
