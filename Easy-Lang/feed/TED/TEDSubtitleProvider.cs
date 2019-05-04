using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class TEDSubtitleProvider : DictionaryProvider
    {
        public override string GetContent(string word, string codeForm, string codeTo)
        {
            string content = base.GetContent(word, codeForm, codeTo);
            if(codeForm != "en") // ru, spanish
                content = WebParser.Decoder(content);
            return content;        
        }

        //Encoding m_DefaultEncoding = null;
        //public override Encoding DefaultEncoding { get { return m_DefaultEncoding; } }

        public override string[] StartTags
        {
            get { return null; }
        }

        public override string URL
        {
      //      get { return "http://www.ted.com/talks/subtitles/id/{0}/lang/{1}"; }
            get { return @"http://www.ted.com/talks/{0}/transcript?lang={1}"; }
        }

        protected override bool IsOnGetResponseErrorThrowing { get { return true; } }  
        

        #region MyRegion
        public override bool ClearFromScript { get { return true; } }

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
            get { return new string[] { DictionaryProvider.AllLanguages }; }
        }
        #endregion
    }
}
