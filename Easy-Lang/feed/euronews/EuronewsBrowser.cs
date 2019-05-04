using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace f
{
    public partial class EuronewsBrowser : BrowserForSownloadUC
    {
        public EuronewsBrowser()
        {
            InitializeComponent();
            this.WWindow.ScriptErrorsSuppressed = true;
            // this.WWindow.ScrollBarsEnabled = false;

            this.WWindow.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbTedView_DocumentCompleted);
            this.WWindow.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wbTedView_Navigating);
            this.WWindow.NewWindow += new System.ComponentModel.CancelEventHandler(this.wbTedView_NewWindow);
            this.Load += EuronewsBrowser_Load;
        }

        void EuronewsBrowser_Load(object sender, EventArgs e)
        {
            this.RefreshWebPage();
        }

        void RefreshWebPage()
        {
            string url = "http://euronews.com/news/";
            WWindow.Navigate(url);
        }

        void wbTedView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WWindow.Document.Window.ScrollTo(0, 450);
            pictureBox1.Visible = false;
            WWindow.Visible = true;
        }

        private void wbTedView_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (EuronewsProviderLoad.IsValidForDownloading(e.Url.AbsoluteUri))
            {
                e.Cancel = true;
                CallRunDownload(e.Url.AbsoluteUri);
            }
        }

        private void wbTedView_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            //MessageSelectOnlyVideo();
        }


        public void CallRunDownload(string url)
        {
            try
            {
                if (RunDownload(url))
                    CallCompleteEvent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, string.Format("Downloading from '{0}'", url), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        f.TED.FormDowloadedInfo progressDownloadForm = null;

        bool RunDownload(string url)
        {
            try
            {
                News newsFrom = null;
                News newsNative = null;
                EuronewsProviderLoad newsProvider = new EuronewsProviderLoad();

                try
                {
                    progressDownloadForm = new f.TED.FormDowloadedInfo();
                    progressDownloadForm.Show();
                    progressDownloadForm.EnSubtProgress = 10;
                    newsFrom = newsProvider.GetContent(url);
                    progressDownloadForm.EnSubtProgress = 60;

                    progressDownloadForm.NativeSubtProgress = 10;
                    string nativeSuffix = CurrentLangInfo.CurrentLangPair.To + ".";
                    string nativeUrl = url.Replace("www.euronews.com", nativeSuffix + "euronews.com");
                    newsNative = newsProvider.GetContent(nativeUrl);
                    if (newsFrom == null) 
                        throw new ApplicationException("Was not found information fo detail data. Try another addres for getting data.");

                    progressDownloadForm.NativeSubtProgress = 60;

                    string folder = GetFolder(newsFrom.Title, rootFolderName);
                    DoDownloadFile(newsFrom.ImgSrc, folder);

                    if (newsFrom != null)
                        DownloadNews(newsFrom, folder);

                    //if (this.newsNative != null && this.newsFrom != null)
                    if (newsNative != null)
                    {
                        newsNative.VideoSrc = null; // skip native video
                        DownloadNews(newsNative, folder, nativeSuffix, newsFrom == null ? newsNative : newsFrom);
                    }
                    return true;
                }
                finally
                {
                    progressDownloadForm.Close();
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("TimeoutException, please try again later");
                return false;
            }
        }

        public static string rootFolderName = "euronews";

        void DownloadNews(News news, string folder) { DownloadNews(news, folder, "en.", news); }
        void DownloadNews(News news, string folder, string nativeSuffix, News sourceNews)
        {
            bool isTargetLanguage = nativeSuffix.Equals("en.");
            try
            {
                if (!string.IsNullOrEmpty(news.VideoSrc))
                {
                    WebDownloader.DownloadProgressDelegate dowloadProgress = new WebDownloader.DownloadProgressDelegate(progressDownloadForm.AssignProgress);
                    m_fileVideo = WebDownloader.Download(news.VideoSrc, folder, dowloadProgress, nativeSuffix + "mp4");
                    if (!string.IsNullOrEmpty(m_fileVideo))
                    {
                        //  news.AllLength = mp4info.FindLength_mciSend(m_fileVideo);
                        //AxWMPLib.AxWindowsMediaPlayer Player = new AxWMPLib.AxWindowsMediaPlayer();
                        VideoControl vc = new VideoControl();
                        vc.Player.URL = m_fileVideo;
                        // не помогает vc.Player.Ctlcontrols.pause(); // т.к. сразу играет
                        while ((int)vc.Player.playState == 9) // connecting
                            Application.DoEvents();
                        news.AllLength = (long)(vc.Player.currentMedia.duration * 1000);
                        vc.Player.URL = "";
                        vc.Dispose();
                    }
                }
                else if (isTargetLanguage)
                {
                    // перейти на страницу чтобы самостоятельно скачать видео
                    MessageBox.Show(this, "Video not found. Try download it self.", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // открывать только если в диалоге выбрали Yes ???
                    //   Runner.OpenURL(url);
                }

                string fileExt = "txt";
                string fileContent = news.HTMLContent;
                if (news.AllLength != -1) // т.е. известна длина видео
                {
                    fileExt = "srt";
                    fileContent = SentenceParser.CreateSubtitles(news);
                }
                else // чтобы кол-во предложений былы синхронным добавим еще одно предложение
                    fileContent = string.Format(VideoUnit.FirstSentence, news.URL) + "." + Environment.NewLine + fileContent; 

                if (!string.IsNullOrEmpty(news.HTMLContent))
                {
                    string fileName = folder + nativeSuffix + fileExt;
                    fileName = FileManager.CreateFile(fileName, fileContent);
                    if (isTargetLanguage)
                    {
                        this.m_FileSubtEn = fileName;
                        progressDownloadForm.EnSubtProgress = 100;
                    }
                    else
                    {
                        this.m_fileSubtNative = fileName;
                        progressDownloadForm.NativeSubtProgress = 100;
                    }
                }

            }
            catch
            {
                MessageBox.Show(this, "Please, try to select another news.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                progressDownloadForm.IsVideoWorng = true;
            }
        }
    }
}
