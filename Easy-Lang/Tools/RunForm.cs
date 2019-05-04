using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class RunForm : Form
    {
        public RunForm()
        {
            InitializeComponent();
            this.openFileDialog1.InitialDirectory = FileSelector.GetFolderForFileSelection("");
        }

        public string FileName
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
                if (!string.IsNullOrEmpty(this.textBox1.Text))
                {
                    this.openFileDialog1.InitialDirectory = FileSelector.GetFolderForFileSelection(this.textBox1.Text);
                }
            }
        }

        internal void Estimate()
        {
            try
            {
                if (this.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(this.textBox1.Text))
                    {
                        E estForm = new E();
                        //                        estForm.TextForEstimate = this.tx1.FullText;
                        estForm.ShowDialog();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.FileName = this.openFileDialog1.FileName;
            }
        }
    }
}