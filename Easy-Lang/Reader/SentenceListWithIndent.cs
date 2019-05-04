using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class SentenceListWithIndent : SentenceList
    {
        public SentenceListWithIndent()
        {
            InitializeComponent();
            this.btTranslate.Visible = false;
            this.btText.ToolTipText = "Here parallel subtitles or notes";
            this.btOpen.Click += new System.EventHandler(this.miOpenText_Click);
            this.List.MouseDoubleClick += delegate { T.ReaderFormInstance.reader.TwinText.textForeignAndTran.ShowParrallelText = !T.ReaderFormInstance.reader.TwinText.textForeignAndTran.ShowParrallelText; };
        }

        #region Indent & TimeIndent
        int m_Indent = 0;
        public int Indent
        {
            set
            {
                this.m_Indent = value;
                RefreshLabelIndent();
            }
            get
            {
                return this.m_Indent;
            }
        }

        double m_TimeIndent = 0;
        public double TimeIndent
        {
            set
            {
                this.m_TimeIndent = value;
                RefreshLabelIndent();
            }
            get
            {
                return 0; // this.m_TimeIndent;
            }
        } 
        #endregion

        void RefreshLabelIndent()
        {
            if (string.IsNullOrEmpty(this.FileName))
            {
                this.toolStripLabelIndent.Visible = false;
                return;
            }

            string indentInfo;
            if (this.TimeIndent > 1 || this.TimeIndent < -1)
                indentInfo = string.Format("TimeShift: {0}{1} sec.", (this.TimeIndent > 0 ? "+ " : ""), Math.Round(this.TimeIndent));
            else // это текстовое смещение
            { 
                indentInfo = string.Format("Shift: {0}{1}", (this.m_Indent > 0 ? "+ " : ""), this.Indent);
            }
            if(string.IsNullOrEmpty(indentInfo))
                this.toolStripLabelIndent.Visible = false;
            else
            {
                this.toolStripLabelIndent.Text = indentInfo;
                this.toolStripLabelIndent.Visible = true;
            }
        }

        public void SetSafeSelectedIndexWithIndent(int index, Sentence sentence)
        {
            //if (this.IsOpenWithSubtitles && sentence is SentenceVideo)
            //{
            //    //TODO: выключено в следующей строке возможность смещения при синхронизации в первых субтитрах (т.к. получается что TimeIndent всегда инкременируется)
            //    double originalStart = ((SentenceVideo)sentence).Start;//  +this.TimeIndent;
            //    originalStart += ((SentenceVideo)sentence).Length / 2;
            //    int ind = SentenceListWithVideo.GetIndexByVideoTime(originalStart, this.Sentences);
            //    if (ind != -1)
            //        this.SafeSelectedIndex = ind;
            //}
            //else 
                this.SafeSelectedIndex = index + this.Indent;
        }
    }
}
