using System.Net.Mail;

namespace Network_Monitor.Library.MailConfigs
{
    public class SMTPMailProviderConfiguration : SmtpClient, IMailProviderConfiguration
    {
        public Providers Provider => Providers.SMTP;
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
