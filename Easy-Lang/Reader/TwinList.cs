using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace f
{
    public partial class TwinList : UserControl
    {
        JSInjection.СhromeView web_view;
        HtmlController m_HtmlController;
        //public HtmlController HtmlControllerInst { get { return m_HtmlController; } }

        public TwinList()
        {
            InitializeComponent();
            this.ListNative.List.ShowToolTip = true;

            this.Load += TwinList_Load;
            this.splitterHor.Paint += new System.Windows.Forms.PaintEventHandler(this.splitterHorizontal_Paint);
            this.splitterVerticalForVideo.Paint += new System.Windows.Forms.PaintEventHandler(this.splitterVertical_Paint);
            this.ListEn.TextReloaded += ListEn_TextReloaded;
        //    this.videoControl1.MinimumSize = new Size(800, 450);
        //    this.videoControl1.mainMenu1.CountRepeat = 1;
            this.videoControl1.mainMenu1.InitHost(this.ListEn);
        }

        #region html
        void TwinList_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                web_view = new JSInjection.СhromeView();
                web_view.ManifestPrefix = "f";
                this.paVideo.Controls.Add(web_view);
                web_view.Dock = DockStyle.Bottom;
                web_view.Height = 70;

                web_view.JSFiles.Add(@"js\d3.v3.min.js");
                web_view.JSFiles.Add(@"js\scroller.js");
                web_view.CSSFiles.Add(@"css\css.css");
                m_HtmlController = new HtmlController(this);
                web_view.WView.RegisterJsObject("cntrl", m_HtmlController);
                web_view.WView.KeyboardHandler = new KeyHandlerPlayer(this.videoControl1.mainMenu1);
                web_view.URL = "scroller.html";
                web_view.WView.LoadCompleted += web_view_LoadCompletedFinished;
                //old code
                //web_view.ManifestURL = "scroller.html";
                //web_view.LoadCompletedFinished += web_view_LoadCompletedFinished;
            }        
        }

        void web_view_LoadCompletedFinished(object sender, EventArgs e)
        {
            InitScroller();
        }

        void ListEn_TextReloaded(SentenceList sender, EventArgs e)
        {
            InitScroller();
        }

        private void InitScroller()
        {
            if (this.web_view != null && this.ListEn.Sentences.Count > 0 && this.ListEn.Sentences[0] is SentenceVideo)
            {
                string allLength = "";
                foreach (SentenceVideo s in this.ListEn.Sentences)
                {
                    allLength += s.Length.ToString() + ",";
                }
                //if (string.IsNullOrEmpty(viewCn.StarterScript)) //TODO: viewCn == null
                //    this.viewCn.StarterScript = "asignSentences([" + allLength + "])";
                //else 
                    this.web_view.WView.ExecuteScript("asignSentences([" + allLength + "])");
             //   this.HTMLScroller_SelectedIndex = this.ListEn.CurrentSentence.Index - 1;
            }
        }

        public int HTMLScroller_SelectedIndex { 
            set { 
                if( this.web_view.WView.IsBrowserInitialized )
                    this.web_view.WView.ExecuteScript("selectSentence(" + value.ToString() + ")"); 
            }
        }
        #endregion

        public class HtmlController
        {
            //private readonly Action<Action> gui_invoke;
            TwinList Host;
            public HtmlController(TwinList host)
            {
                Host = host;
            }

            public void DoCorrectionForLengths(string lengths, bool doForceReplay)
            {
                string[] newLengths = lengths.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                // TODO: not fine
                if( newLengths.Length != Host.ListEn.Sentences.Count ) return;
                int i = 0;
                double startTime = 0;
                foreach (string l in newLengths)
                {
                    double dl = double.Parse(l);
                    ((SentenceVideo)Host.ListEn.Sentences[i++]).SetLength(startTime, dl);
                    startTime += dl;
                }

                if (doForceReplay // ïðîèãðàåì ñíà÷àëà âñåãäà, íî åñëè äâèãàëè êîíåö ïðåäëîæåíèÿ (doForceReplay == false) è ïëååð åùå èãðàë ñòàðò òåêóùåãî ïðèëîæåíèÿ íå äåëàåì
                    ||  !VideoForm.CurrentVideoContrl.IsPlaying) 
                {
                        Host.Invoke((Action)(() =>
                        {
                        try
                        {
                            ((SentenceListWithVideo)Host.ListEn).PlayCurrentSentence();
                        }
                        finally { }
                    }));
                }

                try { // rewrite allFiles
                    SentenceParser.RewriteSubtitles(Host.ListEn.FileName, Host.ListEn.Sentences);
                }
                catch{
                    //DebugMonitor.
                }
            }

            public void Play(double indSentence)
            {
                Host.Invoke((Action)(() =>
                {
                    try
                    {
                //        m_TwinList.ListEn.IsOnlySynch = true;
                        Host.ListEn.SafeSelectedIndex = (int)indSentence;
                    }
                    finally
                    {
                //        m_TwinList.ListEn.IsOnlySynch = false;
                    }
                }));

                //m_TwinList.ListEn.SafeSelectedIndex = (int)indSentence; // double
            }

        }


        #region GUI && controls
        // int oldWidth = -1;
        // int oldHeight = -1;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustSize();
        }

        void AdjustSize()
        {
            //if (!this.ListNative.Visible) return;
            //if (oldWidth != -1 && oldWidth != this.Width)
            //{
            //    //int newWidth = (this.Width - this.splitterVertical.Width - this.Padding.Right - this.Padding.Left) / 3;
            //    //this.ListNative.Width = newWidth;
            //    int increment = (this.Width - oldWidth) / 2;
            //    this.ListEn.Width = oldWidth + increment;
            //}
            //oldWidth = this.Width;
        }

        private void splitterHorizontal_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawHorizontal(sender as Splitter, e);
        }

        private void splitterVertical_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawVertical(sender as Splitter, e);
        } 
        #endregion

        internal void Synchronize()
        {
            this.ListNative.SafeSelectedIndex = this.ListEn.SafeSelectedIndex;// +this.ListNative.Indent;
        }

        public bool ShowParrallelSubtitles
        {
            get { return this.ListNative.Visible;  } 
            set{
                // perhaps here is to make alignment ???
                this.splitterHor.Visible = 
                this.ListNative.Visible = value;
                //this.oldWidth = 0;
                this.AdjustSize();
            }
        }
    }
}
