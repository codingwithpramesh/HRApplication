using HRApplication.Models;

namespace HRApplication.Data.Services
{
    public interface IEmailService
    {

        Task SendTestEmail(UserEmailOptions userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);

        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);

        // Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
