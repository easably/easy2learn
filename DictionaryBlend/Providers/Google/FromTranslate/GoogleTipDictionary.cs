using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleTipDictionary : GoogleTranslateBase
    {
        #region Instance
        private static GoogleTipDictionary instance = new GoogleTipDictionary();
        // Protected constructor.
        protected GoogleTipDictionary() { }
        public static GoogleTipDictionary Instance { get { return instance; } }
        #endregion

        public override bool IsOnlyCaption { get { return true; } }
        public override bool IsHtmlMode { get { return false; } }

        // depricated
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
            article = word + Environment.NewLine + article;
            //            return new TipArticle(articleTitle, article);
            if (string.IsNullOrEmpty(articleTitle))
                return new TipArticle(articleTitle, article);
            else
                return new TipArticle(articleTitle, " ");
        }

        public class TipArticle
        {
            public TipArticle(string caption, string body)
            {
                m_Caption = AvoidDuplicate(caption);
                m_Body = body;
            }

            string AvoidDuplicate(string val)
            {
                string[] arr = val.Split(' ');
                // same time we got this response: сделать сделать
                if ((arr.Length == 2) && arr[0].Equals(arr[1]))
                {
                    return arr[0];
                }
                return val;
            }

            private string m_Caption;
            public string Caption { get { return m_Caption; } }
            private string m_Body;
            public string Body { get { return m_Body; } }
        }
    }
}