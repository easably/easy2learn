using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Longman : DictionaryProvider
    {
        public override string Title { get { return "Longman of Contemporary"; } }
        public override string Copyright { get { return @"Copyright © 2010 Pearson Education"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://www.ldoceonline.com/search/?q={0}";
            }
        }

        public override string CorrectionURL { get { return @"http://www.ldoceonline.com"; } } // /dictionary
        public override string CorrectionURLForImage { get { return @"http://www.ldoceonline.com"; } }

        public override string[] StartTags { get { return new string[] { "<div class=\"content\"" }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn; } }
    }
}
