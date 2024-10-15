using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Models;
using TaskManagementApplication.Services;

namespace TaskManagementInfrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private EmailSettingModel _emailSetting { get; }
        public EmailSender(IOptions<EmailSettingModel> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmail(EmailModel email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress();
            var from = new EmailAddress();
            var mail = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(mail);
            return response.IsSuccessStatusCode;
        }
    }
}
