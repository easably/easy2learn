using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class TextWithTranslate : UserControl, ITextWithSelection
    {
        public TextWithTranslate()
        {
            InitializeComponent();
            this.BackColor = SystemColors.Window;
            //this.txTranslate.HideSelection =
            this.ForeignText.HideSelection = false;
            this.ForeignText.ReadOnly = true;
            this.splitterHorizontal.Paint += new System.Windows.Forms.PaintEventHandler(this.splitterHorizontal_Paint);
            this.ForeignText.BackColor = SystemColors.Window; // ????????????

            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = 700;
            this.timer.Enabled = true;
            
            this.ForeignText.KeyDown += new KeyEventHandler(txForeign_KeyDown);
            //TODO: this.TranslateText_del.KeyDown += new KeyEventHandler(txForeign_KeyDown);
            this.ForeignText.miTranslate.Visible = true;

            this.SetUpLangDir = this.LangDir; // for refreshing LangDir in textTranslated (changin en:ru на ru:en)

            this.splitterVertical.Paint += new System.Windows.Forms.PaintEventHandler(this.splitterVertical_Paint);
            this.ForeignText.LinkClicked += ForeignText_LinkClicked;
        }

        void ForeignText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Runner.OpenURL(e.LinkText);
        }

        #region splitter_Paint
        private void splitterVertical_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawVertical(sender as Splitter, e);
        }

        private void splitterHorizontal_Paint(object sender, PaintEventArgs e)
        {
            Ul.DrawHorizontal(sender as Splitter, e);
        }
        #endregion

        void txForeign_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        #region base logic
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.Sentence == null) return;
            if (this.ForeignText.IsDisposed) return;
            // здесь вызов только выделенного текста
            // oldSelectedText сбрасывается через секунду
            if (oldSelectedText != this.ForeignText.SelectedText) // проверим с таймером что текст устоялся
                oldSelectedText = this.ForeignText.SelectedText;
            else
            {
                if (this.ActiveControl == ForeignText)
                {
                    if (oldSelectedText != previousTextForTranslate)
                    {
                        string _SelectedText = this.ForeignText.SelectedText;
                        string _maskedText = "";
                        // Console.WriteLine(_SelectedText + " -- CallTranslate(_SelectedText);"); 

                        if (_SelectedText.Contains(SentenceForLesson.CharHided)) 
                        {
                            if (_SelectedText.Length == 1) 
                                return;
                            _maskedText = _SelectedText;
                            _SelectedText = TipTextBox.GetClearWord(this.Sentence, 
                                this.ForeignText.SelectionStart, this.ForeignText.SelectionStart + this.ForeignText.SelectionLength);
                        }

                        // старое один выделенный символ не переводим
                        if (previousTextForTranslate == _SelectedText) // || _SelectedText.Length == 1 ) 
                            return;

                        if (oldSelectedText.Length > 0 && UtilsForText.IsWord(_SelectedText)) // IsHaveSeveralWords(_SelectedText))
                        {
                            string translation = this.Sentence.GetCashForTranslation(_SelectedText);
                            if (string.IsNullOrEmpty(translation) && !WWW.InternetIsUnavailable.Equals(translation) )
                            {
                                CallTranslate(_SelectedText, _maskedText);
                            }
                            else
                                this.translatedText.AssignText(translation);
                        }
                        else
                        {
                            this.translatedText.AssignText(this.Sentence.TranslAndComment);
                        }
                        previousTextForTranslate = _SelectedText;
                    }
                }
            }
        }

        void AssignTransatedText(Sentence sentence) // , string keyForCash 
        {
            // т.к. значение переменной теряется в потоке
            // используем this.txForeign.SelectedText            
            if (string.IsNullOrEmpty(this.ForeignText.SelectedText) || this.ForeignText.SelectedText[0] == SentenceForLesson.CharHided[0]) // в tutor-е всегда есть выделение для "●"
                this.translatedText.AssignText(sentence.TranslAndComment);
            else this.translatedText.AssignText(sentence.GetCashForTranslation(this.ForeignText.SelectedText));
        }

        string oldSelectedText = "";
        string previousTextForTranslate;

        MethodInvoker updateTranslatedText = null;
        WaitingUIObjectWithFinish waitObject = null;

        public void UpdateTranslation()
        {
            CallTranslate(null, "");
        }

        void CallTranslate(string word, string maskedText)
        {
            // word maybe equal null

            this.translatedText.AssignText("");
            // возможно уже и ожидание надо включать??

            //if (updateTranslatedText == null)
            updateTranslatedText = new MethodInvoker(delegate
             { AssignTransatedText(this.Sentence); });

            if (waitObject == null)
                waitObject = new WaitingUIObjectWithFinish(this, this.pictureBoxWating, updateTranslatedText);

            new ProcessorForTranslate(
                this.Sentence, word, maskedText,
                this.LangDir.From, this.LangDir.To,
                waitObject);
        } 
        #endregion

        public Sentence Sentence { get { return this.ForeignText.Sentence; } 
            set {
                if (this.ForeignText.Sentence == value) return;
                //TODO: this.TranslateText_del.CheckHidedStatus();
                this.ForeignText.Sentence = value;
                if (value != null)
                {
                    if (string.IsNullOrEmpty(value.TranslAndComment) || WWW.InternetIsUnavailable.Equals(value.TranslAndComment))
                        CallTranslate(null, ""); // argument null for translate all sentence
                    else this.translatedText.AssignText(value.TranslAndComment);
                }
                else this.translatedText.AssignText("");
            }
        }

        #region AdjustSize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustSize(); // false);
        }

        int oldWidth = -1;
        void AdjustSize() // bool force)
        {
            //TODO: while do nothing
            //bool isNewHeight = oldHeight != this.Height;
            //if ( isNewHeight ) // || force)
            //{
            //    int newHeight = (this.ForeignText.Height + this.TranslateText.Height) / 3;
            //    this.TranslateText.Height = newHeight*2;
            //}
            //oldHeight = this.Height;


            if (this.textNative.Visible)
            {
                if (oldWidth != -1 && oldWidth != this.Width) // реально ли изменился размер
                {
                    int newWidth = (this.Width - this.splitterVertical.Width - this.Padding.Right - this.Padding.Left) / 3;
                    this.textNative.Width = newWidth;
                    //int increment = (this.Width - oldWidth) / 2;
                    //this.ListEn.Width = oldWidth + increment;
                }
                oldWidth = this.Width;
            }
        }
        #endregion

        public TipTextBox ActiveTipTextBox
        {
            get { 
                TipTextBox selected = this.ActiveControl as TipTextBox;
                return selected != null ? selected : this.ForeignText;
            }
        }

        public LangPair LangDir
        {
            get { return this.ForeignText.LangDir; }
        }

        public LangPair SetUpLangDir
        {
            set 
            {
                this.ForeignText.LangDir = value; 
                //this.TranslateText_del.LangDir = LangPair.Revert(value);
                if (this.Sentence != null)
                    UpdateTranslation();
            }
        }

        public bool ShowParrallelText
        {
            get { return this.textNative.Visible; }
            set
            {
                //// perhaps here is to make alignment ???
               this.textNative.Visible = 
                this.splitterVertical.Visible =  value;

                ////// чудо!!! в момент запуска  this.textNative.Visible = value не работает Visible остается в false 
                ////// и программа с включенными параллельным текстом не работает
                //////if (this.textNative.Visible) 
                ////// не пройдет
                ////if (value) 
                ////{
                ////    this.textForeignAndTran.Dock = DockStyle.Left;
                ////}
                ////else
                ////{
                ////    //if (this.textForeignAndTran.Dock != DockStyle.Fill)
                ////    this.textForeignAndTran.Dock = DockStyle.Fill;
                ////}
                //this.oldWidth = 0;
                //this.AdjustSize();
            }
        }

        #region ITextWithSelection Members

        string ITextWithSelection.CurrentLowerWord
        {
            get { return ActiveTipTextBox.CurrentWord.ToLower(); }
        }

        LangPair ITextWithSelection.LangDir
        {
            get { return ActiveTipTextBox.LangDir; }
        }

        #endregion
    }
}
