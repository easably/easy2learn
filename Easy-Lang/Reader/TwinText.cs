using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace f
{
    public partial class TwinText : UserControl, IActionsWithText, ITextsForMenu, ITextWithSelection
    {
        public delegate void DelegateShowArticles(RichTextBox textBox);

        public TwinText()
        {
            InitializeComponent();

            // context menu
            //this.miListenSelected.Image = global::f.button_images.speaker1;
            //this.miCitationsForWord.Image = global::f.button_images.find;
            //this.miArticlesForSelected.Image = global::f.button_images.two;
            //this.miOpenIn.Image = global::f.button_images.One;
            //this.miCitationsForWord.Image = global::f.button_images.find_citations;

            //this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);

            //TODO: здесь методы изменю котрые методы надо убить
            //this.miArticlesForSelected.Click += new System.EventHandler(this.miArticlesForSelected_Click);
            //this.miCitationsForWord.Click += new System.EventHandler(this.miCitationsForWord_Click);
            //this.miCopy.Click += new System.EventHandler(this.miCopy_Click);

            //this.miShowLeftText.CheckStateChanged += new System.EventHandler(this.miShowLeftText_CheckStateChanged);

            //Init_miOpenIn(this.miOpenIn.DropDownItems);

            this.textForeignAndTran.ForeignText.HideSelection = false; // в textEn должно подсвечиваться то, что переведено в TextTranslate
            this.textNative.ReadOnly = true;
            this.textForeignAndTran.paForeignText.Controls.Add(this.textNative);

            #region events for texts
            this.textForeignAndTran.ForeignText.ManualTextChanged += new System.EventHandler(this.textEn_ManualTextChanged);
            this.textNative.ManualTextChanged += new System.EventHandler(this.textEn_ManualTextChanged);

            this.textForeignAndTran.ForeignText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEn_KeyDown);
            this.textNative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEn_KeyDown);

            this.textForeignAndTran.ForeignText.MouseDoubleClick += new MouseEventHandler(ForeignText_MouseDoubleClick);
            #endregion

            InitMenuForSelected();
            this.SetUpLangDir = this.LangDir;

            //this.Leave += new EventHandler(TwinText_Leave);
            //this.GotFocus += new EventHandler(TwinText_GotFocus);
            // textForeignAndTran
            this.textForeignAndTran.ForeignText.TextChanged += new EventHandler(ForeignText_TextChanged);
            this.textForeignAndTran.ForeignText.Leave += new EventHandler(TwinText_Leave);
            this.textForeignAndTran.ForeignText.GotFocus += new EventHandler(TwinText_GotFocus);
        }

        void ForeignText_TextChanged(object sender, EventArgs e)
        {
            if ( !this.textForeignAndTran.ForeignText.Focused )
                this.MenuForSelected.IsWordAavailable = false; 
        }

        void TwinText_GotFocus(object sender, EventArgs e)
        {
            this.MenuForSelected.IsWordAavailable = true; 
        }

        void TwinText_Leave(object sender, EventArgs e)
        {
       //     if (this.ActiveTextBox != null && this.ActiveTextBox.SelectedText.Length == 0)
            if (this.textForeignAndTran.ForeignText.SelectedText.Length == 0)
                this.MenuForSelected.IsWordAavailable = false;
        }

        internal void Initialize(SentenceListWithVideo sentenceList,
            SentenceListWithIndent sentenceListWithIndent, IWaitingUIObject waitingUiObject)
        {
            //m_WaitingUiObject = waitingUiObject;
            m_EnList = sentenceList;
            m_NativeList = sentenceListWithIndent;
            //   new DebugMonitor() { WatchObject = this }.Show();
        }

        #region m_MenuForSelecteden && Init
        internal void InitMenuForSelected()
        {
            this.MenuForSelected.ActionsWithText = this;
            this.MenuForSelected.TextsForMenu = this;
            this.MenuForSelected.InitDictionaries(this);
        }
        #endregion

        #region OLD old OLD old !!!!!!!!!!
        //private void contextMenu_Opening(object sender, CancelEventArgs e)
        //{
        //    string word = this.CurrentWordLower;
        //    miListenSelected.Enabled =
        //    miArticlesForSelected.Enabled =
        //    miCitationsForWord.Enabled = !string.IsNullOrEmpty(word);
        //    miCitationsForWord.Text = string.Format("&Find Citations in Text for '{0}'", word);
        //    miCopy.Enabled = !string.IsNullOrEmpty(this.SelectedText);
        //}

        private void miCitationsForWord_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl == this.textForeignAndTran.ForeignText)
                this.EnList.FindCitationsForWordAndShow();
            else if (this.ActiveControl == this.textNative)
                this.NativeList.FindCitationsForWordAndShow();            
        }
        #endregion

        #region props
        RichTextBox lastTextBox = null;
#if DEBUG 
        public 
