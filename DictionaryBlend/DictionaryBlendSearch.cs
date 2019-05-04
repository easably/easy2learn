using System;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public partial class MainForm : Form, ITextWithSelection
    {
        IWaitingUIObject waitingUIObject;

        public MainForm()
        {
            InitializeComponent();
            waitingUIObject = new WaitingUIObjectWithFinish(this, this.pictureBoxWating, null);
            CurrentLangInfo.ChangedLanguageDirection += new EventHandler(Common_ChangedLanguageDirection);
            this.RestoreState();
            this.FormClosed += new FormClosedEventHandler(Tutor_FormClosed);
            FillDictionaries();
        }

        private void FillDictionaries()
        {
            DictCollection.InitMenuForProviders(toolStripDictionary.Items, this, webBrowser1);
            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                if (item is ToolStripButton)
                    item.Click += new EventHandler(item_Click);
                // item.c = true;
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            RegisterEvent();
            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                if ((item is ToolStripButton) && ((ToolStripButton)item).Checked)
                    ((ToolStripButton)item).Checked = false;
            }
            ((ToolStripButton)sender).Checked = true;
        }
        
        private void btSearch_Click(object sender, EventArgs e)
        {
            ToolStripButton lastDictionary = null;
            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                if ((item is ToolStripButton) && ((ToolStripButton)item).Checked)
                    lastDictionary = (ToolStripButton)item;
            }
                        
            if (lastDictionary != null)
            {
                DictCollection.miDict_Click(lastDictionary, EventArgs.Empty);
            }
            else
            // using (WaitCursor wc = new WaitCursor())
            {
                string[] langPairs = LangPair.Split(CurrentLangInfo.PairSeparator);
                new Gator.GatorStarter(this.Word, langPairs[0], langPairs[1], waitingUIObject);
                //                bool f = (new Gator()).ShowArticles(this.Word, langPairs[0], langPairs[1], this);
                RegisterEvent();
            }
        }

        #region RegisterEvent
        private void RegisterEvent()
        {
            if (this.comboBox.Items.Contains(this.Word))
                this.comboBox.Items.Remove(this.Word);
            this.comboBox.Items.Add(this.Word);
            UpdateFormCaption();
        }

        string caption = "'{0}' - Dictionary Blend ({1})";
        private void UpdateFormCaption()
        {
            this.Text = string.Format(caption, this.Word, m_LangPair);
        } 
        #endregion

        #region save and restore
        public void RestoreState()
        {
            try
            {
                // ---- LanguageDirection ----
                CF.AssignValues("MainForm", this);
                CurrentLangInfo.LanguageDirection = CF.GetValue("LanguageDirection", CurrentLangInfo.DefaultLangDir);
                CurrentLangInfo.InitLanguagesMenu(this.miLanguages);
            }
            catch
            { //TODO: add mesage for detail about urestored state
            }
        }

        void Tutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            CF.SetValue("MainForm", this);
            CF.SetValue("LanguageDirection", this.LangPair);
            CF.Config.Save(); //  (System.Configuration.ConfigurationSaveMode.Full);
        }
        #endregion

        #region LangPair
        void Common_ChangedLanguageDirection(object sender, EventArgs e)
        {
            this.LangPair = CurrentLangInfo.LanguageDirection;
            UpdateFormCaption();
            DictCollection.CheckDictionariesForLanguage(this.LangPair, toolStripDictionary.Items);
            // TODO: Search
        }

        private string m_LangPair = CurrentLangInfo.DefaultLangDir;
        public string LangPair
        {
            get { return m_LangPair; }
            set
            {
                m_LangPair = value;
                UpdateFormCaption();
            }
        } 
        #endregion

        #region Word & UpdateFormCaption
        public string Word
        {
            set
            {
                this.comboBox.Text = value;
            }
            get
            {
                return this.comboBox.Text;
            }
        }

        private void cb_TextChanged(object sender, EventArgs e)
        {
            toolStripDictionary.Enabled = !string.IsNullOrEmpty(this.Word);
        }

        private void cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && toolStripDictionary.Enabled)
            {
                btSearch_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region ITextWithSelection Members

        public string CurrentLowerWord
        {
            get { return this.comboBox.Text.ToLower(); }
        }

        public LangPair LangDir
        {
            get { return new LangPair(this.LangPair); }
        }
        #endregion
    }
}
