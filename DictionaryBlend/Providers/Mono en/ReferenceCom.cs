using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class ReferenceCom : DictionaryProvider
    {
        public override string Title { get { return "Reference.Com"; } }

        public override string Copyright { get { return "Dictionary.com, LLC. Copyright © 2011. All rights reserved."; } }

        public override string[] StartTags { get { return new string[] { "<div id=\"luna-Ent\"" }; } }

        public override string[] Languages { get { return new string[] { "en" }; } }

        public override string URL { get { return @"http://dictionary.reference.com/browse/{0}"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn; } }
    }
}
