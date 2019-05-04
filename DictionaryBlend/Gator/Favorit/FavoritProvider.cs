using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class FavoritProvider : DictionaryProvider
    {
        public override string Title { get { return "FavoritList"; } }

        public override string Copyright { get { return "© Forcemem 2008-2012"; } }

        public override string URL { get { return @"www.forcemem"; } }

        public override string[] StartTags { get { return new string[] { @"<div" }; } }


        public override string[] Languages
        {
            get { return new string[] { DictionaryProvider.AllLanguages }; }
        }
    }
}
