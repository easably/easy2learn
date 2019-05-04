using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Idiomcenter : DictionaryProvider
    {
        public override string Title { get { return "IdiomCenter"; } }
        public override string Copyright { get { return @"IdiomCenter.com"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Idiom; } }
        public override bool OnlyAsUrlProvider { get { return false; } }
        public override string URL
        {
            get
            {
                return @"http://www.idiomcenter.com/search/node/{0}";
                /*
                 *  here full article
                                 return @"http://www.idiomcenter.com/dictionary/{0}";
                 * */
            }
        }
        public override string CorrectionURL { get { return @""; } }
// for full article        public override string[] StartTags { get { return new string[] { @"<div class=""left-corner"">" }; } }
        public override string[] StartTags { get { return new string[] { @"<div class=""box""" }; } }
        public override string[] Languages { get { return new string[] { "ru", "en" }; } }

        //public override string GetUrl(string word, LangPair langPair)
        //{
        //    if (string.IsNullOrEmpty(word)) return "";

        //    word = PrepareWord(word);
        //    string newWord = word.Replace(" ", "-");
        //    return string.Format(this.URL, newWord);
        //}
    }
}
