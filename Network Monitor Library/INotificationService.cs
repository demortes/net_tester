using System.Collections.Generic;

namespace Network_Monitor.Tasks
{
    public interface INotificationService
    {
        void SendNotifications(Dictionary<string, HostReport> reports, int totalSuccesses, int totalFailures, int totalTries, float percentFail, float percentSuccess, long averageRoundtripMs);
    }
}