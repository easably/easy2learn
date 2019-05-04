using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class VideoRateForm : Form
    {
        public VideoRateForm()
        {
            InitializeComponent();
            RefreshLabel();
            CheckBtReset();
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.KeyPress += VideoRateForm_KeyPress; // TODO: not working ! ((
            this.KeyDown += Form_KeyDown;
        }

        void VideoRateForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        int delimeter = 100;
        public double Rate
        {
            get
            {
                // force reducing for zero
                if (this.trackBar1.Value > 95 && this.trackBar1.Value < 105) 
                    return 1;

                return Convert.ToDouble(this.trackBar1.Value) / delimeter;
            }
            set
            {
                this.trackBar1.Value = (int)(value * delimeter);
                RefreshLabel();
            }
        }

        void RefreshLabel()
        {
            lbShowInSeconds.Text = string.Format("Rate: {0}", Rate.ToString("0.00"));
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            RefreshLabel();
            CheckBtReset();
        }


        void CheckBtReset()
        {
            this.btReset.Enabled = this.trackBar1.Value != 0;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 100;
        }
    }
}
