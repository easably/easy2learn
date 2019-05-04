using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Freeopendictionary : DictionaryProvider
    {
        public override string Title { get { return "FreeOpenDictionary"; } }
        public override string Copyright { get { return "© Freeopendictionary"; } }
        // http://www.freeopendictionary.com/?ol=ru&tl=en&q=welcome
        public override string URL
        {
            get
            {
                return @"http://www.freeopendictionary.com/?ol={1}&tl={2}&q={0}";
            }
        }
        public override string[] StartTags { get { return new string[] { "<div style=\"float" }; } }
        public override string CorrectionURL
        {
            get
            {
                return @"http://www.freeopendictionary.com/";
            }
        }
        public override string[] Languages
        {
            get
            {
                return new string[] {                 
                    "ar:en", "en:ar",
                    "bg:en", "en:bg",
                    "bn:en", "en:bn",
                    "cs:en", "en:cs",
                    "de:en", "en:de",
                    "el:en", "en:el",
                    "es:en", "en:es",
                    "fi:en", "en:fi",
                    "fr:en", "en:fr",
                    "gu:en", "en:gu",
                    "hi:en", "en:hi",
                    "hr:en", "en:hr",
                    "it:en", "en:it",
                    "iw:en", "en:iw",
                    "ml:en", "en:ml",
                    "mr:en", "en:mr",
                    "pt:en", "en:pt",
                    "ru:en", "en:ru",
                    "sr:en", "en:sr",
                    "ta:en", "en:ta",
                    "te:en", "en:te",
                    "th:en", "en:th",
                };
            }
        }

    }
}

/*
 
"ar">Arabic
"bg">Bulgarian
"bn">Bengali
"cs">Czech
"de">German
"el">Greek
"es">Spanish
"fi">Finnish
"fr">French
"gu">Gujarati
"hi">Hindi
"hr">Croatian
"it">Italian
"iw">Hebrew
"ml">Malayalam
"mr">Marathi
"pt">Portuguese
"ru" Russian
"sr">Serbian
"ta">Tamil					
"te">Telugu
"th">Thai
						
					
 
 */
