using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    class GoogleDictionary_Depricated : DictionaryProvider
    {
        public static string MainTitle { get { return "Google Dictionary"; } }
        public override string Title { get { return MainTitle; } }

            //"<a id=\"logo\" href=\"http://www.google.com/webhp?hl=en\" title=\"Go to Google Home\">" +
            //"Go to Google Home<span></span></a>"; } 

        public override string Copyright { get { return @"©2009 Google"; } }
        public override string URL { get
        {
            return @"http://www.google.com/search?q={0}&tbs=dfn:1&defl={1}&hl={2}";
        //dict      return @"http://www.google.com/dictionary?langpair={1}|{2}&q={0}&hl={2}&aq=0";
        } }
        public override string CorrectionURL { get { return @""; } }

        public override string[] StartTags { get { return new string[] { "<td valign=top", "<td width=60%"}; } }
        //dict public override string[] StartTags { get { return new string[] { @"<div class=""dct-srch-inr rt-sct-exst"">"}; } }
        public override string[] Languages { get { return new string[] { "ar:en", "bn:en", "bg:en", "zh-CN:zh-CN", "zh-CN:en", "zh-TW:zh-TW", "zh-TW:en", "hr:en", "cs:cs", "cs:en", "nl:nl", "en:ar", "en:bn", "en:bg", "en:zh-CN", "en:zh-TW", "en:hr", "en:cs", "en:en", "en:fi", "en:fr", "en:de", "en:el", "en:gu", "en:iw", "en:hi", "en:it", "en:kn", "en:ko", "en:ml", "en:mr", "en:pt", "en:ru", "en:sr", "en:es", "en:ta", "en:te", "en:th", "fi:en", "fr:en", "fr:fr", "de:en", "de:de", "el:en", "gu:en", "iw:en", "hi:en", "it:en", "it:it", "kn:en", "ko:en", "ko:ko", "ml:en", "mr:en", "pt:en", "pt:pt", "ru:en", "ru:ru", "sr:en", "sk:sk", "es:en", "es:es", "ta:en", "te:en", "th:en", }; } }
    

        // for FullPath
        protected override string DoCorrectionForUrl(string response, string prefix, string newPrefix)
        {
            string ret = response.Replace("data=\"/dictionary/", "data=\"http://www.google.com/dictionary/");
                        ret = ret.Replace("value=\"/dictionary/", "value=\"http://www.google.com/dictionary/");
            
            ret = ret.Replace("src=\"/dictionary/", "src=\"http://www.google.com/dictionary/");
            ret = ret.Replace("src=\"\n  /dictionary/", "src=\"http://www.google.com/dictionary/");

            ret = ret.Replace("href=\"/dictionary", "href=\"http://www.google.com/dictionary");
            ret = ret.Replace("href=\"\n  /dictionary", "href=\"http://www.google.com/dictionary");

            ret = ret.Replace("href=\"/translate", "href=\"http://www.google.com/translate");
            
            return ret;
        }
    }
}
/*
en|ar">English &lt;&gt; Arabic</li><li class="clickable" index="12" 
en|bn">English &lt;&gt; Bengali</li><li class="clickable" index="13" 
en|bg">English &lt;&gt; Bulgarian</li><li class="clickable" index="14" 
en|zh-CN">English &lt;&gt; Chinese (Simplified)</li><li class="clickable" index="15" 
en|zh-TW">English &lt;&gt; Chinese (Traditional)</li><li class="clickable" index="16" 
en|hr">English &lt;&gt; Croatian</li><li class="clickable" index="17" 
en|cs">English &lt;&gt; Czech</li><li class="clickable" index="18" 
en|fi">English &lt;&gt; Finnish</li><li class="clickable" index="20" 
en|fr">English &lt;&gt; French</li><li class="clickable" index="21" 
en|de">English &lt;&gt; German</li><li class="clickable" index="22" 
en|el">English &lt;&gt; Greek</li><li class="clickable" index="23" 
en|gu">English &lt;&gt; Gujarati</li><li class="clickable" index="24" 
en|iw">English &lt;&gt; Hebrew</li><li class="clickable" index="25" 
en|hi">English &lt;&gt; Hindi</li><li class="clickable" index="26" 
en|it">English &lt;&gt; Italian</li><li class="clickable" index="27" 
en|kn">English &lt;&gt; Kannada</li><li class="clickable" index="28" 
en|ko">English &lt;&gt; Korean</li><li class="clickable" index="29" 
en|ml">English &lt;&gt; Malayalam</li><li class="clickable" index="30" 
en|mr">English &lt;&gt; Marathi</li><li class="clickable" index="31" 
en|pt">English &lt;&gt; Portuguese</li><li class="clickable" index="32" 
en|ru">English &lt;&gt; Russian</li><li class="clickable" index="33" 
en|sr">English &lt;&gt; Serbian</li><li class="clickable" index="34" 
en|es">English &lt;&gt; Spanish</li><li class="clickable" index="35" 
en|ta">English &lt;&gt; Tamil</li><li class="clickable" index="36" 
en|te">English &lt;&gt; Telugu</li><li class="clickable" index="37" 
en|th">English &lt;&gt; Thai</li></ul>
 */