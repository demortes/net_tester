using System;

namespace Network_Monitor.Library
{
    /// <summary>
    /// General configuration for the application.
    /// </summary>
    public class GeneralConfiguration
    {
        /// <summary>
        /// A collection of target hosts. Cycle through all of them, and report individual results.
        /// </summary>
        public string[] TargetHosts { get; set; } = { "google.com" };
        public int TotalTries { get; set; } = 4;
        public int MaxTimeoutMS { get; set; } = 1000;
        public TimeSpan RunEvery { get; set; } = TimeSpan.FromHours(1);
    }
}