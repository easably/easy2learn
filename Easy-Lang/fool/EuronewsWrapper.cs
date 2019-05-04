using System;
using System.Windows.Forms;
using System.Security.Permissions;

namespace f
{

    //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    //[System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class EuronewsWrapper : Form
    {
        private WebParser webParser = new WebParser();
        private Button button1 = new Button();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
          //   Application.Run(new Form1());
             Application.Run(new EuronewsWrapper());
        }

        public EuronewsWrapper()
        {
            button1.Text = "call script code from client code";
            button1.Dock = DockStyle.Top;
            button1.Click += new EventHandler(button1_Click);
            webParser.webBrowser1.Dock = DockStyle.Fill;
            Controls.Add(webParser.webBrowser1);
            Controls.Add(button1);
            Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string html = FileManager.GetStringFrоmFile(@"E:\FM\ForceMem\Test2\html\subtitle_for_ted_without_script.html");
            webParser.LoadAndParse(html, SubtitleCreator.JsSelector);
            webParser.webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MessageBox.Show(webParser.Result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
    //        webParser.webBrowser1.Document.InvokeScript("transfer", new String[] { "rrrrr" });
            //webParser.webBrowser1.Document.InvokeScript("parse");
            //webParser.webBrowser1.Document.InvokeScript("transfer");
            MessageBox.Show(webParser.Result);
            Application.Exit();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(728, 447);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

    }
}