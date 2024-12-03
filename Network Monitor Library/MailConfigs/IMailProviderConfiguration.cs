namespace Network_Monitor.Library.MailConfigs
{
    /// <summary>
    /// Interface to implement for configuration.
    /// </summary>
    public interface IMailProviderConfiguration
    {
        /// <summary>
        /// Define which provider this is for, sets the format for the rest of the configuration.
        /// </summary>
        Providers Provider { get; }
    }
}