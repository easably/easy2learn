using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Wikidioms : DictionaryProvider
    {
        public override string Title { get { return "Wikidioms"; } }
        public override string Copyright { get { return @"Copyright 2010 Wikidioms"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Idiom; } }
        public override string URL
        {
            get
            {
                return @"http://www.wikidioms.com/find/{1}/idioms/{0}";
            }
        }
        public override string CorrectionURL { get { return @""; } }
        public override string[] StartTags { get { return new string[] {@"<div id=""main-content"">"}; } }
        public override string[] Languages { get { return new string[] { AllLanguages }; } }

        public override string GetUrl(string word, LangPair langPair)
        {
            if (string.IsNullOrEmpty(word)) return "";

            word = PrepareWord(word);
            string newWord = word.Replace(" ", "-");
            newWord = newWord[0] + "/" + newWord;
            return string.Format(this.URL, newWord, langPair.From);
        }
    }
}
