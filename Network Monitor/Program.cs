using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Monitor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Network Monitor");
            var configFileName = "network_monitor.config";
            var fullPath = Path.Combine(appDataPath, configFileName);
            bool firstRun = false;

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            if (!File.Exists(fullPath))
            {
                File.CreateText(fullPath).WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new Network_Monitor.Library.Configuration(), Newtonsoft.Json.Formatting.Indented));
                firstRun = true;
            }

            var Config = new ConfigurationBuilder()
                .SetBasePath(appDataPath)
                .AddJsonFile(configFileName, true, true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotifyIcon trayIcon = new NotifyIcon();
            // TODO MenuItem is no longer supported. Use ToolStripMenuItem instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
            var menuItems = new ToolStripMenuItem[]
            {
                //new MenuItem("Config", Config_Click, Shortcut.CtrlShiftC),
                new("Configure", null, Configure_Click),
                new("Exit", null, Exit_Click)
            };
            // TODO ContextMenu is no longer supported. Use ContextMenuStrip instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
            var cms = new ContextMenuStrip();
            cms.Items.AddRange(menuItems);
            trayIcon.ContextMenuStrip = cms;
            trayIcon.Icon = new System.Drawing.Icon("appIcon.ico");
            trayIcon.Text = "Network Monitor";
            trayIcon.Visible = true;

            Application.Run();
            if(firstRun)
            {
                //First run, pop up configuration.
                var configForm = new ConfigForm();
                configForm.Show();
            }
        }

        private static void Configure_Click(object sender, EventArgs e)
        {
            new ConfigForm().Show();
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
