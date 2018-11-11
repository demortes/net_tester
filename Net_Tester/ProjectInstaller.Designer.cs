namespace Net_Tester
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NetQuailtyTesterINstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.NetQualityTester = new System.ServiceProcess.ServiceInstaller();
            // 
            // NetQuailtyTesterINstaller
            // 
            this.NetQuailtyTesterINstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.NetQuailtyTesterINstaller.Password = null;
            this.NetQuailtyTesterINstaller.Username = null;
            // 
            // NetQualityTester
            // 
            this.NetQualityTester.DelayedAutoStart = true;
            this.NetQualityTester.DisplayName = "Net Quality Tester";
            this.NetQualityTester.ServiceName = "Net_Tester";
            this.NetQualityTester.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.NetQualityTester.AfterInstall += NetQualityTester_AfterInstall;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.NetQuailtyTesterINstaller,
            this.NetQualityTester});

        }

        private void NetQualityTester_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {
        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller NetQuailtyTesterINstaller;
        private System.ServiceProcess.ServiceInstaller NetQualityTester;
    }
}