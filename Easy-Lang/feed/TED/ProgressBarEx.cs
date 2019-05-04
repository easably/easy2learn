using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace f.TED
{
    public class ProgressBarEx : ProgressBar
    {
        bool m_SetRedMode;
        public bool IsRedMode
        {
            get { return m_SetRedMode; }
            set
            {
                m_SetRedMode = value;
                if (value)
                    this.SetStyle(ControlStyles.UserPaint, true);
                else // TODO: nor work
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if(ProgressBarRenderer.IsSupported)
               ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(Brushes.Red, 2, 2, rec.Width, rec.Height);
        }

        //using System.Runtime.InteropServices;

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        //static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        //public static void SetState(this ProgressBar pBar, int state)
        //{
        //    SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        //}
    }
}
