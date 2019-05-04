using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class SentennceShiftForm : Form
    {
        public SentennceShiftForm()
        {
            InitializeComponent();
            RefreshLabel();
            CheckBtReset();
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
        }

        public double TimeShift
        {
            get
            {
                // force reducing for zero
                if (this.trackBar1.Value < 50 && this.trackBar1.Value > -50) 
                    return 0;

                return Convert.ToDouble(this.trackBar1.Value) / 1000;
            }
            set
            {
                this.trackBar1.Value = (int)(value * 1000);
                RefreshLabel();
            }
        }

        void RefreshLabel()
        {
            //            lbShowInSeconds.Text = string.Format("{0} seconds ({1} milliseconds)", TimeShift.ToString("0.0"), TimeShift * 1000D);
            lbShowInSeconds.Text = string.Format("{0} seconds", TimeShift.ToString("0.00"), TimeShift * 1000D);
            lbShowInSeconds.ForeColor = (TimeShift < 0) ? Color.Red : Color.Black;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            RefreshLabel();
            CheckBtReset();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
        }

        void CheckBtReset()
        {
            this.btReset.Enabled = this.trackBar1.Value != 0;
        }
    }
}
