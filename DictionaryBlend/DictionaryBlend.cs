using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace f
{
    public partial class DictionaryBlend : Form, ITextWithSelectionAndWaiting
    {
        public DictionaryBlend()
        {
            InitializeComponent();
            CurrentLangInfo.ChangedLanguageDirection += new EventHandler(Common_ChangedLanguageDirection);
            InitPanelWithDictionaries();
            this.RestoreState(); // DictCollection.CheckDictionariesForLanguage(this.LangPair, toolStripDictionary.Items);
            AllowDropForControls(this);

            this.FormClosed += new FormClosedEventHandler(Tutor_FormClosed);
            this.comboBox.TextChanged += new System.EventHandler(this.cb_TextChanged);
            this.comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);

            this.comboBox.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedValueChanged);
            this.btPrev.Click += new EventHandler(btPrev_Click);
            this.btNext.Click += new EventHandler(btNext_Click);

            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.TempContentUpdates += new EventHandler(webBrowser1_TempContentUpdates);
            this.webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);

            //comboBox.Items.Add("Test");
            //comboBox.Items.Add("More");
            //comboBox.Items.Add("Mere");
            this.miHelpRequests.Click += new System.EventHandler(this.miHelpRequests_Click);
            this.Activated += new System.EventHandler(this.DictionaryBlend_Activated);
            this.comboBox.MouseWheel += new MouseEventHandler(comboBox_MouseWheel);
            this.btPasteText.Click += new EventHandler(btPasteText_Click);
            this.btSearch.Click += new EventHandler(btSearch_Click);
            //if (!Windows7.Windows7Taskbar.Windows7OrGreater)
            //    this.btSearch_.FlatStyle = FlatStyle.Popup;
            this.panelMainBorder.BackColor = CF.ExternalBorder;
        }

        void btSearch_Click(object sender, EventArgs e)
        {
            this.DoSearching();
        }

        void btPasteText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Clipboard.GetText()))
            {
                this.Word = Clipboard.GetText();
                this.DoSearching();
            }
        }

        #region comboBox.Focus
        void comboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // this.webBrowser1.Focus();
            // работает с двумя SendKeys.Send("{TAB}"); причем фокус на combobox 
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            Console.WriteLine("From comboBox_MouseWheel " + this.ActiveControl.Name);

            // this.webBrowser1.Focus();
            //    this.webBrowser1.Focus();
            //    Ul.SendMessage2(this.webBrowser1.Handle, Ul.WM_VSCROLL, (IntPtr)Ul.SB_LINEDOWN, IntPtr.Zero);
        }

        private void BackFocusForTyping()
        {
           // SendKeys.Send("{TAB}");
            comboBox.Focus();
            comboBox.SelectAll();
        }
        
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            BackFocusForTyping();
        }

        private void DictionaryBlend_Activated(object sender, EventArgs e)
        {
            BackFocusForTyping();
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (comboBox.Focused) return; // этот метод почему то вызывается два раза
            if (!e.Control)
            {
                char c = (char)e.KeyData;
                if (char.IsLetter(c))
                {
                    BackFocusForTyping();
                    this.comboBox.Text = c.ToString();
                    this.comboBox.SelectionStart = 1;
                    Console.WriteLine(e.KeyData.ToString());
                    //e.
                }
            }
        }
        #endregion

        #region Navigation Prev & Next
        void btNext_Click(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedIndex != -1)
                AssignValueByIndex(this.comboBox.SelectedIndex - 1);
            else
                AssignValueByIndex(this.comboBox.Items.Count - 1);
        }

        void btPrev_Click(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedIndex != -1)
                AssignValueByIndex(this.comboBox.SelectedIndex + 1);
            else
                AssignValueByIndex(0);
        }

        void AssignValueByIndex(int ind)
        { 
            if( ind >= 0 && this.comboBox.Items.Count > ind)
                this.comboBox.SelectedIndex = ind;
                //this.comboBox.SelectedValue = this.comboBox.Items[ind];
        }

        void CheckButtonsPrevNext()
        {
            this.btNext.Enabled = 
                this.comboBox.SelectedIndex > 0;
            
            this.btPrev.Enabled = 
                this.comboBox.SelectedIndex < this.comboBox.Items.Count-1;

            if( this.comboBox.Items.Count == 0 )
                this.btPrev.Enabled = 
                this.btNext.Enabled = false;
        }
        #endregion

        #region InitPanelWithDictionaries
        private void InitPanelWithDictionaries()
        {
            DictCollection.InitMenuForProviders(toolStripDictionary.Items, this, webBrowser1);
            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                if (item is ToolStripItem)
                    item.Click += new EventHandler(item_Click);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
        //    this.pictureBoxWating.Visible = true;

            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                if ((item is ToolStripButton) && ((ToolStripButton)item).Checked)
                    ((ToolStripButton)item).Checked = false;
                else if ((item is ToolStripMenuItem) && ((ToolStripMenuItem)item).Checked)
                    ((ToolStripMenuItem)item).Checked = false;
            }
            if (sender is ToolStripMenuItem) 
                ((ToolStripMenuItem)sender).Checked = true;
            if (sender is ToolStripButton) 
                ((ToolStripButton)sender).Checked = true;

            OnAfterSearchClick();
        }
        #endregion

        #region DragDrop & AllowDropForControls
        private void AllowDropForControls(Control control)
        {
            foreach (Control cntr in control.Controls)
            {
                if (this.webBrowser1 == cntr) continue;

                cntr.AllowDrop = true;
                cntr.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
                cntr.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
                AllowDropForControls(cntr);
                //this.comboBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
                //this.comboBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
            }
        } 
 
        private void comboBox_DragEnter(object sender, DragEventArgs e)
        {
            string[] fornmats = e.Data.GetFormats(); // by default all methods executed e.Data.GetFormats(true);
            if (Array.IndexOf(fornmats, "Text") > -1 || Array.IndexOf(fornmats, "UnicodeText") > -1)
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
        }

        private void comboBox_DragDrop(object sender, DragEventArgs e)
        {
            if (Array.IndexOf(e.Data.GetFormats(), "UnicodeText") != -1)
                this.Word = e.Data.GetData("UnicodeText") as string;
            else this.Word = e.Data.GetData("Text") as string;
            this.DoSearching();
        }
        #endregion

        #region save and restore
        public void RestoreState()
        {
            try
            {
                // ---- LanguageDirection ----
                CF.AssignValues("MainForm", this, new Point(50, 50), new Size(850, 920));
                this.btTopMost.Checked = CF.GetValue("TopMost", false);
               CurrentLangInfo.InitLanguagesMenu(this.miLanguages);
//                 CurrentLangInfo.InitLanguagesMenu(this.toolStripMainMenu);
                CurrentLangInfo.LanguageDirection = CF.GetValue("LanguageDirection", CurrentLangInfo.DefaultLangDir);
                AssignLastUsedDict(CF.GetValue("LastUsedDict", GoogleDictionary.MainTitle));
                
                string history = CF.GetValue("HistoryList", "WELCOME");
                if (!string.IsNullOrEmpty(history))
                {
                    this.comboBox.Items.AddRange(history.Split(';'));
                    this.comboBox.SelectedIndex = 0;
                }
                CheckButtonsPrevNext();
                UpdateFormCaption();
            }
            catch(Exception ex) {
                Messages.ErrorOnRestoringApp(ex);
            }
        }

        void Tutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            CF.SetValue("MainForm", this);
            CF.SetValue("TopMost", this.TopMost);
            CF.SetValue("LanguageDirection", this.LangDir);
            if (this.LastUsedDict != null)
            {
                CF.SetValue("LastUsedDict", ((RunDictContent)this.LastUsedDict.Tag).Providers[0].ToString());
            }
            #region HistoryList
		    List<string> toSave = new List<string>();
            foreach (object ob in this.comboBox.Items)
            {
                string word = ob as string;
                if (ob is HistoryItem)
                    word = ((HistoryItem)ob).Word;
                if (toSave.Contains(word) || string.IsNullOrEmpty(word)) continue;
                toSave.Add(word);
                if (toSave.Count > 300) break;
            }
            string history = "";
            foreach (string s in toSave)
            {
                if (!string.IsNullOrEmpty(history)) history += ";";
                history += s;
            }
            CF.SetValue("HistoryList", history); 
	        #endregion        
        }

        void AssignLastUsedDict(string name)
        {
            bool isAssigned = false;
            foreach (ToolStripItem item in toolStripDictionary.Items)
            {
                RunDictContent content = item.Tag as RunDictContent;
                // а как назначить последнюю группу словарей?????!!
                // if (content != null && content.Providers[0].ToString().Equals(name))
                if (content != null && content.Providers.Count == 1 && content.Providers[0].ToString().Equals(name))
                {
                    if (item is ToolStripButton)
                        ((ToolStripButton)item).Checked = true;
                    else ((ToolStripMenuItem)item).Checked = true;
                    isAssigned = true;
                    break;
                }
            }
            if (!isAssigned)
                AssignLastUsedDict(GoogleDictionary.MainTitle);
        }
        #endregion

        #region LangPair
        void Common_ChangedLanguageDirection(object sender, EventArgs e)
        {
            this.LangDirection = CurrentLangInfo.LanguageDirection;
            UpdateFormCaption();
            DictCollection.CheckDictionariesForLanguage(this.LangDirection, toolStripDictionary.Items);
            // TODO: Search
        }

        private string m_LangDirection = CurrentLangInfo.DefaultLangDir;
        public string LangDirection
        {
            get { return m_LangDirection; }
            set
            {
                m_LangDirection = value;
                UpdateFormCaption();
            }
        } 
        #endregion

        #region Word & UpdateFormCaption
        public string Word
        {
            set
            {
                this.comboBox.SelectedIndex = -1;
                this.comboBox.Text = value;
            }
            get
            {
                if (this.comboBox.SelectedValue is HistoryItem)
                {
                    return ((HistoryItem)this.comboBox.SelectedValue).Word; 
                }
                return this.comboBox.Text;
            }
        }

        private void cb_TextChanged(object sender, EventArgs e)
        {
            toolStripDictionary.Enabled = !string.IsNullOrEmpty(this.Word);
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && toolStripDictionary.Enabled)
            {
                DoSearching();
                e.SuppressKeyPress = true;
            }
            else if (e.Alt && e.KeyValue == 82) // Alt + r
            {
                btReverse_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region ITextWithSelection Members
        public string CurrentLowerWord
        {
            get {
                if (this.Word.Trim().Contains(" "))
                {
                    // for sentences with names like 
                    //  They change the structure of businesses and markets, especially at Google itself, according to Fried. 
                    return this.Word;
                }
                return this.Word.ToLower();             
            }
        }

        public LangPair LangDir
        {
            get { return new LangPair(this.LangDirection); }
        }

        public PictureBox Picture
        {
            get { return this.pictureBoxWating; }
        }

        public Control Control
        {
            get { return this; }
        }        
        #endregion

        #region Search
        delegate void MethodDelegate(object sender, EventArgs e);

        //private void btSearch_Click(object sender, EventArgs e)
        //{
          //  DoSearching();
        //}

        private void DoSearching()
        {
            ToolStripItem lastDictionary = this.LastUsedDict;
            if (lastDictionary != null)
            {
                //this.pictureBoxWating.Visible = true;
                //MethodDelegate md = new MethodDelegate(DictCollection.Dict_Click);
                //this.BeginInvoke(md, lastDictionary, EventArgs.Empty);
                DictCollection.Dict_Click(lastDictionary, EventArgs.Empty);
            }
            else
            {
                // DictCollection.Dict_Click(lastDictionary, EventArgs.Empty);


                string[] langPairs = LangDirection.Split(CurrentLangInfo.PairSeparator);
                WaitingUIObjectWithFinish waitingUIObject = new WaitingUIObjectWithFinish(this, this.pictureBoxWating, null);
                new Gator.GatorStarter(this.Word, langPairs[0], langPairs[1], waitingUIObject);
                //                bool f = (new Gator()).ShowArticles(this.Word, langPairs[0], langPairs[1], this);
            }
            OnAfterSearchClick();
        }

        ToolStripItem LastUsedDict
        {
            get
            {
                ToolStripItem lastDictionary = null;
                foreach (ToolStripItem item in toolStripDictionary.Items)
                { 
                    if ((item is ToolStripButton) && ((ToolStripButton)item).Checked)
                        lastDictionary = item;
                    else if ((item is ToolStripMenuItem) && ((ToolStripMenuItem)item).Checked)
                        lastDictionary = item;
                }
                return lastDictionary;
            }
        }
        #endregion

        #region UI (TopMost)
        private void btTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = btTopMost.Checked;
        } 
        #endregion

        #region RegisterEvent
        private void OnAfterSearchClick()
        {
            RegisterEvent();
//            this.webBrowser1.Focus();
            BackFocusForTyping();
        }

        private void RegisterEvent()
        {
            if (string.IsNullOrEmpty(this.Word)) return;
            DictionaryProvider provider = null;
            if (this.LastUsedDict != null)
            {
                RunDictContent dictContent = this.LastUsedDict.Tag as RunDictContent;
                if (dictContent != null && dictContent.Providers.Count > 0)
                    provider = dictContent.Providers[0];
            }

            HistoryItem hi = new HistoryItem(this.Word, provider); //, this.webBrowser1.TempContent);
            #region clear old content
            if (this.comboBox.Items.Contains(hi.Word))
                this.comboBox.Items.Remove(hi.Word);
            else
            {
                foreach (object ob in this.comboBox.Items)
                {
                    if (ob is HistoryItem && hi.Equals((HistoryItem)ob))
                        this.comboBox.Items.Remove(hi);
                }
            } 
            #endregion
            this.comboBox.Items.Insert(0, hi);

            try {
                this.comboBox.SelectedValueChanged -= new System.EventHandler(this.comboBox_SelectedValueChanged);
                this.comboBox.SelectedIndex = 0;
            }
            finally {
                this.comboBox.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedValueChanged);
            }
            UpdateFormCaption();
            CheckButtonsPrevNext();
        }

        void webBrowser1_TempContentUpdates(object sender, EventArgs e)
        {
            //if (this.comboBox.SelectedValue is HistoryItem)
            if (this.comboBox.Items.Count > 0 && this.comboBox.Items[0] is HistoryItem)            
            {
                ((HistoryItem)this.comboBox.Items[0]).Content = webBrowser1.TempContent;
            }
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedIndex == -1) return;
            HistoryItem hi = this.comboBox.Items[this.comboBox.SelectedIndex] as HistoryItem;
            if (hi != null)
                this.webBrowser1.DocumentText = hi.Content;
            else
                this.webBrowser1.DocumentText = "";
            CheckButtonsPrevNext();
        }

        private void UpdateFormCaption()
        {
            this.Text = string.Format("'{0}' - Dictionary Blend ({1})", this.Word, this.LangDirection);
        }
        #endregion

        #region menu bar
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new AbandonTopPosition(this))
                (new AboutForm()).ShowDialog();
        }

        private void btEditFavoritList_Click(object sender, EventArgs e)
        {
            using (new AbandonTopPosition(this))
                (new Options()).ShowDialog();
        }

        private void btReverse_Click(object sender, EventArgs e)
        {
            CurrentLangInfo.LanguageDirection = LangPair.Revert(CurrentLangInfo.LanguageDirection);
            BackFocusForTyping();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region pictureBoxWating
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // this.pictureBoxWating.Visible = false;
        }
        #endregion

        private void miHelpRequests_Click(object sender, EventArgs e)
        {
            Utils.AddDictionary();
        }

        public static string MinimizeForm = "MinimizeForm";

        internal bool StartInMinimizeForm
        {
            set { if(value)
                    this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btSpeak_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.comboBox.Text))
                new SoundStarter(this.comboBox.Text.ToLower(), new LangPair(CurrentLangInfo.LanguageDirection).From);
            // else message
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  this.webBrowser1.Focus();
          //  this.webBrowser1.Focus();
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            //this.comboBox.Focus();
            //Ul.SendMessage2(this.webBrowser1.Handle, Ul.WM_VSCROLL, (IntPtr)Ul.SB_LINEDOWN, IntPtr.Zero);
            //Ul.SendMessage2(this.webBrowser1.Handle, Ul.WM_VSCROLL, (IntPtr)Ul.SB_LINEDOWN, IntPtr.Zero);

            Console.WriteLine("From button " + this.ActiveControl.Name);
        }
    }
}
