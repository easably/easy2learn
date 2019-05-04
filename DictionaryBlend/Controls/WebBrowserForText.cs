using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class WebBrowserForText : WebBrowser
    {
        public WebBrowserForText()
        {
            this.Navigate("about:blank");            
            this.DocumentText = "<br/>";
            //AssignText("<HTML><head><style type=\"text/css\"> h1 { color: red }</style></head><body></body></HTML>");
            //HtmlElement head = this.Document.GetElementsByTagName("head")[0];
            //head.InnerHtml = "<style type=\"text/css\"> h1 { color: red }</style>";
            //this.Document.Body.InnerHtml = "<h1>test</h1>";
        }

        public void AssignText(string text)
        {
            if (GoogleDictionary.Instance.IsHidedTrans)
            {
                this.DocumentText = text;
            }
            else
            {
                if (this.Document == null || this.Document.Body == null)
                    this.DocumentText = text;
                else this.Document.Body.InnerHtml = text;
            }
            //try
            //{
            //    this.Document.Body.InnerHtml = text;
            //}
            //catch // for this.Document.Body == null
            //{
            //    this.DocumentText = text;
            //    // else throw to upper
            //}
        }

        //http://social.msdn.microsoft.com/Forums/en-US/ieextensiondevelopment/thread/49dc2c07-ea26-4734-aa2c-99a109ccb46a
        //public void addStyle(string filename, IHTMLDocument2 doc)
        //{
        //    IHTMLStyleSheet style = (IHTMLStyleSheet)doc.createStyleSheet("", 0);
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    StreamReader stream = new StreamReader(assembly.GetManifestResourceStream(filename));
        //    style.cssText = stream.ReadToEnd();
        //    stream.Close();
        //    // ((IHTMLDOMNode)doc.body).appendChild((IHTMLDOMNode)style); // Doesn't work!           
        //}

        // http://stackoverflow.com/questions/5496549/how-to-inject-css-in-webbrowser-control
        //private void AddStyles()
        //{
        //    HtmlElement head = this.Document.GetElementsByTagName("head")[0];
        //    HtmlElement styleEl = this.Document.CreateElement("style");
        //    IHTMLStyleElement element = (IHTMLStyleElement)styleEl.DomElement;
        //    IHTMLStyleSheetElement styleSheet = element.styleSheet;
        //    styleSheet.cssText = @"h1 { color: red }";
        //    head.AppendChild(styleEl);
        //}


        //private void AddStyles2()
        //{
        //    IHTMLDocument2 doc = (this.Document.DomDocument) as IHTMLDocument2;
        //    // The first parameter is the url, the second is the index of the added style sheet.
        //    IHTMLStyleSheet ss = doc.createStyleSheet("", 0);

        //    // Now that you have the style sheet you have a few options:
        //    // 1. You can just set the content as text.
        //    ss.cssText = @"h1 { color: blue; }";
        //    // 2. You can add/remove style rules.
        //    int index = ss.addRule("h1", "color: red;");
        //    ss.removeRule(index);
        //    // You can even walk over the rules using "ss.rules" and modify them.
        //}

        //void AssignTranslate(string text)
        //{
        //    if (this.Document == null || this.Document.Body == null)
        //        this.DocumentText = text;
        //    else this.Document.Body.InnerHtml = text;
        //}


        // http://stackoverflow.com/questions/2562297/c-sharp-webbrowser-control-not-applying-css
        //private void AddStyles()
        //{
        //    try
        //    {
        //        if (this.Document != null)
        //        {
        //            IHTMLDocument2 currentDocument = (IHTMLDocument2)this.Document.DomDocument;

        //            int length = currentDocument.styleSheets.length;
        //            IHTMLStyleSheet styleSheet = currentDocument.createStyleSheet(@"", length + 1);
        //            //length = currentDocument.styleSheets.length;
        //            //styleSheet.addRule("body", "background-color:blue");
        //            TextReader reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "basic.css"));
        //            string style = reader.ReadToEnd();
        //            styleSheet.cssText = style;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
