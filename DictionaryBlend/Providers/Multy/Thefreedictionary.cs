using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Thefreedictionary : DictionaryProvider
    {
        public override string Title { get { return "TheFreeDictionary"; } }
        public override string Copyright { get { return @"Copyright © 2010 Farlex, Inc."; } }
        public override string URL { get { return @"http://{1}.thefreedictionary.com/{0}"; } }
        public override string CorrectionURL { get { return @"http://www.thefreedictionary.com/"; } }
        public override string[] StartTags { get { return new string[] {@"<div id=MainTxt>"}; } }
        public override string[] Languages { get { return new string[] { "en", "es", "de", "fr", "it", "ar", "zh", "pl", "pt", "nl", "no", "el", "ru", "tr", }; } }

    }
}
