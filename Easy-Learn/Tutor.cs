using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Windows7;
using System.Xml.Serialization;

namespace f
{
    public partial class Tutor : Form, ITextsForMenu
    {
        TipTextBox txBox = null;
        public Tutor()
        {
            InitializeComponent();

            this.BackColor = CF.ExternalBorder;
            this.panel1.BackColor = Color.White;
            this.tutorList1.List.Font = new Font(this.Font.Name, 12);
            this.tutorList1.List.SelectedIndexChanged += new EventHandler(List_SelectedIndexChanged);
            this.tutorList1.panelTopIndent.Padding = new Padding(4, 2, 190, 4);
            this.tutorList1.panelTopIndent.Visible = true;

            this.keyBoards.PressYesLetter += new EventHandler(z1_PressYesLetter);

            txBox = this.textArea.ForeignText;
            this.tutorList1.Initialize(txBox);

            this.txBox.HideSelection = false;
            this.txBox.IsSystemTextChaghed = false;
            this.txBox.HideSelection = false;

            this.txBox.SelectionChanged += new System.EventHandler(this.txBox_SelectionChanged);

            this.splitterHorizontal.Paint += new System.Windows.Forms.PaintEventHandler(this.splitterHorizontal_Paint);


            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyProcess);
            this.keyBoards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyProcess);
            this.textArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyProcess);
            this.tutorList1.List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyProcess);

            this.textArea.translatedText.TabStop = false;

            // init menu bar
            this.menuForSelected.TextsForMenu = this;

            // init top menu
            btPrev.Click += new EventHandler(btPrev_Click);
            btNext.Click += new EventHandler(btNext_Click);
            btExit.Click += new EventHandler(btExit_Click);

            #region replace items from main menu
            List<ToolStripItem> menuItems = new List<ToolStripItem>();
            foreach (ToolStripItem item in this.toolStrip1.Items)
                menuItems.Add(item);
            foreach (ToolStripItem item in menuItems)
                this.tutorList1.toolStrip1.Items.Add(item);
            #endregion

           // this.RestoreState();
            this.FormClosed += new FormClosedEventHandler(Tutor_FormClosed);

            this.menuForSelected.TextsForMenu = this;
            this.menuForSelected.InitDictionaries(this.textArea);

            #region scores
            // scores
            this.tutorList1.List.SelectedIndexChanged += new EventHandler(List_SelectedIndexChangedForScore);
            this.tutorList1.TextReloaded += new SentenceList.ListContentUpdated(tutorList1_TextReloaded);
            this.tutorList1.ChangingFile += new EventHandler(tutorList1_ChangingFile);
            this.scoreCurrent.ToolTipPrefix = "Score for current sentence";
            this.scoreProgressForAllSentences.ToolTipPrefix = "Score for the whole lesson ";
            // ResetProgress for all
            this.scoreCurrent.ResetProgress();
            this.scoreProgressForAllSentences.ResetProgress();
            this.scoreCurrent.ResetProgress(); 
            #endregion

            this.textArea.paForeignText.Height = 62;
            this.tutorList1.TextReloaded += new SentenceList.ListContentUpdated(LessonReloaded);

            this.btAbout.Click += new System.EventHandler(this.miAbout_Click);
            this.btSendFeedback.Click += new System.EventHandler(this.miSendFeedback_Click);
            this.btExit.Click += new System.EventHandler(this.miExit_Click);
            this.menuForSelected.IsWordAavailable = true;
            this.menuForSelected.SwitchOfAddWordsToLesson();
            
            CurrentLangInfo.ChangedLanguageDirection += new EventHandler(Common_ChangedLanguageDirection);            
            this.menuForSelected.HideTranslationStateChanged += new EventHandler(MenuForSelected_HideTranslationStateChanged);
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    int half = (int)this.Height / 2;
        //    // if (half < this.TwinText.Height)
        //    {
        //        this.paForText.Height = half;
        //    }
        //    base.OnResize(e);
        //    this.splitterHorizontal.Refresh();
        //}

        void MenuForSelected_HideTranslationStateChanged(object sender, EventArgs e)
        {
            this.textArea.UpdateTranslation();
            ClearCash();
        }

        #region LessonReloaded
        void LessonReloaded(SentenceList sender, EventArgs e)
        {
            UpdateTitle();
            //CheckButtonsForNavigation();
        }

        void UpdateTitle()
        {
            if (!string.IsNullOrEmpty(this.tutorList1.FileName))
                this.Text = string.Format("{0} - {1}", Application.ProductName, Utils.GetShortFileName(this.tutorList1.FileName));
            else this.Text = "Please open a file with extension *.lesson";
        } 
        #endregion

        ToolStripMenuItem itemShowHidePreviousScore = new ToolStripMenuItem("Show/Hide score from previous sessions");

        private void AddExtensions()
        {
            itemShowHidePreviousScore.CheckOnClick = true;
            itemShowHidePreviousScore.CheckedChanged += new EventHandler(item_CheckStateChanged);
            //itemShowHidePreviousScore.ToolTipText = "Click here for Show/Hide score from previous sessions";
            this.menuForSelected.ddbtOptions.DropDownItems.Add(itemShowHidePreviousScore);
        }

        void item_CheckStateChanged(object sender, EventArgs e)
        {
            //TODO: scoreForPreviousSessions
            // this.splitter1.Visible = itemShowHidePreviousScore.Checked;
            // this.scoreForPreviousSessions.Visible = 
        }

        #region Score
        void tutorList1_ChangingFile(object sender, EventArgs e)
        {
            SaveScore();
        }

        void tutorList1_TextReloaded(SentenceList sender, EventArgs e)
        {
            if (IsHaveLessonFile)
                OpenScore();
            else      
            {
                this.scoreCurrent.ResetProgress();
                this.scoreProgressForAllSentences.ResetProgress();
            }
        }

        void List_SelectedIndexChangedForScore(object sender, EventArgs e)
        {
            if (this.CurrentLesson == null) return;
            this.keyBoards.ScoreData = 
            this.scoreCurrent.ScoreData = this.CurrentLesson.ScoreData;
        }
        #endregion

        #region Score Open & Save
        bool IsHaveLessonFile { get {
                return !string.IsNullOrEmpty(this.LessonFileName) 
                    && (this.tutorList1.Sentences.Count > 0 && this.tutorList1.Sentences[0] is IScoreUnit);
            }
        }

        void SaveScore()
        {
            if (IsHaveLessonFile)
            {
                ScoreUtils.SaveScore(GetUnits(), this.LessonFileName);
            }
        }

        void OpenScore()
        {
            if (!IsHaveLessonFile) return;
            List<IScoreUnit> list = GetUnits();           
            ScoreUtils.AssignScore(this.LessonFileName, list);
            // даем предыдущий результат
            this.scoreProgressForAllSentences.ScoreData = ScoreUtils.GetScoreData(list);
            // assign current score
            List_SelectedIndexChangedForScore(null, EventArgs.Empty);
        }

        // translate List<Sentence> to List<IScoreUnit>
        private List<IScoreUnit> GetUnits()
        {
            List<IScoreUnit> list = new List<IScoreUnit>();
            foreach (IScoreUnit unit in this.tutorList1.Sentences)
                list.Add(unit);
            return list;
        }

        List<ScoreData> Scores = new List<ScoreData>();
        #endregion

        #region save and restore
        public void RestoreState()
        {
            try {
                // ---- LanguageDirection ----
               // CF.


                CF.AssignValues("MainForm", this, new Point(100, 100), new Size(871, 712));

                string _LessonFileName = CF.GetValue("LessonFileName", CF.GetFolderForUserFiles() + @"\Video.EN.srt.lesson");
                _LessonFileName = FileManager.FindPath(_LessonFileName, @"\my_video\my_movie.lesson - specify a file with your lesson");


                if (string.IsNullOrEmpty(this.tutorList1.FileName) && File.Exists(_LessonFileName))
                    this.LessonFileName = _LessonFileName;

 //               CurrentLangInfo.InitLanguagesMenu(this.toolStrip1);
                CurrentLangInfo.InitLanguagesMenu(this.miLanguages);
                CurrentLangInfo.LanguageDirection = CF.GetValue("LanguageDirection", CurrentLangInfo.DefaultLangDir);

                this.menuForSelected.LastDictName = CF.GetValue("LastDictionary", GoogleDictionary.MainTitle);

                this.menuForSelected.miHideTranslation.Checked = CF.GetValue("IsHidedTranslation", false);
                this.itemShowHidePreviousScore.Checked = CF.GetValue("ShowPreviousScore", false);
                item_CheckStateChanged(null, EventArgs.Empty);
            }
            catch (Exception ex) {
                Messages.ErrorOnRestoringApp(ex);
            }
        }

        void Tutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveScore();
            CF.SetValue("MainForm", this);
            CF.SetValue("LessonFileName", this.LessonFileName);
            CF.SetValue("LanguageDirection", this.textArea.LangDir.ToString());
            CF.SetValue("IsHidedTranslation", this.menuForSelected.miHideTranslation.Checked);
            CF.SetValue("LastDictionary", this.menuForSelected.LastDictName);
            CF.SetValue("ShowPreviousScore", this.itemShowHidePreviousScore.Checked);
        }

        void Common_ChangedLanguageDirection(object sender, EventArgs e)
        {
            this.textArea.SetUpLangDir = new LangPair(CurrentLangInfo.LanguageDirection);
            ClearCash();
        }

        private void ClearCash()
        {
            if (this.tutorList1.Sentences != null)
                foreach (Sentence sen in this.tutorList1.Sentences)
                    sen.ClearCashForTranslation();
        }
        #endregion

        #region events for top menu
        void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void btNext_Click(object sender, EventArgs e)
        {
            ++this.tutorList1.SafeSelectedIndex;
        }

        void btPrev_Click(object sender, EventArgs e)
        {
            --this.tutorList1.SafeSelectedIndex;
        } 
        #endregion

        #region Keyprocess
        private void KeyProcess(object sender, KeyEventArgs e)
        {            
            bool doSuppressKeyPress = true;
            if (e.KeyData == Keys.PageUp)
                btNext_Click(null, null);
            if (e.KeyData == (Keys.PageUp | Keys.Control))
                this.tutorList1.SafeSelectedIndex -= 10;
            else if (e.KeyData == Keys.PageDown)
                btPrev_Click(null, null);
            else if (e.KeyData == (Keys.PageDown | Keys.Control))
                this.tutorList1.SafeSelectedIndex += 10;
            else if (e.KeyData == (Keys.F1) && e.Alt)
                this.menuForSelected.OpenInLast();
            else if (this.keyBoards.YesLetter == (int)e.KeyData ) // || // Char.ToUpper(this.z1.YesLetter)
            {
                keyBoards.ScoreData.CurPasses += 1;
                OpenCurrentSymbol();
            }
            else if (e.KeyData == Keys.Enter) 
            {
                keyBoards.ScoreData.CurHints += 1;
                OpenCurrentSymbol();
            }
            else if (((e.KeyData == Keys.Left) || (e.KeyData == Keys.Right)) && sender == this.tutorList1.List) // this.tutorList1.Focused)
            {
                this.txBox.Focus();
                this.txBox.Select(this.txBox.SelectionStart + 1, 0);
            }
            else if ( char.IsLetter((char)(int)e.KeyData) ) 
            {
                char c = (char)(int)e.KeyData;
                this.keyBoards.DoActionOnWrongSymbol(c.ToString().ToUpper());
                //this.CurrentSentence.SetWrongSymbol(this.txBox.SelectionStart);
                isHaveWrongAnswer = true;
            }
            else doSuppressKeyPress = false; 
            e.SuppressKeyPress = doSuppressKeyPress;
        }
        #endregion

        #region events for txBox
        private void txBox_SelectionChanged(object sender, EventArgs e)
        {
            this.keyBoards.YesLetter = GetHidedChar();
        }

        SentenceForTutor CurrentLesson { get { return this.txBox.Sentence as SentenceForTutor; } }

        /// <summary>
        /// Возбуждается когда уже произошел правильный выбор
        /// </summary>
        void z1_PressYesLetter(object sender, EventArgs e)
        {
            OpenCurrentSymbol();
        }

        //bool innerEventForTextChanged = false;
        bool isHaveWrongAnswer = false;

        void OpenCurrentSymbol()
        {
            string textValue = this.txBox.Text;
            int index = this.txBox.SelectionStart;
            if (this.txBox.SelectionStart == this.txBox.Text.Length)
                index = this.txBox.Text.Length - 1; 
         
            textValue = textValue.Remove(index, 1);
            textValue = textValue.Insert(index, GetHidedChar().ToString()); // this.z1.YesLetter.ToString());                
            this.txBox.Text =
            this.CurrentSentence.MaskedText = textValue;
            this.tutorList1.List.Refresh(); // визуально обновляем

            if (isHaveWrongAnswer)
            {
                this.txBox.Select(index, 1);
                this.txBox.SelectionFont = new Font(Utils.EditorRTF.SelectionFont, FontStyle.Bold);
                isHaveWrongAnswer = false;
            }

            // go to next symbol
            if (this.txBox.Text.Contains(SentenceForTutor.CharHided))
                SelectNextHidedChar(index);
            else
            {
                this.txBox.SelectionStart = index; // return index for getting current word in function ListenCurrentWord
                DoActionOnCompleteSentence();
            }
            this.txBox.Focus();
        }

        // пока не конец текста
        // будем пропускать символы которые не надо отгадывать
        private void SelectNextHidedChar(int index)
        {
            // здесь работаем с того места где где стоит курсор i (т.е. с середины предложения) 
            for (int i = index; i < this.txBox.Text.Length; ++i)
            {
                if (this.txBox.Text[i] == SentenceForTutor.CharHided[0])
                {
                    this.txBox.SelectionStart = i;
                    this.txBox.SelectionLength = 1;
                    return;
                }
            }

            // если попали сюда проверяем скрытый символ сначала предложения
            for (int i = 0; i < this.txBox.Text.Length; ++i)
            {
                if (this.txBox.Text[i] == SentenceForTutor.CharHided[0])
                {
                    this.txBox.SelectionStart = i;
                    this.txBox.SelectionLength = 1;
                    return;
                }
            }
        }

        private void DoActionOnCompleteSentence()
        {
            if (this.textArea.ForeignText.IsAvailableListen)
            {
                // надо проиграть слово faint, а не ¢faint¢ed
                string guessedWord = CurrentLesson.GetWholeMaskedAsClear(this.txBox.SelectionStart);
                if (!string.IsNullOrEmpty(guessedWord))
                    new SoundStarter(guessedWord, this.textArea.ForeignText.LangDir.From);
                else this.textArea.ForeignText.ListenCurrentWord();
            }
            ScoreUtils.GetScoreState(this.CurrentSentence.ScoreData, false);
            this.tutorList1.SafeSelectedIndex += 1;
            // Update Progress For All Sentences
            ScoreUtils.SetStateForControl(this.scoreProgressForAllSentences, GetUnits());

        }
        #endregion

        char GetHidedChar()
        {
            if (CurrentSentence == null) return '@';
            //Console.WriteLine(CurrentSentence.ClearText);
            //Console.WriteLine(CurrentSentence.ClearText[this.txBox.SelectionStart]);
            if (this.txBox.SelectionStart >= CurrentSentence.ClearText.Length)
            {
                // TODO:
                return CurrentSentence.ClearText[CurrentSentence.ClearText.Length - 1];
            }
            return CurrentSentence.ClearText[this.txBox.SelectionStart];
        }

        void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.keyBoards.Freeze();
                this.textArea.Sentence = this.tutorList1.CurrentSentence;
                // this.txBox.Text = this.tutorList1.CurrentSentence.ToString();
            }
            finally
            {
                this.keyBoards.UnFreeze();
            }
            
            int startInd = this.txBox.Text.IndexOf(SentenceForTutor.CharHided);
            if (startInd != -1)
            {
                this.txBox.SelectionStart = startInd;
                this.txBox.SelectionLength = 1;
            }

            int i = 0;
            foreach (Sentence sent in this.tutorList1.Sentences)
            {
                if( !(sent is SentenceForTutor) ) continue;
                if ( ((SentenceForTutor)sent).IsGuessed ) ++i;
            }
            Windows7Taskbar.CalculateAndSet(this.Handle, this.tutorList1.List.Items.Count, i);
        }

        public string LessonFileName
        {
            get { return this.tutorList1.FileName; }
            set { 
                this.tutorList1.FileName = value;
            }
        }

        public SentenceForTutor CurrentSentence
        {
            get { 
                if(this.tutorList1.List.Items.Count == 0) return null; // иначе создается пустой элемент
                return this.tutorList1.CurrentSentence as SentenceForTutor; 
            }
        }

        private void splitterHorizontal_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawHorizontal(sender as Splitter, e);
        }

        #region ITextsForMenu Members
        public TipTextBox ActiveTextBox
        {
            get { return this.textArea.ActiveTipTextBox; }
        }

        public TipTextBox ForeingTextBox
        {
            get { return this.textArea.ForeignText; }
        }

        public TipTextBox[] TranslTextBoxs { get { return new TipTextBox[] { }; } }
        public TipTextBox[] AllTextBox { get { return new TipTextBox[] { this.textArea.ForeignText}; } }

        //TODO: so-so
        //public TipTextBox[] TranslTextBoxs { get { return new TipTextBox[] { this.textArea.TranslateText }; } }
        //public TipTextBox[] AllTextBox { get { return new TipTextBox[] { this.textArea.ForeignText, this.textArea.TranslateText }; } }
        
        #endregion

        #region utils
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void miSendFeedback_Click(object sender, EventArgs e)
        {
            Utils.SendFeedback();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
