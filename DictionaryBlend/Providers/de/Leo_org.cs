using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Leo_org : DictionaryProvider
    {
        public override string Title { get { return "LEO GmbH"; } }
        public override string Copyright { get { return @"Copyright © LEO DictionaryTeam 2006-11"; } }
        public override string[] Languages { get
        {
            return new string[] {                   
                    "en:de", "fr:de", "de:ru", "it:de", "es:de", 
                    "de:en", "de:fr", "ru:de", "de:it", "de:es",

                    "ch:de", "ch:de", 
                };
            }
        }
        public override string URL
        {
            get
            {
                return @"http://dict.leo.org/{1}de?search={0}";
            }
        }
        public override string CorrectionURL
        {
            get
            {
                return @"http://dict.leo.org/";
            }
        }

        public override string GetUrl(string word, LangPair langPair)
        {
            if(langPair.From == "de")
                return base.GetUrl(word, LangPair.Revert(langPair));
            return base.GetUrl(word, langPair);
        }

        public override string[] StartTags { get { return new string[] { 
            "<table id=\"results\"", 
            "<table cellpadding=0 cellspacing=0 width=\"100%\" id=\"results\"", 
            "<div id=\"singleword\"" ,
            "<td id=\"contentholder\"", 
            "<form name=\"WORDS\"",

        }; } }
    }
}
