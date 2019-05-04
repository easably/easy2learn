using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace f
{
    public static class Runner
    {
        public static void OpenURL(string url)
        {
            if(string.IsNullOrEmpty(url)) return;
        //    if ( url.StartsWith("http:") )
                Process.Start(url);
//            Process.Start("explorer", url);           
//            else Process.Start("\"" + url + "\"");
        }

        #region for WWW
        public static void StartUrlInBrowser(string url, string val, bool multiWindows)
        {
            url = "http://" + string.Format(url, val);

            if (multiWindows && IsDefaultIExplore)
            {
                //Process[] beforeProc = Process.GetProcessesByName("iexplore.exe");
                //if (beforeProc.Length == 0)
                Process.Start("iexplore.exe", url);
                //else
                //    System.Diagnostics.Process.Start(url);
            }
            else
            {
                Process pr = Process.Start(url);
                //                new ha pr.Handle
            }
        }

        static string defaultIExplore = null;
        static bool m_IsDefaultIExplore;

        static bool IsDefaultIExplore
        {
            get
            {
                if (string.IsNullOrEmpty(defaultIExplore))
                {
                    // HKEY_CLASSES_ROOT\http\shell\open\command
                    defaultIExplore = "iexplore.exe";
                    RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command");
                    if (key != null)
                        defaultIExplore = (string)key.GetValue(string.Empty, "iexplore.exe");
                    m_IsDefaultIExplore = defaultIExplore.ToLower().IndexOf("iexplore.exe") != -1;
                }
                return m_IsDefaultIExplore;
            }
        }
        #endregion

        public static void RunBulk(List<string> urls, params string[] prms)
        {
            foreach (string url in urls)
            {
                OpenURL(string.Format("http://" + url, prms));
            }                                
        }

        public static List<string> SubSearch = new List<string>() { 

                    @"www.subtitlecube.com/search-movie-subtitles/{0}",
                    @"www.google.by/#hl=en&Q&q=download+subtitles+{0}&fp=1&cad=b",
	                @"www.findsubtitles.com/search.php?text={0}&lang=all",
                    @"www.moviesubtitles.org",
                    @"subs.com.ru",
                    @"subscene.com/filmsearch.aspx?q={0}",
                    @"www.subtitlesource.org/search/{0}",
                    @"www.opensubtitles.org/ru/search2/moviename-{0}",
                    @"www.allsubs.org//search-subtitle/{0}+/20"};
        }
}
