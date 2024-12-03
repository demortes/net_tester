using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.Library.MailConfigs
{
    public class SMTPMailProviderConfiguration : SmtpClient,IMailProviderConfiguration
    {
        public Providers Provider => Providers.SMTP;
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
