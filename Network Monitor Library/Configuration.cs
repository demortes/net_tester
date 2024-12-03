// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Network_Monitor.Library
{
    /// <summary>
    /// Collection of configuration objects to form a complete configuration for Network Monitor.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Notification base configurations, including what to notify and where
        /// </summary>
        public NotificationConfiguration NotificationConfiguration { get; set; }
        /// <summary>
        /// Configuration for email providers.
        /// </summary>
        public MailConfiguration MailConfiguration { get; set; }
        /// <summary>
        /// Network configuration specific to the machine installed on.
        /// </summary>
        public NetworkConfiguration NetworkConfiguration { get; set; }
        /// <summary>
        /// General configuration, such as target hosts and such. 
        /// </summary>
        public GeneralConfiguration GeneralConfiguration { get; set; }
    }
}
