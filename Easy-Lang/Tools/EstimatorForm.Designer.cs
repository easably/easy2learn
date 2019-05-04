namespace f
{
    partial class E
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Popular 1000");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Second popular 1000");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ability");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Longman Dictionary Minimum 2130", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("All words: 4601 (Words using: 39883)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("All words: 4601 (Words using: 39883)");
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miFindCitations = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tvDictionaries = new System.Windows.Forms.TreeView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.tvWords = new System.Windows.Forms.TreeView();
            this.paSearch = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.paRight = new System.Windows.Forms.Panel();
            this.panelCommon = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.paSearch.SuspendLayout();
            this.paRight.SuspendLayout();
            this.panelCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFindCitations,
            this.miCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 48);
            // 
            // miFindCitations
            // 
            this.miFindCitations.Image = global::f.button_images.find_citations;
            this.miFindCitations.Name = "miFindCitations";
            this.miFindCitations.Size = new System.Drawing.Size(196, 22);
            this.miFindCitations.Text = "&Find Citations for Word";
            // 
            // miCopy
            // 
            this.miCopy.Image = ((System.Drawing.Image)(resources.GetObject("miCopy.Image")));
            this.miCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCopy.Name = "miCopy";
            this.miCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miCopy.Size = new System.Drawing.Size(196, 22);
            this.miCopy.Text = "&Copy";
            // 
            // tvDictionaries
            // 
            this.tvDictionaries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDictionaries.ContextMenuStrip = this.contextMenuStrip1;
            this.tvDictionaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDictionaries.HideSelection = false;
            this.tvDictionaries.Location = new System.Drawing.Point(0, 6);
            this.tvDictionaries.Name = "tvDictionaries";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Popular 1000";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Second popular 1000";
            treeNode3.Name = "Node4";
            treeNode3.Text = "ability";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Longman Dictionary Minimum 2130";
            treeNode5.Name = "Node0";
            treeNode5.Text = "All words: 4601 (Words using: 39883)";
            this.tvDictionaries.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode4,
            treeNode5});
            this.tvDictionaries.Size = new System.Drawing.Size(356, 645);
            this.tvDictionaries.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.tvWords);
            this.panelLeft.Controls.Add(this.paSearch);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(5, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.panelLeft.Size = new System.Drawing.Size(308, 657);
            this.panelLeft.TabIndex = 3;
            // 
            // tvWords
            // 
            this.tvWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvWords.ContextMenuStrip = this.contextMenuStrip1;
            this.tvWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvWords.HideSelection = false;
            this.tvWords.Location = new System.Drawing.Point(6, 39);
            this.tvWords.Name = "tvWords";
            treeNode6.Name = "Node0";
            treeNode6.Text = "All words: 4601 (Words using: 39883)";
            this.tvWords.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tvWords.Size = new System.Drawing.Size(302, 612);
            this.tvWords.TabIndex = 1;
            // 
            // paSearch
            // 
            this.paSearch.Controls.Add(this.textBox1);
            this.paSearch.Controls.Add(this.label1);
            this.paSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.paSearch.Location = new System.Drawing.Point(6, 6);
            this.paSearch.Name = "paSearch";
            this.paSearch.Padding = new System.Windows.Forms.Padding(6);
            this.paSearch.Size = new System.Drawing.Size(302, 33);
            this.paSearch.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(50, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Location = new System.Drawing.Point(313, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(16, 657);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // paRight
            // 
            this.paRight.BackColor = System.Drawing.Color.White;
            this.paRight.Controls.Add(this.tvDictionaries);
            this.paRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paRight.Location = new System.Drawing.Point(329, 5);
            this.paRight.Name = "paRight";
            this.paRight.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.paRight.Size = new System.Drawing.Size(362, 657);
            this.paRight.TabIndex = 5;
            // 
            // panelCommon
            // 
            this.panelCommon.BackColor = System.Drawing.Color.Gray;
            this.panelCommon.Controls.Add(this.paRight);
            this.panelCommon.Controls.Add(this.btClose);
            this.panelCommon.Controls.Add(this.splitter1);
            this.panelCommon.Controls.Add(this.panelLeft);
            this.panelCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommon.Location = new System.Drawing.Point(3, 3);
            this.panelCommon.Name = "panelCommon";
            this.panelCommon.Padding = new System.Windows.Forms.Padding(5);
            this.panelCommon.Size = new System.Drawing.Size(696, 667);
            this.panelCommon.TabIndex = 4;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(282, 232);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Visible = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(702, 673);
            this.Controls.Add(this.panelCommon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "E";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimator";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.paSearch.ResumeLayout(false);
            this.paSearch.PerformLayout();
            this.paRight.ResumeLayout(false);
            this.panelCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TreeView tvDictionaries;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView tvWords;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel paRight;
        private System.Windows.Forms.Panel paSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCommon;
        private System.Windows.Forms.ToolStripMenuItem miFindCitations;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.Button btClose;
    }
}