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
    public partial class AmaraBrowser : UserControl
    {
        public AmaraBrowser()
        {
            InitializeComponent();
        }

        public static bool IsValidForDownloading(string url)
        {
            // example of url @"http://www.amara.org/en/videos/8ooGCZKhHaHQ/info/erb-thomas-edison-vs-nikola-tesla/"
            //                  http://www.amara.org/subtitles/8ooGCZKhHaHQ/en/download/ERB%2520-%2520Thomas%2520Edison%2520vs%2520Nikola%2520Tesla.
            //                  http://www.amara.org/subtitles/8ooGCZKhHaHQ/en/download/erb-thomas-edison-vs-nikola-tesla.en.srt + .en.srt
            string[] parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length >= 3 &&
                parts[1].ToLower().Contains("amara.org") &&
                parts[3].ToLower().StartsWith("videos") &&
                parts[5].ToLower().StartsWith("info");
        }
    }
}
