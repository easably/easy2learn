using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public partial class TedBrowser : BrowserForSownloadUC
    {
        public TedBrowser()
        {
            InitializeComponent();
            #region localization
            if (Utils.GetLocaleForUI().Equals("ru"))
            {
               // // Second subtitles in native language:

               // this.rbTranslation.Text = "Показывать видео с переводом на:";
               //// this.groupBoxForNative.Text = "Дополнительные субтитры на вашем языке:";
               // this.lbHint.Text = "Нажми на видео";

               // rbCategory.Text = "Показать по категориям";
            }
            #endregion

            InitLanguages();

            this.rbTranslation.CheckedChanged += new System.EventHandler(this.ui_Changed);
            this.cmbNativeLanguage.SelectedIndexChanged += new System.EventHandler(this.ui_Changed);
            
            this.wbTedView.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbTedView_DocumentCompleted);
            this.wbTedView.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wbTedView_Navigating);
            this.wbTedView.NewWindow += new System.ComponentModel.CancelEventHandler(this.wbTedView_NewWindow);
            this.Load += TedBrowser_Load;


            //try {
                TEDTags prv = new TEDTags();
                prv.FillTags();
                object selectedTag = null;
                foreach (TitleURLPair ob in prv.Tags)
                {
                    this.cmbTags.Items.Add(ob);
                    if (selectedTag == null && ob.Title.StartsWith("Memory"))
                        selectedTag = ob;
                }
                if (cmbTags.Items.Count > 0)
                {
                    if (selectedTag != null)
                        this.cmbTags.SelectedItem = selectedTag;
                    else this.cmbTags.SelectedItem = this.cmbTags.Items[0];

                    this.cmbTags.SelectedIndexChanged += new System.EventHandler(this.ui_Changed);
                    this.rbCategory.CheckedChanged += new System.EventHandler(this.ui_Changed);
                }
                else
                {
                    rbCategory.Enabled = false;
                }
            //}
            //finally
            //{
            //}
            if (!string.IsNullOrEmpty(prv.ExceptionMessage) && !WWW.IsOnline())
            { 
               IsOfflineMode = true; 
            }
        }

        void TedBrowser_Load(object sender, EventArgs e)
        {
            this.RefreshTedPage();
        }

        bool m_IsOfflineMode = false;
        public bool IsOfflineMode
        {
            private set
            {
                lbNoInternet.Visible =
                m_IsOfflineMode = value;
                pictureBox1.Visible =
                lbHint.Visible = !value;
            }
            get { return m_IsOfflineMode; }
        }

        string m_DefaultToLang = Utils.GetDefaultToLanguageForceDefault();
        string DefaultToLang
        {
            get { return m_DefaultToLang; }
        }

        void wbTedView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (rbCategory.Checked)
            {
                wbTedView.Document.Window.ScrollTo(0, 400);
                panel1.Dock = DockStyle.None;
                panel1.Height = 70;
            }
            else
            {
                wbTedView.Document.Window.ScrollTo(330, 250);
                panel1.Dock = DockStyle.Left;
            }
            wbTedView.Select();
            wbTedView.Visible = true;
        }

        #region InitLanguages
        // Dictionary<string, string> langs = new Dictionary<string, string>();

        void InitLanguages()
        {
//            cbNativeLanguage.Items.Add(new LangName("English", "en"));
           
            cmbNativeLanguage.Items.Add(new LangName("Afrikaans", "af"));               
            cmbNativeLanguage.Items.Add(new LangName("Albanian", "sq"));                
            cmbNativeLanguage.Items.Add(new LangName("Amharic", "amh"));                
            cmbNativeLanguage.Items.Add(new LangName("Arabic", "ar"));                  
            cmbNativeLanguage.Items.Add(new LangName("Armenian", "hy"));                
            cmbNativeLanguage.Items.Add(new LangName("Assamese", "as"));                
            cmbNativeLanguage.Items.Add(new LangName("Azerbaijani", "az"));             
            cmbNativeLanguage.Items.Add(new LangName("Basque", "eu"));                  
            cmbNativeLanguage.Items.Add(new LangName("Bengali", "bn"));                 
            cmbNativeLanguage.Items.Add(new LangName("Bislama", "bi"));                 
            cmbNativeLanguage.Items.Add(new LangName("Bosnian", "bs"));                 
            cmbNativeLanguage.Items.Add(new LangName("Bulgarian", "bg"));               
            cmbNativeLanguage.Items.Add(new LangName("Burmese", "my"));                 
            cmbNativeLanguage.Items.Add(new LangName("Catalan", "ca"));                 
            cmbNativeLanguage.Items.Add(new LangName("Cebuano", "ceb"));                
            cmbNativeLanguage.Items.Add(new LangName("Chinese, Simplified", "zh-cn"));  
            cmbNativeLanguage.Items.Add(new LangName("Chinese, Traditional", "zh-tw")); 
            cmbNativeLanguage.Items.Add(new LangName("Chinese, Yue", "zh"));            
            cmbNativeLanguage.Items.Add(new LangName("Croatian", "hr"));                
            cmbNativeLanguage.Items.Add(new LangName("Czech", "cs"));                   
            cmbNativeLanguage.Items.Add(new LangName("Danish", "da"));                  
            cmbNativeLanguage.Items.Add(new LangName("Dutch", "nl"));

            cmbNativeLanguage.Items.Add(new LangName("English subtitles (only machine translation)", "en"));
      
            cmbNativeLanguage.Items.Add(new LangName("Esperanto", "eo"));               
            cmbNativeLanguage.Items.Add(new LangName("Estonian", "et"));                
            cmbNativeLanguage.Items.Add(new LangName("Filipino", "fil"));               
            cmbNativeLanguage.Items.Add(new LangName("Finnish", "fi"));                 
            cmbNativeLanguage.Items.Add(new LangName("French", "fr"));                  
            cmbNativeLanguage.Items.Add(new LangName("French, Canadian", "fr-ca"));     
            cmbNativeLanguage.Items.Add(new LangName("Galician", "gl"));                
            cmbNativeLanguage.Items.Add(new LangName("Georgian", "ka"));                
            cmbNativeLanguage.Items.Add(new LangName("German", "de"));                  
            cmbNativeLanguage.Items.Add(new LangName("Greek", "el"));                   
            cmbNativeLanguage.Items.Add(new LangName("Gujarati", "gu"));                
            cmbNativeLanguage.Items.Add(new LangName("Hausa", "hau"));                  
            cmbNativeLanguage.Items.Add(new LangName("Hebrew", "he"));                  
            cmbNativeLanguage.Items.Add(new LangName("Hindi", "hi"));                   
            cmbNativeLanguage.Items.Add(new LangName("Hungarian", "hu"));               
            cmbNativeLanguage.Items.Add(new LangName("Hupa", "hup"));                   
            cmbNativeLanguage.Items.Add(new LangName("Icelandic", "is"));               
            cmbNativeLanguage.Items.Add(new LangName("Indonesian", "id"));              
            cmbNativeLanguage.Items.Add(new LangName("Ingush", "inh"));                 
            cmbNativeLanguage.Items.Add(new LangName("Italian", "it"));                 
            cmbNativeLanguage.Items.Add(new LangName("Japanese", "ja"));                
            cmbNativeLanguage.Items.Add(new LangName("Kannada", "kn"));                 
            cmbNativeLanguage.Items.Add(new LangName("Kazakh", "kk"));                  
            cmbNativeLanguage.Items.Add(new LangName("Khmer", "km"));                   
            cmbNativeLanguage.Items.Add(new LangName("Klingon", "tlh"));                
            cmbNativeLanguage.Items.Add(new LangName("Korean", "ko"));                  
            cmbNativeLanguage.Items.Add(new LangName("Kyrgyz", "ky"));                  
            cmbNativeLanguage.Items.Add(new LangName("Lao", "lo"));                     
            cmbNativeLanguage.Items.Add(new LangName("Latvian", "lv"));                 
            cmbNativeLanguage.Items.Add(new LangName("Lithuanian", "lt"));              
            cmbNativeLanguage.Items.Add(new LangName("Luxembourgish", "ltz"));          
            cmbNativeLanguage.Items.Add(new LangName("Macedo", "rup"));                 
            cmbNativeLanguage.Items.Add(new LangName("Macedonian", "mk"));              
            cmbNativeLanguage.Items.Add(new LangName("Malay", "ms"));                   
            cmbNativeLanguage.Items.Add(new LangName("Malayalam", "ml"));               
            cmbNativeLanguage.Items.Add(new LangName("Maltese", "mt"));                 
            cmbNativeLanguage.Items.Add(new LangName("Marathi", "mr"));                 
            cmbNativeLanguage.Items.Add(new LangName("Mongolian", "mn"));               
            cmbNativeLanguage.Items.Add(new LangName("Nepali", "ne"));                  
            cmbNativeLanguage.Items.Add(new LangName("Norwegian Bokmal", "nb"));        
            cmbNativeLanguage.Items.Add(new LangName("Norwegian Nynorsk", "nn"));       
            cmbNativeLanguage.Items.Add(new LangName("Persian", "fa"));                 
            cmbNativeLanguage.Items.Add(new LangName("Polish", "pl"));                  
            cmbNativeLanguage.Items.Add(new LangName("Portuguese", "pt"));              
            cmbNativeLanguage.Items.Add(new LangName("Portuguese, Brazilian", "pt-br"));
            cmbNativeLanguage.Items.Add(new LangName("Romanian", "ro"));                
            cmbNativeLanguage.Items.Add(new LangName("Russian", "ru"));                 
            cmbNativeLanguage.Items.Add(new LangName("Serbian", "sr"));                 
            cmbNativeLanguage.Items.Add(new LangName("Serbo-Croatian", "sh"));          
            cmbNativeLanguage.Items.Add(new LangName("Sinhala", "si"));                 
            cmbNativeLanguage.Items.Add(new LangName("Slovak", "sk"));                  
            cmbNativeLanguage.Items.Add(new LangName("Slovenian", "sl"));               
            cmbNativeLanguage.Items.Add(new LangName("Spanish", "es"));                 
            cmbNativeLanguage.Items.Add(new LangName("Swahili", "swa"));                
            cmbNativeLanguage.Items.Add(new LangName("Swedish", "sv"));                 
            cmbNativeLanguage.Items.Add(new LangName("Tagalog", "tl"));                 
            cmbNativeLanguage.Items.Add(new LangName("Tamil", "ta"));                   
            cmbNativeLanguage.Items.Add(new LangName("Telugu", "te"));                  
            cmbNativeLanguage.Items.Add(new LangName("Thai", "th"));                    
            cmbNativeLanguage.Items.Add(new LangName("Turkish", "tr"));                 
            cmbNativeLanguage.Items.Add(new LangName("Ukrainian", "uk"));               
            cmbNativeLanguage.Items.Add(new LangName("Urdu", "ur"));                    
            cmbNativeLanguage.Items.Add(new LangName("Uzbek", "uz"));                   
            cmbNativeLanguage.Items.Add(new LangName("Vietnamese", "vi"));

            string prefix = this.DefaultToLang.ToLower();
            foreach (LangName ln in cmbNativeLanguage.Items)
            {
                if ( ln.Code.Equals(prefix) )
                {
                    cmbNativeLanguage.SelectedItem = ln;
                    break;
                }
            }

            if (cmbNativeLanguage.SelectedItem == null)
            {
                foreach (LangName ln in cmbNativeLanguage.Items)
                {
                    // ("Filipino", "fil")); 
                    // ("French, Canadian", "fr-ca")); 
                    // ("Portuguese, Brazilian", "pt-br"));
                    if (ln.Code.Contains(prefix))
                    {
                        cmbNativeLanguage.SelectedItem = ln;
                        break;
                    }
                }
            }
        }
        
        #endregion

        class LangName
        {
            string m_namem;
            string m_code;

            public string Code
            {
                get { return m_code; }
            }

            public LangName(string name, string code)
            {
                m_namem = name; m_code = code;
            }

            public override string ToString()
            {
                return m_namem;
            }
        }


        private void ui_Changed(object sender, EventArgs e)
        {
            RefreshTedPage();
        }

        string urlForBrowsingPrefix = "http://www.ted.com/translate/languages/";
        string urlForBrowsing = "http://www.ted.com/translate/languages/{0}/";

        internal string urlForVideo = "http://www.ted.com/talks/";

        string m_CurrentUrl;
        void RefreshTedPage()
        {
            string url = "";
            if (rbCategory.Checked)
            {
                url = ((TitleURLPair)this.cmbTags.SelectedItem).URL;
            }
            else
            {
                if (rbTranslation.Checked && cmbNativeLanguage.SelectedItem is LangName)
                {
                    url = string.Format(urlForBrowsing, ((LangName)cmbNativeLanguage.SelectedItem).Code);
                }
                else
                    url = string.Format(urlForBrowsing, "en");

                if (url.EndsWith("en/"))
                {
                    url = url.Replace("en/", "en?page=10");
                }
            }
            if (!url.Equals(m_CurrentUrl))
            {
                m_CurrentUrl = url;
                wbTedView.Url = new Uri(url);
                wbTedView.Visible = false; // and waiting page loading 
            }
        }

        private void wbTedView_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.AbsoluteUri.StartsWith(urlForBrowsingPrefix) || e.Url.AbsoluteUri.StartsWith(TEDTags.url)) 
                return;
            e.Cancel = true;
            // Console.WriteLine(e.Url);
            if (e.Url.AbsoluteUri.StartsWith(urlForVideo))
            {
                IsVideoWasSelected = true;
                RunDownload(e.Url.AbsoluteUri);
            }
            else
                MessageSelectOnlyVideo();
        }

        private void wbTedView_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            MessageSelectOnlyVideo();
        }

        bool IsVideoWasSelected = false;

        void MessageSelectOnlyVideo()
        {
            if (!wbTedView.Visible) return;
            if (!IsVideoWasSelected)
                MessageBox.Show(this, "You should be selected link only with video!", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        f.TED.FormDowloadedInfo tedProgressForm = null;
        public static string rootFolderName = "TED";

        public void RunDownload(string url)
        {
           // url = @"http://www.ted.com/talks/drew_curtis_how_i_beat_a_patent_troll.html";
            tedProgressForm = new f.TED.FormDowloadedInfo();
            tedProgressForm.Show();
            try
            {
                m_TEDProvider = new TEDProvider();
                m_TEDProvider.GetContent(url, "", "");
                // get info
                if (string.IsNullOrEmpty(m_TEDProvider.SubtitleId))
                {
                }
                else
                    tedProgressForm.EnSubtProgress = 50;

                string folder = GetFolder(m_TEDProvider.VideoTitle, rootFolderName);

                DoDownloadFile(m_TEDProvider.ImgSrc, folder);

                m_FileSubtEn = m_TEDProvider.GetSubtitles("en", folder);
                if (!string.IsNullOrEmpty(m_FileSubtEn)) 
                    tedProgressForm.EnSubtProgress = 100;
                else
                    tedProgressForm.IsEnSubtWorng = true;
 
                // native
                if (rbTranslation.Checked && cmbNativeLanguage.SelectedItem is LangName)
                {
                    string nativeCode = ((LangName)cmbNativeLanguage.SelectedItem).Code;
                    if (!nativeCode.Equals("en"))
                    {
                        m_fileSubtNative = m_TEDProvider.GetSubtitles(nativeCode, folder);
                        if (!string.IsNullOrEmpty(m_fileSubtNative)) 
                            tedProgressForm.NativeSubtProgress = 100;
                        else tedProgressForm.IsNativeSubtWorng = true;
                    }
                }

                if (!string.IsNullOrEmpty(m_TEDProvider.VideoURL))
                {
                    WebDownloader.DownloadProgressDelegate dowloadProgress = new WebDownloader.DownloadProgressDelegate(ShowProgress);
                    m_fileVideo = WebDownloader.Download(m_TEDProvider.VideoURLFull, folder + "\\", dowloadProgress, "en.mp4");
                    CallCompleteEvent();
                }
                else
                {
                    // перейти на страницу чтобы самостоятельно скачать видео
                    MessageBox.Show(this, "Video not found. Try download it self.", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Runner.OpenURL(url);
                }
            }
            catch
            {
                MessageBox.Show(this, "Please, try to select another episode.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tedProgressForm.IsVideoWorng = true;
            }            
            tedProgressForm.Close();
        }

        private void ShowProgress(int progress)
        {
            tedProgressForm.VideoProgress = progress;
            tedProgressForm.Refresh();
        }

        TEDProvider m_TEDProvider;
        public TEDProvider TEDProvider { get { return m_TEDProvider; } }
    }
}
