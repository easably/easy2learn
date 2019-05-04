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
    public partial class YouTubeBrowser : UserControl
    {
        public YouTubeBrowser()
        {
            InitializeComponent();
        }

        public static bool IsValidForDownloading(string url)
        {
            // div id="watch7-secondary-actions" -->> <span class="yt-uix-clickcard"> -->> next или четвертый span

            // example of url @"https://www.youtube.com/watch?v=o-zM8IQHVzI"
            //                  https://www.youtube.com/api/timedtext?v=o-zM8IQHVzI&key=yttt1&sparams=caps%2Cv%2Cexpire&caps&signature=A1F7312D58692D77823D1A07C513032812FF7304.C7A7B3FDC5EDE2FDE2B3992CBEB547AE56179279&hl=ru-RU&expire=1396617225&type=track&lang=en&name&kind&fmt=1
            string[] parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length >= 3 &&
                parts[1].ToLower().Contains("youtube.com") &&
                parts[1].ToLower().StartsWith("watch?");
        }
    }
}
