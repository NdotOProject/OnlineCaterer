
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

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

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = htmlMessage
        };

        var message = new MimeMessage
        {
            Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail),
            Subject = subject,
            Body = bodyBuilder.ToMessageBody()
        };
        message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        message.To.Add(MailboxAddress.Parse(email));

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

            _logger.LogInformation(message: $"Send error, save mail at - {emailsavefile}");
            _logger.LogError(message: ex.Message);
        }

        smtp.Disconnect(true);

        _logger.LogInformation("Send mail to " + email);
    }
}
