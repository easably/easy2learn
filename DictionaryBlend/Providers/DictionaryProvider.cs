using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Net.Cache;

namespace f
{
    public abstract class DictionaryProvider : IDictionaryProvider
    {
        public abstract string Title { get; }
        public abstract string Copyright { get; }
        public abstract string URL { get; }
        public abstract string[] StartTags { get; }
        public virtual string BookmarkForStarTag { get { return null; } }
        public virtual string Styles { get { return null; } }

        public abstract string[] Languages { get; }

        public virtual string[] RequestParameters { get { return new string[] { }; } }
        public virtual string CorrectionURL { get { return this.URL.Replace("{0}", ""); } }
        public virtual string CorrectionURLForImage { get { return CorrectionURL; } }

        public virtual DictionaryProviderType DictType { get { return DictionaryProviderType.Simple; } }
        public virtual bool OnlyAsUrlProvider { get { return false; } }

        public virtual Encoding DefaultEncoding { get { return null; } } // by default will got from response otherwise will getting Encoding.Default
        public virtual bool ClearFromScript { get { return false; } }
        public virtual bool ClearFromIframe { get { return false; } }

        bool m_IsOnGetResponseErrorThrowing = false;
        protected virtual bool IsOnGetResponseErrorThrowing { get { return m_IsOnGetResponseErrorThrowing; } }  
        
        public const string RequiredDictionary = "f.GoogleDictionary";  // typeof(GoogleDictionary).FullName;

        readonly Dictionary<string, string> history = new Dictionary<string, string>();


        public string GetContent(string word, LangPair lp)
        {
            word = word.Replace('\n', ' ');
            return GetContent(word, lp.From, lp.To);
        }

