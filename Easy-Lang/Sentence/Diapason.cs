using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Diapason
    {
        public Diapason(int Start, int length, string value)
        {
            m_Start = Start;
            m_Length = length;
            m_TextValue = value;
        }
        int m_Start;
        public int Start { get { return m_Start; } }

        int m_Length;
        public int Length { get { return m_Length; } }

        string m_TextValue;
        public string TextValue { get { return m_TextValue; } }
    }
}
