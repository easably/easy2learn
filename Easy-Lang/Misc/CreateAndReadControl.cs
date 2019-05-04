using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace f.Misc
{
    public partial class CreateAndReadControl : UserControl
    {
        public CreateAndReadControl()
        {
            InitializeComponent();
            btPasteTextForReading.Click += new EventHandler(btPasteTextForReading_Click);
            btRunText.Click += new EventHandler(btRunText_Click);
            textBox.TextChanged += new EventHandler(tbForReading_TextChanged);
            AdjustForm();
        }

        void tbForReading_TextChanged(object sender, EventArgs e)
        {
            btRunText.Enabled = !string.IsNullOrEmpty(btRunText.Text);
        }

        void btRunText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btRunText.Text))
            {
                MessageBox.Show(this, "Firstly paste a text", Application.ProductName, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string fileName = CF.GetFolderForUserFiles() + @"\Texts\";
            if (!Directory.Exists(fileName)) 
                Directory.CreateDirectory(fileName);
            fileName += DateTime.Today.ToString("yy_MM_dd");
            string textForName = textBox.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)[0];
            if (textForName.Length > 0)
            {
                if( textForName.Trim(' ').Length < 150)
                    textForName = " " + textForName;
                else if (!string.IsNullOrEmpty(textForName))
                    textForName = "_" + textForName.Substring(0, 150);
            }
            textForName = textForName.Replace(':', ' ').Replace('?', ' ').Replace('<', ' ').Replace('>', ' ').Replace('|', ' ').Replace('"', ' ').Replace('/', ' ').Replace('\\', ' ');
            try
            {
                m_CurrentTextFileName = fileName + textForName + ".txt";
                FileManager.CreateFile(m_CurrentTextFileName, textBox.Text);
            }
            catch(Exception ex)
            {
                m_CurrentTextFileName = "";
                MessageBox.Show(this, ex.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        string m_CurrentTextFileName = "";
        public string CurrentTextFileName
        {
            get { return m_CurrentTextFileName; }
        }
        
        private void AdjustForm()
        {
            if (!Windows7.Windows7Taskbar.Windows7OrGreater)
            {
                this.btPasteTextForReading.FlatStyle =
                this.btRunText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            }
            if (Utils.GetLocaleForUI().Equals("ru"))
            {
                this.btPasteTextForReading.Text = FileSelector.ruEmptyIndent + "Вставить текст";
                this.btRunText.Text = FileSelector.ruEmptyIndent + "Читать текст";
                this.toolTip1.SetToolTip(this.btRunText, "Запустить программу для чтения");
            }
            else
            {
                this.btPasteTextForReading.Text = FileSelector.enEmptyIndent + "Paste Text";
                this.btRunText.Text = FileSelector.enEmptyIndent + "Read Text";
                this.toolTip1.SetToolTip(this.btRunText, "Read text by sentences");
            }
        }

        void btPasteTextForReading_Click(object sender, EventArgs e)
        {
            this.textBox.Text = Clipboard.GetText();
            this.textBox.SelectAll();
            this.textBox.Select();
        }
    }
}