        public virtual string GetContent(string word, string codeForm, string codeTo)
        {
            m_ExceptionMessage = "";
            if (string.IsNullOrEmpty(word)) return string.Empty;

            this.ResetLastResultFromResponse();
            LangPair lp = new LangPair(codeForm, codeTo);
            // TODO: некрасивый дизайн
            string _acceptedLanguageCode = GetContainsSourceLanguage(lp.ToString());
            if (string.IsNullOrEmpty(_acceptedLanguageCode)) // проверка поддержки языка
                return ""; // язык не поддерживается

            string url = this.GetUrl(word, lp);


            //TODO: если пользователь меняет конфигурацию словарей то надо сбросить
            //TODO: историю для текстов храним?? может по ключу текста определятся))
            if (history.ContainsKey(word + _acceptedLanguageCode))
            {
                m_LastResultFromResponse = new ResultFromResponse(url, _acceptedLanguageCode, history[word + _acceptedLanguageCode]);
                return history[word + _acceptedLanguageCode];
            }

            string response = "";
            if (IsDoFullLoading)
                response = DoAddLoading(url);
            else
            {
                #region Getting response
                #region request
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Proxy = null;
                request.UserAgent = "Mozilla/5"; // "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3 GTB7.1 ( .NET CLR 3.5.30729; .NET4.0E) GTBA"

                /////////////////////////////////////////
                // headers test for www.euronews.com
//request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1920.0 Safari/537.36";                
//request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
//request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
//request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
//request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default); // "Cache-Control", "max-age=0";
//request.Headers.Add("Cache-Control", "max-age=0");

//request.KeepAlive = true; //request.Connection = "Keep-alive";

////string raw = "__gads=ID=63ac347ea76af89f:T=1395648872:S=ALNI_MaprzlJGOpP_i-K7nBBgJlgGyBpyg; EN_meteo_fc=C; EN_textSize=1; __atuvc=5%7C13%2C3%7C14";
////string rawAr = raw.Split('=', ';');

//Uri target = new Uri("http://euronews.com/");
//request.CookieContainer = new CookieContainer();
//request.CookieContainer.Add(new Cookie("__gads", "ID=63ac347ea76af89f:T=1395648872:S=ALNI_MaprzlJGOpP_i-K7nBBgJlgGyBpyg")  { Domain = target.Host });
//request.CookieContainer.Add(new Cookie("EN_meteo_fc", "C") { Domain = target.Host });
//request.CookieContainer.Add(new Cookie("EN_textSize", "1") { Domain = target.Host });
//request.CookieContainer.Add(new Cookie("__atuvc", "5%7C13%2C3%7C14") { Domain = target.Host });
//request.Host = "euronews.com";
                /////////////////////////////////////////
                
                //  request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //  request.Headers.Add("Accept-Language", "en-us,en;q=0.5");
                //  request.Headers.Add("Accept-Encoding", "gzip,deflate");
                //  request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
                //  request.Headers.Add("Cookie", "PREF=ID=e0d94a24a2fa9cc4:U=1c449fa392bc9632:TB=2:TM=1267174677:LM=1273649640:DV=8atQZBunt08B:GM=1:S=x8X2uigJVBwIPI8s; NID=34=B0FfFFFonIaztkSsAmNGRUc2d_zPSqDjWdTKuaQgtMO4v7jmGspcZB0SyUq8sjyCSzzdPeB8T9YeCoUXAn1gkqNecV5TheVtz7gBdH7QHCAU8r6g6H1xV4sNqo9oe-UT; rememberme=true; SID=DQAAAKUAAADbnRqRs2S1NuzS-DqVUTlfDNQUAGZmdptrFk_TtFGpcndN1-wH_J04MBexODkaLHgoJItKux_SIuL4xdCmYZ4PkG_hMSGA9I1u9aiIDP0BVejn5_rXhP6tLrK20SXoFrs2icfy-M3B-nwmhcQpzrSKAC9joJu3E36zvgbrokwZhHMr2oe7Jb2GzfvRb5dXilY0uw67CVTBS8vQtLw1qLPoKu99bi3lZGuXv7LSbTWn-g; HSID=Ap1PAdWAwDLJcgF58; S=indic-transliteration=eE3u86HcynSHRqj7jy_xdg");

                // for multitran
                //request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.13) Gecko/20101203 Firefox/3.6.13";
                //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //request.Headers.Add("Accept-Language", "en-us,en;q=0.5");
                //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                //request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
                //request.Headers.Add("Keep-Alive", "	115");
                //request.Headers.Add("Cookie", "	langs=2 1"); 
                #endregion

                #region Gets a Stream  object to use to write request data
                if (this.RequestParameters.Length > 0 &&
                    !this.URL.Contains("{0}")) // && this.StartTag == string.Empty)
                {
                    request.Method = "POST";
                    Stream newStream = request.GetRequestStream();


                    Encoding encoding = new ASCIIEncoding();
                    //  string encodingName = "koi8-r windows-1251";
                    //  string encodingName = Encoding.UTF8;
                    string encodingName = "ISO-8859-1";

                    encoding = System.Text.Encoding.GetEncoding(encodingName,
                        new EncoderReplacementFallback("(unknown)"),
                         new DecoderReplacementFallback("(error)"));
                    encoding = Encoding.Default;

                    //  Console.WriteLine("Request with EncodingName: " + encoding.EncodingName + " CodePage: " + encoding.CodePage);

                    byte[] byte1;

                    //byte1 = encoding.GetBytes("security_token=" + "AKrFfvIEjIbGcYBjuELVb-iUTz8SO_5xQg:1285153424972");
                    //newStream.Write(byte1, 0, byte1.Length);

                    //byte1 = encoding.GetBytes("entity=" + "00001otndccsdmo");
                    //newStream.Write(byte1, 0, byte1.Length);

                    //byte1 = encoding.GetBytes("esm=" + "true");
                    //newStream.Write(byte1, 0, byte1.Length);

                    //Console.WriteLine("!!!!!!!!");

                    byte1 = encoding.GetBytes(this.RequestParameters[0] + word);
                    newStream.Write(byte1, 0, byte1.Length);

                    //byte1 = encoding.GetBytes("sl=" + lp.From);
                    //newStream.Write(byte1, 0, byte1.Length);

                    //byte1 = encoding.GetBytes("tl=" + lp.To);
                    //newStream.Write(byte1, 0, byte1.Length);

                    newStream.Close();
                }
                #endregion

                #region GetResponse
                WebResponse resp = null;
                try
                {
                    resp = request.GetResponse();
                    //Console.WriteLine("Log: Get response for URL: '{0}'", url);
                }
                catch (WebException ex)
                {
                    // тем самым состояние установим что у нас были проблемы
                    m_ExceptionMessage = ex.Message + Environment.NewLine + request.Address.ToString();

                    if (this.IsOnGetResponseErrorThrowing)
                        throw ex;

                    if (!WWW.IsOnline())
                    {
                        m_ExceptionMessage = WWW.InternetIsUnavailable;
                        return WWW.InternetIsUnavailable;
                    }

                    //var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    //return "An error occurred, status code: " + statusCode;

                    // if (ex.Message.Contains("(404)")) 
                    return m_ExceptionMessage; // ex.Status == ProtocolError // from System.Net.WebExceptionStatus
                    //  if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                    //Console.WriteLine("Errror: {0}, Response: {1}, URL: {2}", ex.Message, ex.Response, url);
                }
                #endregion

                if (resp == null)
                {
                    if (!WWW.IsOnline())
                        return WWW.InternetIsUnavailable;
                    return "An error occurred while processing the request.";
                }
                response = GetStringFromResponse(resp);
                #endregion
            }

            this.LastRawResponse = response;

            if (this.StartTags != null && !string.IsNullOrEmpty(this.StartTags[0]))
                response = GetContentFromTag(response);

            // (c использованием base не получилось)
            //response = string.Format(@"<base target=""_blank"" /> <base href=""{0}"" /> ", this.CorrectionURL) + response;

            response = DoCorrectionForUrl(response, "href=\"#", url); // for bookmarks
            response = DoCorrectionForUrl(response, "href=\"", this.CorrectionURL); // for href=" (c использованием base не получилось)
            response = DoCorrectionForUrl(response, "src=\"", this.CorrectionURLForImage);
            response = DoCorrectionForUrl(response, "href=/", this.CorrectionURL); // for href=/ (c использованием base не получилось)
            response = DoCorrectionForUrl(response, "src=/", this.CorrectionURLForImage);
            response = DoCorrectionForUrl(response, "src='", this.CorrectionURLForImage);

            if(this.ClearFromScript)
                response = DoCorrectionForScript(response);

            if (this.ClearFromIframe)
                response = DoCorrectionForIframe(response);

            // for preventing opening new window (meat-in urban dictionary; unknownword - in wordReference)
            //response = response.Replace("<iframe", @"<base target=""_parent"" /> <iframe");
            //response = response.Replace("<iframe", @"<iframe target=""_parent""");
            
            lock (history)
            {
                if (!history.ContainsKey(word + _acceptedLanguageCode)) // другой поток мог успеть добавить
                    history.Add(word + _acceptedLanguageCode, response);
            }
            m_LastResultFromResponse = new ResultFromResponse(url, _acceptedLanguageCode, response);
            if ( !String.IsNullOrEmpty(this.Styles) )
            { 
                string htmlTemplate = @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN""><html><head>{0}</head><body>{1}</body></html>";
                response = string.Format(htmlTemplate, this.Styles, response);
            }
            return response;
        }

