using System;
using System.ServiceProcess;

namespace Net_Tester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var newService = new Net_Tester();
                newService.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Net_Tester()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
