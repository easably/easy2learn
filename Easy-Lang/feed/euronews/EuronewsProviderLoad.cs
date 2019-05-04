using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace f
{
    public class EuronewsProviderLoad : EuronewsProvider
    {
        WebParser m_Parser = null;
        WebParser Parser { get { if (m_Parser == null) m_Parser = new WebParser(); return m_Parser; } }
        long lengthForFirstSentence = 500;

        public News GetContent(string url)
        {
            string title, description, imgSrc, videoSrc = "";

         //   string contentFull = this.Parser.Load(url); очень долго все грузить ... если прерывать то статус остается незагруженный
            string content = GetContent(url, "en", ""); // en by default
            string contentFull = this.LastRawResponse; // en by default

            int startIndex = 0;
            title = GetMidleString(contentFull, "<title>", " | ", ref startIndex).Trim();
            title = WebUtility.HtmlDecode(title);
            description = GetMidleString(contentFull, "name=\"description\" content=\"", @""" />", ref startIndex);
            description = WebUtility.HtmlDecode(description);
            videoSrc = GetMidleString(contentFull, "file: \"", "?", ref startIndex);
            imgSrc = GetMidleString(contentFull, "image: \"", "?", ref startIndex);

            this.Parser.LoadAndParse(content, this.JsSelector);
            string _sentences = this.Parser.Result;
            if (!string.IsNullOrEmpty(videoSrc) && !string.IsNullOrEmpty(_sentences))
            {
                //string cuttedResponse = ClearScriptAndIFrame(this.LastRawResponse);
                //string type = GetTypeArticle(cuttedResponse);
                //if (type == "hi-tech") // hi-tech special for http://euronews.com/programs
                //    lengthForFirstSentence = 9000;
                // т.к. старый ie8 не переваривает селекторы типа 'div.themeBreadcrumb a:contains(hi-tech)'
                if( contentFull.Contains(@"<a href=""/programs/hi-tech/"">hi-tech</a>") )
                    lengthForFirstSentence = 9000;

                News nw = new News(title, description, imgSrc, videoSrc, _sentences) 
                    { URL = url, LengthForFirstSentence = lengthForFirstSentence };
                return nw;
            }
            return null;
        }

        public string GetTypeArticle(string html)
        {
            this.Parser.LoadAndParse(html, this.JsSelectorForType);
            return this.Parser.Result;
        }

        static string GetMidleString(string content, string startTag, string endTag, ref int startIndex)
        {
            if (startIndex < 0) startIndex = 0;
            startIndex = content.IndexOf(startTag);
            if (startIndex > 0)
            {
                startIndex = startIndex + startTag.Length;
                int end = content.IndexOf(endTag, startIndex);
                return content.Substring(startIndex, end - startIndex);
            }
            return "";
        }

        public string JsSelector = WebParser.LoadResourceText("_4win.euronews_subtitles_parse.js");
        public string JsSelectorForType = WebParser.LoadResourceText("_4win.euronews_type_parse.js");

        public static bool IsValidForDownloading(string url)
        {
            // example of url @"http://ru.euronews.com/2014/03/24/greener-tyres-on-the-road/"
            string[] parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int foo = -1;
            return parts.Length >= 5 &&
                parts[1].ToLower().Contains("euronews.com") &&
                (int.TryParse(parts[2], out foo) && 
                int.TryParse(parts[3], out foo) && 
                int.TryParse(parts[4], out foo));
        }
    }
}
