using TaskManagementApplication.Models;

namespace TaskManagementApplication.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailModel email);
    }
}
