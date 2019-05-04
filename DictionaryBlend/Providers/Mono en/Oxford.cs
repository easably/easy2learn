using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Oxford : DictionaryProvider
    {
        public override string Title { get { return "Oxford"; } }
        //"<a id=\"logo\" href=\"http://www.google.com/webhp?hl=en\" title=\"Go to Google Home\">" +
        //"Go to Google Home<span></span></a>"; } 

        public override string Copyright
        {
            get { return @"Oxford University Press Copyright © 2012 Oxford University Press. All rights reserved."; }
        }
        public override string URL { get { return @"http://oxforddictionaries.com/definition/{0}?q={0}"; } }
        public override string[] StartTags { get { return new string[] {
            @"<div id=""mainContent""", 
            @"<div xmlns=""http://www.w3.org/1999/xhtml"" xmlns:h=""http://www.w3.org/1999/xhtml"" id=""mainContent"""}; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn | DictionaryProviderType.Idiom; } }

        public override string Styles
        { 
            get {
                return @"<link type=""text/css"" rel=""stylesheet"" href=""http://oxforddictionaries.com/external/styles/content.css?version=1.0.0"">";
            } 
        }

        public override string GetContent(string word, string codeForm, string codeTo)
        {
            if (word.Contains(" "))
            {
                word = word.Replace(" ", "+");
            }
            return base.GetContent(word, codeForm, codeTo);
        }
    }
}