        private string DoCorrectionForIframe(string response)
        {
            string result = "";
            bool odd = true;
            string[] splited = response.Split(new string[] { "<iframe", "</iframe>", "<IFRAME", "</IFRAME>", }, StringSplitOptions.None);
            //            string[] splited = responseWithScript.ToLower().Split(new string[] { "<script>", "</script>" }, StringSplitOptions.None);
            foreach (string part in splited)
            {
                if (odd)
                    result += part;
                odd = !odd;
            }
            return result;
        }

        protected void ClearCash()
        {
            history.Clear();
        }

        string m_ExceptionMessage = "";
        public string ExceptionMessage
        {
            get { return m_ExceptionMessage; }
        }


        // TODO: если два скрипта встречаются сразу
        public static string DoCorrectionForScript(string response)
        {
            string result = "";
            bool odd = true;
            string[] splited = response.Split(new string[] { "<script", "</script>", "<SCRIPT", "</SCRIPT>", }, StringSplitOptions.None);
            //            string[] splited = responseWithScript.ToLower().Split(new string[] { "<script>", "</script>" }, StringSplitOptions.None);
            foreach (string part in splited)
            {
                if (odd)
                    result += part;
                odd = !odd;
            }
            return result;
        }

        void WriteResult(DateTime timeStart)
        {
            //TimeSpan span = DateTime.Now.Subtract(timeStart);
            //Console.WriteLine(string.Format("Log: Executed in {2}: {0}:{1}", span.Seconds, span.Milliseconds, this.Title));
        }

