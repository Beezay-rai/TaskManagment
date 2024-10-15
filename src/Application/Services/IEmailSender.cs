using TaskManagementApplication.Models;

namespace TaskManagementApplication.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailModel email);
    }
}
