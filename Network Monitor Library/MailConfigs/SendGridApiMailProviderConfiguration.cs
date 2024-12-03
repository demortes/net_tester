using SendGrid;

namespace Network_Monitor.Library.MailConfigs
{
    public class SendGridApiMailProviderConfiguration : SendGridClientOptions, IMailProviderConfiguration
    {
        public Providers Provider => Providers.SendGridAPI;
        public string FromAddress { get; set; }
    }
}
