using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Word
    {
        public Word(string word)
        {
            this.m_InitText = word;
            m_Text = word;
            //TODO: ref this.m_Text
            foreach (string cardRaw in D.GetCards(ref this.m_Text))
            {
                Card card = new Card(cardRaw, this.Text);
                this.Cards.Add(card);
                if (card.PartSpeech == EE.n)
                {
                    this.Nouns.Add(card);
                }
                else if (card.PartSpeech == EE.v)
                {
                    this.Verbs.Add(card);
                }
                else if (card.PartSpeech == EE.adv)
                {
                    this.Adverbs.Add(card);
                }
                else if (card.PartSpeech == EE.adj || card.PartSpeech == EE.adj2)
                {
                    this.Adjectives.Add(card);
                }
            }
            m_IsDubbing = !string.IsNullOrEmpty(T.SoundWords.GetWordIndex(this.Text));
            if (D.Index.ContainsKey(this.m_Text))
                m_Phonetic = D.Index[this.m_Text].Phonetic;
        }

        public bool IsEmpty
        {
            get
            {
                return this.Cards.Count == 0;
            }
        }

        #region List<Card> (Nouns, Verbs, Advrebs, Adjectives)
        List<Card> m_Nouns = new List<Card> { };
        public List<Card> Nouns
        {
            get
            {
                return m_Nouns;
            }
        }


        List<Card> m_Verbs = new List<Card> { };
        public List<Card> Verbs
        {
            get
            {
                return m_Verbs;
            }
        }

        List<Card> m_Advrebs = new List<Card> { };
        public List<Card> Adverbs
        {
            get
            {
                return m_Advrebs;
            }
        }


        List<Card> m_Adjectives = new List<Card> { };
        public List<Card> Adjectives
        {
            get
            {
                return m_Adjectives;
            }
        }

        List<Card> m_Cards = new List<Card> { };
        public List<Card> Cards
        {
            get
            {
                return m_Cards;
            }
        }
        #endregion

        bool m_IsDubbing = false;
        public bool IsDubbing
        {
            get
            {
                return m_IsDubbing;
            }
        }

        string m_InitText;
        public string InitText
        {
            get
            {
                return this.m_InitText;
            }
        }

        string m_Text;
        public string Text
        {
            get
            {
                return this.m_Text;
            }
        }


        public void PlayWord()
        {
            T.SoundWords.PlayWord(this.Text);
        }

        //TODO: потом перенести в свой тип TreeNode
        Rectangle m_TreeNodeBounds;
        public Rectangle TreeNodeBounds
        {
            get
            {
                return m_TreeNodeBounds;
            }
            set
            {
                m_TreeNodeBounds = value;
            }
        }

        string m_Phonetic = null;
        public string Phonetic
        {
            get
            {
                return m_Phonetic;
            }
        }

        public override string ToString()
        {
            string ret = this.Text;
            if (!string.IsNullOrEmpty(this.Phonetic))
                ret += "   / " + this.Phonetic + " /";
            return ret;
        }

        static public string GetLetters(string text)
        {
            //foreach (string part in PartSpeechUtil.Parts)
            //{
            //    text = text.Replace(part + '.', "");
            //}
            string ret = "";
            foreach (string word in text.Split(' '))
            {
                ret += " ";
                foreach (char ch in word)
                    if (char.IsLetter(ch) || char.IsDigit(ch) || ch == '\'' || ch == '.' || ch == '-')
                        ret += ch;
            }
            return ret.Trim();
        }

        public int GetSumUsingCount()
        {
            int i = 0;
            foreach(Card c in this.Nouns)
                i += c.CountOfUsage;
            foreach(Card c in this.Verbs)
                i += c.CountOfUsage;
            foreach(Card c in this.Adverbs)
                i += c.CountOfUsage;
            foreach (Card c in this.Adjectives)
                i += c.CountOfUsage;
            return i;
        }

        #region IComparable Members
        class ListCardComparsion : IComparer<List<Card>>
        {
            public int Compare(List<Card> x, List<Card> y)
            {
                int ix = 0;
                foreach (Card c in x)
                    ix += c.CountOfUsage;
                int iy = 0;
                foreach (Card c in y)
                    iy += c.CountOfUsage;
                return (ix - iy) * -1; // -1 for descending
            }
        }
        #endregion
       
        public string GetHTML()// bool firstNoun)
        {
            string ret = "";
            // bool showOnlyUsableWords = this.GetSumUsingCount() > 0;
            
            // отсортируем для показа в первую очерь ту часть речи, где есть максимум употребления слова
            List<List<Card>> lists = new List<List<Card>>();
            if (this.Nouns.Count > 0) lists.Add(this.Nouns);
            if (this.Verbs.Count > 0) lists.Add(this.Verbs);
            if (this.Adjectives.Count > 0) lists.Add(this.Adjectives);
            if (this.Adverbs.Count > 0) lists.Add(this.Adverbs);
            //if(firstNoun)
            //  lists.Sort(new ListCardComparsion());

            foreach(List<Card> cards in lists)
            {
                int counter = 0;
                foreach (Card c in cards)
                {
                    // т.е. покажем все карточки когда нет карточек с каким либо кол-вом словоупотреблений
                    // if (showOnlyUsableWords && c.CountOfUsage == 0) continue; 

                    if (counter == 0)
                    {
                        //string partOfSpeech = string.Format(HTML.Paragraph, HTML.AlignCenter, partOfSpeech);
                        string partOfSpeech = string.Format(HTML.Font, string.Format(HTML.Color, HTML.ColorService), GetNameByList(cards));
                        ret += partOfSpeech + HTML.NewLine;
                    }

                    ret += string.Format(HTML.Font, string.Format(HTML.Color, HTML.ColorNumber), ++counter + ") ");

                    // Meaning
                    for (int i = 0; i < c.Meanings.Length; i++)
                    {
                        string meaning = c.Meanings[i].Replace('"', '\'');
                        ret += PrepareText(meaning, (i==0 ? 2 : 0)) + HTML.NewLine;
                    }
                    // syn
                    string _synonyms = c.Synonyms.Replace(this.InitText + ", ", "").Trim(' ', ',');
                    if (_synonyms == this.InitText)
                        _synonyms = "";
                    if (_synonyms.EndsWith(" " + this.InitText))
                        _synonyms = _synonyms.Substring(0, _synonyms.Length - this.InitText.Length);
                    _synonyms = _synonyms.Trim(' ', ',');
                    if (!string.IsNullOrEmpty(_synonyms))
                    {
                        _synonyms = PrepareText(_synonyms, 5);
                        ret += string.Format(HTML.Font, HTML.ColorSynon, "syn: ") + _synonyms + HTML.NewLine;
                        //ret += "syn: " + string.Format(HTML.Font, HTML.ColorSynon, string.Format(HTML.Bold, _synonyms)) + HTML.NewLine;
                    }
                    // example
                    foreach (string example in c.ExamplesClearText)
                    {
                        ret += string.Format(HTML.Cursive, PrepareText("- " + example, 0)) + HTML.NewLine;
                    }
                }
            }
            if (ret.EndsWith(HTML.NewLine))
                ret = ret.Substring(0, ret.Length - HTML.NewLine.Length);
            return ret;
        }

        //перенос и замена слова
        string PrepareText(string text, int decrementForFirstLine)
        {
            const int _max = 30;

            if (string.IsNullOrEmpty(text.Trim(' '))) return "";
            int maxVal = _max - decrementForFirstLine;
            string ret = "";
            text = text.Trim();
            if (text.Length > maxVal)
            {
                string line = "";
                foreach (string word in text.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if ((line + " " + word).Length > maxVal)
                    {
                        if (ret != "") // is not first line
                        {
                            ret += HTML.NewLine;
                            maxVal = _max;
                        }
                        ret += line;
                        line = word;
                    }
                    else line += " " + word;
                }
                if (ret != "") // is not first line
                    ret += HTML.NewLine;
                ret += line;
            }
            else ret = text;
            return ret.Replace(this.InitText, "@@");
        }

        private string GetNameByList(List<Card> cards)
        {
 	        if(cards == this.Nouns) return "Noun";
 	        if(cards == this.Verbs) return "Verb";
 	        if(cards == this.Adjectives) return "Adjective";
 	        if(cards == this.Adverbs) return "Adverb";
            return "Not Found";
        }
    }
}