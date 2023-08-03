
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineCaterer.Application.Common.Models.Mail;

namespace OnlineCaterer.Infrastructure.Services;

public class MailService : IEmailSender
{
    private readonly MailSettings _mailSettings;

    private readonly ILogger<MailService> _logger;

    public MailService(IOptions<MailSettings> mailSettings, ILogger<MailService> logger)
    {
        _mailSettings = mailSettings.Value;
        _logger = logger;
        _logger.LogInformation("Create MailService");
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MimeMessage();
        message.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
        message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = htmlMessage;
        message.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(message);
        }
        catch (Exception ex)
        {
            System.IO.Directory.CreateDirectory("mailssave");
            var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
            await message.WriteToAsync(emailsavefile);

            _logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
            _logger.LogError(message: ex.Message);
        }

        smtp.Disconnect(true);

        _logger.LogInformation("send mail to " + email);
    }
}
