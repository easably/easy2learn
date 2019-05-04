using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Synonymizer : DictionaryProvider
    {
       // public override bool IsUTF8 { get { return true; } }
        public override string Title { get { return "Synonymizer"; } }
        public override string Copyright { get { return @"© Synonymizer"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }


        public override string[] Languages { 
            get
            {
                return new string[] {"ru"};
            }
        }

        public override string URL
        {
            get
            {
                return @"http://www.synonymizer.ru/index.php?sword={0}";
            }
        }

        public override string GetUrl(string word, LangPair langPair)
        {
            string convertedWord = System.Web.HttpUtility.UrlEncode(word, System.Text.Encoding.Default);
            return base.GetUrl(convertedWord, langPair);
        }

//        public override string[] StartTags { get { return new string[] { "<td" }; } }
        public override string[] StartTags { get { return new string[] { "<textarea" }; } }


        protected override string GetContentFromTag(string response)
        {
            string contentFromResponse = response;
            string elementName = "body";
            int indStart = -1;
            int startForSearching = 0;
            if (!string.IsNullOrEmpty(this.BookmarkForStarTag) && contentFromResponse.IndexOf(this.BookmarkForStarTag) != -1)
                startForSearching = contentFromResponse.IndexOf(this.BookmarkForStarTag);

            foreach (string startTag in this.StartTags)
            {
                indStart = contentFromResponse.IndexOf(startTag, startForSearching);
                if (indStart != -1)
                {
                    elementName = GetElementName(startTag);
                    break;
                }
            }
            if (indStart == -1)
                indStart = contentFromResponse.IndexOf("<body");
            if (indStart != -1)
                contentFromResponse = contentFromResponse.Substring(indStart);
            else
                return contentFromResponse;

            string responseWithWorm = ""; // is result 
            int elementCountForGetting = 4; // пересмотреть алгоритм почему на 3 элементах забирает только 2
            int counter = 0;
            string[] vals = contentFromResponse.Trim().Split('<');
            foreach (string line in vals)
            {
                if (string.IsNullOrEmpty(line)) continue;
                responseWithWorm += '<' + line;

                if (line.StartsWith(elementName)) ++counter;
                if (line.StartsWith("/" + elementName)) --counter;
                if (counter == 0)
                {
                    if (elementCountForGetting == 0)
                        break;
                    elementCountForGetting--;
                }
            }
            return responseWithWorm;
        }
    }
}