        // for change <span class="topiclinks"><img src="/images/665/ldoce_arrow.gif"/> => <span class="topiclinks"><img src="/images/665/ldoce_arrow.gif"/>
        // where prefix = "href=\"";
        // <a class="topic_other" title="CRICKET topic" href=/Cricket-topic/ >CRICKET</a>
        protected virtual string DoCorrectionForUrl(string response, string delimiter, string newPrefix)
        {
            if (string.IsNullOrEmpty(newPrefix)) return response;
            string[] parts = response.Split(new string[] { delimiter, delimiter.ToUpper() }, StringSplitOptions.None);
            if (parts.Length == 1) return response;
            string ret = "";
            foreach (string rootForCorrection in parts)
            {
                if (string.IsNullOrEmpty(ret)) // first
                {
                    ret = rootForCorrection;
                    continue;
                }
                string rootWithCorrection = "";

                // если начинается с http то ничего не добавляем
                if (rootForCorrection.StartsWith("http")) // может быть и без кавычек типа такого  href=/Cricket-topic/
                    rootWithCorrection = delimiter + rootForCorrection;
                else if (delimiter.EndsWith("#")) // Bookmarks      ----??skipping 
                {
                    rootWithCorrection = newPrefix + "#" + rootForCorrection;
                    rootWithCorrection = delimiter.Remove(delimiter.Length - 1, 1) + rootWithCorrection;
                }
                else
                {
                    // используем только при составлении урла с новым префиксом только здесь (пока в одном месте)
                    rootWithCorrection = JoinWithCorrection(newPrefix, rootForCorrection);
                    // ниже уже JoinWithCorrection не подойдет
                    if (delimiter.EndsWith("/"))
                        rootWithCorrection = delimiter.Remove(delimiter.Length - 1, 1) + rootWithCorrection;
                    else rootWithCorrection = delimiter + rootWithCorrection;
                }
                ret += rootWithCorrection;
            }
            return ret; // for debug ret.Split(new string[] {prefix}, StringSplitOptions.None) 
        }

        // используем только при составлении урла с новым префиксом
        string JoinWithCorrection(string val1, string val2)
        {
            if (!val1.EndsWith("/") && !val2.StartsWith("/"))
                return val1 + "/" + val2;
            else if (val1.EndsWith("/") && val2.StartsWith("/"))
                return val1 + val2.Remove(0, 1);
            else return val1 + val2;
        }

        private static string GetEncodeName(WebResponse resp)
        {
            if (resp.ContentType.Split(';').Length > 1 && resp.ContentType.Split(';')[1].Split('=').Length > 1)
                return resp.ContentType.Split(';')[1].Split('=')[1]; // text/plain; charset=KOI8-R
            else
            {
                // Content-Type	= "application/json"
                //string contentType = resp.Headers["Content-Type"];
                //if (string.IsNullOrEmpty(contentType))
                //{
                //    return contentType;
                //}

                // multitran ISO-8859-1
                if (resp is HttpWebResponse)
                    return ((HttpWebResponse)resp).CharacterSet;
                return string.Empty;
            }
        }

        protected string GetElementName(string val)
        {
            string[] splited = val.Split(new char[] { '<', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length > 0)
                return splited[0];
            return "body";
        }

       protected virtual string GetContentFromTag(string response)
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
            int counter = 0;
            string[] vals = contentFromResponse.Trim().Split('<');
            foreach (string line in vals)
            {
                if (string.IsNullOrEmpty(line)) continue;
                responseWithWorm += '<' + line;

                if (line.StartsWith(elementName)) ++counter;
                if (line.StartsWith("/" + elementName)) --counter;
                if (counter == 0)
                    break;
            }
            return responseWithWorm;
        }

        public static string AllLanguages = "all";

