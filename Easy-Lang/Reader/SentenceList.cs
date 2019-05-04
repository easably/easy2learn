using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace f
{
    public partial class SentenceList : UserControl
    {
        public delegate void ListContentUpdated(SentenceList sender, EventArgs e);
        public event ListContentUpdated TextReloaded;
        public event EventHandler ChangingFile;
        private TwinList m_ParentTwinList;

        public SentenceList()
        {
            InitializeComponent();
            
            //this.BackColor = CF.ExternalBorder;

            //this.miSynchronizeWithVideo.ShortcutKeys = System.Windows.Forms.Keys.F11; // End;
            //this.miRepeatVideo.ShortcutKeys = System.Windows.Forms.Keys.F12; // Home;

            this.saveLessonFileDialog.Filter = GlobalOptions.GetFileFilterForLesson(true);

            this.Load += new EventHandler(SentenceList_Load);

            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            this.miGoToTranslatebyPromt.Click += new System.EventHandler(this.miGoToTranslateByGoogle_Click);

            #region Images
            //zoomInToolStripMenuItem.Image = f.button_images.zoom_in.ToBitmap();
            //zoomOutToolStripMenuItem.Image = f.button_images.zoom_out.ToBitmap();
            this.miPaste.Image = f.button_images.paste;

            this.miGoToTranslateByGoogle.Image = this.miTranslateByGoogle.Image;
            this.miGoToTranslateByMicrosoft.Image = this.miTranslateByMicrosoft.Image;
            this.miGoToTranslateByYahoo.Image = this.miTranslateByYahoo.Image;

            //this.btEstimate.Image = global::f.button_images.estimate;
            //this.btFind.Image = global::f.button_images.find;
            // this.btSearchSubtitles.Image = global::f.button_images.find;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SentenceList));
            this.miOpenLesson.Image = ((System.Drawing.Image)(resources.GetObject("btOpen.Image")));
            this.miOpenText.Image = ((System.Drawing.Image)(resources.GetObject("btOpen.Image")));
            this.miOpenVideo.Image = ((System.Drawing.Image)(resources.GetObject("btOpen.Image")));

            this.saveToolStripMenuItem.Image = // miSaveText
            this.miSaveLesson.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
           
            this.miCloseText.Image = 
            this.miCloseVideo.Image = global::f.button_images.Close;
           // this.miCloseLesson.Image = global::f.button_images.Close; чтобы не отвлекал внимание
            #endregion

            #region events
            // -------- text
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
            this.miOpenText.Click += new EventHandler(miOpenText_Click);
            this.miCloseText.Click += new System.EventHandler(this.miCloseText_Click);   

            this.nextSentenceToolStripMenuItem.Click += new System.EventHandler(this.nextSentenceToolStripMenuItem_Click);
            this.previousSentenceToolStripMenuItem.Click += new System.EventHandler(this.previousSentenceToolStripMenuItem_Click);

            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            this.miPasteText.Click +=new EventHandler(miPasteText_Click);

            this.btText.DropDownOpening += new System.EventHandler(this.moreMenuButton_Click);
            #endregion

            this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection("");
            this.panelTopIndent.Visible = false;
        }

        #region . Initialize .
        public void Initialize(TipTextBox richTextBox)
        {
            this.m_TipTextBox = richTextBox;
        }

        void SentenceList_Load(object sender, EventArgs e)
        {
            if (this.Parent != null && this.Parent.Parent != null && this.Parent.Parent is TwinList)
                this.m_ParentTwinList = (TwinList)this.Parent.Parent;
        } 
        #endregion

        #region . Text --- Open Close FileName .
        protected void miOpenText_Click(object sender, EventArgs e)
        {
            OpenTextUI();
        }

        void OpenTextUI()
        {
            // TODO: SuggestFileName
            using (new FilterFileDialog(this.openFileDialog))
            {
                AssignFilterForTextFile();
                this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);
                using (new AbandonTopPosition(VideoForm.CurrentForm))
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.FileName = this.openFileDialog.FileName;
                        SuggestLessonFile();
                        SuggestVideoFile(this.openFileDialog.FileName);
                    }
                }
            }
        }

        protected virtual void AssignFilterForTextFile()
        {
            this.openFileDialog.Filter = GlobalOptions.GetFileFilterForSubtitles(true);
        }

        private void miCloseText_Click(object sender, EventArgs e)
        {
            if (CheckFilesOnSave() == DialogResult.Cancel)
                    return;
            this.FileName = "";
            if(this is SentenceListWithVideo)
                ((SentenceListWithVideo)this).LessonFileName = "";
        }

        public virtual DialogResult CheckFilesOnSave()
        {
            return DialogResult.None;
        }

        private void moreMenuButton_Click(object sender, EventArgs e)
        {
            this.btFind.Enabled =
            this.btEstimate.Enabled = 
            this.miCloseText.Enabled = !string.IsNullOrEmpty(this.FileName);
            this.nextSentenceToolStripMenuItem.Enabled = this.List.Items.Count > this.List.SelectedIndex + 1;
            this.previousSentenceToolStripMenuItem.Enabled = 0 < this.List.SelectedIndex;

            // TODO: а были ли изменения??
            this.saveToolStripMenuItem.Enabled = !string.IsNullOrEmpty(this.FileName);
          //  this.btEstimate.Enabled = !string.IsNullOrEmpty(this.FullText);

            #region btFindUsages.Enabled
            string _currentWordOrText = TipTextBox.GetCurrentWord(this.TipTextBox);
     //       this.btFind.Enabled = !string.IsNullOrEmpty(this.FullText);
            string _menuText = "Find '{0}'";
            if (this.btFind.Enabled)
            {
                this.btFind.ToolTipText = string.Format(_menuText, _currentWordOrText);
            }
            else
            {
                this.btFind.ToolTipText = string.Format(_menuText, "Selected");
            }
            #endregion
        }
        #endregion

        #region CurrentSentence && Sentences
        public Sentence CurrentSentence
        {
            get
            {
                if (this.List.SelectedIndex == -1)
                {
                    if (this.List.Items.Count == 0)
                    {
                        this.Sentences = new List<Sentence>();
                        Sentence sen = new Sentence("", this.Sentences);
                        this.Sentences.Add(sen);
                        this.List.Items.Add(sen);
                    }
                    this.List.SelectedIndex = 0;
                }
                return this.List.Items[this.List.SelectedIndex] as Sentence;
            }
        }

        public void InitCurrentSentence(string intialText)
        {
            List<Sentence> list = new List<Sentence>(); 
            list.Add(new Sentence("", list));
            this.Sentences = list;
        }

        private string m_FullText;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullText
        {
            set
            {
                this.m_FullText = value;
                this.Sentences = SentenceParser.GetListSentence(value);
            }
            //TODO: Check Saved or UnSaved text in sentences
            get 
            { 
                return m_FullText; 
            }
        }

        public string GetAllSentences()
        {
            string res = string.Empty;
            if (this.Sentences != null)
            {
                foreach (Sentence sen in this.Sentences)
                    res += " \r\n " + sen.TextValue;
            }
            return res;
        }


        List<Sentence> _mSentences;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Sentence> Sentences
        {
            protected set
            {
                using (new WaitCursor())
                {
                    try
                    {
                        this.List.BeginUpdate();
                        this.ClearList();
                        _mSentences = value;
                        this.List.Items.AddRange(_mSentences.ToArray());
                        this.SafeSelectedIndex = 0;
                    }
                    finally
                    {
                        this.List.EndUpdate();
                    }
                }
            }
            get
            {
                return _mSentences;
            }
        }

 //       public event EventHandler ChangeCurrentSentence; 
        #endregion

        #region FileName && OpenFile
        string m_FileName;
        private void AssingFileName(string fileName)
        {
            m_FileName = fileName;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                if (string.IsNullOrEmpty(m_FileName) && string.IsNullOrEmpty(value))
                    return; // do cheking because "" != null

                this.OnChangingFile();

                if (m_FileName != value) 
                    OnOpenOtherText();
                m_FileName = FileManager.FindPathAndReturnFullFileName(value);

                // файл может быть т.к. его можно переоткрыть
                if ( File.Exists(m_FileName) ) // SentenceParser.CheckFile(ref m_FileName))
                {
                    try
                    {
                        this.LoadFile();
                        this.miCloseText.Text = string.Format("Close '{0}'", Utils.GetShortFileName(m_FileName));
                        this.btText.Image = button_images.GreenDotSmall;
                        this.btLesson.Enabled = true;
                        this.btText.ToolTipText = "Actions for subtitles or text";
                    }
                    catch(Exception ex) //(FileNotFoundException)
                    {
                        string mess = string.Format("File '{0}' could not be opened." + Environment.NewLine + "This file may be corrupted or not suitable", m_FileName);
                        this.btText.ToolTipText = mess;
                        MessageBox.Show(mess, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //this.OnClosingText();
                        this.m_FileName = "";
                        this.OnClosedText();

                        // Console.WriteLine(ex);
                        Utils.PublicException(ex);
                        // продолжаем дальше работать, пользователь может открыть другой файл!
                        //throw ex;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_FileName))
                        MessageBox.Show(string.Format("File '{0}' not found.", m_FileName), 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.m_FileName = "";
                    this.OnClosedText();
                }
                if (TextReloaded != null)
                    TextReloaded.Invoke(this, new EventArgs());
            }
        }

        protected virtual void LoadFile()
        {
            this.ReadOnly = true;
            string ext = Path.GetExtension(this.FileName).ToLower();
            if (ext == ".txt" && this is SentenceListWithIndent) {
                LoadFileAsText();
            }
            else if ( Array.IndexOf(GlobalOptions.SubtitlesFileExtensions, ext) != -1)
            {
                try
                {
                    List<Sentence> result = SentenceParser.GetSentencesFromSubtitles(this.FileName);
                    if (result.Count == 1 && 
                        string.IsNullOrEmpty(result[0].TextValue) && 
                        string.Equals(".txt", ext)) // is empty
                    {
                        this.FullText = SentenceParser.GetFileByRichTextBox(this.FileName);
                        this.ReadOnly = false;
                    }
                    else
                    {
                        this.Sentences = result;
                        this.m_FullText = this.GetAllSentences();
                    }
                }
                catch // если не смогли пропарсить как субтитры попробуем открыть просто как текст
                {  
                    // TODO: дублируется код 3 раза
                    if (string.Equals(".txt", ext))
                    {
                        LoadFileAsText();
                    }
                }
            }
            else
            {
                this.FullText = SentenceParser.GetFileByRichTextBox(this.FileName);
                this.ReadOnly = false;
            }
        }

        private void LoadFileAsText()
        {
            this.FullText = SentenceParser.GetFileByRichTextBox(this.FileName);
            this.ReadOnly = false;
        }

        internal virtual void OpenFileUI()
        {
            openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);
            using (new AbandonTopPosition( VideoForm.CurrentForm))
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    this.FileName = openFileDialog.FileName;
            }
        }

        protected string GetSuggestedDirectory()
        {
            return FileManager.GetDirectory(GetSuggestedFileName());
        }
        #endregion

        #region SafeSelectedIndex
        public int SafeSelectedIndex
        {
            set
            {
                if (this.List.Items.Count == 0) return;
                int newIndex = value;
                if (newIndex < 0)
                    newIndex = 0;
                if (this.List.SelectedIndex == newIndex && this is SentenceListWithVideo)
                    ((SentenceListWithVideo)this).PlayCurrentSentence();
                else if (this.List.Items.Count > newIndex)
                    this.List.SelectedIndex = newIndex;
                else
                    this.List.SelectedIndex = this.List.Items.Count - 1;
                this.List.ScrollSelectedToCenter();
            }
            get
            {
                return this.List.SelectedIndex;
            }
        }

        private void nextSentenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ++SafeSelectedIndex;
        }

        private void previousSentenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            --SafeSelectedIndex;
        } 
        #endregion

        #region FontSize managment
        public void ChangeFont(bool isIncrease)
        {
            float step = 0.5f;
            this.FontSize = this.List.Font.Size + (isIncrease ? step : -1 * step);
        }

        public float FontSize
        {
            get
            {
                return this.List.Font.Size;
            }
            set
            {
                if (value == 0) 
                    value = 11.5f;
                this.List.Font = new Font(this.Font.Name, value);
                //                this.List.Font = new Font(this.Font.Name, value);
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont(true);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont(false);
        } 
        #endregion

        #region save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.FileName = GetSuggestedFileName();
            using (new AbandonTopPosition( VideoForm.CurrentForm))
            {
                if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        //if (this.saveFileDialog1.FileName.EndsWith(".rtf"))
                        //    FileManager.CreateFile(this.saveFileDialog1.FileName, this.);
                        //else 

                        File.WriteAllText(this.saveFileDialog.FileName, this.GetAllSentences(), Encoding.UTF8);
                        //    FileManager.CreateFile(this.saveFileDialog.FileName, this.FullText);
                        this.AssingFileName(this.saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //public bool IsUnSave
        //{
        //    get { return string.IsNullOrEmpty(this.FileName) && !this.IsEmpty; } // !string.IsNullOrEmpty(this.FullText); }
        //} 

        string GetSuggestedFileName()
        {
            string ret = "";
            if (this is SentenceListWithIndent)
                ret = m_ParentTwinList.ListEn.FileName;
            else ret = this.FileName;

            if (!string.IsNullOrEmpty(ret) && ret.LastIndexOf('.') != -1)
            {
                string fileName = ret.Substring(0, ret.LastIndexOf('.'));
                if (!fileName.EndsWith(this.TipTextBox.LangDir.From))
                    ret = fileName + "_" + this.TipTextBox.LangDir.From;
            }
            return ret;
        }
        #endregion

        #region props
        public TipTextBox m_TipTextBox;

        public TipTextBox TipTextBox
        {
            get { return m_TipTextBox; }
        }

        // т.к. все очень абстрактно
        //public bool IsEmptyText
        //{
        //    get { return string.IsNullOrEmpty(this.FileName) && this.TextBox.Text.Length == 0; }
        //        // всегда есть строка в списке т.е. this.List.Items.Count > 0; }
        //}

        Boolean m_ReadOnly;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                this.m_ReadOnly =
                this.TipTextBox.ReadOnly = value;
                this.cmiAdd.Visible =
                this.cmiInser.Visible = 
                this.cmiRemove.Visible = !m_ReadOnly;
            }
        } 
        #endregion

        #region OnClosingText && ClearAll
        protected void OnChangingFile()
        {
            if (ChangingFile != null)
                ChangingFile.Invoke(this, new EventArgs());
        }

        protected virtual void OnOpenOtherText()
        { 
            
        }

        protected virtual void OnClosedText()
        {
            this.InitCurrentSentence(""); // для редактирования
            this.btText.Image = null;
            this.miCloseText.Text = "Close";
            this.btLesson.Enabled = false;
        }

        void ClearList()
        {
            this.List.Items.Clear();
            if (this.TipTextBox != null)
            {
                try
                {
                    this.TipTextBox.IsSystemTextChaghed = true;
                    this.TipTextBox.Clear();
                }
                finally
                {
                    this.TipTextBox.IsSystemTextChaghed = false;
                }
            }
        }
        #endregion

        #region Paste
        private void miPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        internal void Paste()
        {
            /*Clipboard.GetDataObject().GetFormats()
{string[6]}
    [0]: "System.String"
    [1]: "UnicodeText"
    [2]: "Text"
    [3]: "Rich Text Format"
    [4]: "Hidden Text Banner Format"
    [5]: "Locale"
             * 
             * 
             * http://stackoverflow.com/questions/150208/how-do-i-convert-html-to-rtf-rich-text-in-net-without-paying-for-a-component
             * 
             * Clipboard.GetData("HTML Format")
"Version:0.9\r\nStartHTML:0000000213\r\nEndHTML:0000001597\r\nStartFragment:0000000251\r\nEndFragment:0000001559\r\nSourceURL:http://www.nytimes.com/reuters/2010/10/01/world/asia/international-uk-pakistan-nato.html?_r=1&hp\r\n<html>\r\n<body>\r\n<!--StartFragment-->\r\n<span class=\"Apple-style-span\" style=\"border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; \"><span class=\"Apple-style-span\" style=\"font-family: georgia, 'times new roman', times, serif; font-size: 15px; line-height: 22px; text-align: left; \">ARACHI (Reuters) - Suspected militants in Paki
stan set fire to tankers carrying fuel for<span class=\"Apple-converted-space\">В </span><a href=\"http://topics.nytimes.com/top/reference/timestopics/organizations/n/north_atlantic_treaty_organization/index.html?inline=nyt-org\" title=\"More articles about the North Atlantic Treaty Organization.\" class=\"meta-org\" style=\"color: rgb(0, 66, 118); text-decoration: underline; \">NATO</a><span class=\"Apple-converted-space\">В </span>troops in Afghanistan on Friday, officials said, a day after three soldiers were killed in a cross-border NATO air strike.</span></span>\r\n<!--EndFragment-->\r\n</body>\r\n</html>"

             * 
             * 
             * for Clipboard.GetData("Rich Text Format")
             * 
*/

            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                this.FullText = text;
            }
        } 
        #endregion

        #region Translate
        private void miGoToTranslateByGoogle_Click(object sender, EventArgs e)
        {
            if (sender == miGoToTranslateByGoogle)
                Runner.OpenURL(@"http://translate.google.com/");
            else if (sender == miGoToTranslateByMicrosoft)
                Runner.OpenURL(@"http://www.microsofttranslator.com/Default.aspx");
            else if (sender == miGoToTranslateByYahoo)
                Runner.OpenURL(@"http://babelfish.yahoo.com/translate_txt");
            else if (sender == miGoToTranslatebyPromt)
                Runner.OpenURL(@"http://www.online-translator.com/");

        } 
        #endregion

        #region Tools Estimate & FindCitations
        private void btEstimate_Click(object sender, EventArgs e)
        {
            EstimateTest();
        }

        public void EstimateTest()
        {
            if (!string.IsNullOrEmpty(this.FullText))
            {
                E estForm = new E();
                string text = this.FullText;
                estForm.AssignTextForEstimate(this.FullText, this.TipTextBox.LangDir.From);
                using (new AbandonTopPosition(VideoForm.CurrentForm))
                {
                    estForm.ShowDialog(this);
                }
            }
        }

        private void btFindUsages_Click(object sender, EventArgs e)
        {
            FindCitationsForWordAndShow();
        }

        public void FindCitationsForWordAndShow()
        {
            string _currentWordOrText = TipTextBox.GetCurrentWord(this.TipTextBox);
            if (string.IsNullOrEmpty(_currentWordOrText)) return;
            FindForm searcher = new FindForm();
            searcher.InitAndSearch(this.FullText, _currentWordOrText);
            //TODO:             using (new AbandonTopPosition(Utils.VideoForm))
            // а надо ли ?
            searcher.Show();
        } 
        #endregion

        #region Context menu
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sentence sen = new Sentence("", this.Sentences);
            this.Sentences.Add(sen);
            this.List.Items.Add(sen);
        }

        private void inserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sentence sen = new Sentence("", this.Sentences);
            this.Sentences.Insert(this.List.SelectedIndex, sen);
            this.List.Items.Insert(this.List.SelectedIndex, sen);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Sentences.Remove(this.CurrentSentence);
            this.Sentences = this.Sentences; // how refresh, иначе не персчитывается индекс
        }

        private void menuForList_Opening(object sender, CancelEventArgs e)
        {
            cmiInser.Enabled = this.List.SelectedIndex != -1;
            cmiRemove.Enabled = this.Sentences.Count > 1 && this.List.SelectedIndex != -1;
        } 
        #endregion

        public bool IsOpenWithSubtitles
        {
            get
            {
                return !string.IsNullOrEmpty(this.FileName) && 
                    //this.Sentences.Count > 0 && 
                    this.CurrentSentence is SentenceVideo;
            }
        }

        #region Suggest allFiles
        public void SuggestLessonFile()
        {
            if (string.IsNullOrEmpty(this.FileName)) return;
            if (this is SentenceListWithVideo)
            {
                if (File.Exists(this.FileName + GlobalOptions.LessonFileExtension))
                {
                    ((SentenceListWithVideo)this).LessonFileName = this.FileName + GlobalOptions.LessonFileExtension;
                }
            }
        }

        protected void SuggestVideoFile(string fileName)
        {
            if (this is SentenceListWithVideo)
            {
                if (File.Exists(((SentenceListWithVideo)this).VideoFileName)) return; // переоткрывать ничего не будем, будет непредсказуемо для пользователя

                if (string.IsNullOrEmpty(fileName) && fileName.LastIndexOf('.') != -1) return;
                fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                foreach (string ext in GlobalOptions.AllVideoExt)
                {
                    if (File.Exists(fileName + ext))
                    {
                        ((SentenceListWithVideo)this).VideoFileName = fileName + ext;
                        break;
                    }
                }
            }
        }

        protected void SuggestTextFile(string fileName)
        {
            if (File.Exists(this.FileName)) return; // переоткрывать ничего не будем, будет непредсказуемо для пользователя

            if (string.IsNullOrEmpty(fileName) && fileName.LastIndexOf('.') != -1) return;
            fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
            foreach (string ext in GlobalOptions.SubtitlesFileExtensions)
            {
                if (File.Exists(fileName + ext))
                {
                    this.FileName = fileName + ext;
                    SuggestLessonFile();
                    break;
                }
            }
        }
        #endregion

        private void miPasteText_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void miCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData("Text", this.CurrentSentence.ToString());
        }

        #region filter
        private void miShowOnlyWithWordsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            var selInd = (this.CurrentSentence != null) ? this.CurrentSentence.Index : -1;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.List.SuspendLayout();
                this.List.Items.Clear();
                if (miShowOnlyWithWordsToolStripMenuItem.Checked)
                {
                    this.btFilter.Visible = true; this.btFilter.Checked = true;
                    bool firstSent = true;
                    for (int i = 0; i < this.Sentences.Count; ++i)
                    {
                        Sentence s = this.Sentences[i];
                        if (s.WordsToLearn.Count > 0)
                        {
                            Sentence sPrev = (i > 0) ? this.Sentences[i - 1] : null;
                            Sentence sNext = (i+1 < this.Sentences.Count) ? this.Sentences[i + 1] : null;
                            if (sPrev != null && !this.List.Items.Contains(sPrev))
                            {
                                if (firstSent) firstSent = false;
                                //4.5.6. ... 7.8.9. ... if 5. and 8. have word for learning then betweeen  6. and 7. should not be ...
                                else if (sPrev.Index - 1 != ((Sentence)this.List.Items[this.List.Items.Count-1]).Index)
                                    this.List.Items.Add(" ... "); 
                                this.List.Items.Add(sPrev);
                            }
                            this.List.Items.Add(s); // sentence for lesson 
                            if (sNext != null && sNext.WordsToLearn.Count == 0)
                                this.List.Items.Add(sNext);
                        }
                    }
                }
                else
                {
                    // this.btFilter.Visible = false;
                    this.List.Items.AddRange(_mSentences.ToArray());
                }
            }
            finally
            {
                this.List.ResumeLayout();
                this.Cursor = Cursors.Default;
                FindBestPosition(selInd);
            }
        }

        private void FindBestPosition(int selInd)
        {
            if (this.List.Items.Count == 0) return;
            Sentence lastNearest = null;
            foreach (object obj in this.List.Items)
            {
                Sentence s = obj as Sentence; if (s == null) continue;
                if (lastNearest == null) lastNearest = s;
                if (selInd == s.Index) { lastNearest = s; break; }
                else
                {
                    lastNearest = Math.Abs(s.Index - selInd) < Math.Abs(lastNearest.Index - selInd) ? s : lastNearest;
                }
            }
            if (lastNearest != null) this.List.SelectedItem = lastNearest;
            else { ; }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            miShowOnlyWithWordsToolStripMenuItem.Checked = btFilter.Checked;
        }
        #endregion

        private void btWebExport_Click(object sender, EventArgs e)
        {
            foreach (Sentence sn in this.Sentences)
            {
                if (sn.WordsToLearn.Count > 0)
                {

                }
            }
        }
    }
}
