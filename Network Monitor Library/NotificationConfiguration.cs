namespace Network_Monitor.Library
{
    /// <summary>
    /// Use to set up configuration for notifications.
    /// </summary>
    public class NotificationConfiguration
    {
        /// <summary>
        /// If present, assume attempt to email using email configuration.
        /// <seealso cref="MailConfiguration"/>
        /// </summary>
        public string[] EmailAddresses { get; set; }

        /// <summary>
        /// Trigger a windows notification, using notification center.
        /// </summary>
        public bool WindowsNotification { get; set; }

        /// <summary>
        /// Write to a log file. If present, assumes this is the file path.
        /// </summary>
        public string LogFile { get; set; }

        /// <summary>
        /// Define if a log entry should be inserted into Event Viewer (Windows Only)
        /// </summary>
        public bool EventViewer { get; set; }
    }
}