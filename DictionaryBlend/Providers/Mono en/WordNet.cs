using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class WordNet : DictionaryProvider
    {
        public override string Title { get { return "WordNet"; } }
        //"<a id=\"logo\" href=\"http://www.google.com/webhp?hl=en\" title=\"Go to Google Home\">" +
        //"Go to Google Home<span></span></a>"; } 

        public override string Copyright { get { return @"© 2010 The Trustees of Princeton University"; } }
        public override string URL { get { return @"http://wordnetweb.princeton.edu/perl/webwn?s={0}"; } }
        public override string CorrectionURL { get { return @"http://wordnetweb.princeton.edu/perl/"; } }
        public override string[] StartTags { get { return new string[] {@"<body "}; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn | DictionaryProviderType.Idiom; } }
    }
}
