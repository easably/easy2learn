using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace f
{
    public partial class MenuForSelected : UserControl
    {
        public MenuForSelected()
        {
            InitializeComponent();
            this.btAddWordToLesson.Click += new System.EventHandler(this.btAddWordToLesson_Click);
            this.miPopupWindow.CheckedChanged += new EventHandler(miPopupWindow_CheckedChanged);
            this.miPopupAsMonoDictionary.CheckedChanged += new EventHandler(miPopupAsMonoDictionary_CheckedChanged);
            this.btFindSynonyms.Click += new EventHandler(btFindSynonyms_Click);
            CurrentLangInfo.ChangedLanguageDirection += new EventHandler(Common_ChangedLanguageDirection);

            this.miEditDictionaryBlendOptions.Click += new System.EventHandler(this.miEditDictionaryBlendOptions_Click);
            this.btOpenInLast.Click += new System.EventHandler(this.btOpenInLast_Click);
            this.btFindInDictionaryBlend.Click += new System.EventHandler(this.btFindInDictionaryBlend_Click);
            this.miHideTranslation.CheckStateChanged += new System.EventHandler(this.miHideTranslation_CheckStateChanged);

            this.IsWordAavailable = false;            
            // а то слишком сложно
            this.miGetWordToTutor.Visible = false;
        }

        void miPopupAsMonoDictionary_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TextsForMenu != null)
            {
                this.TextsForMenu.ForeingTextBox.IsMonoRegim = this.UseGoogleAsMonoDictionary;
            }
        }

        void Common_ChangedLanguageDirection(object sender, EventArgs e)
        {
            DictCollection.CheckDictionariesForLanguage(CurrentLangInfo.LanguageDirection, this.btOpenIn.DropDownItems);
            if (lastDictionary != null)
                btOpenInLast.Enabled = this.IsWordAavailable && ((RunDictContent)lastDictionary.Tag).Providers[0].IsSupport(CurrentLangInfo.LanguageDirection);
        }

        #region ShowSynonyms
        void btFindSynonyms_Click(object sender, EventArgs e)
        {
            Runner.OpenURL(string.Format(@"https://www.google.com/search?q={0}&tbm=isch", this.TextsForMenu.ActiveTextBox.CurrentWord));
           // ShowSynonyms(this.TextsForMenu.ActiveTextBox);
        }

        void ShowSynonyms(TipTextBox textBox)
        {
            if (textBox == null) { MessageBox.Show("Current editor is missing"); return; }

            GoogleSynonymsDictionary dict = new GoogleSynonymsDictionary();
            if (string.IsNullOrEmpty(dict.GetContainsSourceLanguage(textBox.LangDir.From)))
            { MessageBox.Show(string.Format("Language {0} is missing for dictionary", textBox.LangDir.From)); return; }

            int start = textBox.SelectionStart;
            int end = start;

            string word = TipTextBox.GetWord(textBox, ref start, ref end);
            string titledWord = word;
            
            if (word.Contains(SentenceForLesson.CharHided))
            {
                if (textBox.Sentence == null) { MessageBox.Show("Current sentence is missing"); return; }
                word = TipTextBox.GetClearWord(textBox.Sentence, start, end);
            }

            if (!string.IsNullOrEmpty(word))
            {
                FloatWebBrowserForm browserForm = new FloatWebBrowserForm();
                browserForm.HTMLContent = dict.GetContent(word, textBox.LangDir);
                browserForm.Text = string.Format("Synonyms for '{0}'", titledWord);
                browserForm.Show(this);
            }
        } 
        #endregion

        void miPopupWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TextsForMenu != null)
            {
                foreach( TipTextBox tx in this.TextsForMenu.AllTextBox )
                    tx.IsShowPopup = this.IsShowPopupWindow;
            }
        }

        private void miHideTranslation_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.TextsForMenu != null)
            {
                //foreach (TipTextBox tx in this.TextsForMenu.TranslTextBoxs)
                //    tx.IsHidedTranslation = this.miHideTranslation.Checked;

                GoogleDictionary.Instance.IsHidedTrans = this.miHideTranslation.Checked;
                if (HideTranslationStateChanged != null)
                    HideTranslationStateChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler HideTranslationStateChanged;

        #region ITextsForMenu && IActionsWithText
     
        ITextsForMenu m_TextsForMenu;
        public ITextsForMenu TextsForMenu
        {
            get { return m_TextsForMenu; }
            set {
                    if ((value != null) && (value.ForeingTextBox != null))
                    {
                        value.ForeingTextBox.SelectionChanged += new EventHandler(TextBox_SelectionChanged);

                        // only for txForeign, but listen function available also in txTranslate
                        this.btListenSelected.Click += new EventHandler(btListenSelected_Click);
                        value.ForeingTextBox.MouseClick += new MouseEventHandler(btListenSelected_Click);
                        value.ForeingTextBox.ChangeLangDir += new EventHandler(txForeign_ChangeLangDir);
                        value.ForeingTextBox.SelectionChanged += new EventHandler(textEn_SelectionChanged);
                    }
                    else if ((value == null) && (m_TextsForMenu != null) && (m_TextsForMenu.ForeingTextBox != null))
                    {
                        m_TextsForMenu.ForeingTextBox.SelectionChanged -= new EventHandler(TextBox_SelectionChanged);
                        this.btListenSelected.Click -= new EventHandler(btListenSelected_Click);
                        value.ForeingTextBox.MouseClick -= new MouseEventHandler(btListenSelected_Click);

                        value.ForeingTextBox.ChangeLangDir -= new EventHandler(txForeign_ChangeLangDir);
                        value.ForeingTextBox.SelectionChanged -= new EventHandler(textEn_SelectionChanged);
                    }
                    m_TextsForMenu = value;
                }
        }

        void TextBox_SelectionChanged(object sender, EventArgs e)
        {
            //   this.btAddWordToLesson.Enabled = this.IsWordAavailable && ((TipTextBox)sender).SelectedText.Length > 0;
        }

        #region for ForeignText Listen
        void txForeign_ChangeLangDir(object sender, EventArgs e)
        {
            this.btListenSelected.Enabled = this.IsWordAavailable && ((TipTextBox)sender).IsAvailableListen;
        }

        void textEn_SelectionChanged(object sender, EventArgs e)
        {
            //TipTextBox txBox = (TipTextBox)sender;
            //if (txBox.IsAvailableListen)
            //{
            //    if (txBox.SelectedText.Length > 0)
            //        // т.к. нельзя озвучиьт фразу
            //        this.btListenSelected.Enabled = this.IsWordAavailable && txBox.SelectedText.Trim().IndexOf(" ") == -1;
            //    else this.btListenSelected.Enabled = true;
            //}
        }

        void btListenSelected_Click(object sender, EventArgs e)
        {
            if (this.IsListenByClick)
            {
                this.TextsForMenu.ActiveTextBox.ListenCurrentWord();
                if(string.IsNullOrEmpty(this.TextsForMenu.ActiveTextBox.SelectedText))
                    this.TextsForMenu.ActiveTextBox.SelectCurrentWord();
            }
        }
        #endregion

        IActionsWithText m_ActionsWithText;
        public IActionsWithText ActionsWithText
        {
            set
            {
                m_ActionsWithText = value;
                this.EnabledAddWords = m_ActionsWithText != null;
            }
        }

        private void btAddWordToLesson_Click(object sender, EventArgs e)
        {
            if (m_ActionsWithText != null)
                m_ActionsWithText.AddToLesson();
        }        
        #endregion

        private void miEditDictionaryBlendOptions_Click(object sender, EventArgs e)
        {
    //        using (new AbandonTopPosition(this))
                (new Options()).ShowDialog();
        }

        #region props settings
        public bool IsAutoHideTranslation
        {
            get { return this.miHideTranslation.Checked; }
            set { this.miHideTranslation.Checked = value; }
        }

        public bool IsShowPopupWindow
        {
            get { return this.miPopupWindow.Checked; }
             set { this.miPopupWindow.Checked = value; }
        }

        public bool IsListenByClick
        {
            get { return this.miListenByClick.Checked; }
             set { this.miListenByClick.Checked = value; }
        }

        public bool IsAddWordToTutor
        {
            get { return this.miGetWordToTutor.Checked; }
             set { this.miGetWordToTutor.Checked = value; }
        }

        public bool UseGoogleAsMonoDictionary
        {
            get { return this.miPopupAsMonoDictionary.Checked; }
             set { this.miPopupAsMonoDictionary.Checked = value; }
        }
        #endregion

        bool EnabledAddWords { 
            set { 
                this.btAddWordToLesson.Visible = 
                    this.toolStripSeparator1.Visible = 
                    this.miGetWordToTutor.Visible = value; 
            } 
        }

        private void btFindInDictionaryBlend_Click(object sender, EventArgs e)
        {
            OpenInDictionaryBlend(this.TextsForMenu.ActiveTextBox.CurrentWord);
        }

        public static void OpenInDictionaryBlend(string word)
        {
            if (string.IsNullOrEmpty(word)) return;

            string fileName = FileManager.FindPathAndReturnFullFileName("dictionaryblend.exe");
            if( File.Exists(fileName) )
            {
                ProcessStartInfo info = new ProcessStartInfo(fileName, word);
                Process.Start(info);
            }
        }

        #region LastDict
        ToolStripItem lastDictionary = null;

        public void InitDictionaries(ITextWithSelection text)
        {
            DictCollection.InitMenuForProviders(this.btOpenIn.DropDownItems, text, null);
            foreach (ToolStripItem item in this.btOpenIn.DropDownItems)
                item.Click += new EventHandler(item_Click);
        }

        void item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem && ((ToolStripItem)sender).Tag is RunDictContent)
            {
                lastDictionary = (ToolStripItem)sender;
                this.toolStripSeparatorForSearchInLast.Visible =
                btOpenInLast.Visible = true; // _btOpenInLast.Enabled
                btOpenInLast.Enabled = this.IsWordAavailable;
                btOpenInLast.Text = string.Format("Find in '{0}'", ((ToolStripItem)sender).Text);
            }
        }

        #region LastDictName
        public string LastDictName
        {
            get {
                if (lastDictionary != null && lastDictionary.Tag is RunDictContent)
                    return ((RunDictContent)lastDictionary.Tag).Providers[0].ToString();
                else return GoogleDictionary.MainTitle;
            }
            set { AssignLastDict(value); }
        }

        void AssignLastDict(string dictionaryProviderName)
        {
            foreach (ToolStripItem item in this.btOpenIn.DropDownItems)
            {
                if (item is ToolStripItem && ((ToolStripItem)item).Tag is RunDictContent)
                {
                    RunDictContent content = (RunDictContent)((ToolStripItem)item).Tag;
                    if( content.Providers.Count == 1 && content.Providers[0].ToString().Equals(dictionaryProviderName))
                    {
                        item_Click(item, EventArgs.Empty);
                        break;
                    }
                }
            }
        } 
        #endregion

        private void btOpenInLast_Click(object sender, EventArgs e)
        {
            OpenInLast();
        }

        public void OpenInLast()
        {
            if (lastDictionary != null)
                using (new WaitCursor())
                    DictCollection.Dict_Click(lastDictionary, EventArgs.Empty);
        }
        #endregion

        bool m_IsWordAavailable = false;
        public bool IsWordAavailable
        {
            set {
                m_IsWordAavailable =
                this.btAddWordToLesson.Enabled = 
                this.btListenSelected.Enabled = 
                this.btOpenInLast.Enabled =
                this.btOpenIn.Enabled =
                this.btFindSynonyms.Enabled = value;
            }
            get { return m_IsWordAavailable; }            
        }

        public void SwitchOfAddWordsToLesson()
        {
            this.btAddWordToLesson.Visible =
            this.toolStripSeparator1.Visible = false;
        }
    }
}
