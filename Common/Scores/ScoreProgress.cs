using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class ScoreProgress : UserControl
    {
        public ScoreProgress()
        {
            InitializeComponent();
            Maximum = 50;
            this.TabStop = false;
        }

        ScoreData m_ScoreData = null;
        public ScoreData ScoreData
        { 
            set { 
                if( m_ScoreData != null) 
                    m_ScoreData.StateChange -=new EventHandler(m_ScoreData_StateChange);
                m_ScoreData = value;
                if (m_ScoreData != null)
                {
                    m_ScoreData.StateChange += new EventHandler(m_ScoreData_StateChange);
                    m_ScoreData_StateChange(null, EventArgs.Empty);
                }
                else
                {
                    this.ResetProgress();
                }
            }
            get { return m_ScoreData; }
        }

        void  m_ScoreData_StateChange(object sender, EventArgs e)
        {
            try {
                this.BeginUpdate();
                this.Errors = m_ScoreData.CurErrors + m_ScoreData.PrevErrors;
                this.Hints = m_ScoreData.CurHints + m_ScoreData.PrevHints;
                this.Passes = m_ScoreData.CurPasses + m_ScoreData.PrevPasses;
                this.Maximum = m_ScoreData.MaxScrore + GetMaximum(m_ScoreData.PrevErrors, m_ScoreData.PrevHints, m_ScoreData.PrevPasses);
            }
            finally {
                this.EndUpdate();
            }
        }

        int m_Maximum;
        public int Maximum
        {
            get { return this.m_Maximum; }
            set {
                if (this.m_Errors != value) {
                    m_Maximum = value; 
                    this.UpdateInfo();
                }
            }
        }

        #region Values
        int m_Errors;
        public int Errors
        {
            get {
                return m_Errors;
            }
            set {
                if (this.m_Errors != value)
                {
                    this.m_Errors = value;
                    this.UpdateInfo();
                }
            }
        }

        int m_Hints;
        public int Hints
        {
            get {
                return m_Hints;
            }
            set {
                if (this.m_Hints != value)
                {
                    this.m_Hints = value;
                    this.UpdateInfo();
                }
            }
        }

        int m_Passes;
        public int Passes
        {
            get {
                return m_Passes;
            }
            set {
                if (this.m_Passes != value)
                {
                    this.m_Passes = value;
                    this.UpdateInfo();
                }
            }
        } 
        #endregion

        public String ToolTipPrefix;

        //float fWE, fWH, fWP = 0;
        int fWEr, fWHint, fWPs = 0;
        int fWErPrev, fWHintPrev, fWPsPrev = 0;
        void UpdateInfo()
        {
            this.toolTip1.SetToolTip(this, GetScoreInfo()); 
            
            fWEr = GetWidth(this.Errors);
            fWHint = GetWidth(this.Hints);
            fWPs = GetWidth(this.Passes);
            if (this.ScoreData == null)
                fWErPrev = fWHintPrev = fWPsPrev = 0;
            else
            {
                fWErPrev = this.ScoreData.CurErrors == 0 ? 0 : GetWidth(this.ScoreData.PrevErrors);
                fWHintPrev = this.ScoreData.CurHints == 0 ? 0 : GetWidth(this.ScoreData.PrevHints);
                fWPsPrev = this.ScoreData.CurPasses == 0 ? 0 : GetWidth(this.ScoreData.PrevPasses);
            }
            if (updateCount == 0)
                this.Invalidate();
        }

        private int GetWidth(int value)
        {
            if (value == 0) return 0;
            float precent = (float)value / this.Maximum; // 61/100=0  !=  61.0/100 = 0.61   ===>>> (float)61/100=0.61
            int res = (int)(this.Width * precent);
            if (res == 0 && precent > 0)
                return 1;
            return res;
        }

        #region Drawing
        public static Color ColorErrors = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        public static Color ColorHints = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        public static Color ColorPasses = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));

        private void ScoreProgress_Paint(object sender, PaintEventArgs e)
        {
            Brush brushBackRound = new SolidBrush(Color.White);
            
            int h = this.Height / 3;
            drawSolidBar(e.Graphics, ColorErrors, 0, 0, fWEr, h, brushBackRound);
            DrawPrevLine(e, fWErPrev, 0, h);

            drawSolidBar(e.Graphics, ColorHints, 0, h, fWHint, h, brushBackRound);
            DrawPrevLine(e, fWHintPrev, h, h*2);

            int twoH = h * 2;
            h = this.Height - twoH;
            drawSolidBar(e.Graphics, ColorPasses, 0, twoH, fWPs, h, brushBackRound);
            DrawPrevLine(e, fWPsPrev, twoH, twoH + h);
        }

        private void DrawPrevLine(PaintEventArgs e, int xPrevLine, int y, int yLineEnd)
        {
            if (xPrevLine != 0) 
                e.Graphics.DrawLine(Pens.Gray, xPrevLine, y, xPrevLine, yLineEnd-1);
        }

        private void drawSolidBar(Graphics gr, Color color, int x, int y, int width, int height, Brush brushBackRound)
        {
            gr.FillRectangle(new SolidBrush(color), x, y, width, height);
            if (width > 3)
                Ul.DoSmoothAngle(gr, brushBackRound, new Rectangle(x, y, width, height));
        }
        #endregion

        #region BeginUpdate
        int updateCount = 0;

        public void BeginUpdate()
        {
            updateCount += 1;
        }

        public void EndUpdate()
        {
            updateCount -= 1;
            if (updateCount == 0) this.Invalidate();
        } 
        #endregion

        static int GetMaximum(int i1, int i2, int i3)
        {
            return Math.Max(Math.Max(i1, i2), Math.Max(i2, i3));
        }

        public void ResetProgress()
        {
            this.Errors =
            this.Hints =
            this.Passes = 0;
        }

        #region ToolTip
        string GetScoreInfo()
        {
            string nl = Environment.NewLine;
            string ret = "";
            if (this.ScoreData != null)
            {
                string values = string.Format("{0} - Errors; {1} - Hints; {2} - Passes",
                    this.ScoreData.CurErrors, this.ScoreData.CurHints, this.ScoreData.CurPasses);
                string prevValues = "";
                if (this.ScoreData.PrevPasses > 0 || this.ScoreData.PrevHints > 0 || this.ScoreData.PrevPasses > 0)
                    prevValues = string.Format("{0} - Errors; {1} - Hints; {2} - Passes",
                        this.ScoreData.PrevErrors, this.ScoreData.PrevHints, this.ScoreData.PrevPasses);
                //if (this.ScoreData.PrevErrors > 0)
                //    prevValues = string.Format(nl + " {0} - Errors; ", this.ScoreData.PrevErrors);
                //if (this.ScoreData.PrevHints > 0)
                //    prevValues += string.Format(nl + " {0} - Hints; ", this.ScoreData.PrevHints);
                //if (this.ScoreData.PrevPasses > 0)
                //    prevValues += string.Format(nl + " {0} - Passes; ", this.ScoreData.PrevPasses);

                if (!string.IsNullOrEmpty(this.ToolTipPrefix))
                    ret = this.ToolTipPrefix + nl;
                ret += nl + "Current score: " + nl + values;
                if (!string.IsNullOrEmpty(prevValues))
                    ret += nl + nl + "Previous score: " + nl + prevValues;
            }
            return ret;
        }

        private void ScoreProgress_MouseClick(object sender, MouseEventArgs e)
        {
            //    this.toolTip1.Show(GetScoreInfo(), this, this.toolTip1.InitialDelay, e.X, e.Y);
            this.toolTip1.Show(GetScoreInfo(), this);
        } 
        #endregion
    }
}
