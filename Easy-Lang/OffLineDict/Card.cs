using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Card
    {
        public Card(string rawWord, string rootWord)
        {
            this.m_RootWord = rootWord.ToLower();
            Fill(rawWord);
        }

        private Card(string rootWord, int id, EE partSpeech) //, string tie)
        {
            if (string.IsNullOrEmpty(rootWord)) throw new ArgumentNullException("targetWord");
            this.m_RootWord = rootWord.ToLower();
            this.m_ID = id;
            this.m_PartSpeech = partSpeech;
            //            this.m_TieName = tie;
        }

        //rawWord == 63;01330791 00 a 01 known 0 011 ^ 00026869 a 0000 ^ 00940237 a 0000 ^ 01091172 a 0000 ! 01332421 a 0101 & 01331163 a 0000 & 01331306 a 0000 & 01331448 a 0000 & 01331735 a 0000 & 01331882 a 0000 & 01332049 a 0000 & 01332232 a 0000 | apprehended with certainty; \"a known quantity\"; \"the limits of the known world\"; \"a musician known throughout the world\"; \"a known criminal\"  "
        void Fill(string rawCard)
        {
            if (m_IsFilled) return;
            if (string.IsNullOrEmpty(rawCard)) return;

            int _iCoountUsing = rawCard.IndexOf(';');
            if (_iCoountUsing != -1)
            {
                string coountUsingString = rawCard.Substring(0, _iCoountUsing);
                if (int.TryParse(coountUsingString, out m_CountOfUsage))
                {
                    rawCard = rawCard.Substring(_iCoountUsing + 1);
                }
            }

            string[] vals = rawCard.Split('|');
            string[] links = vals[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            #region I - word
            if (!int.TryParse(links[0], out this.m_ID))
                throw new ApplicationException(string.Format("'{0}' is not valid format for id.", links[0]));
            this.m_PartSpeech = (EE)links[2][0];
            string _TempWord = links[4];
            this.m_Synonyms = _TempWord; // в первом узле это равно == RootWord
            #region links
            List<string> forDoubleLinks = new List<string> { }; // избежим дублирования карточек
            for (int i = 5; i < links.Length; ++i)
            {
                string s = links[i];
                int id;
                if (s.Length == 8 && int.TryParse(s, out id))
                {
                    EE _partSpeech = (EE)links[i + 1][0];
                    string tie = links[i - 1];
                    string idForDoubleLinks = id + _partSpeech + tie;
                    if (forDoubleLinks.IndexOf(idForDoubleLinks) == -1)
                    {
                        forDoubleLinks.Add(idForDoubleLinks);
                        if (Tie.Types.Contains(tie))
                            tie = (string)Tie.Types[tie];

                        Card card = new Card(this.RootWord, id, _partSpeech); // , tie);
                        Childs.Add(card, tie);
                        // TODO: избежим зациклиности в дереве а может зациклиность это и правильно 
                        //if (card.ID == this.ID)
                        //    Console.WriteLine("acyclicity");
                    }
                    ++i;
                }
                // 00004711 02 r 05 merely 0 simply 0 just 0 only 2 but 1 002 \\ 01734801 a 0203 
                else if (s.Length != 1 && D.IsLetter(s[0]))
                {
                    this.m_Synonyms += ", " + s;
                }
            }
            #endregion

            this.m_Synonyms = this.m_Synonyms.Replace('_', ' ');
            #endregion
            #region II - Meanings & examples
            if (vals.Length > 1)
            {
                string[] examples = vals[1].Split(';');
                int meaningCount = 0;
                foreach (string val in examples)
                {
                    if (val.Trim().StartsWith("\""))
                        break;
                    else ++meaningCount;
                }

                this.m_Meanings = new string[meaningCount];
                for (int i = 0; i < meaningCount; ++i)
                {
                    this.m_Meanings[i] = examples[i].Trim();
                }

                this.m_Examples = new string[examples.Length - meaningCount];
                if (examples.Length > meaningCount) // если имеем примеры                
                {
                    string _BoldText = this.RootWord; // string.IsNullOrEmpty(this.RootWord) ? this.Word : this.RootWord;
                    for (int i = 0; i < examples.Length - meaningCount; ++i)
                    {
                        string _exm = examples[i + meaningCount].Trim(' ');
                        if(_exm.Trim('"').IndexOf('"') > -1) // isCitation
                            _exm = _exm.Replace('"', '\'');
                        else _exm = _exm.Trim('"');
                        ExamplesClearText.Add(_exm);

                        // вставляем пробел между кавычками
                        string _val = examples[i + meaningCount].Replace("\"", " \" ").Trim();
                        // выделяем пример если он содержит _rootWord
                        if (_val.IndexOf(_BoldText) != -1) // " Test пример с заглавной буквы " и test не совместимы
                            _val = _val.Replace(_BoldText, "<b>" + _BoldText + "</b>");
                        //_val = _val.ToUpper();  
                        this.m_Examples[i] = _val;
                    }
                }
            }
            #endregion
            m_IsFilled = true;
        }

        public void DelayedFill()
        {
            if (m_IsFilled) return;
            string rawWord = D.GetCardWordByID((char)this.PartSpeech + this.ID.ToString());
            Fill(rawWord);
        }

        #region props
        public static Hashtable TieAl = new Hashtable();// for test

        public Dictionary<Card, string> m_Childs = new Dictionary<Card, string> { };
        public Dictionary<Card, string> Childs
        {
            get
            {
                return m_Childs;
            }
        }

        bool m_IsFilled = false;
        public bool IsFilled
        {
            get { return m_IsFilled; }
        }

        int m_ID = -1;
        public int ID
        {
            get { return m_ID; }
        }

        string m_RootWord = "";
        public string RootWord
        {
            get { return m_RootWord; }
        }

        //string m_TieName = "";
        //public string TieName
        //{
        //    get { return m_TieName; }
        //}

        string m_Synonyms = "";
        public string Synonyms
        {
            get { return m_Synonyms; }
        }

        string[] m_Meanings = new string[] { };
        public string[] Meanings
        {
            get { return m_Meanings; }
        }

        string[] m_Examples = new string[] { };
        public string[] Examples
        {
            get { return m_Examples; }
        }

        List<string> m_ExamplesClearText = new List<string>();
        public List<string> ExamplesClearText
        {
            get { return m_ExamplesClearText; }
        }

        EE m_PartSpeech;
        public EE PartSpeech
        {
            get { return m_PartSpeech; }
        }

        int m_CountOfUsage = 0;
        public int CountOfUsage
        {
            get
            {
                return m_CountOfUsage;
            }
        }
        #endregion

        public static string MeaningDelimiter = "\r\n";

        public string ToolTipText
        {
            get
            {
                string tab = "  ";
                string ret = "";
                for (int i = 0; i < this.Meanings.Length; i++)
                {
                    ret += MeaningDelimiter + tab + this.Meanings[i] + (this.Meanings.Length - 1 > i ? ";" : "") + tab;
                }
                ret += MeaningDelimiter;
                foreach (string exm in this.Examples)
                    ret += MeaningDelimiter + tab + exm + tab;
                if (this.Examples.Length > -1)
                    ret += MeaningDelimiter;
                ret = ClearHtml(ret);
                return ret;
            }
        }

        //static string bold = "<b>{0}</b>";
        //static string marker = "<span style=\"background-color: #E9E9E9;\">{0}</span>";

        public string HTMLContent
        {
            get
            {
                return this.ToolTipText;
            }
        }

        static public List<string> GetExamplesByRawCard(string word, string rawCard)
        {
            List<string> list = new List<string> { };
            int startExamples = rawCard.IndexOf('"');
            if (startExamples == -1) return list;
            string subRaw = rawCard.Substring(startExamples - 1);
            foreach (string example in subRaw.Split(';'))
            {
                //                if (example.IndexOf(word + ' ') != -1 || example.IndexOf(' ' + word) != -1)
                if (example.IndexOf(word) != -1)
                {
                    string ret = example.Replace(word, "<b>" + word + "</b>");
                    ret = ret.Replace("\"", " \" ").Trim();
                    list.Add(ret);
                }
            }
            return list;
        }

        static public string ClearHtml(string text)
        {
            if (text.IndexOf("<b>") != -1)
                text = text.Replace("<b>", "").Replace("</b>", "");
            return text;
        }
    }

    //TODO: создать список идиом
}