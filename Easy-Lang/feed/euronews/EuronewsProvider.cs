using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace f
{
    public class EuronewsProvider : DictionaryProvider
    {
        public string GetContentArticle_for_test(string url)
        {
            string content = base.GetContent(url, "", ""); // en by default
            content = this.GetContentFromTag(content);
            return content;
        }

        public override string GetUrl(string word, LangPair langPair)
        {
            return word;
        }

      //  public override bool IsDoFullLoading { get { return true; } }
      //  public override bool IsDoFullLoadingTwice { get { return true; } }

        #region service props
        public override string[] StartTags
        {
            get
            {
                return new string[] { "<div id='articleTranscript'" };
            }
        }

        string m_URL = @"http://{0}.euronews.com/";
        public override string URL
        {
            get { return m_URL; }
        }

        public override string Title
        {
            get { return null; }
        }

        public override string Copyright
        {
            get { return null; }
        }

        public override string[] Languages
        {
            get { return new string[] { "en", "gr", "hu", "fr", "de", "it", "es", "pt", "pl", "ru", "ua", "tr", "ar", "fa" }; }
        }
        #endregion
    }
}
