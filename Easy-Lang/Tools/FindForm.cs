using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        public void InitAndSearch(string allText, string word)
        {
            txWord.Text = word;
            m_AllText = allText;
            textBox1_TextChanged(null, null);
            this.FindWord();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string m_AllText;
        public string AllText { get { return m_AllText; } }
        public string Word { get { return this.txWord.Text; } }

        void FindWord()
        {
            //try
            //{
            //    this.txNote.BeginUpdate();
            txNote.Select(0, 0); // если не сделать так то будет влиять на выделение слов в startedPoints, выделяемое будет смещатся на -1
            this.txNote.Clear();
            if (string.IsNullOrEmpty(this.Word)) return;
            if (string.IsNullOrEmpty(AllText)) return;
            this.Text = string.Format("Citations for '{0}'", this.Word);
            string word = this.Word.ToLower();
            string lowerText = AllText.ToLower();

            DateTime timeMarker = DateTime.Now;
            int start = 0;
            int lenght = 170;
            List<int> startedPoints = new List<int>();
            //                StringBuilder sb = new StringBuilder();
            while (start < AllText.Length && lowerText.IndexOf(word, start) != -1)
            {
                if (D.IsLetter(AllText[lowerText.IndexOf(word, start) - 1])) // т.е. предыдущий символ начало слова
                {
                    start = AllText.IndexOf(word, start) + word.Length;
                    continue; // т.е. избежим выделения таких слов как This для his, будут выделятся только совпадающее начало
                }
                int marker = lowerText.IndexOf(word, start);
                if (marker < lenght / 2)
                    marker = 0;
                else marker -= lenght / 2;
                string elementName = AllText.Substring(marker, marker + lenght < AllText.Length ? lenght : lowerText.Length - marker);
                elementName = elementName.Replace('\r', ' ').Replace('\n', ' ');
                while (elementName.IndexOf("  ") != -1)
                    elementName = elementName.Replace("  ", " ");
                int i = elementName.IndexOf(' ');
                int length = elementName.LastIndexOf(' ');
                string line = "..." + elementName.Substring(i, length - i) + "...\r\n"; // this.tx1.Text.Substring(i, length) + "\r\n";
                // для выделения слова
                //TODO: а если  .... his ... This .... тогда выделится This 
                startedPoints.Add(txNote.Text.Length + line.ToLower().IndexOf(word.ToLower())); // - startedPoints.Count); чтоб так не делать сделаем вначале txNote.Select(0, 0)
                txNote.Text += line;
                start = marker + lenght; //TODO: не учитываются отрезанные конец и начало
            }
            // подсветим слова
            foreach (int startWord in startedPoints)
            {
                if (startWord == -1) continue;
                txNote.Select(startWord, this.Word.Length);
                txNote.SelectionBackColor = Color.Gainsboro;
            }
            txNote.Select(0, 0); // possible textBox.SelectionStart = 0;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            FindWord();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btFind.Enabled = txWord.Text.Length > 0 && !string.IsNullOrEmpty(AllText);
        }

        private void txWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && btFind.Enabled)
                FindWord();
        }
    }
}
