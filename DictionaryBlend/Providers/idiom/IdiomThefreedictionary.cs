using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class IdiomThefreedictionary : Thefreedictionary
    {
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Idiom; } }

        public override string URL { get { return @"http://idioms.thefreedictionary.com/{0}"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }

    }
}
