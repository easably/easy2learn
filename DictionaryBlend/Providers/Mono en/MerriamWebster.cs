using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class MerriamWebster : DictionaryProvider
    {
        public override string Title { get { return "Merriam-Webster"; } }
        public override string Copyright { get { return @"© 2011 Merriam-Webster, Incorporated"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://www.merriam-webster.com/dictionary/{0}";
            }
        }

        public override string[] StartTags { get { return new string[] { "<div class=\"definition\"", "<div id=\"content\"" }; } }
        public override bool ClearFromScript { get { return true; } }

        public override string CorrectionURLForImage { get { return @"http://www.merriam-webster.com"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn; } }

    }
}
