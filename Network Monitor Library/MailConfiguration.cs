using Network_Monitor.Library.MailConfigs;

namespace Network_Monitor.Library
{
    /// <summary>
    /// Define the mail configuration for the network monitor to send notifications.
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// If any present, try top one first, then move on until we get one as a success.
        /// </summary>
        public IMailProviderConfiguration[] ProviderConfiguration { get; set; }
    }
}