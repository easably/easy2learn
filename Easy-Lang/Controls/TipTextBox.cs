using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace f
{
    public class TipTextBox : FmRichTextBox
    {
        public static char[] SymbolEndWord = new char[] { ' ', '-', '\n', '\r', '\\', '\"', '“', '”', '〝', '〞', '(', ')', '/', '.', ':', ';', ',', '~', '?', '!', '&', '。' };
        private ContextMenuStrip contextMenu;
        internal ToolStripMenuItem miTranslate;
        private ToolStripMenuItem miOpenInDictionaryBlend;

        public delegate void DelegatePopupDictionaryArticle(TipTextBox sender, Point point, int charIndexUnderCursor);
        private DelegatePopupDictionaryArticle delegatePopupDictionaryArticle;

        public TipTextBox()
        {
            InitializeComponent();

           // this.MinimumSize = new Size(60, 30);
            //this.vs

            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Font = new Font(this.Font.Name, 12);

            delegatePopupDictionaryArticle = new DelegatePopupDictionaryArticle(TipHelper.Instance.PopupDictionaryArticle);

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textEn_MouseMove);
            this.MouseLeave += new EventHandler(textEn_MouseLeave);
            this.TextChanged += new EventHandler(ToolTipTextBox_TextChanged);
            
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            this.IsShowPopup = true; // timer.Start();

            // contextMenu
            this.ContextMenuStrip = this.contextMenu;
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(contextMenu_Opening);
            this.miTranslate.Visible = false;
            this.miCopy.Click += new EventHandler(miCopy_Click);
            this.miTranslate.Click += new EventHandler(miTranslate_Click);
            this.miOpenInDictionaryBlend.Click += new EventHandler(miOpenInDictionaryBlend_Click);
        }

        #region context Menu
        void miOpenInDictionaryBlend_Click(object sender, EventArgs e)
        {
            if (this.SelectedText.Length > 0)
                MenuForSelected.OpenInDictionaryBlend(this.SelectedText);
            else MenuForSelected.OpenInDictionaryBlend(this.CurrentWord);
        }

        void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.miTranslate.Visible )
                this.miTranslate.Enabled = this.SelectedText.Length == 0;
            SeCursorUnderArrow();
        } 

        void miCopy_Click(object sender, EventArgs e)
        {
            if (this.SelectedText.Length > 0)
            {
                Clipboard.SetData("Text", this.SelectedText);
            }
            else
            {
                Clipboard.SetData("Text", this.Text);
                // old variant  Clipboard.SetData("Text", this.CurrentWord);
            }
        }

        void miTranslate_Click(object sender, EventArgs e)
        {
           // if (this.SelectedText.Length == 0)
                this.SelectCurrentWord();
        }

        internal void SelectCurrentWord()
        {
            int ifoo = this.SelectionStart;
            int iWordStart = this.SelectionStart;
            string word = GetWord(this, ref iWordStart, ref ifoo);
            //if (word.StartsWith(" ")) iWordStart -= 1;

            if (!string.IsNullOrEmpty(word))
            {
                if (word.Contains(SentenceForLesson.CharHided))
                {
                    ifoo = this.SelectionStart;
                    iWordStart = this.SelectionStart;
                    string maskedWord = GetMaskedWord(this, ref iWordStart, ref ifoo);
                    if (!string.IsNullOrEmpty(maskedWord))
                        this.Select(iWordStart, ifoo - iWordStart);
                }
                else
                {
                    //                    bool isPlural = word.ToLower().EndsWith("s");
                    //                    this.Select(iWordStart, ifoo - iWordStart + (isPlural ? -1 : 0));
                    this.Select(iWordStart, ifoo - iWordStart);
                }
            }
        }

        private void SeCursorUnderArrow()
        {
            Point p = ((Control)this).PointToClient(Cursor.Position);
            if (!this.Focused) this.Focus(); // autoselect control
            int index = this.GetCharIndexFromPosition(p);
            if (UtilsForText.IsInSelectedText(index, this)) return;
            this.Select(index, 0);
        }
        #endregion

        void ToolTipTextBox_TextChanged(object sender, EventArgs e)
        {
             this.CloseToolTip();
        }

        private Timer timer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem miCopy;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipTextBox));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenInDictionaryBlend = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 500;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTranslate,
            this.miCopy,
            this.miOpenInDictionaryBlend});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(204, 70);
            // 
            // miTranslate
            // 
            this.miTranslate.Name = "miTranslate";
            this.miTranslate.Size = new System.Drawing.Size(203, 22);
            this.miTranslate.Text = "Translate";
            this.miTranslate.ToolTipText = "Translate current word (text under cursor)";
            // 
            // miCopy
            // 
            this.miCopy.Image = ((System.Drawing.Image)(resources.GetObject("miCopy.Image")));
            this.miCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCopy.Name = "miCopy";
            this.miCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miCopy.Size = new System.Drawing.Size(203, 22);
            this.miCopy.Text = "&Copy";
            // 
            // miOpenInDictionaryBlend
            // 
            this.miOpenInDictionaryBlend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miOpenInDictionaryBlend.Name = "miOpenInDictionaryBlend";
            this.miOpenInDictionaryBlend.Size = new System.Drawing.Size(203, 22);
            this.miOpenInDictionaryBlend.Text = "Open in DictionaryBlend";
            this.miOpenInDictionaryBlend.ToolTipText = "Open DictionaryBlend with current word (text under cursor)";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Get ... UnderCursor
        int GetCharIndexUnderCursor(Point point)
        {
            int ret = this.GetCharIndexFromPosition(point);

            // проверим можеткурсор находится под текстом (а не над)
            Point pointForCheck = this.GetPositionFromCharIndex(ret); // крайний верхний y(игрик) текста
            int ExtremeBottomLine = pointForCheck.Y + (int)(this.Font.Size * 1.7);
            if (ExtremeBottomLine < point.Y)
                return -1;
            return ret;
        }

        internal string GetStringUnderCursor(int charIndexUnderCursor, ref string maskWord)
        {
            if (charIndexUnderCursor == -1) return "";

            //  Console.WriteLine(wordStart.ToString());
            int wordStart = charIndexUnderCursor;
            int wordEnd = charIndexUnderCursor;
            //  if (oldInitialStartWord == wordStart) return;
            string word = "";
            if (IsInSelectedText(wordStart, this)) // курсор находится в выделенном
            {
                wordStart = this.SelectionStart;
                wordEnd = wordStart + this.SelectionLength;
                word = this.Text.Substring(wordStart, wordEnd - wordStart).Trim(SymbolEndWord);
            }
            else
            {
                word = GetWord(this, ref wordStart, ref wordEnd);
            }
            // if (ttForCurrentDisplay == this.toolTip2 || ttForCurrentDisplay == null)
            //ttForCurrentDisplay = this.toolTip1;
            //  else ttForCurrentDisplay = this.toolTip2;

            // Console.WriteLine("Log: finded word '{0}'", word);
            // может быть одно и то же слово в разных местах, поэтому сравниваем со страм словом по индексу
            if (oldStartWord == wordStart && oldEndWord == wordEnd
                //                && !ttForCurrentDisplay.Active // Active это showed
                )
                return "";

            // Console.WriteLine("oldwordStart - {0}; oldwordEnd - {1}", oldStartWord, oldEndWord);
            oldStartWord = wordStart;
            oldEndWord = wordEnd;
            //  Console.WriteLine("wordStart - {0}; wordEnd - {1}", wordStart, wordEnd);
            if (word.Contains(SentenceForLesson.CharHided) && this.Sentence != null)
            {
                maskWord = word;
                word = GetClearWord(this.Sentence, wordStart, wordEnd);
            }
            return word;
        }
        
        #endregion
        /// <summary>
        /// Replace hided chars
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="wordStart"></param>
        /// <param name="wordEnd"></param>
        /// <returns></returns>
        public static string GetClearWord(Sentence sentence, int wordStart, int wordEnd)
        {
            string clearText = sentence.TextValue.Replace(SentenceForLesson.DelimiterForWord.ToString(), "");
            string word = clearText.Substring(wordStart, wordEnd - wordStart);
            return word.Trim();
        }

        #region LangDir
        public event EventHandler ChangeLangDir;

        LangPair m_LangDir = new LangPair("en", "ru");
        public LangPair LangDir
        {
            get { return m_LangDir; }
            set
            {
                m_LangDir = value;
                if (ChangeLangDir != null) 
                    ChangeLangDir.Invoke(this, EventArgs.Empty);
            }
        } 
        #endregion

        #region static
        public static string GetCurrentWord(RichTextBox textBox)
        {
            if (textBox == null) return "";

            string word = textBox.SelectedText;
            if (string.IsNullOrEmpty(word))
            {
                int ifoo = textBox.SelectionStart;
                int iWordStart = textBox.SelectionStart;
                word = GetWord(textBox, ref iWordStart, ref ifoo);
            }
            word = word.Trim(SymbolEndWord);
            return word;
        }

        public static string GetWord(RichTextBox sender, ref int wordStart, ref int wordEnd)
        {
            if (!((wordStart >= 0) && (wordStart < sender.Text.Length)))
                return string.Empty;
            if (sender.Text[wordStart] == ' ') return string.Empty;
            int iMax = sender.Text.Length;
            while ((iMax > wordEnd) && IsLetter(sender.Text[wordEnd]))
                ++wordEnd;
            while ((wordStart > 0) && IsLetter(sender.Text[wordStart-1]))
                --wordStart;
            string word = sender.Text.Substring(wordStart, wordEnd - wordStart).Trim(SymbolEndWord);
            return word;
        }

        public static string GetMaskedWord(RichTextBox sender, ref int wordStart, ref int wordEnd)
        {
            if (!((wordStart >= 0) && (wordStart < sender.Text.Length)))
                return string.Empty;
            if (sender.Text[wordStart] == ' ') return string.Empty;
            int iMax = sender.Text.Length;
            while ((iMax > wordEnd) && sender.Text[wordEnd] == SentenceForLesson.MaskedChar)
                ++wordEnd;
            while ((wordStart > 0) && sender.Text[wordStart - 1] == SentenceForLesson.MaskedChar)
                --wordStart;
            string word = sender.Text.Substring(wordStart, wordEnd - wordStart).Trim(SymbolEndWord);
            return word;
        }

        static bool IsInSelectedText(int index, RichTextBox sender)
        {
            return sender.SelectedText.Length > 0 &&
                sender.SelectionStart < index && // т.е. курсор находится в выделенном диапазоне текста
                (sender.SelectionStart + sender.SelectionLength) > index;
        }

        static bool IsLetter(char c)
        {
            return (char.IsLetter(c) && !char.IsPunctuation(c) && !char.IsSeparator(c)) || c == SentenceForLesson.CharHided[0];
        }
        #endregion

        #region Hint
        int oldStartWord, oldEndWord;
        private bool isMouseMoved = false;
        private MouseEventArgs savedMouseEventArgs = null;

        public bool IsMonoRegim { get; set; }

        void ResetOldDataForHint()
        {
            oldStartWord = oldEndWord = -1;
        }

        int ResetCounter = 0;
        int WatingCounterOnMouseOver = 0; // for wating on mouse enter over textbox

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!this.IsShowPopup) return;

            if (savedMouseEventArgs == null) return;
            if (this.Disposing || this.IsDisposed) return;

            int charIndexUnderCursor = GetCharIndexUnderCursor(new Point(savedMouseEventArgs.X, savedMouseEventArgs.Y));
           // if (charIndexUnderCursor == -1) this.CloseToolTip();

            ++ResetCounter;
            if (ResetCounter > 3) // 3*800 == 2500
            {
                ResetOldDataForHint();
                ResetCounter = 0;
            }
            if (WatingCounterOnMouseOver > 1 && isMouseMoved)
            {
                isMouseMoved = false;
                this.BeginInvoke(delegatePopupDictionaryArticle,
                    new object[] { this, savedMouseEventArgs.Location, charIndexUnderCursor });
            }
            ++WatingCounterOnMouseOver;
        }

        bool m_ShowPopup;
        public bool IsShowPopup
        {
            get { return m_ShowPopup; }
            set
            {
                m_ShowPopup = value;
                this.timer.Enabled = m_ShowPopup;
            }
        }
        #endregion

        #region Mouse for Hint
        private void textEn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                if (savedMouseEventArgs == null || !savedMouseEventArgs.Location.Equals(e.Location))
                {
                    // для дальнейшей обработки таймером
                    savedMouseEventArgs = e;
                    isMouseMoved = true;
                    // Console.WriteLine("isMouseMoved = true, move args {0}", e.Location);
                }
            }
            //  PopupDictionaryArticle(savedTextBox, savedMouseEventArgs);
        }

        void textEn_MouseLeave(object sender, EventArgs e)
        {
            //if (tipIsShowed)
            {
                if (!MousePointerUnderControl(this)) // , Cursor.Position))
                    CloseToolTip();
            }
            WatingCounterOnMouseOver = 0;
        }

        static bool MousePointerUnderControl(Control cntr) // , Point point)
        {
            Rectangle rect = new Rectangle(cntr.Left, cntr.Top, cntr.Right, cntr.Bottom);
            return cntr.RectangleToScreen(rect).Contains(Cursor.Position);
        }

        private void CloseToolTip()
        {
            //if (this.ToString().ToLower().Contains("lest"))
            //    Console.WriteLine(this.ToString());
            TipHelper.Instance.Hide(this);
            ResetOldDataForHint();
            isMouseMoved = false;
        }
        #endregion
       
        Sentence m_Sentence;
        public Sentence Sentence
        {
            get { return m_Sentence; }
            set {
                if ( m_Sentence == value) return;
                m_Sentence = value;
                if (m_Sentence != null)
                {
                    if (m_Sentence is SentenceForTutor)
                        this.Text = ((SentenceForTutor)m_Sentence).MaskedText;
                    else                     
                    {
                        try
                        {
                            this.IsSystemTextChaghed = false;

                            if (!string.IsNullOrEmpty(m_Sentence.TextAsRTF))
                            {
                                float factor = this.ZoomFactor;
                                this.Rtf = m_Sentence.TextAsRTF;
                                if (factor != this.ZoomFactor) this.ZoomFactor = factor;
                            }
                            else this.Text = m_Sentence.TextValue;
                        }
                        finally
                        {
                            this.IsSystemTextChaghed = false;
                        }
                    }  
                }
                else this.Text = "";
            }
        }

        public void ListenCurrentWord()
        {
            if (!IsAvailableListen) return;
            new SoundStarter(GetCurrentWord(this).ToLower(), this.LangDir.From);
        }

        public bool IsAvailableListen { get { return true; } }// this.LangDir.From.Equals("en"); } }

        public string CurrentWord
        {
            get
            {
                return TipTextBox.GetCurrentWord(this);
            }
        }

        #region HidedText
        LinkLabel m_HidedLinkLabel = null;
        LinkLabel HidedLinkLabel
        { 
            get{
                if (m_HidedLinkLabel == null)
                {
                    m_HidedLinkLabel = CreateLinkLabel(SHOW_TRANSLATED);
                    this.Controls.Add(m_HidedLinkLabel);
                    m_HidedLinkLabel.Dock = DockStyle.Fill;
                    m_HidedLinkLabel.Click += new EventHandler(ll_Click);
                }
                return m_HidedLinkLabel;
            }
        }

        static readonly string SHOW_TRANSLATED = "SHOW TRANSLATION";

        public bool m_IsHidedTranslation = false;
        // [ Designable false
        public bool IsHidedTranslation
        {
            set { m_IsHidedTranslation = value; CheckHidedStatus(); }
            get { return m_IsHidedTranslation; }
        }

        internal void CheckHidedStatus()
        {
            HidedLinkLabel.Visible = this.IsHidedTranslation;

            //if(this.IsHidedTranslation)
            //{
            //    true;
            //}
        }

        private LinkLabel CreateLinkLabel(string value)
        {
            LinkLabel ll = new LinkLabel();
            ll.ActiveLinkColor = System.Drawing.Color.Black;
            ll.BackColor = System.Drawing.Color.Gainsboro;
//            ll.BackColor = System.Drawing.SystemColors.Info; // System.Drawing.SystemColors.Window;
            ll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ll.LinkColor = System.Drawing.Color.Silver;
            ll.Location = new System.Drawing.Point(93, 273);
            ll.Name = "lbShowHided";
            ll.Size = new System.Drawing.Size(416, 128);
            ll.TabIndex = 6;
            ll.TabStop = true;
            ll.Text = value;
            ll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ll.VisitedLinkColor = System.Drawing.Color.Silver;
            return ll;
        }

        void ll_Click(object sender, EventArgs e)
        {
            //IsHidedTranslation = false;
            ((Control)sender).Visible = false;
        }
        #endregion
    }
}
