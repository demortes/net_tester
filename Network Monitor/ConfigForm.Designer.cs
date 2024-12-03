namespace Network_Monitor
{
    partial class ConfigForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            timer1 = new System.Windows.Forms.Timer(components);
            materialListBox1 = new ReaLTaiizor.Controls.MaterialListBox();
            metroLabel1 = new ReaLTaiizor.Controls.MetroLabel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // materialListBox1
            // 
            materialListBox1.BackColor = System.Drawing.Color.White;
            materialListBox1.BorderColor = System.Drawing.Color.LightGray;
            materialListBox1.Depth = 0;
            resources.ApplyResources(materialListBox1, "materialListBox1");
            materialListBox1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialListBox1.Name = "materialListBox1";
            materialListBox1.SelectedIndex = -1;
            materialListBox1.SelectedItem = null;
            materialListBox1.SelectedIndexChanged += materialListBox1_SelectedIndexChanged;
            // 
            // metroLabel1
            // 
            resources.ApplyResources(metroLabel1, "metroLabel1");
            metroLabel1.IsDerivedStyle = true;
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabel1.StyleManager = null;
            metroLabel1.ThemeAuthor = "Taiizor";
            metroLabel1.ThemeName = "MetroLight";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += addHostBtn_Click;
            // 
            // ConfigForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(metroLabel1);
            Controls.Add(materialListBox1);
            Name = "ConfigForm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private ReaLTaiizor.Controls.MaterialListBox materialListBox1;
        private ReaLTaiizor.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}