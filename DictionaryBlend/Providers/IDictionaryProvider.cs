using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public interface IDictionaryProvider
    {
        string Title { get; }
        string Copyright { get; }
        DictionaryProviderType DictType { get; }
        bool OnlyAsUrlProvider { get; }
        string URL { get; }
        string CorrectionURL { get; }
        string[] StartTags { get; }
        string[] RequestParameters { get; }
        string[] Languages { get; }
        string GetContent(string word, string codeForm, string codeTo);
//        bool ContaintAnswer();
    }

    [Flags]
    public enum DictionaryProviderType
    {
        Idiom = 0x1, Definition = 0x2, Simple = 0x4, MonoEn = 0x8 // , Trans = 0xF
    }
}
