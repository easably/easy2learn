using System;
using System.Collections.Generic;
using System.Text;

namespace f
{

    public class LangPair
    {
        private string m_from = "";
        private string m_to = "";
        public LangPair(string from_AND_to)
        {
            m_from = from_AND_to.Split(CurrentLangInfo.PairSeparator)[0];
            m_to = from_AND_to.Split(CurrentLangInfo.PairSeparator)[1];
        }

        public LangPair(string from, string to)
        {
            m_from = from;
            m_to = to;
        }

        public string From { get { return m_from; } }
        public string To { get { return m_to; } }

        public override string ToString()
        {
            return m_from + CurrentLangInfo.PairSeparator + m_to;
        }


        static public LangPair Revert(LangPair lp)
        {
            return new LangPair(lp.To, lp.From);
        }

        static public string Revert(string lp)
        {
            string[] parts = lp.Split(CurrentLangInfo.PairSeparator);
            return parts[1] + CurrentLangInfo.PairSeparator + parts[0];
        }
    }
}
