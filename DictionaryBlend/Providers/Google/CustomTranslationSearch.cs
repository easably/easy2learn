using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class CustomTranslationSearch : DictionaryProvider
    {
        // declare singleton field
        private static CustomTranslationSearch instance = null;
        // Protected constructor.
        protected CustomTranslationSearch() { }
        // Get instance
        public static CustomTranslationSearch Instance
        {
            get
            {
                if (instance == null) instance = new CustomTranslationSearch();
                return instance;                
            }
        }


        public override string Title { get { return ""; } }
        public override string Copyright { get { return @"©2009 Google"; } }
        public override string URL { get
        {
            return @"http://translate.google.com/toolkit/gettm";
        } }
        public override string CorrectionURL { get { return @""; } }
        public override string[] StartTags { get { return new string[] {string.Empty}; } }
        // "src" - word, sl=>tl = en->ru
        public override string[] RequestParameters { get { return new string[] { "src", "sl", "tl" }; } }
        public override string[] Languages { get { return new string[] { AllLanguages }; } }

        public override string GetContent(string word, string codeForm, string codeTo)
        {
            if (!WWW.IsOnline()) return WWW.InternetIsUnavailable;
            string baseResponse = base.GetContent(word, codeForm, codeTo);
            return baseResponse; // GetResultFromJSONDictionary(baseResponse);
        }

        public static string GetResultFromJSONDictionary(string jsonString)
        {
            string result = "";
            string[] trans_dict = jsonString.Split(new string[] { "]]," }, StringSplitOptions.None);
            for (int i = 0; i < trans_dict.Length-1; ++i)
            {
                if (i == 0) // translate
                {
                    string traslatedOnly = trans_dict[i].Split(new string[] {"\",\""}, StringSplitOptions.None)[0];
                    result += traslatedOnly.Substring(4, traslatedOnly.Length-4);
                }
                else // dictionary
                {
                    result += "\r\n\r\n";
                    string part = trans_dict[i].Replace("\",[\"", "\r\n\t");
                    result += part.Trim('[', '\"', ']');
                }
            }
            result = result.Replace("\",\"", ", ");
            return result;
        }

        public static string GetResultFromJSONDictionaryOld(string jsonString)
        {
            string result = "";
            string[] trans = jsonString.Split(new string[] { "{\"trans\":\"" }, StringSplitOptions.None);
            for (int i = 1; i < trans.Length; ++i)
            {
                string line = trans[i];
                int iEnd = trans[i].IndexOf("\",\"orig\":\"");
                result += line.Substring(0, iEnd);
            }

            string[] dict = jsonString.Split(new string[] { "{\"pos\":\"" }, StringSplitOptions.None);
            for (int i = 1; i < dict.Length; ++i)
            {
                string line = dict[i];
                if (i + 1 == dict.Length && line.IndexOf("\"]}],\"src\":\"") != -1)
                    line = line.Substring(0, line.IndexOf("\"]}],\"src\":\""));
                const string tag = "\",\"terms\":[\"";
                int iEnd = line.IndexOf(tag);
                result += "\r\n\r\n" + line.Substring(0, iEnd);
                iEnd += tag.Length;
                result += "\r\n\t" +
                          line.Substring(iEnd, line.Length - iEnd).Replace("\",\"", ", ").Replace("\"]},", "");
            } 
            return result;
        }


        public static TipArticle GetTipArticle(string word, string article)
        {
            string articleTitle = word;
            string[] lines = article.Split('\r');
            if (lines.Length > 0)
            {
                articleTitle = article.Split('\r')[0];
                article = article.Remove(0, articleTitle.Length);
                if (article.StartsWith("\r\n\r\n"))
                    article = article.Remove(0, 4);
                if (string.IsNullOrEmpty(article))
                {
                    if (word.ToLower().Equals(articleTitle.ToLower()))
                    {
                        article = string.Format("try to select part of the word '{0}'", articleTitle); // "";
                        articleTitle = string.Format("Word '{0}' not founded", word);
                    }
                    else
                    {
                        article = " "; // статья не может быть пустая иначе не покажется ToolTip                    
                    }
                }
            }
            article = word + "\r\n\r\n" + article;
            return new TipArticle(articleTitle, article);
        }

        public class TipArticle
        {
            public TipArticle(string caption, string body)
            {
                m_Caption = caption;
                m_Body = body;
            }

            private string m_Caption;
            public string Caption { get { return m_Caption; } }
            private string m_Body;
            public string Body { get { return m_Body; } }
        }

        protected override string DoCorrectionForUrl(string response, string prefix, string newPrefix)
        {
            return response;
        }
    }
}
