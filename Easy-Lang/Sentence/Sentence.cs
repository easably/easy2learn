using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace f
{
    public class Sentence : ISentence
    {
        //internal static string emptySentence = "#emptySentence#";
        internal static string emptySentenceContent = "#emptySentenceContent#";
        protected List<Sentence> m_ParentList;

        public Sentence(string text, List<Sentence> parentList)
        {
            if (parentList == null) throw new ArgumentNullException();


            if (!string.IsNullOrEmpty(text)) // т.к. могут быть пустые предложения
            {
                if (text.Contains(SentenceForLesson.DelimiterForTranslComment))
                {
                    string[] texts = text.Split(new string[] { SentenceForLesson.DelimiterForTranslComment }, StringSplitOptions.RemoveEmptyEntries);
                    text = texts[0];
                    this._TranslAndComment = texts[1];
                }
            }
            else text = "";

            // чистим от наших символов
            m_TextValue = text.Replace(ForceListBox.SentenceTabSymbol, "").Replace(emptySentenceContent, "");
            // чистим от переходов на новую строку
            m_TextValue = m_TextValue.Trim(new char[] { ' ', '\n', '\r' });
            this.TextValueAsLine = this.TextValue;

            
            List<string> idioms = IdiomService.GetIdioms(this.TextValueAsLine);
            if (idioms.Count > 0) this.AddIdioms(idioms);

            m_ParentList = parentList;
        }

        string m_TextValue;
        /// <summary>
        /// Строка с переносами
        /// </summary>
        public string TextValue
        {
            get
            {
                return this.m_TextValue;
            }
            set
            {
                this.m_TextValue = value;
                this.TextValueAsLine = value;
            }
        }

        string m_TextValueAsLine;
        /// <summary>
        /// Строка для вида в списке
        /// </summary>
        public string TextValueAsLine
        {
            get
            {
                return this.m_TextValueAsLine;
            }
            set
            {
                // полностью чистим для отображения в ListBox
                m_TextValueAsLine = value.Replace("\r\n", " ").Replace('\r', ' ').Replace('\n', ' '); // .Replace(TabSymbol, indent);
                //TODO: с русскими субтитрами не пошло
                //while (m_placard.IndexOf("  ") > -1)
                //    m_placard = m_placard.Replace("  ", " ");
            }
        }

        /// <summary>
        /// Чистая строка для списка
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}.  {1}", this.Index, this.TextValueAsLine);
        }

        public int Index
        {
            get{
                return m_ParentList.IndexOf(this)+1;
            }
        }

        #region Idiomsn and RTF
        List<string> m_Idioms = null;
        List<string> ListIdioms
        {
            get
            {
                if (m_Idioms == null) m_Idioms = new List<string>();
                return m_Idioms;
            }
        }

        public string[] Idioms
        {
            get { return (string[])ListIdioms.ToArray(); }
        }

        bool IsNeedRefreshTextAsRTF = false;

        public void AddIdioms(List<string> idioms)
        {
            this.ListIdioms.AddRange(idioms);
            // здесь нельзя вызвать поскольку идиомы вызыввются в другом потоке и форма ещё не успела запустится
            IsNeedRefreshTextAsRTF = true;
        }

        #region Diapasons for define idiom in text (for context menu)
        //                    ClearDiapasons();


        //List<Diapason> Diapasons = new List<Diapason>();

        //public void AddDiapason(int Start, int length, string value)
        //{
        //    Diapasons.Add(new Diapason(Start, length, value));
        //}

        //public Diapason GetSelectedIdiom(int position)
        //{
        //    foreach (Diapason d in Diapasons)
        //    {
        //        if (d.Start <= position && position <= (d.Start + d.Length))
        //            return d;
        //    }
        //    return null;
        //}

        //public void ClearDiapasons()
        //{
        //    Diapasons.Clear();
        //    //this.Text.SelectAll();
        //    //this.Text.SelectionBackColor = Color.White;
        //    //this.Text.DeselectAll();
        //}
        #endregion

        #endregion

        #region WordsToLearn and RTF
        public List<string> WordsToLearn
        {
            get { return ListWordsToLearn; }
        }
        
        public void AddAllWordsToLearn(List<string> words)
        {
            this.ListWordsToLearn.AddRange(words);
            RefreshTextAsRTF();
            GlobalOptions.IsChangedLesson = true;
        }

        public void AddWordsToLearn(string word)
        {
            if (string.IsNullOrEmpty(word)) return;
            this.ListWordsToLearn.Add(word);
            RefreshTextAsRTF();
            GlobalOptions.IsChangedLesson = true;
        }

        public void RemoveWordsToLearn(string word)
        {
            this.ListWordsToLearn.Remove(word);
            RefreshTextAsRTF();
            GlobalOptions.IsChangedLesson = true;
        }
        
        public void RemoveAllWordsToLearn()
        {
            if (m_WordsToLearn != null)
            {
                this.WordsToLearn.Clear();
                RefreshTextAsRTF();
                GlobalOptions.IsChangedLesson = true;
            }
        }

        List<string> m_WordsToLearn = null;
        List<string> ListWordsToLearn
        {
            get
            {
                if (m_WordsToLearn == null) m_WordsToLearn = new List<string>();
                return m_WordsToLearn;
            }
        } 

        string m_TextAsRTF = null;
        public string TextAsRTF
        {
            get
            {
                if (string.IsNullOrEmpty(m_TextAsRTF) || IsNeedRefreshTextAsRTF)
                    RefreshTextAsRTF();
                return m_TextAsRTF; 
            }
        }

        //public void SetWrongSymbol(int ind)
        //{
        //    Utils.EditorRTF.Rtf = this.TextAsRTF;
        //    Utils.EditorRTF.Select(ind, 1);
        //    Utils.EditorRTF.SelectionFont = new Font(Utils.EditorRTF.SelectionFont, FontStyle.Bold);
        //    this.m_TextAsRTF = Utils.EditorRTF.Rtf;
        //}
        #endregion

        void RefreshTextAsRTF()
        {
            Utils.EditorRTF.Text = this.TextValue;
            foreach (string word in WordsToLearn) // здесь строки
            {
                int start = -1;
                #region поиск участка (диапазона) выделения
                foreach (char c in IdiomService.IdiomDelimiters)
                {// искать будем по первой паре слов
                    //TODO: может произойти более раннее выделение
//                        string firstCoupleWords = d.Split(' ')[0] + c + d.Split(' ')[1];
                    string firstCoupleWords = word.ToLower();
                    start = Utils.EditorRTF.Text.ToLower().IndexOf(firstCoupleWords); //если работать с переменной sentence почему то может различаться на пробел ... a few = (The writer of these humble lines being a Waiter, and having come of a family of Waiters, and owning at the present time fi)
                    if (start != -1)
                        break;
                }
                if (start == -1)
                {
                    //MessageBox.Show(string.Format("Error on selected word '{0}'", word), this.TextValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                #endregion
                // выделение
                Utils.EditorRTF.Select(start, word.Length);
                Utils.EditorRTF.SelectionBackColor = ForceListBox.LightColor; //very strong!! Color.Silver;
                if (start == 0) Utils.doResetPreviousColorState = true;
            }

            #region idioms
            foreach (string idiom in this.Idioms)
            {
                int start = -1;
                #region поиск участка выделения
                foreach (char c in IdiomService.IdiomDelimiters)
                {// искать будем по первой паре слов
                    //TODO: может произойти более раннее выделение
                    string firstCoupleWords = idiom.Split(' ')[0] + c + idiom.Split(' ')[1];
                    start = Utils.EditorRTF.Text.ToLower().IndexOf(firstCoupleWords); //если работать с переменной sentence почему то может различаться на пробел ... a few = (The writer of these humble lines being a Waiter, and having come of a family of Waiters, and owning at the present time fi)
                    if (start != -1)
                        break;
                }
                if (start == -1)
                {
            //        MessageBox.Show(string.Format("Error on selected idiom {0}", idiom), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                #endregion

                // выделение
                Utils.EditorRTF.Select(start, idiom.Length);
                Utils.EditorRTF.SelectionFont = new Font(Utils.EditorRTF.Font.Name, Utils.EditorRTF.Font.Size, FontStyle.Underline);
                // если выделение цветом началось с первого слова то эта зараза распространится дальше
                if (start == 0) Utils.doResetPreviousColorState = true;
                //editorForIdiom.SelectionFont = new Font(editorForIdiom.SelectionFont, FontStyle.Underline);
              //  this.AddDiapason(start, idiom.Length, idiom);
            } 
            #endregion
            m_TextAsRTF = Utils.EditorRTF.Rtf;
            IsNeedRefreshTextAsRTF = false;
            if (Utils.doResetPreviousColorState)
            {
                Utils.EditorRTF.SelectAll();
                Utils.EditorRTF.SelectionBackColor = Color.White;
                Utils.EditorRTF.SelectionFont = new Font(Utils.EditorRTF.Font.Name, Utils.EditorRTF.Font.Size, FontStyle.Regular);
                Utils.doResetPreviousColorState = false;
            }
        }

        #region CashForTranslation
       // string _keyForCash = "";

        Dictionary<string, string> CashForTranslation = null;

        //TODO: isFullSentence кривой параметр
        internal void AddCashForTranslation(string key, string translation)
        {
            if (string.IsNullOrEmpty(key)) 
                this._TranslAndComment = translation;
            else {
                if (CashForTranslation == null) 
                    CashForTranslation = new Dictionary<string, string>();
                if (CashForTranslation.ContainsKey(key))
                    CashForTranslation[key] = translation;
                else CashForTranslation.Add(key, translation);
            }
        }

        internal string GetCashForTranslation(string key)
        {
            if (CashForTranslation != null) 
                if (CashForTranslation.ContainsKey(key))
                    return CashForTranslation[key];
            return "";
        }

        string _TranslAndComment = "";
        public string TranslAndComment
        {
            get { return this._TranslAndComment; 
            }
        }

        /// <summary>
        /// При смене языка чистим кеши
        /// </summary>
        public void ClearCashForTranslation()
        {
            if (CashForTranslation != null) 
                CashForTranslation.Clear();
            _TranslAndComment = null;
        }
        #endregion

        internal string GetTextLesson()
        {
            string ret = this.TextValueAsLine; // similar to  ==     ret = ret.Replace("\r", "").Replace("\n", "");
            foreach (string word in WordsToLearn) // здесь строки
            {
                if (!string.IsNullOrEmpty(word))
                    ret = ret.Replace(word, SentenceForLesson.DelimiterForWord + word + SentenceForLesson.DelimiterForWord);
            }

            if (!string.IsNullOrEmpty(this.TranslAndComment))
                ret += SentenceForLesson.DelimiterForTranslComment + " "; // this.TranslAndComment;
            return ret;
        }
    }
}