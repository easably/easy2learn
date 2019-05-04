using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class IndexItemList<T> : List<T>
    {
        public IndexItemList(string listName)
        {
            if (string.IsNullOrEmpty(listName)) throw new ArgumentNullException("listName");
            m_Name = listName;
        }

        string m_Name;

        public override string ToString()
        {
            return this.m_Name;
        }
    }

    public class IndexItem
    {
        // test%transcription%n_103;704719|103;899329|90;899329%v_103;704719|103;899329|90;899329
        string m_Text;
        string m_ToString;
        public IndexItem(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            m_Text = text;
            string[] parts = text.Split('%');
            m_Word = parts[0];
            m_ToString = this.Word;
            for (int i = 2; i < parts.Length; ++i)
            {
                m_ToString += (i == 2 ? "   " : "; ");
                m_ToString += PartSpeechUtil.GetReadableName((EE)parts[i].Substring(0, 1)[0]); //  +".";
            }
        }

        // test%transcription%n_103;704719|103;899329|90;899329%v_103;704719|103;899329|90;899329
        public List<string> GetIDs()
        {
            List<string> list = new List<string> { };
            string[] parts = m_Text.Split('%');
            for (int i = 2; i < parts.Length; ++i)
            {
                char charDict = parts[i][0];
                foreach (string subPart in parts[i].Split('|'))
                {
                    string ret = subPart.Split(';')[0];
                    if (ret.IndexOf('_') != -1)
                        ret = ret.Substring(ret.IndexOf('_') + 1);
                    ret = ret + ';' + charDict + subPart.Split(';')[1];
                    list.Add(ret); // 103;n704719 103;n899329
                }
            }
            return list;
        }

        string m_Word;
        public string Word
        {
            get
            {
                return m_Word;
            }
        }

        public string Phonetic
        {
            get
            {
                return m_Text.Split('%')[1];
            }
        }

        // TODO: test n;v
        public override string ToString()
        {
            return m_ToString;
        }
    }
}