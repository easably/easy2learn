namespace f.key
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btPrev = new System.Windows.Forms.ToolStripButton();
            this.btRepeat = new System.Windows.Forms.ToolStripSplitButton();
            this.miRepOnce = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepTwice = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepThrice = new System.Windows.Forms.ToolStripMenuItem();
            this.btNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miVideoRate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miFromList = new System.Windows.Forms.ToolStripButton();
            this.miFromAndToList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbtOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btDictionaryBlendHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.btSearchSubtitles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFiles,
            this.toolStripSeparator4,
            this.btPrev,
            this.btRepeat,
            this.btNext,
            this.toolStripSeparator3,
            this.miVideoRate,
            this.toolStripSeparator1,
            this.miFromList,
            this.miFromAndToList,
            this.toolStripSeparator2,
            this.ddbtOptions});
            this.tsMenu.Location = new System.Drawing.Point(5, 5);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1003, 25);
            this.tsMenu.TabIndex = 32;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btFiles
            // 
            this.btFiles.Image = global::f.button_images.home;
            this.btFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFiles.Name = "btFiles";
            this.btFiles.Size = new System.Drawing.Size(60, 22);
            this.btFiles.Text = "Home";
            this.btFiles.ToolTipText = "Select other video";
            this.btFiles.Click += new System.EventHandler(this.btFiles_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btPrev
            // 
            this.btPrev.Image = global::f.Buttons.PrevSent;
            this.btPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(23, 22);
            this.btPrev.ToolTipText = "ShortKey - \'P\'";
            // 
            // btRepeat
            // 
            this.btRepeat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRepOnce,
            this.miRepTwice,
            this.miRepThrice});
            this.btRepeat.Image = global::f.button_images.Repeat;
            this.btRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRepeat.Name = "btRepeat";
            this.btRepeat.Size = new System.Drawing.Size(75, 22);
            this.btRepeat.Text = "Repeat";
            this.btRepeat.ToolTipText = "ShortKey - \'R\'";
            // 
            // miRepOnce
            // 
            this.miRepOnce.Name = "miRepOnce";
            this.miRepOnce.Size = new System.Drawing.Size(246, 22);
            this.miRepOnce.Text = "Repeate Once With Speed - 0.8";
            // 
            // miRepTwice
            // 
            this.miRepTwice.Name = "miRepTwice";
            this.miRepTwice.Size = new System.Drawing.Size(246, 22);
            this.miRepTwice.Text = "Repeate Twice  - 0.8 > 0.9";
            // 
            // miRepThrice
            // 
            this.miRepThrice.Name = "miRepThrice";
            this.miRepThrice.Size = new System.Drawing.Size(246, 22);
            this.miRepThrice.Text = "Repeated Thrice -  0.7 > 0.8 > 0.9";
            // 
            // btNext
            // 
            this.btNext.Image = global::f.Buttons.NextSent;
            this.btNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(51, 22);
            this.btNext.Text = "Next";
            this.btNext.ToolTipText = "ShortKey - \'N\'";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // miVideoRate
            // 
            this.miVideoRate.Image = global::f.button_images.turtle_side_view;
            this.miVideoRate.Name = "miVideoRate";
            this.miVideoRate.Size = new System.Drawing.Size(117, 25);
            this.miVideoRate.Text = "Playback Speed";
            this.miVideoRate.ToolTipText = "Change playback speed";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // miFromList
            // 
            this.miFromList.Checked = true;
            this.miFromList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miFromList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miFromList.Image = ((System.Drawing.Image)(resources.GetObject("miFromList.Image")));
            this.miFromList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFromList.Name = "miFromList";
            this.miFromList.Size = new System.Drawing.Size(24, 22);
            this.miFromList.Text = "en";
            this.miFromList.Click += new System.EventHandler(this.miFromList_Click);
            // 
            // miFromAndToList
            // 
            this.miFromAndToList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miFromAndToList.Image = ((System.Drawing.Image)(resources.GetObject("miFromAndToList.Image")));
            this.miFromAndToList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFromAndToList.Name = "miFromAndToList";
            this.miFromAndToList.Size = new System.Drawing.Size(43, 22);
            this.miFromAndToList.Text = "en+ru";
            this.miFromAndToList.Click += new System.EventHandler(this.miFromList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ddbtOptions
            // 
            this.ddbtOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btDictionaryBlendHistory,
            this.btSearchSubtitles,
            this.toolStripMenuItem2,
            this.miAbout,
            this.miHelpRequests,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.ddbtOptions.Image = global::f.button_images.Options;
            this.ddbtOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtOptions.Name = "ddbtOptions";
            this.ddbtOptions.Size = new System.Drawing.Size(29, 22);
            this.ddbtOptions.Text = "Options, Feedback, DictionaryBlend, Resources, About ....";
            this.ddbtOptions.ToolTipText = "Options";
            // 
            // btDictionaryBlendHistory
            // 
            this.btDictionaryBlendHistory.Name = "btDictionaryBlendHistory";
            this.btDictionaryBlendHistory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.btDictionaryBlendHistory.Size = new System.Drawing.Size(256, 22);
            this.btDictionaryBlendHistory.Text = "&History of DictionaryBlend";
            this.btDictionaryBlendHistory.ToolTipText = "Show history of DictionaryBlend";
            this.btDictionaryBlendHistory.Visible = false;
            // 
            // btSearchSubtitles
            // 
            this.btSearchSubtitles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSearchSubtitles.Name = "btSearchSubtitles";
            this.btSearchSubtitles.Size = new System.Drawing.Size(256, 22);
            this.btSearchSubtitles.Text = "Web Search for Subtitles";
            this.btSearchSubtitles.ToolTipText = "Search in internet";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(253, 6);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(256, 22);
            this.miAbout.Text = "&About";
            // 
            // miHelpRequests
            // 
            this.miHelpRequests.Image = global::f.Properties.Resources.email;
            this.miHelpRequests.Name = "miHelpRequests";
            this.miHelpRequests.Size = new System.Drawing.Size(256, 22);
            this.miHelpRequests.Text = "Help Requests";
            this.miHelpRequests.ToolTipText = "For example: How add a new dictionary www.somewebsite.com";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(253, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tsMenu);
            this.Name = "MainMenu";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1013, 36);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripSplitButton btRepeat;
        private System.Windows.Forms.ToolStripMenuItem miRepOnce;
        private System.Windows.Forms.ToolStripMenuItem miRepTwice;
        private System.Windows.Forms.ToolStripMenuItem miRepThrice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btPrev;
        private System.Windows.Forms.ToolStripButton btNext;
        private System.Windows.Forms.ToolStripDropDownButton ddbtOptions;
        private System.Windows.Forms.ToolStripMenuItem btSearchSubtitles;
        private System.Windows.Forms.ToolStripMenuItem btDictionaryBlendHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHelpRequests;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        internal System.Windows.Forms.ToolStripMenuItem miVideoRate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton miFromList;
        private System.Windows.Forms.ToolStripButton miFromAndToList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}
