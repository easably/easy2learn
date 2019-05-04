using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace f
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class WebParser
    {
        #region ctor && Timer
        public WebParser()
        {
            m_Timer.Enabled = false;
            m_Timer.Interval = 21 * 1000;
            m_Timer.Tick += m_Timer_Tick;
        }

        void m_Timer_Tick(object sender, EventArgs e)
        {
            doStop = true;
            m_Timer.Stop();
        }

        Timer m_Timer = new Timer();
        bool doStop = false;
        DateTime m_TimeStarted;
        #endregion

        WebBrowser m_WebBrowser = null;
        public WebBrowser WebBrowserInstance{
            get {
                if (m_WebBrowser == null)
                {
                    m_WebBrowser = new WebBrowser();
                    m_WebBrowser.ScriptErrorsSuppressed = true;
                    //webBrowser1.AllowWebBrowserDrop = false; // this called exception in log - HRESULT E_FAIL
                    //   webBrowser1.IsWebBrowserContextMenuEnabled = false;
                    //    webBrowser1.WebBrowserShortcutsEnabled = false;
                    m_WebBrowser.ObjectForScripting = this;
                    m_WebBrowser.Navigating += m_WebBrowser_Navigating;
                }
                return m_WebBrowser; 
            }
        }

        void m_WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine((DateTime.Now - m_TimeStarted).TotalSeconds.ToString() + "  TargetFrameName:" + e.TargetFrameName);

            string url = e.Url.ToString();
            if (url.StartsWith(@"res://ieframe.dll") ||
                url.StartsWith(@"http://www.facebook.com") ||
                url.StartsWith(@"http://platform.twitter.com") ||
                url.StartsWith(@"http://s7.addthis.com") ||
                url.StartsWith(@"https://www.youtube.com") ||
                url.StartsWith(@"https://apis.google.com"))
            {
                Console.WriteLine("Skipped: " + url);
               // e.Cancel = true;
            }
            else
            {
                Console.WriteLine(url);
              //  e.Cancel = false;
            }
        }

        string m_Result;
        public string Result{ get { return m_Result;} }
        public void setResult(string objRes) { m_Result = objRes; }
        public event EventHandler ParseCompleted;

        public string Load(string url)  
        {
            WebBrowser wb = this.WebBrowserInstance;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);
            try {
                StartTimer();
                // while ((int)wb.ReadyState <= 1e && !doStop) {  
                while (wb.ReadyState != WebBrowserReadyState.Complete && !doStop) { 
                    Application.DoEvents();
                }
            }
            finally {
                this.StopTimer();
            } 
            if (doStop && string.IsNullOrEmpty(wb.DocumentText))
                throw new TimeoutException("Timeout expired for " + url);
            return wb.DocumentText;
        }

        private void StartTimer()
        {
            doStop = false;
            m_TimeStarted = DateTime.Now;
            m_Timer.Start();
        }

        private void StopTimer()
        {
            doStop = false;
            Console.WriteLine("!!!!!!!!!!!!!! Done !!!!!!!!!!!!!!");
            Console.WriteLine((DateTime.Now - m_TimeStarted).TotalSeconds.ToString());
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            m_Timer.Stop();
        }

        public void LoadAndParseWithPreload(string url, string jsParse)
        {
            this.LoadAndParse(this.Load(url), jsParse);
        }

        public void LoadAndParse(string html, string jsParse) {
            WebBrowser wb = this.WebBrowserInstance;
            string scriptWrapper = "<script type='text/javascript'>{0}</script>";
            string jquery = LoadResourceText("js.jquery-1.11.0.min.js");
            //string allDoc = html.Replace("</head>", 
            //    string.Format(scriptWrapper, jquery) +
            //    string.Format(scriptWrapper, 
            //    "; var external_result = 'yet nothing'; " + 
            //    " function transfer(d) { window.external.setResult( external_result ? external_result : 'external_result not assigned') }") +

            //    string.Format(scriptWrapper, jsParse) + "</head>");
            string scripts = string.Format(scriptWrapper, jquery);
            scripts += string.Format(scriptWrapper,
                    " var external_result = 'external_result was inited'; " +
                    " function transfer(d) { window.external.setResult( external_result ); } " + 
                    jsParse);

            wb.DocumentText = html + scripts;
            try
            {
                StartTimer();
                // http://stackoverflow.com/questions/6748702/alternative-to-application-doevents http://stackoverflow.com/questions/5181777/use-of-application-doevents/5183623#5183623
                while (wb.ReadyState != WebBrowserReadyState.Complete && !doStop)
                    Application.DoEvents();
            }
            finally {
                this.StopTimer();
            }
            DoParseAndTransfer();
        }

        private void DoParseAndTransfer()
        {
            this.WebBrowserInstance.Document.InvokeScript("parse");
            this.WebBrowserInstance.Document.InvokeScript("transfer");
            if (this.ParseCompleted != null)
            {
                ParseCompleted.Invoke(this, EventArgs.Empty);
            }
        }

        public static string LoadResourceText(string name)
        {
            return LoadResourceText(name, null, "f");
        }

        public static string LoadResourceText(string name, Assembly assembly, string manifestPrefix)
        {
            String res = "";
            if (assembly == null) { assembly = typeof(WebParser).Assembly; }
            if (string.IsNullOrEmpty(manifestPrefix)) { manifestPrefix = typeof(WebParser).Assembly.GetName().Name; }
            name = manifestPrefix + ".html." + name;
            Stream stream = assembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                string mes = string.Format("Status: Not founded '{0}'", name);
                //throw new ApplicationException(mes);
                MessageBox.Show(mes, "On loading problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception();
            }
            else
            {
                StreamReader streamReader = new StreamReader(stream);
                res = streamReader.ReadToEnd();
            }
            return res;
        }



        static private Regex _regex = new Regex(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);

        public static string Decoder(string value)
        {
            return _regex.Replace(value, new MatchEvaluator(DoMatchEvaluator));

            //return value = _regex.Replace(
            //    value,
            //    m => ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString()
            //);
        }

        static string DoMatchEvaluator(Match match)
        {
            return ((char)int.Parse(match.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
        }

        // https://o-ssl.tedcdn.com/r/images.ted.com/images/ted/19d8523b9f45386879d0ffd5928cdf42fecf03e4_1600x1200.jpg?ll=1&quality=89&w=800
        public static string GetClearURL(string rawUrl)
        {
            if (!string.IsNullOrEmpty(rawUrl))
                return rawUrl.Split('?')[0];
            return rawUrl;
        }

    }
}
