namespace f
{
    partial class Y
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Y));
            this.menuForTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilState = new System.Windows.Forms.ImageList(this.components);
            this.panelCollector = new System.Windows.Forms.Panel();
            this.paWrapperTextWord = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.paListWords = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pnInWrapperDict = new System.Windows.Forms.Panel();
            this.menuForTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAutohistoryforcards = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panelForSelectedCard = new System.Windows.Forms.Panel();
            this.txSelectedCard = new System.Windows.Forms.TextBox();
            this.pnOutWrapperDict = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tv1 = new WordsTreeView();
            this.txWord = new EnterLine();
            this.listItemGroups = new ForceListBox();
            this.listWords = new ForceListBox();
            this.menuForTextBox.SuspendLayout();
            this.panelCollector.SuspendLayout();
            this.paWrapperTextWord.SuspendLayout();
            this.paListWords.SuspendLayout();
            this.pnInWrapperDict.SuspendLayout();
            this.menuForTree.SuspendLayout();
            this.panelForSelectedCard.SuspendLayout();
            this.pnOutWrapperDict.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuForTextBox
            // 
            this.menuForTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuForTextBox.Name = "tvMenu";
            this.menuForTextBox.Size = new System.Drawing.Size(151, 92);
            this.menuForTextBox.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuForTextBox_Opening);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // ilState
            // 
            this.ilState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilState.ImageStream")));
            this.ilState.TransparentColor = System.Drawing.Color.Transparent;
            this.ilState.Images.SetKeyName(0, "CheckBoxEmpty.bmp");
            this.ilState.Images.SetKeyName(1, "CheckBox.bmp");
            // 
            // panelCollector
            // 
            this.panelCollector.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelCollector.Controls.Add(this.paWrapperTextWord);
            this.panelCollector.Controls.Add(this.splitter1);
            this.panelCollector.Controls.Add(this.paListWords);
            this.panelCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCollector.Location = new System.Drawing.Point(0, 0);
            this.panelCollector.Name = "panelCollector";
            this.panelCollector.Padding = new System.Windows.Forms.Padding(4, 4, 4, 1);
            this.panelCollector.Size = new System.Drawing.Size(595, 91);
            this.panelCollector.TabIndex = 0;
            this.panelCollector.Resize += new System.EventHandler(this.panelCollector_Resize);
            // 
            // paWrapperTextWord
            // 
            this.paWrapperTextWord.BackColor = System.Drawing.SystemColors.Window;
            this.paWrapperTextWord.Controls.Add(this.txWord);
            this.paWrapperTextWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paWrapperTextWord.Location = new System.Drawing.Point(321, 4);
            this.paWrapperTextWord.Name = "paWrapperTextWord";
            this.paWrapperTextWord.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.paWrapperTextWord.Size = new System.Drawing.Size(270, 86);
            this.paWrapperTextWord.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Location = new System.Drawing.Point(310, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(11, 86);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            this.splitter1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter1_Paint);
            // 
            // paListWords
            // 
            this.paListWords.BackColor = System.Drawing.SystemColors.Window;
            this.paListWords.Controls.Add(this.listItemGroups);
            this.paListWords.Controls.Add(this.splitter4);
            this.paListWords.Controls.Add(this.listWords);
            this.paListWords.Dock = System.Windows.Forms.DockStyle.Left;
            this.paListWords.Location = new System.Drawing.Point(4, 4);
            this.paListWords.Name = "paListWords";
            this.paListWords.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.paListWords.Size = new System.Drawing.Size(306, 86);
            this.paListWords.TabIndex = 0;
            this.paListWords.Resize += new System.EventHandler(this.paListWords_Resize);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter4.Location = new System.Drawing.Point(141, 5);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(7, 76);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // pnInWrapperDict
            // 
            this.pnInWrapperDict.BackColor = System.Drawing.SystemColors.Window;
            this.pnInWrapperDict.Controls.Add(this.tv1);
            this.pnInWrapperDict.Controls.Add(this.splitter3);
            this.pnInWrapperDict.Controls.Add(this.panelForSelectedCard);
            this.pnInWrapperDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInWrapperDict.Location = new System.Drawing.Point(4, 0);
            this.pnInWrapperDict.Name = "pnInWrapperDict";
            this.pnInWrapperDict.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pnInWrapperDict.Size = new System.Drawing.Size(587, 502);
            this.pnInWrapperDict.TabIndex = 0;
            this.pnInWrapperDict.Resize += new System.EventHandler(this.pnInWrapperDict_Resize);
            // 
            // menuForTree
            // 
            this.menuForTree.BackColor = System.Drawing.Color.White;
            this.menuForTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAutohistoryforcards});
            this.menuForTree.Name = "contextMenuStrip1";
            this.menuForTree.Size = new System.Drawing.Size(191, 26);
            // 
            // miAutohistoryforcards
            // 
            this.miAutohistoryforcards.Checked = true;
            this.miAutohistoryforcards.CheckOnClick = true;
            this.miAutohistoryforcards.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miAutohistoryforcards.Image = global::f.Properties.Resources.CheckBox;
            this.miAutohistoryforcards.Name = "miAutohistoryforcards";
            this.miAutohistoryforcards.Size = new System.Drawing.Size(190, 22);
            this.miAutohistoryforcards.Text = "Auto history for cards";
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.Window;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(4, 69);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(579, 10);
            this.splitter3.TabIndex = 17;
            this.splitter3.TabStop = false;
            this.splitter3.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter3_Paint);
            // 
            // panelForSelectedCard
            // 
            this.panelForSelectedCard.Controls.Add(this.txSelectedCard);
            this.panelForSelectedCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForSelectedCard.Location = new System.Drawing.Point(4, 0);
            this.panelForSelectedCard.Name = "panelForSelectedCard";
            this.panelForSelectedCard.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panelForSelectedCard.Size = new System.Drawing.Size(579, 69);
            this.panelForSelectedCard.TabIndex = 19;
            // 
            // txSelectedCard
            // 
            this.txSelectedCard.BackColor = System.Drawing.Color.White;
            this.txSelectedCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txSelectedCard.ContextMenuStrip = this.menuForTextBox;
            this.txSelectedCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSelectedCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txSelectedCard.Location = new System.Drawing.Point(5, 0);
            this.txSelectedCard.Multiline = true;
            this.txSelectedCard.Name = "txSelectedCard";
            this.txSelectedCard.ReadOnly = true;
            this.txSelectedCard.Size = new System.Drawing.Size(569, 69);
            this.txSelectedCard.TabIndex = 19;
            this.txSelectedCard.Text = "  the act of testing something  \r\n\r\n  \" in the experimental trials the amount of " +
                "carbon was measured separately \"  \r\n  \" he called each flip of the coin a new tr" +
                "ial \"  ";
            this.txSelectedCard.TextChanged += new System.EventHandler(this.txSelectedCard_TextChanged);
            this.txSelectedCard.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txSelectedCard_MouseDoubleClick);
            // 
            // pnOutWrapperDict
            // 
            this.pnOutWrapperDict.AutoScroll = true;
            this.pnOutWrapperDict.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnOutWrapperDict.Controls.Add(this.pnInWrapperDict);
            this.pnOutWrapperDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnOutWrapperDict.Location = new System.Drawing.Point(0, 99);
            this.pnOutWrapperDict.Name = "pnOutWrapperDict";
            this.pnOutWrapperDict.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pnOutWrapperDict.Size = new System.Drawing.Size(595, 506);
            this.pnOutWrapperDict.TabIndex = 1;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Window;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 91);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(595, 8);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            this.splitter2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter2_Paint);
            // 
            // tv1
            // 
            this.tv1.AllowDrop = true;
            this.tv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv1.CheckBoxes = true;
            this.tv1.ContextMenuStrip = this.menuForTree;
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tv1.HideSelection = false;
            this.tv1.Location = new System.Drawing.Point(4, 79);
            this.tv1.Name = "tv1";
            this.tv1.ShowNodeToolTips = true;
            this.tv1.Size = new System.Drawing.Size(579, 419);
            this.tv1.StateImageList = this.ilState;
            this.tv1.TabIndex = 0;
            // 
            // txWord
            // 
            this.txWord.AllowDrop = true;
            this.txWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txWord.ContextMenuStrip = this.menuForTextBox;
            this.txWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txWord.Location = new System.Drawing.Point(0, 5);
            this.txWord.Multiline = true;
            this.txWord.Name = "txWord";
            this.txWord.Size = new System.Drawing.Size(265, 76);
            this.txWord.TabIndex = 0;
            this.txWord.Text = "merely 33333333333333333333333333333333333333332\r\nsimply\r\njust";
            this.txWord.TextChanged += new System.EventHandler(this.txWord_TextChanged);
            this.txWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txWord_KeyDown);
            // 
            // listItemGroups
            // 
            this.listItemGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listItemGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listItemGroups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listItemGroups.Location = new System.Drawing.Point(5, 5);
            this.listItemGroups.MarkedItemIndex = -1;
            this.listItemGroups.MarkedText = null;
            this.listItemGroups.Name = "listItemGroups";
            this.listItemGroups.ShowToolTip = true;
            this.listItemGroups.Size = new System.Drawing.Size(136, 76);
            this.listItemGroups.TabIndex = 0;
            this.listItemGroups.SelectedIndexChanged += new System.EventHandler(this.listItemGroups_SelectedIndexChanged);
            // 
            // listWords
            // 
            this.listWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listWords.Dock = System.Windows.Forms.DockStyle.Right;
            this.listWords.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listWords.Location = new System.Drawing.Point(148, 5);
            this.listWords.MarkedItemIndex = -1;
            this.listWords.MarkedText = null;
            this.listWords.Name = "listWords";
            this.listWords.ShowToolTip = true;
            this.listWords.Size = new System.Drawing.Size(158, 76);
            this.listWords.TabIndex = 0;
            this.listWords.Enter += new System.EventHandler(this.listWords_Enter);
            this.listWords.DoubleClick += new System.EventHandler(this.listWords_DoubleClick);
            this.listWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listWords_KeyDown);
            // 
            // Y
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnOutWrapperDict);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panelCollector);
            this.Name = "Y";
            this.Size = new System.Drawing.Size(595, 605);
            this.Load += new System.EventHandler(this.Y_Load);
            this.Resize += new System.EventHandler(this.Y_Resize);
            this.menuForTextBox.ResumeLayout(false);
            this.panelCollector.ResumeLayout(false);
            this.paWrapperTextWord.ResumeLayout(false);
            this.paWrapperTextWord.PerformLayout();
            this.paListWords.ResumeLayout(false);
            this.pnInWrapperDict.ResumeLayout(false);
            this.menuForTree.ResumeLayout(false);
            this.panelForSelectedCard.ResumeLayout(false);
            this.panelForSelectedCard.PerformLayout();
            this.pnOutWrapperDict.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal WordsTreeView tv1;
        private System.Windows.Forms.ContextMenuStrip menuForTextBox;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ImageList ilState;
        private System.Windows.Forms.Panel panelCollector;
        internal EnterLine txWord;
        private System.Windows.Forms.Panel paWrapperTextWord;
        private System.Windows.Forms.Panel pnInWrapperDict;
        private System.Windows.Forms.Panel pnOutWrapperDict;
        private ForceListBox listWords;
        private System.Windows.Forms.Panel paListWords;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private ForceListBox listItemGroups;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panelForSelectedCard;
        private System.Windows.Forms.TextBox txSelectedCard;
        private System.Windows.Forms.ContextMenuStrip menuForTree;
        private System.Windows.Forms.ToolStripMenuItem miAutohistoryforcards;
    }
}