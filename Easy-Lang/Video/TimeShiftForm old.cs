using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class TimeShiftForm : Form
    {
        public TimeShiftForm()
        {
            InitializeComponent();
            RefreshLabel();
        }

        public double TimeShift
        {
            get {
                if (string.IsNullOrEmpty(this.numericUpDown1.Text))
                    this.numericUpDown1.Value = 0; // if text was this.numericUpDown1.Text = ""
                // return Convert.ToDouble(Math.Round(this.numericUpDown1.Value) / 1000);
                // т.к. !!! вместо 300 дает !! this.numericUpDown1.Value = 300.000011920929
                return Convert.ToDouble(Math.Round(this.numericUpDown1.Value) / 1000); 
            }
            set { 
                this.numericUpDown1.Value = Convert.ToDecimal(value * 1000);
                 this.numericUpDown1.Text = this.numericUpDown1.Value.ToString(); // if text was this.numericUpDown1.Text = ""
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshLabel();
        }

        void RefreshLabel()
        {
            lbShowInSeconds.Text = string.Format("= {0} seconds", TimeShift);
        }
    }
}
