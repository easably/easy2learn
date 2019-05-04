using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class WebBrowserForForm : WebBrowserForText
    {
        public WebBrowserForForm()
        {
            this.NewWindow += new System.ComponentModel.CancelEventHandler(WebBrowserForForm_NewWindow);
            this.Navigating += new WebBrowserNavigatingEventHandler(WebBrowserForForm_Navigating);
            OpenUrlInExternalWindow = true;
        }

        #region TempContentUpdates
        public event EventHandler TempContentUpdates;

        string m_TempContent;
        public string TempContent
        {
            set
            {
                m_TempContent = value;
                if (TempContentUpdates != null)
                    TempContentUpdates.Invoke(this, EventArgs.Empty);
            }
            get { return m_TempContent; }
        } 
        #endregion

        public bool OpenUrlInExternalWindow { set; get; }
        
        void WebBrowserForForm_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string blank = "blank";
            if (e.Url.AbsolutePath != blank && !IsNotIFrame(sender))
            {
                e.Cancel = true;
                return;
            }
            if (OpenUrlInExternalWindow)
            {
                // if this not bookmark
                // if (!e.Url.AbsoluteUri.StartsWith("#") && !e.Url.AbsoluteUri.StartsWith("about:/#")) 
                {
                    if (e.Url.AbsolutePath != blank)
                    {
                        e.Cancel = true;
                        Runner.OpenURL(e.Url.AbsoluteUri);
                    }
                }
            }
        }

        void WebBrowserForForm_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsNotIFrame(sender))
            {
                e.Cancel = true;
                return;
            }
        }

        // for preventing opening new window (meat-in urban dictionary; unknownword - in wordReference)
        bool IsNotIFrame(object sender)
        { 
            WebBrowser wb = sender as WebBrowser;
            if(wb == null) return false;
            if (wb.Document.ActiveElement == null) return false;
            if (string.IsNullOrEmpty(wb.Document.ActiveElement.InnerText)) return false;
            if (wb.Document.ActiveElement.InnerHtml.ToLower().Contains("iframe")) return false;
            return true;
        }
    }


   // http://stackoverflow.com/questions/1562619/prevent-webbrowser-control-from-stealing-focus
}
