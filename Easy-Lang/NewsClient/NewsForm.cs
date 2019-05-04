using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class NewsForm : Form
    {
        public NewsForm()
        {
            InitializeComponent();
            f.newsServer.Service1 ser = new f.newsServer.Service1();
            this.Text = ser.HelloWorld();
        }
    }
}