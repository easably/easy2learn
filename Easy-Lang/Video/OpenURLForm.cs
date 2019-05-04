using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{

    // Укажите видео для открытия прямо из интернета

    public partial class OpenURLForm : Form
    {
        public OpenURLForm()
        {
            InitializeComponent();
            this.txURLforDownload.SelectAll();
        }

        public string URL { 
            get { return this.txURLforDownload.Text; }  
            set { this.txURLforDownload.Text = value; } 
        }

        private void llbHowGetURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Runner.OpenURL(@"http://userscripts.org/scripts/show/25105");
            Runner.OpenURL(@"https://addons.mozilla.org/en-US/firefox/addon/download-youtube/");            
        }
    }
}
