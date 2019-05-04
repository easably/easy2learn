using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Wikipedia : DictionaryProvider
    {
        public override string Title { get { return "Wikipedia"; } }
        public override string Copyright { get { return ""; } }
        public override string URL { get { return @"http://{1}.wikipedia.org/wiki/{0}"; } }
        public override string CorrectionURL { get { return string.Format(@"http://{0}.wikipedia.org/", 
            new LangPair(CurrentLangInfo.LanguageDirection).From); } }
        public override string[] StartTags { get { return new string[] {"<li id=\"ca-current\""}; } }
        public override string[] Languages { get { return new string[] { AllLanguages }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }

        // private string m_LastLanguageCode = "";

        // here mono dictionary get only the first part of langPair (from)
        public override string GetContainsSourceLanguage(string langPair)
        {
            string m_LastLanguageCode = langPair;
            if (langPair.Split(CurrentLangInfo.PairSeparator).Length > 1)
                m_LastLanguageCode = langPair.Split(CurrentLangInfo.PairSeparator)[0];
            return m_LastLanguageCode;
        }
    }
}
