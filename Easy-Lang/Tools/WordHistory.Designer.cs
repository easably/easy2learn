namespace f
{
    partial class WordHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordHistory));
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tv = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miOpenParentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenWord = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(224, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 47);
            this.panel1.TabIndex = 3;
            // 
            // tv
            // 
            this.tv.ContextMenuStrip = this.contextMenu;
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(7, 7);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(312, 513);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenParentFolder,
            this.miCopy,
            this.miOpenWord});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(191, 92);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // miOpenParentFolder
            // 
            this.miOpenParentFolder.Image = ((System.Drawing.Image)(resources.GetObject("miOpenParentFolder.Image")));
            this.miOpenParentFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miOpenParentFolder.Name = "miOpenParentFolder";
            this.miOpenParentFolder.ShortcutKeyDisplayString = "";
            this.miOpenParentFolder.Size = new System.Drawing.Size(190, 22);
            this.miOpenParentFolder.Text = "&Open in Parent Folder";
            this.miOpenParentFolder.Click += new System.EventHandler(this.miOpenParentFolder_Click);
            // 
            // miCopy
            // 
            this.miCopy.Image = ((System.Drawing.Image)(resources.GetObject("miCopy.Image")));
            this.miCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCopy.Name = "miCopy";
            this.miCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miCopy.Size = new System.Drawing.Size(190, 22);
            this.miCopy.Text = "&Copy";
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            // 
            // miOpenWord
            // 
            this.miOpenWord.Image = ((System.Drawing.Image)(resources.GetObject("miOpenWord.Image")));
            this.miOpenWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miOpenWord.Name = "miOpenWord";
            this.miOpenWord.ShortcutKeyDisplayString = "DoubleClick";
            this.miOpenWord.Size = new System.Drawing.Size(190, 22);
            this.miOpenWord.Text = "&Open";
            this.miOpenWord.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // WordHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(326, 574);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 612);
            this.Name = "WordHistory";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "History of words";
            this.panel1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem miOpenWord;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        public System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ToolStripMenuItem miOpenParentFolder;
    }
}