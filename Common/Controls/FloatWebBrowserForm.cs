using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class FloatWebBrowserForm : Form
    {
        public FloatWebBrowserForm()
        {
            InitializeComponent();
        }

        public string HTMLContent { 
            set { this.webBrowser1.DocumentText = value; } 
            get { return this.webBrowser1.DocumentText; } }

    }
}
