using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace f.feed.TED
{
    public partial class UCTedTopics : UserControl
    {
        public UCTedTopics()
        {
            InitializeComponent();
        }

        int currInd = 0;

        public string loadMoreContent() 
        {

            ++currInd;
            return ""; 
        }

        public void LoadPage(string topic)
        {
            this.webBrowser1.Navigate(@"http://www.ted.com/topics/" + topic);
        }
    }
}
