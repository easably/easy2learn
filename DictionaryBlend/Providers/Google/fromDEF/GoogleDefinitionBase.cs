using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public abstract class GoogleDefinitionBase : DictionaryProvider
    {
        public override bool IsDoFullLoading { get { return true; } }
        public override string Copyright { get { return @"©2009 Google"; } }
        public override string URL
        {
            get
            {
                return @"http://www.google.com/search?q={0}&tbs=dfn:1&defl={1}&hl={2}"; // &defl=ru &hl=en
                //return @"http://www.google.com/custom?q=define:{0}"; // l&hl=en
            }
        }

        protected string[] NotFoundsStartTags
        {
            get
            {
                return new string[] {@"<div id=center_col",  @"<div style=visibility:",};
            }
        }

        public override string CorrectionURL { get { return "http://www.google.com"; } }
        
     // for FullPath
//        protected override string DoCorrectionForUrl(string response, string prefix, string newPrefix)
    
        protected string DoCorrectionForUrl_Depricated(string response, string prefix, string newPrefix)
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