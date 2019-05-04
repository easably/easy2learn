using System;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public partial class WordHistory : Form
    {
        public WordHistory()
        {
            InitializeComponent();
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWords_NodeMouseClick);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillByWords(string curenLangPair)
        {
            string folder = CF.GetFolderForUserFiles() + "history\\";
            if (!Directory.Exists(folder))
            {
                MessageBox.Show(this, string.Format("History was not created. Directory '{0}' not founded", folder), this.Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;                
            }
            foreach (string dir in Directory.GetDirectories(folder))
            {
                //  Directory.
                string langPair = FileManager.GetLastDirName(dir);
                TreeNode tnLang = tv.Nodes.Add(langPair);
                if (!string.IsNullOrEmpty(curenLangPair) && curenLangPair.Equals(langPair))
                {
                    tv.SelectedNode = tnLang;
                    tnLang.Expand();
                }
                tnLang.Tag = dir;
                foreach (string dirLetter in Directory.GetDirectories(dir))
                {
                    TreeNode tnLetter = tnLang.Nodes.Add(FileManager.GetLastDirName(dirLetter));
                   
                    tnLetter.Tag = dirLetter;
                    foreach (string word in Directory.GetFiles(dirLetter))
                    {
                        TreeNode tnWord = tnLetter.Nodes.Add(FileManager.GetFileName(word));
                        tnWord.Tag = word;
                    }
                }
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            miOpenWord.Visible = //tv.SelectedNode != null && !string.IsNullOrEmpty(tv.SelectedNode.Tag as string);
            miCopy.Visible = tv.SelectedNode != null && tv.SelectedNode.Level == 2;
            miOpenParentFolder.Visible = tv.SelectedNode != null && tv.SelectedNode.Level < 2;
        }

        #region OpenSelected Node
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenSelectedNode();
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            if(tv.SelectedNode != null && tv.SelectedNode.Level == 2)
                OpenSelectedNode();
        }

        void OpenSelectedNode()
        {
            if (!string.IsNullOrEmpty(tv.SelectedNode.Tag as string))
                Runner.OpenURL((string)tv.SelectedNode.Tag);
        }

        private void miOpenParentFolder_Click(object sender, EventArgs e)
        {
            OpenSelectedNode();
        }
        #endregion

        private void miCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tv.SelectedNode.Text);
        }

        private void tvWords_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if( e.Button == MouseButtons.Right )
                e.Node.TreeView.SelectedNode = e.Node;
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 && !e.Node.IsExpanded)
                e.Node.Expand();
        }
    }
}
