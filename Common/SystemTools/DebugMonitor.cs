using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class DebugMonitor : Form
    {
        public DebugMonitor()
        {
            InitializeComponent();
        }

        public object WatchObject
        {
            set { this.propertyGrid1.SelectedObject = value; }
        }
    }
}
