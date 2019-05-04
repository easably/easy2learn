using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class WordreferenceCom : DictionaryProvider
    {
        public override string Title { get { return "WordReference.com"; } }
        public override string Copyright { get { return @"Copyright © 2011 WordReference.com"; } }
        public override string[] Languages { get { return new string[] { 
        
        	        // Spanish 
	                "en:es", // enes" selected="selected English-Spanish 
	                "es:en", // esen Spanish-English 
	                "es:fr", // esfr Spanish-French 
	                "es:pt", // espt Spanish-Portuguese 
	                "es:es", // eses Spanish: definition 
	                "es:sin", // essin Spanish: synonyms 
	                "es:conj", // esconj Spanish: conjugations 
                	 
	                // French 
	                "en:fr", // enfr English-French 
	                "fr:en", // fren French-English 
	                "fr:es", // fres French-Spanish 
	                "fr:conj", // frconj French: conjugations 
                	 
	                // Italian 
	                "en:it", // enit English-Italian 
	                "it:en", // iten Italian-English 
	                "it:it", // itit Italian definition 
	                "it:conj",// itconj Italian: conjugations 
                	 
	                // German 
	                "en:de", // ende English-German 
	                "de:en", // deen German-English 
                	 
	                // Russian 
	                "en:ru", // enru English-Russian 
	                "ru:en", // ruen Russian-English 
                	 
	                // Portuguese 
	                "en:pt", // enpt English-Portuguese 
	                "pt:en", // pten Portuguese-English 
	                "pt:es", // ptes Portuguese-Spanish 
                	 
	                // Polish 
	                "en:po", // enpl English-Polish 
	                "po:en", // poen Polish-English 
                	 
	                // Romanian 
	                "en:ro", // enro English-Romanian 
	                "roen", // roen Romanian-English 
                	 
	                // Czech 
	                "en:cz", // encz English-Czech 
	                "cz:en", // czen Czech-English 
                	 
	                // Greek 
	                "en:gr", // engr English-Greek 
	                "gr:en", // gren Greek-English 
                	 
	                // Turkish 
	                "en:tr", // entr English-Turkish 
	                "tr:en", // tren Turkish-English 
                	 
	                // Chinese 
	                "en:zh", // enzh English-Chinese 
	                "zh:en", // zhen Chinese-English 
                	 
	                // Japanese 
	                "en:ja", // enja English-Japanese 
	                "ja:en", // enja Japanese-English 
                	 
	                // Korean 
	                "en:ko", // enko English-Korean 
	                "ko:en", // koen Korean-English 
                	 
	                // Arabic 
	                "en:ar", // enar English-Arabic 
	                "ar:en", // aren Arabic-English 
                	 
	                "en:en", // enen English definition 
	                "en:the", // enthe English synonyms                 
                }; 
            } 
        }

        public override string URL
        {
            get
            {
                return @"http://www.wordreference.com/{1}{2}/{0}";
            }
        }

        public override string CorrectionURL
        {
            get
            {
                //LangPair lp = CurrentLangInfo.CurrentLangPair;
                //return string.Format(@"http://www.wordreference.com/{0}{1}/", lp.From, lp.From); 
                return @"http://www.wordreference.com/";
            }
        }
        public override string CorrectionURLForImage { get { return @"http://www.wordreference.com"; } }       
        public override string[] StartTags { get { return new string[] { "<div id='Otbl'", "<div id=\"Otbl\"" }; } }
    }
}
