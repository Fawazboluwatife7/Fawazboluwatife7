using Microsoft.AspNetCore.Identity.UI.Services;

namespace aBookApp.Data
{
    public class Email : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
