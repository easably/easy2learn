using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Wiktionary : DictionaryProvider
    {
        public override string Title { get { return "Wiktionary"; } }
        public override string Copyright { get { return @"Copyright © 2011 Wikimedia Foundation"; } }
        public override string URL { get { return @"http://{1}.wiktionary.org/wiki/{0}"; } }
        public override string CorrectionURL { get { return @"http://www.wiktionary.org/"; } }
        public override string[] StartTags { get { return new string[] { @"<div id=content>" }; } }
        public override string[] Languages { get { return new string[] { "simple",
            "en", "et", "fa", "fr", "hi", "ko", "io", "it", "kn", "kk", "ku", "lo", "hu", 
            "ml", "my", "nl", "ja", "pl", "ru", "fi", "sv", "ta", "te", "tr", "vi", "zh", };
            }
        }
        
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }

    }


    //TODO: здесь есть simple English!!!!!!!! код - simple
}
