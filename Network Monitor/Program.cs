using Microsoft.Extensions.Configuration;
using Network_Monitor.Library;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Network_Monitor
{
    internal static class Program
    {
        private static Configuration Config;
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
                var fileHandler = File.CreateText(fullPath);
                fileHandler.Write(JsonConvert.SerializeObject(new Network_Monitor.Library.Configuration(), Newtonsoft.Json.Formatting.Indented));
                fileHandler.Close();
                firstRun = true;
            }

            Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(fullPath));

            Application.EnableVisualStyles();
#if NETCOREAPP3_1 || NET6_0 || NET7_0 || NET8_0 || NET9_0
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up tray icon.
            NotifyIcon trayIcon = new();

            var menuItems = new ToolStripMenuItem[]
            {
                //new MenuItem("Config", Config_Click, Shortcut.CtrlShiftC),
                new("Configure", null, Configure_Click),
                new("Exit", null, Exit_Click)
            };
            var cms = new ContextMenuStrip();
            cms.Items.AddRange(menuItems);
            trayIcon.ContextMenuStrip = cms;
            trayIcon.Icon = new System.Drawing.Icon("appIcon.ico");
            trayIcon.Text = "Network Monitor";
            trayIcon.Visible = true;

            // Run without a form.
            Application.Run();
        }

        private static void Configure_Click(object sender, EventArgs e)
        {
            new ConfigForm(Config).Show();
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