        // моно словарь определяется в descendants
        public virtual string GetContainsSourceLanguage(string abbreviature)
        {
            if (this.Languages.Length == 1 && this.Languages[0].Equals(AllLanguages)) return abbreviature;
            if (Array.IndexOf(this.Languages, abbreviature) != -1) return abbreviature;
            if (Array.IndexOf(this.Languages, abbreviature.Split(CurrentLangInfo.PairSeparator)[0]) != -1)
                return abbreviature.Split(CurrentLangInfo.PairSeparator)[0];
            
            if (this.Languages.Length == 1 && this.Languages[0].IndexOf(CurrentLangInfo.PairSeparator) == -1)// т.е. язык типа "ru" "en"
            {
                // TODO: проверку для всех this.Languages
                if (abbreviature.Contains(this.Languages[0]))
                    return abbreviature; // чтобы работало в en:ru для чисто русского словаря ru  
            }
            return string.Empty;
        }

        public bool IsSupport(string abbreviature)
        {
            return !string.IsNullOrEmpty(this.GetContainsSourceLanguage(abbreviature));
        }

        #region ResultFromResponse
        ResultFromResponse m_LastResultFromResponse = null;
        public ResultFromResponse LastResultFromResponse
        {
            get
            {
                return m_LastResultFromResponse;
            }
        }

        void ResetLastResultFromResponse()
        {
            m_LastResultFromResponse = null;
        }

        public class ResultFromResponse
        {
            public ResultFromResponse(string lastUrl, string acceptedLanguageCode, string content)
            {
                m_LastURL = lastUrl;
                m_AcceptedLanguageCode = acceptedLanguageCode;
                m_Content = content;
            }

            private string m_LastURL;
            public string LastURL { get { return m_LastURL; } }

            private string m_AcceptedLanguageCode;
            public string AcceptedLanguageCode { get { return m_AcceptedLanguageCode; } }

            private string m_Content;
            public string Content { get { return m_Content; } }
        }
        #endregion


        public virtual string GetUrl(string word, LangPair langPair)
        {
            if (string.IsNullOrEmpty(word)) return "";
            word = PrepareWord(word);
            return string.Format(this.URL, word, langPair.From, langPair.To);
        }

        // URL for web page (is not for getting data)
        public virtual string GetPublicUrl(string word, LangPair langPair)
        {
            return GetUrl(word, langPair);
        }

        protected static string PrepareWord(string word)
        {
            word = word.Trim().Replace('“', '\"');
            word = word.Replace('”', '\"');
            return word;
        }

        public override string ToString()
        {
            if (DictionaryProviderType.Simple == this.DictType)
                return this.Title;
            else
                return string.Format("{0} : {1}", this.Title, Enum.GetName(typeof(DictionaryProviderType), this.DictType));
        }

        #region Additional load for parsing
        public virtual bool IsDoFullLoading { get { return false; } }
        public virtual bool IsDoFullLoadingTwice { get { return false; } }

        bool loadedDocForParsing = false;
        bool loadedDocForParsingTwice = false;

        WebBrowser m_WebBrowser = null;
        WebBrowser WebBrowserAdd
        {
            get
            {
                if (m_WebBrowser == null)
                {
                    m_WebBrowser = new WebBrowser();
                    m_WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
                }
                return m_WebBrowser;
            }
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            if (wb == null) return;
            if (!e.Url.Equals(wb.Url)) return;
            // below  e.Url.Equals(wb.Url) == true
            if (loadedDocForParsing)
                loadedDocForParsingTwice = true;
            loadedDocForParsing = true;
            //Console.WriteLine(wb.Url);
        }

