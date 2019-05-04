using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace f.key
{
    public partial class MainMenu : UserControl, IActionPlayerHost
    {
        public MainMenu()
        {
            InitializeComponent();
            this.btPrev.Click += delegate { PlayPrev(); };
            this.btNext.Click += delegate { PlayNext(); };
            this.btRepeat.ButtonClick += delegate { RePlay(); };

            this.miRepOnce.Click += miRepThrice_Click;
            this.miRepTwice.Click += miRepThrice_Click;
            this.miRepThrice.Click += miRepThrice_Click;

            this.miVideoRate.Click += new EventHandler(miVideoRate_Click);
            CurrentLangInfo.ChangedLanguageDirection += delegate { InitButtonsByCurrentLanguages(); };
            InitButtonsByCurrentLanguages();
        }

        #region visual states
        public void SubscribeOnEvents()
        {
            T.ReaderFormInstance.reader.TwinList.ListEn.TextReloaded += delegate { InitToolTipForButtons(); };
            T.ReaderFormInstance.reader.TwinList.ListNative.TextReloaded += delegate { InitToolTipForButtons(); };
        }

        private void InitToolTipForButtons()
        {
            this.miFromList.Enabled = !string.IsNullOrEmpty(T.ReaderFormInstance.reader.TwinList.ListEn.FileName);
            this.miFromList.ToolTipText = this.miFromAndToList.Enabled ? string.Format("Show list from file {0}", T.ReaderFormInstance.reader.TwinList.ListEn.FileName) : "";

            this.miFromAndToList.Enabled = !string.IsNullOrEmpty(T.ReaderFormInstance.reader.TwinList.ListNative.FileName);
            this.miFromAndToList.ToolTipText = this.miFromAndToList.Enabled ? string.Format("Show list from file {0}", T.ReaderFormInstance.reader.TwinList.ListNative.FileName) : "";
        }

        private void InitButtonsByCurrentLanguages()
        {
            miFromList.Text = CurrentLangInfo.CurrentLangPair.From;
            miFromAndToList.Text = miFromList.Text + "+" + CurrentLangInfo.CurrentLangPair.To;
        }
        
        #endregion
        SentenceListWithVideo ParentList;
        public void InitHost(SentenceListWithVideo parentList)
        {
            if (parentList == null) throw new ArgumentNullException("parentList");
            this.ParentList = parentList;
            this.ParentList.TextReloaded += delegate { CheckButtonsState(); };
            CheckButtonsState();
        }

        public void CheckButtonsState()
        {
            bool isHaveSentensec = ParentList.List.Items.Count > 1;
            this.btPrev.Enabled =
            this.btNext.Enabled = isHaveSentensec;

            // в этот момент  Utils.VideoFormIsAccesible равно true
            this.btRepeat.Enabled = !string.IsNullOrEmpty(ParentList.VideoFileName) && ParentList.CurrentSentence != null;

            //this.btRepeat.Enabled = VideoForm.IsAccesibleCurrent && isHaveSentensec;
            //this.btRepeat.Enabled = this.btNext.Enabled && this.btRepeat.Enabled;
        }

        #region CountRepeat
        int m_CountRepeat = 1;
        public int CountRepeat { get { return m_CountRepeat; } set { m_CountRepeat = value; } }

        void miRepThrice_Click(object sender, EventArgs e)
        {
            if (sender == this.miRepOnce)
                RePlay(22);
            else if (sender == this.miRepTwice)
                RePlay(2);
            else if (sender == this.miRepThrice)
                RePlay(3);
        }
        #endregion

        #region IActionPlayerHost
        public void RePlay(int i)
        {
            this.ParentList.PlayCurrentSentence(i);
        }

        public void RePlay()
        {
            this.ParentList.PlayCurrentSentence(0);
        }

        public void PlayNext()
        {
            ++this.ParentList.SafeSelectedIndex;
            CheckButtonsState();
        }

        public void PlayPrev()
        {
            --this.ParentList.SafeSelectedIndex;
            CheckButtonsState();
        }

        public void Play()
        {
            VideoForm.CurrentVideoContrl.PlayOrPause();
        }

        public void Pause()
        {
            VideoForm.CurrentVideoContrl.PlayOrPause();
        }
        #endregion


        VideoRateForm m_VideoRateForm = null;

        void miVideoRate_Click(object sender, EventArgs e)
        {
            if (this.m_VideoRateForm == null)
                this.m_VideoRateForm = new VideoRateForm();
            m_VideoRateForm.Rate = VideoForm.CurrentVideoContrl.PlaybackRate;
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                if (m_VideoRateForm.ShowDialog() == DialogResult.Yes)
                    VideoForm.CurrentVideoContrl.PlaybackRate = m_VideoRateForm.Rate;
            }
        }

        private void miFromList_Click(object sender, EventArgs e)
        {
            ToolStripButton mi = (ToolStripButton)sender;
            ToolStripButton miOther = mi.Equals(miFromList) ? miFromAndToList : miFromList;
            if (mi.Checked) mi.Checked = false;
            else if (miOther.Checked) // mi.Checked == false
            {
                miOther.Checked = false;
                mi.Checked = true;
            }
            else
            {
                mi.Checked = true;
            }
            UpdateListState();
        }

        private void UpdateListState()
        {
            T.ReaderFormInstance.reader.TwinList.splitterVerticalForVideo.Visible = 
            T.ReaderFormInstance.reader.TwinList.paLists.Visible = miFromList.Checked || miFromAndToList.Checked;

           // будет только по дабл клику   T.ReaderFormInstance.reader.TwinText.textForeignAndTran.ShowParrallelText =           
            T.ReaderFormInstance.reader.TwinList.ShowParrallelSubtitles = miFromAndToList.Checked;
        }

        private void btFiles_Click(object sender, EventArgs e)
        {
            if (ReaderForm.FileSelectorInstance.Visible)
                ReaderForm.FileSelectorInstance.Activate();
            else ReaderForm.FileSelectorInstance.Show();
        }
    }
}
