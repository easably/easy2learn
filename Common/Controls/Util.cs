using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace f
{
    public class Ul
    {
        public const int SB_LINEUP = 0; // Scrolls one line up
        public const int SB_LINEDOWN = 1; // Scrolls one line down
        public const int WM_VSCROLL = 277; // Vertical scroll

        public const int SB_PAGEUP = 2;
        public const int SB_PAGEDOWN = 3;

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage2(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static void DoSmoothAngle(Graphics graphics, Brush backRound, Rectangle rect)
        {
            Pen pn = new Pen(backRound);
            // Pen pn = new Pen(Color.Red);

            Point l = rect.Location;
            graphics.DrawPolygon(pn, new Point[] { l, new Point(l.X + 1, l.Y), new Point(l.X, l.Y + 1) });

            Point lb = new Point(l.X, rect.Bottom - 1);
            graphics.DrawPolygon(pn, new Point[] { lb, new Point(lb.X, lb.Y - 1), new Point(lb.X + 1, lb.Y) });

            Point rb = new Point(l.X + rect.Width - 1, lb.Y);
            graphics.DrawPolygon(pn, new Point[] { rb, new Point(rb.X - 1, rb.Y), new Point(rb.X, rb.Y - 1), });

            Point rT = new Point(rb.X, l.Y);
            graphics.DrawPolygon(pn, new Point[] { rT, new Point(rT.X - 1, rT.Y), new Point(rT.X, rT.Y + 1), });
        }

        public static void DrawVertical(Splitter sp, PaintEventArgs e)
        { 
            DrawVertical(sp, e, Color.Gray, 3);
        }

        public static void DrawVertical(Splitter sp, PaintEventArgs e, Color color, int lineWidth)
        {
            if (sp == null) return;
            if (sp.Width == 0) return;
            using (Pen pen = new Pen(color))
            {
                pen.DashStyle = DashStyle.Dot;
                pen.Width = lineWidth;
                int x = sp.Width / 2;
                Point p1 = new Point(x, 0);
                Point p2 = new Point(x, sp.Height);
                e.Graphics.DrawLine(pen, p1, p2);
            }
        }

        //public static void DrawTwoSolidVertical_depr(Splitter sp, PaintEventArgs e, Color color)
        //{
        //    if (sp == null) return;
        //    if (sp.Width == 0) return;
        //    using (Pen pen = new Pen(color))
        //    {
        //        pen.DashStyle = DashStyle.Solid;
        //        pen.Width = 4;
        //        Point p1 = new Point(2, 0);
        //        Point p2 = new Point(2, sp.Height);
        //        e.Graphics.DrawLine(pen, p1, p2);
        //        p1 = new Point(sp.Width-2, 0);
        //        p2 = new Point(sp.Width-2, sp.Height);
        //        e.Graphics.DrawLine(pen, p1, p2);
        //    }
        //}

        public static void DrawHorizontal(Splitter sp, PaintEventArgs e)
        {
            DrawHorizontal(sp, e, Color.Gray, 3);
        }

        public static void DrawHorizontal(Splitter sp, PaintEventArgs e, Color color, int lineWidth)
        {
            if (sp == null) return;
            if (sp.Height == 0) return;
            using (Pen pen = new Pen(color))
            {
                pen.DashStyle = DashStyle.Dot;
                pen.Width = lineWidth;
                int y = sp.Height / 2;
                Point p1 = new Point(0, y);
                Point p2 = new Point(sp.Width, y);
                e.Graphics.DrawLine(pen, p1, p2);
            }
        }

        public static void DrawCurvedRectangle(Rectangle rect, Graphics gr, Pen pen,
                        int intend, int intendCurve)
        {
            int intendCurveHalf = intendCurve + 2;

            Point p1 = new Point(intend, intend); // точки по часовой стрелке 
            Point p2 = new Point(rect.Width - intend, intend);
            Point p3 = new Point(rect.Width - intend, rect.Height - intend);
            Point p4 = new Point(intend, rect.Height - intend);

            Point p11 = new Point(p1.X + intendCurve, p1.Y);
            Point p12 = new Point(p2.X - intendCurve, p2.Y);
            Point p21 = new Point(p2.X, p2.Y + intendCurve);
            Point p22 = new Point(p3.X, p3.Y - intendCurve);
            Point p31 = new Point(p3.X - intendCurve, p3.Y);
            Point p32 = new Point(p4.X + intendCurve, p4.Y);
            Point p41 = new Point(p4.X, p4.Y - intendCurve);
            Point p42 = new Point(p1.X, p1.Y + intendCurve);

            gr.DrawLine(pen, p11, p12);
            gr.DrawLine(pen, p21, p22);
            gr.DrawLine(pen, p31, p32);
            gr.DrawLine(pen, p41, p42);

            // copy paste!! from previous
            intendCurve += 1;
            p11 = new Point(p1.X + intendCurve, p1.Y);
            p12 = new Point(p2.X - intendCurve, p2.Y);
            p21 = new Point(p2.X, p2.Y + intendCurve);
            p22 = new Point(p3.X, p3.Y - intendCurve);
            p31 = new Point(p3.X - intendCurve, p3.Y);
            p32 = new Point(p4.X + intendCurve, p4.Y);
            p41 = new Point(p4.X, p4.Y - intendCurve);
            p42 = new Point(p1.X, p1.Y + intendCurve);

            p1 = new Point(intendCurveHalf, intendCurveHalf); // точки по часовой стрелке 
            p2 = new Point(rect.Width - intendCurveHalf, intend);
            p3 = new Point(rect.Width - intendCurveHalf, rect.Height - intendCurveHalf);
            p4 = new Point(intendCurveHalf, rect.Height - intendCurveHalf);

            gr.DrawCurve(pen, new Point[] { p11, p1, p42 });
            gr.DrawCurve(pen, new Point[] { p12, p2, p21 });
            gr.DrawCurve(pen, new Point[] { p22, p3, p31 });
            gr.DrawCurve(pen, new Point[] { p32, p4, p41 });
        }
    }

    public sealed class Win32Helper
    {
        public struct TRIVERTEX
        {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;
            public TRIVERTEX(int x, int y, Color color)
                : this(x, y, color.R, color.G, color.B, color.A)
            {
            }
            public TRIVERTEX(
                int x, int y,
                ushort red, ushort green, ushort blue,
                ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = (ushort)(red << 8);
                this.Green = (ushort)(green << 8);
                this.Blue = (ushort)(blue << 8);
                this.Alpha = (ushort)(alpha << 8);
            }
        }

        public struct GRADIENT_RECT
        {
            public uint UpperLeft;
            public uint LowerRight;
            public GRADIENT_RECT(uint ul, uint lr)
            {
                this.UpperLeft = ul;
                this.LowerRight = lr;
            }
        }


        [DllImport("Msimg32.dll", SetLastError = true, EntryPoint = "GradientFill")]
        public extern static bool GradientFill2(
            IntPtr hdc,
            TRIVERTEX[] pVertex,
            uint dwNumVertex,
            GRADIENT_RECT[] pMesh,
            uint dwNumMesh,
            uint dwMode);

        public const int GRADIENT_FILL_RECT_H = 0x00000000;
        public const int GRADIENT_FILL_RECT_V = 0x00000001;

    }
}