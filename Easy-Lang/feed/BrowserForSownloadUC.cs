using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace f
{
    public partial class BrowserForSownloadUC : UserControl
    {
        public BrowserForSownloadUC()
        {
            InitializeComponent();
        }

        protected void CallCompleteEvent()
        {
            VideoUnit vu = new VideoUnit(Path.GetFullPath(m_fileVideo)) { video = m_fileVideo, target = m_FileSubtEn, native = m_fileSubtNative };
            ReaderForm.FileSelectorInstance.historyListUC1.RefreshList(true);
            FileSelector.VideoUnit = vu;
        }

        protected string m_fileVideo = "";
        public string FileVideo
        {
            get { return m_fileVideo; }
        }

        protected string m_FileSubtEn = "";
        public string FileSubtEn
        {
            get { return m_FileSubtEn; }
        }

        protected string m_fileSubtNative = "";
        public string FileSubtNative
        {
            get { return m_fileSubtNative; }
        }

        public static string GetFolder(string titleNews, string rootFolderName)
        {
            string folder = FileManager.CheckAndCreateFolder(rootFolderName);
            string fileRootName = FileManager.TuneFileName(titleNews);
            fileRootName = Utils.GetDateForFolderName() + fileRootName;
            folder = FileManager.CheckAndCreateFolder(rootFolderName + "\\" + fileRootName + "\\");
            return folder;
        }

        protected void DoDownloadFile(string url, string folder)
        {
            if (string.IsNullOrEmpty(url)) return; // TODO: maybe need defult image
            string fileName = Path.GetFileName(url);
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                    ++DownloadedCounter;
                    webClient.DownloadFileAsync(new Uri(url), folder + fileName);
                }
                catch
                {
                    --DownloadedCounter;
                }
            }
        }

        int m_DownloadedCounter = 0;
        int DownloadedCounter { set { m_DownloadedCounter = value; } get { return m_DownloadedCounter; } }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            --DownloadedCounter;
            ((WebClient)sender).DownloadFileCompleted -= webClient_DownloadFileCompleted;
            //    ((WebClient)sender).Dispose();             
        }
    }
}