#endif

        string SelectedText
        {
            get
            {
                // TODO: so-so 
                //if (this.ActiveTextBox != this.textForeignAndTran.translatedText)
                //    lastTextBox = this.ActiveTextBox;
                if (lastTextBox == null)
                {
                    //return "";
                    lastTextBox = this.textForeignAndTran.ForeignText;
                }
                return lastTextBox.SelectedText;
            }
        }

        public Sentence CurrentSentence
        {
            get
            {
                if (this.EnList == null) return null; // for design time

                if (this.ActiveControl == this.textNative)
                    return this.NativeList.CurrentSentence;
                else return this.EnList.CurrentSentence;
            }
        }

        SentenceListWithVideo m_EnList;
        public SentenceListWithVideo EnList
        {
            get { return m_EnList; }
        }

        SentenceList m_NativeList;
        public SentenceList NativeList
        {
            get { return m_NativeList; }
        }
        #endregion

        internal TipTextBox textNative { get { return this.textForeignAndTran.textNative; } }

        #region Navigation
        private void textEn_KeyDown(object sender, KeyEventArgs e)
        {
            SentenceList currentlist = this.EnList;
            if (sender == this.textNative)
                currentlist = this.NativeList;
            if (currentlist == null) return;

            if (currentlist.ReadOnly)
            {
                if (e.KeyData == (Keys.A | Keys.Alt))
                    AddToLesson();
                else if (e.KeyData == (Keys.D | Keys.Alt))
                { 
                    //OpenInDictionaryBlend();
                }
                else if (e.KeyData == (Keys.F1))
                    this.MenuForSelected.OpenInLast();
            }
        } 
        #endregion

        #region text changed
        private void textEn_ManualTextChanged(object sender, EventArgs e)
        {
            if (!((RichTextBox)sender).ReadOnly)
                ApplayChangedTextToSentence((RichTextBox)sender);
        }

        void ApplayChangedTextToSentence(RichTextBox textBox)
        {
            SentenceList sl = this.m_EnList;
            if (textBox == textNative)
                sl = this.m_NativeList;
            sl.CurrentSentence.TextValue = textBox.Text;
            sl.List.Refresh();
        } 
        #endregion

        #region Mouse Actions
        void ForeignText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.MenuForSelected.IsAddWordToTutor)
                AddToLesson();
        }
        #endregion

        #region interfaces

        #region IActionWithText Members
        public void AddToLesson()
        {
            if (this.CurrentSentence == null) return;
            string currentWord = this.textForeignAndTran.ForeignText.CurrentWord;
            if (string.IsNullOrEmpty(currentWord)) return;
            if (this.CurrentSentence.WordsToLearn.Contains(currentWord))
                this.CurrentSentence.RemoveWordsToLearn(currentWord);
            else
                this.CurrentSentence.AddWordsToLearn(currentWord);
            RefreshText();
            try
            {
                T.ReaderFormInstance.reader.TwinList.ListEn.SaveLessonForce(); // только точка желтой остается
            }
            catch { 
            }
        }

        void RefreshText()
        {
            int iStart = this.textForeignAndTran.ForeignText.SelectionStart;
            int iLength = this.textForeignAndTran.ForeignText.SelectionLength;

            this.textForeignAndTran.ForeignText.Rtf = this.CurrentSentence.TextAsRTF;
            this.EnList.List.Refresh();

            this.textForeignAndTran.ForeignText.SelectionStart = iStart;
            this.textForeignAndTran.ForeignText.SelectionLength = iLength;
        }
        #endregion

        #region ITextsForMenu
        public TipTextBox ActiveTextBox
        {
            get
            {
                if (this.textForeignAndTran.ForeignText.SelectedText.Length > 0) return this.textForeignAndTran.ForeignText;
                if (this.ActiveControl == this.textNative)
                    return this.textNative;
                else return this.textForeignAndTran.ActiveTipTextBox;
            }
        }

        public TipTextBox ForeingTextBox
        {
            get { return this.textForeignAndTran.ForeignText; }
        }

        // TODO: was deleted this.textForeignAndTran.TranslateText_del
        //public TipTextBox[] TranslTextBoxs { get { return new TipTextBox[] { this.textForeignAndTran.TranslateText_del, this.textNative }; } }
        //public TipTextBox[] AllTextBox { get { return new TipTextBox[] { this.textForeignAndTran.ForeignText, this.textForeignAndTran.TranslateText_del, this.textNative }; } }
        public TipTextBox[] TranslTextBoxs { get { return new TipTextBox[] { this.textNative }; } }
        public TipTextBox[] AllTextBox { get { return new TipTextBox[] { this.textForeignAndTran.ForeignText, this.textNative }; } }
        #endregion

        #region ITextWithSelection
        public string CurrentLowerWord
        {
            get { return this.CurrentWordLower; }
        }

        public LangPair LangDir
        {
            get { return ActiveTextBox.LangDir; }
        }

        public LangPair SetUpLangDir
        {
            set
            {
                this.textForeignAndTran.SetUpLangDir = value;
                this.textNative.LangDir = LangPair.Revert(value);
            }
        }

        public string CurrentWordLower
        {
            get
            {
                string word = TipTextBox.GetCurrentWord(this.ActiveTextBox);
                if (string.IsNullOrEmpty(word))
                    return word.ToLower();
                return word;
            }
        }
        #endregion

        #endregion

    }
}
