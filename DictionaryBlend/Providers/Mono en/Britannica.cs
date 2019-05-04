using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Britannica : DictionaryProvider
    {
        public override string Title { get { return "Encyclopædia Britannica"; } }
        public override string Copyright { get { return @"© 2011 Encyclopædia Britannica, Inc. "; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://britannica.com/bps/dictionary?query={0}";
            }
        }

        public override string CorrectionURL { get { return @"http://britannica.com/bps/"; } }
        public override string[] StartTags { get { return new string[] { "<div id=\"bps-results-container\"" }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn; } }
    }
}
