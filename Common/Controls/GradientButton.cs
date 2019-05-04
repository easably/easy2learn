using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class GB : Control
    {
        #region ctor & Dispose
        private System.ComponentModel.IContainer components = null;
        Timer tmIn = new Timer();
        Timer tmOut = new Timer();

        public GB()
        {
            components = new System.ComponentModel.Container();
            this.Font = new Font("Arial", 8F, FontStyle.Regular);

            this.tmOut.Interval = tmIn.Interval = 33;
            this.tmOut.Tick += new EventHandler(tmOut_Tick);
            this.tmIn.Tick += new EventHandler(tmIn_Tick);

            this.MouseEnter += new EventHandler(GB_MouseEnter);
            this.MouseLeave += new EventHandler(GB_MouseLeave);
        }

        #region Mouse and Timer
        void GB_MouseLeave(object sender, EventArgs e)
        {
            this.tmOut.Enabled = true;
        }

        void GB_MouseEnter(object sender, EventArgs e)
        {
            this.tmIn.Enabled = true;
        }

        void tmIn_Tick(object sender, EventArgs e)
        {
            if (this.tmOut.Enabled) return;
            this.EndOffset += 1;
            this.Refresh();
            this.tmIn.Enabled = this.EndOffset < this.Height / 2;
        }

        void tmOut_Tick(object sender, EventArgs e)
        {
            this.EndOffset -= 1;
            this.Refresh();
            this.tmOut.Enabled = this.EndOffset > 1;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region props
        private Gl.FillDirection m_FillDirectionValue = Gl.FillDirection.TopToBottom;
        /// <summary>
        /// Controls the direction in which the button is filled.
        /// </summary>
        public Gl.FillDirection FillDirection
        {
            get
            {
                return m_FillDirectionValue;
            }
            set
            {
                m_FillDirectionValue = value;
                Invalidate();
            }
        }

        private Color m_StartColorValue = Color.White;
        /// <summary>
        /// The start color for the GradientFill. This is the color
        /// at the left or top of the control depeneding on the value
        /// of the FillDirection property.
        /// </summary>
        public Color StartColor
        {
            get { return m_StartColorValue; }
            set
            {
                m_StartColorValue = value;
                Invalidate();
            }
        }

        private Color m_EndColorValue = Color.Silver;
        /// <summary>
        /// The end color for the GradientFill. This is the color
        /// at the right or bottom of the control depending on the value
        /// of the FillDirection property
        /// </summary>
        public Color EndColor
        {
            get { return m_EndColorValue; }
            set
            {
                m_EndColorValue = value;
                Invalidate();
            }
        }

        private int m_StartOffsetValue;
        /// <summary>
        /// This is the offset from the left or top edge
        ///  of the button to start the gradient fill.
        /// </summary>
        public int StartOffset
        {
            get { return m_StartOffsetValue; }
            set
            {
                m_StartOffsetValue = value;
                Invalidate();
            }
        }


        private int m_EndOffsetValue;
        /// <summary>
        /// This is the offset from the right or bottom edge
        ///  of the button to end the gradient fill.
        /// </summary>
        public int EndOffset
        {
            get { return m_EndOffsetValue; }
            set
            {
                m_EndOffsetValue = value;
                Invalidate();
            }
        }
        #endregion

        // Used to double-buffer our drawing to avoid flicker
        // between painting the background, border, focus-rect
        // and the text of the control.
        private Bitmap DoubleBufferImage
        {
            get
            {
                if (bmDoubleBuffer == null)
                    bmDoubleBuffer = new Bitmap(
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                return bmDoubleBuffer;
            }
            set
            {
                if (bmDoubleBuffer != null)
                    bmDoubleBuffer.Dispose();
                bmDoubleBuffer = value;
            }
        }
        private Bitmap bmDoubleBuffer;

        // Called when the control is resized. When that happens,
        // recreate the bitmap used for double-buffering.
        protected override void OnResize(EventArgs e)
        {
            DoubleBufferImage = new Bitmap(
                this.ClientSize.Width,
                this.ClientSize.Height);
            base.OnResize(e);
        }

        // Called when the control gets focus. Need to repaint
        // the control to ensure the focus rectangle is drawn correctly.
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        //
        // Called when the control loses focus. Need to repaint
        // the control to ensure the focus rectangle is removed.
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Capture)
            {
                Point coord = new Point(e.X, e.Y);
                if (this.ClientRectangle.Contains(coord) !=
                    this.ClientRectangle.Contains(lastCursorCoordinates))
                {
                    DrawButton(this.ClientRectangle.Contains(coord));
                }
                lastCursorCoordinates = coord;
            }

            base.OnMouseMove(e);
        }

        // The coordinates of the cursor the last time
        // there was a MouseUp or MouseDown message.
        Point lastCursorCoordinates;

        internal void OnMouseDownOut(MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Start capturing the mouse input
                this.Capture = true;
                // Get the focus because button is clicked.
                this.Focus();

                // draw the button
                DrawButton(true);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Capture = false;

            DrawButton(false);

            base.OnMouseUp(e);
        }

        bool bGotKeyDown = false;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            bGotKeyDown = true;
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    DrawButton(true);
                    break;
                case Keys.Up:
                case Keys.Left:
                    this.Parent.SelectNextControl(this, false, false, true, true);
                    break;
                case Keys.Down:
                case Keys.Right:
                    this.Parent.SelectNextControl(this, true, false, true, true);
                    break;
                default:
                    bGotKeyDown = false;
                    base.OnKeyDown(e);
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    if (bGotKeyDown)
                    {
                        DrawButton(false);
                        OnClick(EventArgs.Empty);
                        bGotKeyDown = false;
                    }
                    break;
                default:
                    base.OnKeyUp(e);
                    break;
            }
        }

        // Override this method with no code to avoid flicker.
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButton(e.Graphics, this.Capture &&
                (this.ClientRectangle.Contains(lastCursorCoordinates)));
        }

        //
        // Gets a Graphics object for the provided window handle
        //  and then calls DrawButton(Graphics, bool).
        //
        // If pressed is true, the button is drawn
        // in the depressed state.
        void DrawButton(bool pressed)
        {
            Graphics gr = this.CreateGraphics();
            DrawButton(gr, pressed);
            gr.Dispose();
        }

        // Draws the button on the specified Grapics
        // in the specified state.
        //
        // Parameters:
        //  gr - The Graphics object on which to draw the button.
        //  pressed - If true, the button is drawn in the depressed state.
        void DrawButton(Graphics gr, bool pressed)
        {
            // Get a Graphics object from the background image.
            Graphics gr2 = Graphics.FromImage(DoubleBufferImage);

            // Fill solid up until where the gradient fill starts.
            if (this.StartOffset > 0)
            {
                if (this.FillDirection ==
                    Gl.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(
                        new SolidBrush(pressed ? EndColor : StartColor),
                        0, 0, this.StartOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(
                        new SolidBrush(pressed ? EndColor : StartColor),
                        0, 0, Width, this.StartOffset);
                }
            }

            // Draw the gradient fill.
            Rectangle rc = this.ClientRectangle;
            if (this.FillDirection == Gl.FillDirection.LeftToRight)
            {
                rc.X = this.StartOffset;
                rc.Width = rc.Width - this.StartOffset - this.EndOffset;
            }
            else
            {
                rc.Y = this.StartOffset;
                rc.Height = rc.Height - this.StartOffset - this.EndOffset;
            }
            Gl.Fill(
                gr2,
                rc,
                pressed ? this.EndColor : this.StartColor,
                pressed ? this.StartColor : this.EndColor,
                this.FillDirection);

            // Fill solid from the end of the gradient fill
            // to the edge of the button.
            if (this.EndOffset > 0)
            {
                if (this.FillDirection ==
                    Gl.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(
                        new SolidBrush(pressed ? StartColor : EndColor),
                        rc.X + rc.Width, 0, this.EndOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(
                        new SolidBrush(pressed ? StartColor : EndColor),
                        0, rc.Y + rc.Height, Width, this.EndOffset);
                }
            }

            // Draw the text.
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center; // alin by bottom StringAlignment.Far;
            Rectangle textRect = this.ClientRectangle;
            //            textRect.Height -= 10;
            gr2.DrawString(this.Text, this.Font,
                new SolidBrush(this.ForeColor),
                textRect, sf);

            // Draw the border.
            // Need to shrink the width and height by 1 otherwise
            // there will be no border on the right or bottom.
            rc = this.ClientRectangle;
            rc.Width--;
            rc.Height--;
            Pen pen = new Pen(SystemColors.WindowFrame);

            //    gr2.DrawRectangle(pen, rc);
            Pen penForCurve = new Pen(Color.Gray); // White
            penForCurve.Width = 1;
            int intend = 3;
            int intendCurve = 2;
            //Rectangle rectForCurve = rc;
            ////rectForCurve.Width += intend*2;
            ////rectForCurve.Height += intend*2;
            //rectForCurve.X -= intend*2;
            //rectForCurve.Y -= intend*2;
            Ul.DrawCurvedRectangle(rc, gr2, penForCurve, intend, intendCurve);
            penForCurve.Dispose();

            // Draw from the background image onto the screen.
            gr.DrawImage(DoubleBufferImage, 0, 0);
            gr2.Dispose();
        }
    }
}