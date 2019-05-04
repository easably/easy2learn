using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace f
{
    public class EuronewsProviderArchive : EuronewsProvider
    {
        public override bool ClearFromScript { get { return true; } }
        public override bool ClearFromIframe { get { return true; } }

        protected override bool IsOnGetResponseErrorThrowing { get { return true; } }  

        string m_URL = @"http://euronews.com/{0}/";
        public new string URL
        {
            get { return m_URL; }
        }

        public override string GetContent(string word, string codeForm, string codeTo)
        {
            string content = "Content not found";
            try
            {
                content = base.GetContent(word, codeForm, codeTo);
            }
            catch (WebException ex)
            {   
                // TODO: 
                if (ex.Response != null)
                    content = GetStringFromResponse(ex.Response);
                // TODO: else

                //using (WebClient client = new WebClient())
                //    content = client.DownloadString(this.URL);
            }
            if (!String.IsNullOrEmpty(content))
            { 
                
            }
            return content;
        }

        public override string GetUrl(string word, LangPair langPair)
        {
            return string.Format(this.URL, word, langPair.From, langPair.To);
        }
    }
}
