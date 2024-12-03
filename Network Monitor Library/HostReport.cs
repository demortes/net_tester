using System.Collections.Generic;
using System.Linq;

namespace Network_Monitor.Tasks
{
    /// <summary>
    /// Report for a single host. Used as part of a dictionary.
    /// </summary>
    public class HostReport
    {
        public int TotalTries { get; set; }
        public int TotalSuccesses { get; set; }
        public List<long> SuccessRoundaboutTimeMs { get; set; } = new();
        public int TotalFailures { get; set; }
        public long AverageRoundAboutMs => SuccessRoundaboutTimeMs.Sum() / SuccessRoundaboutTimeMs.Count;
    }
}