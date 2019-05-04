using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class SearchSubtitles : BaseForm
    {
        public SearchSubtitles()
        {
            InitializeComponent();
        }

        public string MovieName
        {
            get { return this.textBox1.Text;  }
            set { this.textBox1.Text = value;  }
        }
    }
}
