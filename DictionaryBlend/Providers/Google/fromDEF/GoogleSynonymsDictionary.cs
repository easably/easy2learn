using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleSynonymsDictionary : GoogleDefinitionBase
    {
        public override string Title { get { return "Synonyms+Related"; } }
        public override string[] Languages { get { return new string[] { "es", "ru", "pt", "ko", "it", "de", "fr", "en", "nl", "cz", "zh-CN" }; } }
        public override string[] StartTags { get { return new string[] { 
                "<td style=\"padding-left:30px", "<td valign=\"top\"",
                this.NotFoundsStartTags[0], this.NotFoundsStartTags[1], };
            }
        }
       // public override string[] StartTags { get { return new string[] { "<div style=\"margin-bottom", "<div class=\"dct-srch-rslt" }; } }

       // public override string URL
       // {
       //     get
       //     {

       //         return @"http://www.google.com/search?q={0}&tbs=dfn:1";
       //      // return @"http://www.google.com/dictionary?langpair={1}|{1}&q={0}&hl=en&aq=0";
       ////                http://www.google.com/dictionary?langpair=it|it&q=piacere&hl=en&aq=f
       //     }
       // }
    }
}
