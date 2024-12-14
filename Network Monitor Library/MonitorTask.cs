using Network_Monitor.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Network_Monitor.Library.Tasks
{
    public sealed class NetworkMonitorTask : IBack
    {
        /// <summary>
        /// Configuration to be used during completion of the tasks.
        /// </summary>
        public Configuration Configuration { get; set; }
        private bool Cancelled = false;
        private readonly INotificationService _notificationService;

        public NetworkMonitorTask(Configuration configuration, INotificationService notificationService)
        {
            Configuration = configuration;
            _notificationService = notificationService;
        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += TaskCancelled;
            do
            {
                // Ping hosts. Should make this async, but let's make it work first.
                var pingTasks = new List<Task>();
                var pingReports = new List<(string hostname, PingReply reply)>();
                foreach (var target in Configuration.GeneralConfiguration.TargetHosts)
                {
                    pingTasks.Add(Task.Run(async () =>
                    {
                        Ping pingTask = new Ping();
                        for (int i = 0; i < Configuration.GeneralConfiguration.TotalTries; i++)
                        {
                            var reply = pingTask.Send(target, Configuration.GeneralConfiguration.MaxTimeoutMS);
                            pingReports.Add((target, reply));
                        }
                    }));
                }
                Task.WaitAll(pingTasks.ToArray());

                // Generate report.
                // First collect per host.
                Dictionary<string, HostReport> reports = new Dictionary<string, Tasks.HostReport>();
                foreach (var report in pingReports)
                {
                    var hostReport = reports[report.hostname];
                    hostReport.TotalTries++;
                    switch (report.reply.Status)
                    {
                        case IPStatus.Success:
                            hostReport.TotalSuccesses++;
                            hostReport.SuccessRoundaboutTimeMs.Add(report.reply.RoundtripTime);
                            continue;
                        case IPStatus.DestinationHostUnreachable:
                        case IPStatus.DestinationNetworkUnreachable:
                        case IPStatus.DestinationUnreachable:
                        case IPStatus.TtlExpired:
                        case IPStatus.TimedOut:
                        case IPStatus.TimeExceeded:
                            hostReport.TotalFailures++;
                            continue;
                        default:
                            continue;
                    }
                }

                // Now calculate various totals.
                var totalSuccesses = reports.Sum(x=>x.Value.TotalSuccesses);
                var totalFailures = reports.Sum(x=>x.Value.TotalFailures);
                var totalTries = reports.Sum(x => x.Value.TotalTries);
                var percentFail = totalFailures / (float)totalTries * 100;
                var percentSuccess = totalSuccesses / (float)totalTries * 100;
                var averageRoundtripMs = reports.Sum(x => x.Value.AverageRoundAboutMs);

                // Trigger notifications accordingly.
                _notificationService.SendNotifications(reports, totalSuccesses, totalFailures, totalTries, percentFail, percentSuccess, averageRoundtripMs);

                // Delay until next execution time.
                Task.Delay(Configuration.GeneralConfiguration.RunEvery);
            } while (!Cancelled);

            taskInstance.GetDeferral().Complete();
        }

        private void TaskCancelled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason) => Cancelled = true;
    }
}