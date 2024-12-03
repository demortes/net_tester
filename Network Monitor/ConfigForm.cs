using Network_Monitor.Library;
using ReaLTaiizor.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Network_Monitor
{
    public partial class ConfigForm : MetroForm
    {
        private Configuration _configuration;

        public ConfigForm(Configuration configuration)
        {
            InitializeComponent();
            //Populate ListBox for Host
            _configuration = configuration;

            foreach(var host in _configuration.GeneralConfiguration.TargetHosts)
            {
                materialListBox1.AddItem(new ReaLTaiizor.Child.Material.MaterialListBoxItem
                {
                    Text = host
                });
            }
        }

        private void materialListBox1_SelectedIndexChanged(object sender, ReaLTaiizor.Child.Material.MaterialListBoxItem selectedItem)
        {

        }

        private void addHostBtn_Click(object sender, System.EventArgs e)
        {

        }
    }
}
