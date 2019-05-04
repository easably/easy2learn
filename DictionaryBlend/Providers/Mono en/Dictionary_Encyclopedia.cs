using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Dictionary_Encyclopedia : Dictionary_com
    {
        public override string Title { get { return "LLC Encyclopedia"; } }
        public override string URL { get { return @"http://www.reference.com/browse/{0}"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }
    }
}
