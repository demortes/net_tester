using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.Library.MailConfigs
{
    public class SendGridApiMailProviderConfiguration : SendGridClientOptions, IMailProviderConfiguration
    {
        public Providers Provider => Providers.SendGridAPI;
        public string FromAddress { get; set; }
    }
}
