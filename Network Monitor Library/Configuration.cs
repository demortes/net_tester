// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Newtonsoft.Json;

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
        [JsonProperty(Required = Required.Always)]
        public NotificationConfiguration NotificationConfiguration { get; set; } = new();
        /// <summary>
        /// Configuration for email providers.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public MailConfiguration MailConfiguration { get; set; } = new();
        /// <summary>
        /// Network configuration specific to the machine installed on.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public NetworkConfiguration NetworkConfiguration { get; set; } = new();
        /// <summary>
        /// General configuration, such as target hosts and such. 
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public GeneralConfiguration GeneralConfiguration { get; set; } = new();
    }
}
