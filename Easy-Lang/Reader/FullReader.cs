using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Windows7;

namespace f
{
    public partial class FullReader : UserControl
    {
        public FullReader()
        {
            InitializeComponent();

            //this.TwinList.ListEn.Controller = new ReaderController(false);
            //this.TwinList.ListNative.Controller = new ReaderController(true);
            this.TwinList.ListEn.Initialize(this.TwinText.textForeignAndTran.ForeignText);
            this.TwinList.ListNative.Initialize(this.TwinText.textNative);

            //TranslateCurrentSentenceInvoker = new MethodInvoker(this.TranslateCurrentSentence);
            this.TwinList.ListEn.btTranslate.Click += new System.EventHandler(this.miTranslateByGoogle_Click);
            this.TwinList.ListEn.miTranslateByGoogle.Click += new System.EventHandler(this.miTranslateByGoogle_Click);

            // by default with one sentence for editing
            this.TwinList.ListEn.InitCurrentSentence("");
            this.TwinList.ListNative.InitCurrentSentence(""); 


            this.TwinList.ListEn.List.SelectedValueChanged += new EventHandler(List_SelectedValueChanged);
            this.TwinList.ListNative.List.SelectedValueChanged += new EventHandler(List_SelectedValueChangedForNative);

            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.R_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.R_DragEnter);

            this.TwinList.ListEn.TextReloaded += new SentenceList.ListContentUpdated(List_TextReloaded);
            this.TwinText.MenuForSelected.HideTranslationStateChanged += new EventHandler(MenuForSelected_HideTranslationStateChanged);
        }

        void MenuForSelected_HideTranslationStateChanged(object sender, EventArgs e)
        {
            this.TwinText.textForeignAndTran.UpdateTranslation();
            ClearCash();
        }


        #region other for list
        void List_TextReloaded(SentenceList sender, EventArgs e)
        {
            //TODO: 
            // попутно всегда обнуляем паралельный текст 
            if(sender is SentenceListWithIndent)
                this.TwinList.ListNative.SafeSelectedIndex = this.TwinList.ListEn.SafeSelectedIndex;
        }

        void List_SelectedValueChangedForNative(object sender, EventArgs e)
        {
            this.TwinText.textNative.CheckHidedStatus();
            this.TwinText.textNative.Sentence = this.TwinList.ListNative.CurrentSentence;
            //if (this.TwinList.ListEn.CurrentSentence is SentenceVideo &&
            //    this.TwinList.ListNative.CurrentSentence is SentenceVideo)
            //{ // в первую очередь нас интересует время
            //    this.TwinList.ListNative.TimeIndent = ((SentenceVideo)this.TwinList.ListNative.CurrentSentence).Start - ((SentenceVideo)this.TwinList.ListEn.CurrentSentence).Start;
            //    //TODO: add time also for this.TwinList.ListNative.List.SelectedIndex - this.TwinList.ListEn.List.SelectedIndex
            //}
            //else
            {
                this.TwinList.ListNative.Indent = this.TwinList.ListNative.List.SelectedIndex - this.TwinList.ListEn.List.SelectedIndex;
            }
        }
        #endregion

        #region List_SelectedValueChanged
        public void RefreshSelectedSentence()
        {
            List_SelectedValueChanged(null, EventArgs.Empty);
        }

