﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Net_Tester
{
    public partial class Net_Tester : ServiceBase
    {
        DateTime lastRun = DateTime.MinValue;
        private bool KeepRunning = true;

        public Net_Tester()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                var ShouldLogToEventViewer = bool.Parse(ConfigurationManager.AppSettings["LogToEventViewer"]);
                try
                {
                    var configTimespan = int.Parse(ConfigurationManager.AppSettings["RunEverySeconds"]);
                    var runEveryTimespan = new TimeSpan(0, 0, configTimespan);

                    while (KeepRunning)
                    {
                        if(DateTime.Now < (lastRun + runEveryTimespan))
                        {
                            var waitFor = (lastRun + runEveryTimespan) - DateTime.Now;
                            Thread.Sleep(waitFor);
                        }
                        if (KeepRunning == false)
                            break;
                        int success = 0, fail = 0;
                        long roundTrip = 0;
                        lastRun = DateTime.Now;
                        var ipAddressToPing = ConfigurationManager.AppSettings["PingIP"];
                        Ping pinger = new Ping();
                        var count = int.Parse(ConfigurationManager.AppSettings["PingCount"]);
                        for (int i = 0; i < count; i++)
                        {
                            var reply = pinger.Send(ipAddressToPing);
                            if (reply.Status == IPStatus.Success)
                            {
                                success++;
                                roundTrip += reply.RoundtripTime;
                            }
                            else
                                fail++;
                        }

                        var averageTrip = roundTrip / success;
                        var logMessage = string.Format("IP: {0} - Success: {1} - Fail: {2} - Average Round Trip: {3}", ipAddressToPing, success, fail, averageTrip);
                        var ShouldEmail = bool.Parse(ConfigurationManager.AppSettings["EmailResults"]);
                        if (ShouldEmail)
                        {
                            var fromEmail = ConfigurationManager.AppSettings["EmailFromAddress"];
                            var toEmail = ConfigurationManager.AppSettings["EmailAddress"];
                            MailMessage mail = new MailMessage(fromEmail, toEmail);
                            var subject = ConfigurationManager.AppSettings["EmailSubject"];
                            mail.Subject = subject;
                            mail.Body = logMessage;
                            var smtpHost = ConfigurationManager.AppSettings["SMTPServer"];
                            var smtpPort = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
                            var smtpTLS = bool.Parse(ConfigurationManager.AppSettings["SMTPTLS"]);
                            SmtpClient client = new SmtpClient();
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
                            client.Port = smtpPort;
                            client.Host = smtpHost;
                            client.EnableSsl = smtpTLS;
                            client.Send(mail);
                        }

                        if (ShouldLogToEventViewer)
                        {
                            using (EventLog eventLog = new EventLog("Application"))
                            {
                                eventLog.Source = "Application";
                                var LogPacketLossAsError = bool.Parse(ConfigurationManager.AppSettings["EventViewerErrorPacketLoss"]);
                                var EventType = (LogPacketLossAsError && fail > 0) ? EventLogEntryType.Error : EventLogEntryType.Information;
                                EventLog.WriteEntry(".NET Runtime", logMessage, EventType, 1000);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ShouldLogToEventViewer)
                        using (EventLog eventLog = new EventLog("Application"))
                        {
                            eventLog.Source = "Application";
                            eventLog.WriteEntry("Exception thrown: " + ex.Message, EventLogEntryType.Error, 101, 1);
                        }
                    this.OnStop();
                    throw;
                }
            });
        }

        protected override void OnStop()
        {
            KeepRunning = false;
        }
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
    }
}
