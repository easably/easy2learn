using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class MerriamWebsterThesaurus : MerriamWebster
    {
        public override string Title { get { return "Merriam-Webster Thesaurus"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }        
        public override string URL
        {
            get
            {
                return @"http://www.merriam-webster.com/thesaurus/{0}";
            }
        }

        public override string[] StartTags { get { return new string[] { "<div class=\"thesaurus\"" }; } }
    }
}