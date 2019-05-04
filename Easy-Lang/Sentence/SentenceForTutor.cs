using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class SentenceForTutor : SentenceForLesson, IScoreUnit
    {
        public SentenceForTutor(string text, List<Sentence> parentList)
            : base(text, parentList)
        {
            string txt = this.TextValue;
            this.m_ClearText = txt.Replace(DelimiterForWord.ToString(), "");
            this.MaskedText = GetMaskedText();
            this.m_CharHidedCount = this.MaskedText.Length - this.MaskedText.Replace(CharHided.ToString(), "").Length;        
        }

        string m_ClearText;
        public string ClearText { get { return m_ClearText; } }

        int m_CharHidedCount;
        int CharHidedCount { get { return m_CharHidedCount; } }

        #region MaskedText
        public string GetWholeMaskedAsClear(int wordStart)
        {
            string maskedText = GetMaskedText();
            // get masked diapason for word
            int start = wordStart;
            int end = start;
            return GetMaskedWord(maskedText, ref start, ref end);
        }

        public string GetMaskedWord(string maskedText, ref int wordStart, ref int wordEnd)
        {
            if (!((wordStart >= 0) && (wordStart < maskedText.Length)))
                return string.Empty;
            int iMax = maskedText.Length;
            while ((iMax > wordEnd) && CharHided[0] == maskedText[wordEnd])
                ++wordEnd;
            while ((wordStart > 0) && CharHided[0] == maskedText[wordStart - 1])
                --wordStart;
            string word = this.ClearText.Substring(wordStart, wordEnd - wordStart);
            return word;
        }

        public string MaskedText { get; set; }

        string GetMaskedText()
        {
            string ret = "";
            bool isFirtsTeg = false;
            foreach (char c in this.TextValue)
            {
                if (c == DelimiterForWord)
                {
                    isFirtsTeg = !isFirtsTeg;
                }
                else
                {
                    if (isFirtsTeg)
                    {
                        if (Array.IndexOf(Excludes, c) == -1)
                            ret += CharHided;
                        else ret += c;
                    }
                    else ret += c;
                }
            }
            return ret;
        }
        #endregion

        public override string ToString()
        {
            //return string.Format("{0}) {1}. {2}", m_ParentList.IndexOf(this) + 1, NumberSentence, this.MaskedText);
            return string.Format("{0}-{1}. {2}", m_ParentList.IndexOf(this) + 1, NumberSentence, this.MaskedText);
        }


#if !PRO
        public static List<Sentence> GetSentencesForTutor(string fileName)
        {
            string[] sentenses = 
                FileManager.GetStringFrоmFile(fileName).Split(
                    new string[] { SentenceParser.Delimeter }, StringSplitOptions.None);

            List<Sentence> sents = new List<Sentence>(5) { };
            int i = 0;
            foreach (string line in sentenses)
            {
                if (i > 5)
                {
                    DialogResult dr = MessageBox.Show("You are using trial version of 'Easy-Learn'." + Environment.NewLine +
                        "You can't open more than five sentences." + Environment.NewLine + Environment.NewLine +
                        "To give a more information?", 
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                        SentenceListWithVideo.ShowLearnWordsArticle();
                    break;
                }

                if (!string.IsNullOrEmpty(line.Trim('\n')))
                {
                    sents.Add(new SentenceForTutor(line, sents));
                }
                ++i;
            }
            return sents;
        }
#else

        public static List<Sentence> GetSentencesForTutor(string fileName)
        {
            string[] sentenses = FileManager.GetStringFrоmFile(fileName).Split(new string[] { SentenceParser.Delimeter }, StringSplitOptions.None);
            List<Sentence> sents = new List<Sentence> { };
            foreach (string line in sentenses)
            {
                if (!string.IsNullOrEmpty(line.Trim('\n')))
                {
                    sents.Add(new SentenceForTutor(line, sents));
                }
            }
            return sents;
        }

#endif
        public bool IsGuessed { get { return !MaskedText.Contains(CharHided); } }

        //int GetUnGuessedWordsLength()
        //{
        //    int ret = 0;
        //    this.CharHidedCount


        //    return ret;
        //}

        #region IScoreUnit Members
        public string ID
        {
            get { return this.NumberSentence.ToString(); }
        }

        ScoreData m_ScoreData = null;
        public ScoreData ScoreData
        {
            get
            {
                if (m_ScoreData == null)
                    m_ScoreData = new ScoreData(this.ID, ScoreState.Unknown, this.CharHidedCount);
                return m_ScoreData;
            }
        }

        public void SetScoreData(ScoreData scoreData)
        {
            m_ScoreData = scoreData;
            m_ScoreData.MaxScrore = CharHidedCount; // слова могли добавится 
        }

        public void ClearScoreData()
        {
            m_ScoreData = null;
        }

        public bool IsHaveScore { get { return m_ScoreData != null; } }

        #endregion
    }
}
