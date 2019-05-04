using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f.TED
{
    public partial class FormDowloadedInfo : Form
    {
        public FormDowloadedInfo()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDowloadedInfo_FormClosing);
        }

        public int EnSubtProgress { set { this.pbEnSubt.Value = value; LiveUpdate(); } }
        public bool IsEnSubtWorng { set { this.pbEnSubt.IsRedMode = value; LiveUpdate(); } }

        public int NativeSubtProgress { set { this.pbNativeSubt.Value = value; LiveUpdate(); } }
        public bool IsNativeSubtWorng { set { this.pbNativeSubt.IsRedMode = value; LiveUpdate(); } }
        
        public int VideoProgress { set { this.pbVideo.Value = value; LiveUpdate(); } }
        public bool IsVideoWorng { set { this.pbVideo.IsRedMode = value; LiveUpdate(); } }

        private void LiveUpdate() {
            this.Refresh(); 
            Application.DoEvents();
        }

        private void FormDowloadedInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string mes = "To stop file downloading? Are you sure?";
            //if (MessageBox.Show(mes, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    // break all
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        // for calling how callback
        public void AssignProgress(int progress)
        {
            this.VideoProgress = progress;
        }
    }
}