        void List_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.Created) return;
            if (this.TwinList.ListEn.miShowOnlyWithWordsToolStripMenuItem.Checked)
            { // without indent
                if (this.TwinList.ListEn.CurrentSentence != null)
                    this.TwinList.ListNative.SafeSelectedIndex = this.TwinList.ListEn.CurrentSentence.Index; 
            }
            else
                this.TwinList.ListNative.SetSafeSelectedIndexWithIndent(this.TwinList.ListEn.List.SelectedIndex, this.TwinList.ListEn.CurrentSentence);
            
          //  if (!this.TwinList.ListEn.IsOnlySynch)
                this.TwinList.HTMLScroller_SelectedIndex = this.TwinList.ListEn.CurrentSentence.Index-1;

            if (this.TwinText.textForeignAndTran.Sentence != this.TwinList.ListEn.CurrentSentence)
                this.TwinText.textForeignAndTran.Sentence = this.TwinList.ListEn.CurrentSentence;
            

            Windows7Taskbar.CalculateAndSet(this.Parent.Handle, this.TwinList.ListEn.List.Items.Count, this.TwinList.ListEn.List.SelectedIndex);
        }
        #endregion

        #region Translate
        private void miTranslateByGoogle_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripSplitButton && !((ToolStripSplitButton)sender).ButtonPressed)
                return;
            if (string.IsNullOrEmpty(this.TwinList.ListEn.FullText))
            {
                MessageBox.Show("Foreign text is empty. Please at first open (or paste) text in left side.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (new WaitCursor())
            {
                this.TwinList.ListNative.FullText = GoogleDictionary.Instance.GetContent(this.TwinList.ListEn.FullText, this.TwinText.textForeignAndTran.LangDir);
                this.TwinList.Synchronize();
            }
        }   

        #endregion

        #region DragDrop
        private void R_DragEnter(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData("FileNameW");
            if (obj != null)
            {
                string fileName = obj is Array ? ((Array)obj).GetValue(0).ToString() : null;
                if (!string.IsNullOrEmpty(fileName) && System.IO.File.Exists(fileName))
                    e.Effect = DragDropEffects.Copy;
            }
            else
            {
                string[] fornmats = e.Data.GetFormats(); // by default all methods executed e.Data.GetFormats(true);
                if (Array.IndexOf(fornmats, "Text") > -1 || Array.IndexOf(fornmats, "UnicodeText") > -1)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
        }

        private void R_DragDrop(object sender, DragEventArgs e)
        {
            SentenceList currentList = this.FocusedList;

            object obj = e.Data.GetData("FileNameW");
            if (obj != null)
            {
                string fileName = obj is Array ? ((Array)obj).GetValue(0).ToString() : null;
                if (!string.IsNullOrEmpty(fileName) && System.IO.File.Exists(fileName))
                {
                    if (currentList is SentenceListWithVideo)
                        ((SentenceListWithVideo)currentList).CheckAndAssignFileNameFormUI(fileName);
                        // другие файлы автоматом назначатся
                    else
                    {
                        currentList.FileName = fileName;
                        currentList.SuggestLessonFile();
                    }
                }
            }
            else
            {
                // by default all methods executed  this.GetData(format, true);

                if (Array.IndexOf(e.Data.GetFormats(), "UnicodeText") != -1 )
                    obj = e.Data.GetData("UnicodeText");
                else obj = e.Data.GetData("Text"); 
                currentList.FileName = "";
                currentList.FullText = (string)obj;
            }
        }
        #endregion

        #region other
        public SentenceList FocusedList
        {
            get
            {
                //SentenceList currentList = this.TwinList.ListEn;
                //if (this.TwinList.ActiveControl == this.TwinList.ListNative ||
                //    this.TwinList.ActiveControl == this.TwinText.textNative)
                //    currentList = this.TwinList.ListNative;

                if (this.TwinList.ListNative.List.Focused || this.TwinText.textNative.Focused)
                    return this.TwinList.ListNative;
                else return this.TwinList.ListEn;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            int half = (int)this.Height/2;
           // if (half < this.TwinText.Height)
            {
                this.TwinText.Height = half;
            }
            base.OnResize(e);
            this.splitter1.Refresh();
        }

        private void splitter1_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawHorizontal(sender as Splitter, e);
            // Ul.DrawTwoSolidVertical(sender as Splitter, e, CF.ExternalBorder); // SystemColors.AppWorkspace
        } 
        #endregion

        #region LanguageDirection
        string m_LanguageDirection = CurrentLangInfo.DefaultLangDir;
        [Browsable(false)]
        public string LanguageDirection
        {
            get { return m_LanguageDirection; }
            set
            {
                if (m_LanguageDirection != value)
                {
                    m_LanguageDirection = value;
                    UpdateAfterChangeLanguageDirection(m_LanguageDirection);
                }
            }
        }

        void UpdateAfterChangeLanguageDirection(string languageDirection)
        {
            ClearCash();
            LangPair lp = new LangPair(LanguageDirection);
            this.TwinText.SetUpLangDir = lp; // here called autoUpdate

            //this.TwinText.textWithTranslate.ForeignText.Text = "";
            //this.TwinText.textWithTranslate.Sentence = this.TwinList.ListEn.CurrentSentence;
            // this.RefreshSelectedSentence();
        }

        private void ClearCash()
        {
            foreach (Sentence sen in this.TwinList.ListEn.Sentences)
                sen.ClearCashForTranslation();
        } 
        #endregion
    }
}
