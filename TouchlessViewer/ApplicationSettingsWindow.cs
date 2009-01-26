using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace TouchlessViewer
{
    public partial class ApplicationSettingsWindow : Form
    {
        public ApplicationSettingsWindow()
        {
            InitializeComponent();
            this.syncFadeBox();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void syncFadeBox()
        {
            this.labelFadeDelay.Enabled = this.checkBoxFade.Checked;
            this.textBoxFadeDelay.Enabled = this.checkBoxFade.Checked;
        }

        private void saveSettings()
        {

        }

        private void checkBoxFade_CheckedChanged(object sender, EventArgs e)
        {
            this.syncFadeBox();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.saveSettings();
            this.Close();
        }

    }
}
