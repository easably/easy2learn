using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleMonoDictionary : GoogleDefinitionBase
    {
        public override string Title { get { return "Thesaurus mono"; } }
        public override string[] Languages { get { return new string[] { "es", "ru", "pt", "ko", "it", "de", "fr", "en", "nl", "cz", "zh-CN" }; } }
        public override string[] StartTags
        {
            get
            {
                return new string[] { 
                  //  @"<div id=""search""", @"<div id=""ires""", 
                    "<td valign=top", "<td width=60%",
                    this.NotFoundsStartTags[0], this.NotFoundsStartTags[1], 
                };
            }
        }
    }
}
