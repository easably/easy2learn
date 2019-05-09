using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public partial class FileSelector : Form
    {
        internal const string enEmptyIndent = "     ";
        internal const string ruEmptyIndent = "  ";

        public FileSelector()
        {
            InitializeComponent();
            CurrentLangInfo.InitLanguagesMenu(this.miLanguages);
            CurrentLangInfo.ChangedLanguageDirection += CurrentLangInfo_ChangedLanguageDirection;

            if (T.splash != null) T.splash.Hide();

            tabControl.Selected += new TabControlEventHandler(tabControl1_Selected);

            // TODO: what is this tedBrowser1.IsOfflineMode?
            // if(tedBrowser1.IsOfflineMode)
            this.tabControl.SelectedIndex = this.tabControl.TabPages.IndexOf(this.tpVideoFiles);
            AdjustForm();

            this.btDownloadfromURL.Click += new System.EventHandler(this.button1_Click);
            this.txURLforDownload.TextChanged += new System.EventHandler(this.URLforDownload_TextChanged);

            btVideoOpen.Click += new EventHandler(btVideoOpen_Click);
            btSubtitleOpen.Click += new EventHandler(btSubtitleOpen_Click);
            this.btRun.Click += btRun_Click;

            this.FormClosed += FileSelector_FormClosed;
            this.FormClosing += FileSelector_FormClosing;
       }

        void FileSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            if (VideoUnit != null) 
                e.Cancel = true; // никогда не закрываем только прячем
        }

        void CurrentLangInfo_ChangedLanguageDirection(object sender, EventArgs e)
        {
        }

        void FileSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO:
            if (this.tabControl.SelectedTab == tpReadingText)
            {
                m_SubtitleFileName = this.createAndReadControl1.CurrentTextFileName;
            }
        }

        #region Download by URL
        private void button1_Click(object sender, EventArgs e)
        {
            if (isTedVideo) 
                this.tedBrowser1.RunDownload(this.txURLforDownload.Text);
            else if (isEuronewsVideo) 
                this.euronewsBrowser1.CallRunDownload(this.txURLforDownload.Text);
            // else if (isYouTube) this.youTube.IsValidForDownloading(this.txURLforDownload.Text);
            // else if (isAmara) this.amaraBrowser.IsValidForDownloading(this.txURLforDownload.Text);
            // closing this form will be after action of downloading
        }

        bool isTedVideo = false;
        bool isEuronewsVideo = false;
        bool isYouTube = false;
        bool isAmara = false;

        private void URLforDownload_TextChanged(object sender, EventArgs e)
        {
            isTedVideo = this.txURLforDownload.Text.StartsWith(this.tedBrowser1.urlForVideo);
            isEuronewsVideo = EuronewsProviderLoad.IsValidForDownloading(this.txURLforDownload.Text);
            isYouTube = YouTubeBrowser.IsValidForDownloading(this.txURLforDownload.Text);
            isAmara = AmaraBrowser.IsValidForDownloading(this.txURLforDownload.Text);
            this.btDownloadfromURL.Enabled = isTedVideo || isEuronewsVideo || isYouTube || isAmara;
        } 
        #endregion

        void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpTedCom)
            {
            }
            else if (e.TabPage == tpReadingText)
            {
                // maybe 
                this.createAndReadControl1.textBox.SelectAll();
                this.createAndReadControl1.textBox.Select();
            }
        }

        private void AdjustForm()
        {
            tabControl.TabPages.Remove(tpParents);
         //   tabControl.TabPages.Remove(tpReadingText);
          //  tabControl.TabPages.Remove(tpFromURL);
            
            if (!Windows7.Windows7Taskbar.Windows7OrGreater)
            {
                this.btVideoOpen.FlatStyle = 
                this.btSubtitleOpen.FlatStyle =
                this.btRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            }

            #region langs
            string lang = Utils.GetLocaleForUI();
            if (lang == "ru")
            {
                this.tpHistory.Text = enEmptyIndent + "Скаченное видео" + enEmptyIndent;
                this.tpEuronewsArchive.Text = "   Новости от Euronews   ";
                this.tpEuronews.Text = "    Программы Euronews    ";
                this.tpTedCom.Text = enEmptyIndent + "Видео от TED.com" + enEmptyIndent;
                 this.tpVideoFiles.Text = enEmptyIndent + "Открыть файлы" + enEmptyIndent;
              // this.tpParents.Text = enEmptyIndent + "Учить детей" + enEmptyIndent;
               // this.tpReadingText.Text = enEmptyIndent + "Читать текст" + enEmptyIndent;
                this.tpFromURL.Text = ruEmptyIndent + "Скачать по адресу" + ruEmptyIndent;

                this.Text = "Выберите видео материал для обучения";

                this.btRun.Text = ruEmptyIndent + "Запустить";
                this.toolTip1.SetToolTip(this.btRun, "Запустить программу для просмотра видео");

                this.label1.Text = "Файл c видео (фильм, новость):";
                this.label2.Text = "Файл с субтитрами (можно просто текст):";

                this.toolTip1.SetToolTip(this.btVideoOpen, "Выбрать файл");
                this.toolTip1.SetToolTip(this.btSubtitleOpen, "Выбрать файл");
                this.lbIntrodaction.Text = "Для просмотра видео по шагам надо два файла субтитры + видео";
                //this.lbIntrodaction.Text = "Для программы нужны обычные файлы (ничего специального)."
                //    + Environment.NewLine + "Достаточно двух файлов видео и субтитры.";




                this.lbURLforVideo.Text = enEmptyIndent + "Адрес для видео для сайта www.ted.com" + enEmptyIndent;
                this.btDownloadfromURL.Text = ruEmptyIndent + "Скачать";
                // побуждение интереса к обучению
                // http://www.ted.com/talks/lang/ru/ramsey_musallam_3_rules_to_spark_learning.html 

                // this.cbAlwaysThisDialog_deleted.Text = "Всегда показывать этот диалог";
            }
            else
            {
                this.Text = "Select a video training material";
                this.btRun.Text = enEmptyIndent + "Run";
                this.btDownloadfromURL.Text = enEmptyIndent + "Download and Run";
            }
            #endregion
        }

        #region Open dialog and GetFileName
        void btRun_Click(object sender, EventArgs e)
        {
            VideoUnit = new VideoUnit(Path.GetDirectoryName(this.txVideoFile.Text) + "\\") { video = this.txVideoFile.Text, target = this.txSubtFile.Text };
        }

        void btSubtitleOpen_Click(object sender, EventArgs e)
        {
            GetFileName(GlobalOptions.GetFileFilterForSubtitles(true), this.txSubtFile);
        }

        void btVideoOpen_Click(object sender, EventArgs e)
        {
            GetFileName(GlobalOptions.GetFileFilterForVideo(true), this.txVideoFile);
        }

        private void GetFileName(string filter, TextBox box)
        {
            string fileName = FileManager.FindPathAndReturnFullFileName(box.Text);
            this.openFileDialog1.InitialDirectory = GetFolderForFileSelection(box.Text);           

            this.openFileDialog1.FileName = box.Text;
            this.openFileDialog1.Filter = filter;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                box.Text = this.openFileDialog1.FileName;
                this.toolTip1.SetToolTip(box, box.Text);
            }
        }

        public static string GetFolderForFileSelection(string fileName)
        {
            string ret = "";
            if (!string.IsNullOrEmpty(fileName) && Directory.Exists(Path.GetDirectoryName(fileName)))
                ret = Path.GetDirectoryName(fileName);
            else if (VideoUnit != null && Directory.Exists(VideoUnit.path))
                ret = VideoUnit.path;
            else
                ret = CF.GetFolderForUserFiles(); // Application.CommonAppDataPath;
            return ret;
        } 
        #endregion

        #region public props
        string m_VideoFileName;
        public string VideoFileName
        {
            get { return m_VideoFileName; }
            set { 
                this.txVideoFile.Text = value;
                this.toolTip1.SetToolTip(this.txVideoFile, value);
            }
        }

        string m_SubtitleFileName = "";

        public string SubtitleFileName
        {
            get { return m_SubtitleFileName; }
            set { 
                this.txSubtFile.Text = value;
                this.toolTip1.SetToolTip(this.txSubtFile, value);
            }
        }

       // string m_SubtitleNativeFileName;
        public string SubtitleNativeFileName
        {
            get; // { return m_SubtitleNativeFileName; }
            set;
            //set
            //{
            //    this.txSubtFile.Text = value;
            //    this.toolTip1.SetToolTip(this.txSubtFile, value);
            //}
        }

        public string LessonFileName
        {
            get;
            set;
        }

        private void cbUseSamples_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseSamples.Checked)
            { 
                
            }
        }

        public void DoUseSample()
        {
            cbUseSamples.Checked = true;
        }
        #endregion

        static VideoUnit m_VideoUnit = null;
        public static VideoUnit VideoUnit { 
            set {
                m_VideoUnit = value;
                if (ReaderForm.FileSelectorInstance.Visible)
                {
                    ReaderForm.FileSelectorInstance.Hide();
                }
                if (m_VideoUnit != null)
                {
                    T.ReaderFormInstance.AssignFiles();
                  //  ReaderForm.
                }
           }
            get { return m_VideoUnit; }
        }
    }
}
