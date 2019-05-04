using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace f
{
    public class TEDProvider : DictionaryProvider
    {
 
//            string prefixForAttr = "contentFull=\"";
//            string prefixForAttr = "href=\"";
        const string delimeterForURLMp4 = "?apikey";
        const string startVideoURL = "http://download.ted.com/talks/";
        const string prefixForAttrSub = "data-id=\"";

        public const string jsSelectorForImage = "function parse() { external_result = $('.talk-hero__image').attr('src'); }";

        public override string GetContent(string url, string codeForm, string codeTo)
        {
            m_URL = url;
            string content = base.GetContent(url, "", "");

            m_VideoTitle = getVideoTitle(url);

            AssignVideoURL(url, content);

            int start = content.IndexOf(prefixForAttrSub);
            //if (start > 0)
            //{
            //    start = start + prefixForAttrSub.Length;
            //    int end = contentFull.IndexOf("\"", start);
            //    m_SubtitleId = contentFull.Substring(start, end - start);
            //}
            //else 
            {
                m_SubtitleId = m_VideoTitle;
            }

            WebParser parser = new WebParser();
            parser.LoadAndParse(content, jsSelectorForImage); // here from source page
            m_ImgSrc = WebParser.GetClearURL(parser.Result);
            
            return content;
        }

        private void AssignVideoURL(string word, string content)
        {
            //const string prefixForAttrVideo = "=\"" + startVideoURL;      
            const string prefixForAttrVideo = "file\":\"" + startVideoURL;      
            int start = content.IndexOf(prefixForAttrVideo);
            if (start > 0)
            {
                //int end = contentFull.IndexOf("\"", start + prefixForAttrVideo.Length);
                int end = content.IndexOf("?", start + prefixForAttrVideo.Length);
                m_VideoURL = content.Substring(start, end - start);
                m_VideoURL = m_VideoURL.Replace(prefixForAttrVideo, "");
                m_VideoTitle = getVideoTitle(word);
            }
        }

        #region Subtitles
        public string GetSubtitles(string code, string folder)
        {
            string fileName = "";

            if (!string.IsNullOrEmpty(SubtitleId))
            {
                TEDSubtitleProvider subProvider = new TEDSubtitleProvider();
                try
                {
                    string subtText = subProvider.GetContent(m_SubtitleId, code, "");
                    string _firstSentence = string.Format(VideoUnit.FirstSentence, this.URL);
                    //string _firstSentence = string.Format(VideoUnit.FirstSentence, this.URL, this.VideoTitle); 
                    fileName = string.Format(@"{0}\{1}.srt", folder, code);
                    SubtitleCreator sc = new SubtitleCreator(subtText, fileName, _firstSentence);
                    //while (!File.Exists(fileName))
                    //{
                    //    Application.DoEvents();
                    //}
                    return fileName;
                }
                catch
                {
                    MessageBox.Show("Subtitles was not created for language '" + code + "'"); 
                    //MessageBox.Show("Subtitles was not created for selected episode on TED");
                  //  MessageBox.Show("Subtitles was not created yet For selected episode The Try later.");
                    return null;
                }
            }
            return fileName;
        }

        string m_VideoTitle = "";
        public string VideoTitle
        {
            get { return m_VideoTitle; }
        }

        string m_SubtitleId = "";
        public string SubtitleId
        {
            get { return m_SubtitleId; }
        }
        #endregion

        private string getVideoTitle(string word)
        {
            int start = word.LastIndexOf("/")+1;
            int end = word.LastIndexOf(".");
            if (start != -1 && end != -1 && start < end)
                return word.Substring(start, end - start);
            else if (start != -1)
                return word.Substring(start).Trim('/');
            return "SameVideoNameForTedVideo";
        }

        string m_VideoURL = ""; // "ChrisBliss_2011X.mp4?apikey=TEDDOWNLOAD"
        public string VideoURL
        {
            get { return m_VideoURL; }
        }

        public string VideoURLFull
        {
            get
            {
                return 
                    startVideoURL + (this.VideoURL.IndexOf(delimeterForURLMp4) > 0 ? 
                        this.VideoURL.Substring(0, this.VideoURL.IndexOf(delimeterForURLMp4)) : this.VideoURL);

            }
        }

        #region service props
        public override string[] StartTags
        {
            get { return null; }
        }

        string m_URL = "{0}";
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
            get { return new string[] {DictionaryProvider.AllLanguages}; }
        } 
        #endregion

        public string m_ImgSrc;
        public string ImgSrc { get { return m_ImgSrc; } }
    }
}


//if (this.webBrowser1.Url == null)
// this.webBrowser1.Navigate("http://www.ted.com/translate/languages/ru"); // с языком по умолчанию открыть 

// <div id="maincontent" style="background: none">  - потом можно взять div 
//    <div id="list" class="talkListContainer horiz clearfix"> -- этот див без листания

//  //  this.webBrowser1.Navigate("http://www.ted.com/talks?sort=mosttranslated");
//  this.webBrowser1.Navigate("http://www.ted.com/OpenTranslationProject");


//  http://www.ted.com/talks/subtitles/id/1/lang/ru -- здесь можно просто подбирать субтитры


// 1.
// http://www.ted.com/talks?lang=en&event=&duration=&sort=newest
// http://www.ted.com/talks?lang=en&event=&duration=&sort=newest&tag=&page=2
// http://www.ted.com/talks?lang=en&event=&duration=&sort=newest&tag=&page=3

// а это страницы с переводом
// http://www.ted.com/translate/languages/en?page=2
// http://www.ted.com/translate/languages/en?page=3

// 2.
// http://www.ted.com/talks/lang/ru/christina_warinner_tracking_ancient_diseases_using_plaque.html -- url
// <meta property="og:video" contentFull="http://download.ted.com/talks/ChristinaWarinner_2012U-320k.mp4"> -- id для видео
// <div id="share_and_save" class="share-data clearfix" data-id="1425" data-model="talks" data-title="Кристина Вариннер: Отслеживаем древние болезни по... зубному камню" data-url="http://www.ted.com/talks/lang/ru/christina_warinner_tracking_ancient_diseases_using_plaque.html" data-slug="christina_warinner_tracking_ancient_diseases_using_plaque"> -- id для субтитров

// 3.
// http://www.ted.com/talks/titles/id/1425/lang/it - кто писал перевод 
// http://www.ted.com/talks/subtitles/id/1425/lang/it - сам перевод
// http://video.ted.com/talk/podcast/2012U/None/ChristinaWarinner_2012U.mp4 - сама скачка
// http://download.ted.com/talks/ChristinaWarinner_2012U-320k.mp4 - сама скачка
// http://www.ted.com/download/links/slug/ChristinaWarinner_2012U/type/talks/ext/mp4/lang/ru - форма скачки

