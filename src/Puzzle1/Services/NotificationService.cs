using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Puzzle1.Services
{
    public class NotificationService
    {
        private readonly ILogger _logger;
        private readonly NotificationOptions _options;

        public NotificationService(ILogger<NotificationService> logger, IOptions<NotificationOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public Task NotifyAsync()
        {

            try
            {
                if (string.IsNullOrWhiteSpace(_options.SmtpServerAddress))
                {
                    _logger.LogWarning("Unable to send notification. No SMTP Server Address was specified.");
                }
                else
                {
                    using (MailMessage mail = new MailMessage(_options.FromEmailAddress, _options.ToEmailAddress))
                    {
                        mail.Subject = "Puzzle 1 Solved";
                        mail.Body = "Someone has solved Puzzle 1.";

                        using (SmtpClient smtpClient = new SmtpClient(_options.SmtpServerAddress, _options.SmtpServerPort))
                        {
                            smtpClient.Credentials = new System.Net.NetworkCredential()
                            {
                                UserName = _options.Username,
                                Password = _options.Password
                            };

                            smtpClient.EnableSsl = _options.EnableSsl;

                            smtpClient.Send(mail);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unable to send email using SMTP server: {Server}", _options.SmtpServerAddress);
            }

            return Task.CompletedTask;
        }
    }
}
