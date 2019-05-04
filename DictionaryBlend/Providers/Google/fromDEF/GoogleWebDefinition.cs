using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    // 
    public class GoogleWebDefinition : GoogleDefinitionBase
    {
        public override string Title { get { return "Web Definitions"; } }
        public override string BookmarkForStarTag { get { return "<h5"; } }
        public override string[] StartTags
        {
            get { 
                return new string[] { 
             //       @"<div id=""search""", @"<div id=""ires""", // from mono
                    "<div class=std", @"<div class=""std""", 
                this.NotFoundsStartTags[0], this.NotFoundsStartTags[1], 
                }; 
            } 
        }

        //dict public override string[] StartTags { get { return new string[] { @"<div class=""dct-srch-inr rt-sct-exst"">"}; } }

        public override string[] Languages { get { return new string[] { "ar:en", "bn:en", "bg:en", "zh-CN:zh-CN", "zh-CN:en", "zh-TW:zh-TW", "zh-TW:en", "hr:en", "cs:cs", "cs:en", "nl:nl", "en:ar", "en:bn", "en:bg", "en:zh-CN", "en:zh-TW", "en:hr", "en:cs", "en:en", "en:fi", "en:fr", "en:de", "en:el", "en:gu", "en:iw", "en:hi", "en:it", "en:kn", "en:ko", "en:ml", "en:mr", "en:pt", "en:ru", "en:sr", "en:es", "en:ta", "en:te", "en:th", "fi:en", "fr:en", "fr:fr", "de:en", "de:de", "el:en", "gu:en", "iw:en", "hi:en", "it:en", "it:it", "kn:en", "ko:en", "ko:ko", "ml:en", "mr:en", "pt:en", "pt:pt", "ru:en", "ru:ru", "sr:en", "sk:sk", "es:en", "es:es", "ta:en", "te:en", "th:en", }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }
    
    }
}