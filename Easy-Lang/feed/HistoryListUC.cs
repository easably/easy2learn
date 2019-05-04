using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using CefSharp.WinForms;

namespace f
{
    public partial class HistoryListUC : UserControl
    {
        CefSharp.WinForms.WebView webView;

        public HistoryListUC()
        {
            InitializeComponent();
            webView = CreateWebView();
        }

        #region CreateWebView + HtmlController
        private CefSharp.WinForms.WebView CreateWebView()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                JSInjection.СhromeView viewCn = new JSInjection.СhromeView() { ManifestPrefix = "f", Dock = DockStyle.Fill };
                this.Controls.Add(viewCn);
                viewCn.WView.RegisterJsObject("cntrl", new HtmlController(this));
                viewCn.CSSFiles.Add(@"css.selector-list.css");
                viewCn.JSFiles.Add(@"js.selector-list.js");
                viewCn.URL = "history_list_uc.html";
                viewCn.WView.LoadCompleted += viewCn_LoadCompletedFinished;
                //old code
                //viewCn.ManifestURL = "history_list_uc.html";
                //viewCn.LoadCompletedFinished += viewCn_LoadCompletedFinished;
                return viewCn.WView;
            }
            return null;
        }

        public class HtmlController
        {
            Control Host;
            public HtmlController(Control host)
            {
                Host = host;
            }

            public void OpenVideoUnit(String folder)
            {
                Host.Invoke((Action)(() =>
                {
                    try
                    {
                        VideoUnit vu = VideoUnit.GetUnit(folder.Replace(@"/", @"\")); // for exammple System.IO.DirectoryNotFoundException когда удалили директорию
                        FileSelector.VideoUnit = vu;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }));
            }

            public void OpenLessonUnit(String folder)
            {
           //     Host.Invoke((Action)(() =>
           //     {
                    try
                    {
                        VideoUnit vu = VideoUnit.GetUnit(folder.Replace(@"/", @"\")); // for exammple System.IO.DirectoryNotFoundException когда удалили директорию
                        if (!string.IsNullOrEmpty(vu.lesson)) {
                            SentenceListWithVideo.RunLessson(vu.path + vu.lesson);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Application.ProductName, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
            //    }));
            }
        }
        #endregion

        void viewCn_LoadCompletedFinished(object sender, EventArgs e)
        {            
            this.RefreshList(true);
        }

        public void RefreshList(bool doClear)
        {
            string arg = VideoUnit.GetUnitsJSON(VideoUnit.GetUnits());
            string command = string.Format("{0}('{1}')", (doClear ? "fillWithClear" : "fill"), arg);
            this.webView.ExecuteScript(command);
        }
    }
}
