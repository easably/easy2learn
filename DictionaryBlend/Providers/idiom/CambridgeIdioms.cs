using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class CambridgeIdioms : DictionaryProvider
    {
        public override string Title { get { return "Cambridge International Dictionary of Idioms (en)"; } }
        public override string Copyright { get { return @"© Cambridge University Press 2011"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://dictionaries.cambridge.org/{0}/cmd_search.asp";
                // return @"http://dictionaries.cambridge.org/results.asp?searchword={0}&x=33&y=10";
            }
        }

        public override string CorrectionURL { get { return @"http://dictionaries.cambridge.org/"; } }
        public override string[] StartTags { get { return new string[] { "<div id=\"luna-Ent\"" }; } }

    }
}
