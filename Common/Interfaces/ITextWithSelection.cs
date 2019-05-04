using System;
using System.Text;

namespace f
{
    public interface ITextWithSelection
    {
        string CurrentLowerWord { get; }

        LangPair LangDir { get; }
    }

}
