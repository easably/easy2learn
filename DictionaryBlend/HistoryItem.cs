using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class HistoryItem : IComparable
    {
        string m_Word;
        DictionaryProvider m_DictionaryProvider;

//        public HistoryItem(string word, DictionaryProvider dictionaryProvider, string content)
        public HistoryItem(string word, DictionaryProvider dictionaryProvider)
        {
            m_Word = word;
            m_DictionaryProvider = dictionaryProvider;
           // m_Content = content;
        }

        public string Word { get { return m_Word;  } }
        public DictionaryProvider DictionaryProvider { get { return m_DictionaryProvider; } }

        //string m_Content;
        //public string Content { get { return m_Content; } }
        public string Content { get; set; }
        
        public override string ToString()
        {
            return this.Word;

            //if (m_DictionaryProvider == null) return m_Word;
            //else 
            //    return string.Format("{0} - ( {1} )", m_Word, m_DictionaryProvider.ToString());
        }

        #region IComparable Members
        public int CompareTo(object obj)
        {
            HistoryItem hi = obj as HistoryItem;
            if (hi == null) return 1;
            if (hi.m_Word.Equals(this.Word) && hi.m_DictionaryProvider.Equals(this.DictionaryProvider))
                return 0;
            return 1;
        }
        #endregion
    }
}
