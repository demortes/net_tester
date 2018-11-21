using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Tester
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void NetQualityTester_AfterInstall_1(object sender, InstallEventArgs e)
        {
            using (System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController(NetQualityTester.DisplayName))
            {
                sc.Start();
            }
        }
    }
}
