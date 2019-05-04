using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class TM : UserControl
    {
        public TM()
        {
            InitializeComponent();
            this.gbPlus.Height = this.gbOpen.Height / 2;
            this.pnCompaund.Width = gbOpen.Width * 2;

            this.gbAbout.Width = gbHelp.Width = gbOpen.Width;
        }

        private void TM_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Rectangle rect = e.ClipRectangle;
            Pen pen = new Pen(Color.Gray);
            pen.Width = 2;
            int intend = 6;
            int intendCurve = 6;
            Ul.DrawCurvedRectangle(rect, gr, pen, intend, intendCurve);
            pen.Dispose();
        }
    }
}