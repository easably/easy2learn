using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class EuronewsArchiveView : UserControl
    {
        WebParser m_Parser = null;
        WebParser Parser { get { if (m_Parser == null) m_Parser = new WebParser(); return m_Parser; } }
       // public string JsSelector = WebParser.LoadResourceText("_4win.euronews_subtitles_parse.js");
        public string JsSelector = WebParser.LoadResourceText("_4win.euronews_subtitles_parse.js");
        string css = "";

        public EuronewsArchiveView()
        {
            InitializeComponent();
            // TODO: loading news
            //dateTimePicker1.Value = DateTime.Today;
            //dateTimePicker1.MaxDate = DateTime.Today;
            css = WebParser.LoadResourceText(@"css.selector-list-euronews-archive.css");
            webBrowser1.Navigating += webBrowser1_Navigating;
            this.Load += EuronewsBrowser_Load;
        }

        void EuronewsBrowser_Load(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.AbsoluteUri.Replace("localhost", "http://euronews.com");
            if (EuronewsProviderLoad.IsValidForDownloading(url))
            {
                (new EuronewsBrowser()).CallRunDownload(e.Url.AbsoluteUri);
            }
            if (e.Url.AbsoluteUri != "about:blank")
                e.Cancel = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        public static string GetURLData(DateTime dateTime)
        {
            // need format for http://euronews.com/2014/05/09/
            return string.Format(@"{0}/{1}/{2}", dateTime.Year,
                (dateTime.Month < 10 ? "0" + dateTime.Month.ToString() : dateTime.Month.ToString()),
                (dateTime.Day < 10 ? "0" + dateTime.Day.ToString() : dateTime.Day.ToString()));
        }

        public void RefreshData()
        {
            string html = RefreshData(GetURLData(dateTimePicker1.Value));
            this.webBrowser1.DocumentText = html;
            //this.webBrowser1.
        }

        public string RefreshData(string dt)
        {
            EuronewsProviderArchive prv = new EuronewsProviderArchive();
            string html = prv.GetContent(dt, CurrentLangInfo.CurrentLangPair); //TODO: список языков ограничен в euronews
// was before     string func = "function parse() { external_result = $('#main-content > div.column.span-16 > div.col-16-bg.col-p-t.col-m-b').html(); }";
// didn't work            string func = "function parse() { external_result = document.querySelector('#enw-search-articles').outerHTML; }";
            string func = "function parse() { external_result = $('#enw-search-articles')[0].outerHTML}";
            this.Parser.LoadAndParse(html, func); // here from page with subtitles
            string res = WWW.InternetIsUnavailable;
            if(!string.IsNullOrEmpty(this.Parser.Result))
                res = this.Parser.Result.Replace(@"http://.euronews.com", @"http://euronews.com");
            return res;
        }
    }
}
