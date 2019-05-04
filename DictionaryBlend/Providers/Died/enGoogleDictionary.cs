using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class enGoogleDictionary : GoogleDictionary
    {
        public override string Title { get { return "Google Mono Dictionary"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://www.google.com/dictionary?langpair=en|en&q={0}&hl=en&aq=0";
//                return @"http://www.google.com/dictionary?langpair={1}|{1}&q={0}&hl={1}&aq=0";
            }
        }
    }
}