        protected string DoAddLoading(string url)
        {
            try
            {
                WebBrowserAdd.Url = new Uri(url);
            }
            catch
            {
                try
                {
                    WebBrowserAdd.Navigate(url);
                    #region System.NullReferenceException in WebBrowser
                    //              System.NullReferenceException occurred
                    //Message=В экземпляре объекта не задана ссылка на объект.
                    //Source=System.Windows.Forms
                    //StackTrace:
                    //     в System.Windows.Forms.UnsafeNativeMethods.IWebBrowser2.Navigate2(Object& URL, Object& flags, Object& targetFrameName, Object& postData, Object& headers)
                    //     в System.Windows.Forms.WebBrowser.PerformNavigate2(Object& URL, Object& flags, Object& targetFrameName, Object& postData, Object& headers)
                    //     в System.Windows.Forms.WebBrowser.PerformNavigateHelper(String urlString, Boolean newWindow, String targetFrameName, Byte[] postData, String headers)
                    //     в System.Windows.Forms.WebBrowser.set_Url(Uri value)
                    //     в f.DictionaryProvider.DoAddLoading(String url) в D:\FM\ForceMem\DictionaryBlend\Providers\DictionaryProvider.cs:строка 538
                    //InnerException:  
                    #endregion
                }
                catch
                {
                    // todo: непонятно что делать 
                }
            }
            DateTime start = DateTime.Now;
            while (true)
            {
                Application.DoEvents();
                if (this.loadedDocForParsingTwice)
                {
                    //Console.WriteLine("Completed from loadedDocForParsingTwice"); ;
                    break;
                }
                if (this.loadedDocForParsing && !this.IsDoFullLoadingTwice)
                {
                    //Console.WriteLine("Completed from loadedDocForParsing"); ;
                    break;
                }
                if (loadedDocForParsing)
                {
                    //Console.WriteLine("Completed"); ;
                    break;
                }

                //Console.WriteLine((DateTime.Now - start).Seconds);
                if ((DateTime.Now - start).TotalSeconds > 60)
                {
                   // Console.WriteLine("TimeOut"); ;
                    break;
                }
                //Console.WriteLine((DateTime.Now - start).Seconds);
            }
            return this.WebBrowserAdd.DocumentText;
        }

        protected string GetStringFromResponse(WebResponse resp)
        {
            string response = "";
            if (resp != null) { 
                #region get encode
            Encoding encode = this.DefaultEncoding;
            if (encode == null)
            {
                string codeName = GetEncodeName(resp);
                if (!string.IsNullOrEmpty(codeName))
                {
                    try
                    {
                        //  codeName = "ISO-8859-1"; // for 1251 = ISO-8859-5
                        //  codeName = "windows-1251"; // "koi8-r

                        encode = System.Text.Encoding.GetEncoding(codeName,
                            new EncoderReplacementFallback("(unknown)"),
                             new DecoderReplacementFallback("(error)"));
                        // encode = Encoding.UTF8; // ASCIIEncoding(); //                    
                        // Console.WriteLine("Response with EncodingName: " + encode.EncodingName + " CodePage: " + encode.CodePage);
                    }
                    catch (ArgumentException) { }
                }
            }
            if (encode == null)
                encode = Encoding.Default;
            #endregion

                var httpResponseStream = new StreamReader(resp.GetResponseStream(), encode, true);
                //var httpResponseStream = new StreamReader(resp.GetResponseStream());
                try
                {
                    response = httpResponseStream.ReadToEnd();
                }
                catch (Exception ex)
                {
                    /* System.Threading.ThreadAbortException: Поток находился в процессе прерывания.   в System.Net.ConnectStream.Read(Byte[] buffer, Int32 offset, Int32 size)   в System.IO.StreamReader.ReadBuffer()   в System.IO.StreamReader.ReadToEnd()   в f.DictionaryProvider.GetContent(String word, String codeForm, String codeTo) в d:\FM\ForceMem\DictionaryBlend\Providers\DictionaryProvider.cs:строка 205 */
                    // на медленном интернете из "Idiom Center" одножды прилетело при запросе из всех словарей
                    // пока тихорим
                    // System.Threading.ThreadAbortException]: {Unable to evaluate expression because the code is optimized or a native frame is on top of the call stack.}
                    //                    Console.WriteLine(ex);
                    // TODO: try word "discipline" from google synonims
                    // может проявлятся на медленном интенете
                    Utils.PublicException(ex);
                    m_ExceptionMessage = ex.Message;
                }
                finally
                {
                    httpResponseStream.Close();
                    resp.Close();
                }
            }
            return response;
        }
        #endregion
        
        protected string LastRawResponse = "";

        public string ClearScriptAndIFrame(string rawResponse){
            string result = DoCorrectionForScript(rawResponse);
            result = DoCorrectionForIframe(result);
            return result; // Console.WriteLine("was cutted: " + rawResponse.Length - result.Length)
        }
    }
}
