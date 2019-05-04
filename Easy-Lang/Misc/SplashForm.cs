using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class H : Form
    {
        public H()
        {
            InitializeComponent();
            //this.BackColor = CF.ExternalBorder;

            lbVersion.Text = "v " + Application.ProductVersion;

#if !PRO
            this.boxInitial.Visible =
            this.boxDemo.Visible = true;
            this.boxProLabel.Visible = false;
#else
            //this.boxInitial.Visible =
            //this.boxDemo.Visible = false;
            //this.boxProLabel.Visible = true;
#endif
            this.boxDemo.Visible = false;
            // this.boxProLabel.Visible = ;
        
        }
    }
}