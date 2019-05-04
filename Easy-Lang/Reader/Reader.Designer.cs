namespace f
{
    partial class ReaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderForm));
            this.startTrainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxWating = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ddbtOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btShowParrallelSubtitles = new System.Windows.Forms.ToolStripMenuItem();
            this.miResources = new System.Windows.Forms.ToolStripMenuItem();
            this.miVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.miTED = new System.Windows.Forms.ToolStripMenuItem();
            this.newsmultiLanguagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miInopressa_ru = new System.Windows.Forms.ToolStripMenuItem();
            this.miTheepochtimes = new System.Windows.Forms.ToolStripMenuItem();
            this.miBBC = new System.Windows.Forms.ToolStripMenuItem();
            this.bookLibrariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gutenbergToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishLibrarynetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manybooksnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bibliomaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPpenLocalLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.btSearchSubtitles = new System.Windows.Forms.ToolStripMenuItem();
            this.btDictionaryBlendHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.reader = new f.FullReader();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTrainerToolStripMenuItem
            // 
            this.startTrainerToolStripMenuItem.Name = "startTrainerToolStripMenuItem";
            this.startTrainerToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.startTrainerToolStripMenuItem.Text = "&Start Trainer";
            this.startTrainerToolStripMenuItem.Visible = false;
            // 
            // pictureBoxWating
            // 
            this.pictureBoxWating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWating.Image = global::f.OtherImages.icon_wait;
            this.pictureBoxWating.Location = new System.Drawing.Point(1312, 5);
            this.pictureBoxWating.Name = "pictureBoxWating";
            this.pictureBoxWating.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxWating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWating.TabIndex = 22;
            this.pictureBoxWating.TabStop = false;
            this.pictureBoxWating.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxWating);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 33, 5);
            this.panel1.Size = new System.Drawing.Size(1342, 36);
            this.panel1.TabIndex = 23;
            this.panel1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbtOptions});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1304, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ddbtOptions
            // 
            this.ddbtOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btShowParrallelSubtitles,
            this.miResources,
            this.btSearchSubtitles,
            this.btDictionaryBlendHistory,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem,
            this.miHelpRequests,
            this.miAbout});
            this.ddbtOptions.Image = global::f.button_images.Options;
            this.ddbtOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtOptions.Name = "ddbtOptions";
            this.ddbtOptions.Size = new System.Drawing.Size(29, 22);
            this.ddbtOptions.Text = "Options, Feedback, DictionaryBlend, Resources, About ....";
            this.ddbtOptions.ToolTipText = "Options";
            // 
            // btShowParrallelSubtitles
            // 
            this.btShowParrallelSubtitles.CheckOnClick = true;
            this.btShowParrallelSubtitles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btShowParrallelSubtitles.Name = "btShowParrallelSubtitles";
            this.btShowParrallelSubtitles.Size = new System.Drawing.Size(256, 22);
            this.btShowParrallelSubtitles.Text = "Show Native Subtitles";
            this.btShowParrallelSubtitles.ToolTipText = "Off/On panel with parallel subtitles on the native language";
            // 
            // miResources
            // 
            this.miResources.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miVideo,
            this.newsmultiLanguagesToolStripMenuItem,
            this.bookLibrariesToolStripMenuItem,
            this.miPpenLocalLibrary});
            this.miResources.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miResources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miResources.Name = "miResources";
            this.miResources.Size = new System.Drawing.Size(256, 22);
            this.miResources.Text = "Multilingual Resources ";
            this.miResources.ToolTipText = "MultiLanguage resources: Subtitles, News, Texts for the parallel read";
            // 
            // miVideo
            // 
            this.miVideo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTED});
            this.miVideo.Name = "miVideo";
            this.miVideo.Size = new System.Drawing.Size(148, 22);
            this.miVideo.Text = "Video";
            // 
            // miTED
            // 
            this.miTED.Name = "miTED";
            this.miTED.Size = new System.Drawing.Size(252, 22);
            this.miTED.Text = "The TED Open Translation Project";
            // 
            // newsmultiLanguagesToolStripMenuItem
            // 
            this.newsmultiLanguagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInopressa_ru,
            this.miTheepochtimes,
            this.miBBC});
            this.newsmultiLanguagesToolStripMenuItem.Name = "newsmultiLanguagesToolStripMenuItem";
            this.newsmultiLanguagesToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newsmultiLanguagesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newsmultiLanguagesToolStripMenuItem.Text = "&News";
            // 
            // miInopressa_ru
            // 
            this.miInopressa_ru.Name = "miInopressa_ru";
            this.miInopressa_ru.Size = new System.Drawing.Size(180, 22);
            this.miInopressa_ru.Text = "inopressa.ru";
            // 
            // miTheepochtimes
            // 
            this.miTheepochtimes.Name = "miTheepochtimes";
            this.miTheepochtimes.Size = new System.Drawing.Size(180, 22);
            this.miTheepochtimes.Text = "theepochtimes.com";
            // 
            // miBBC
            // 
            this.miBBC.Name = "miBBC";
            this.miBBC.Size = new System.Drawing.Size(180, 22);
            this.miBBC.Text = "news.bbc.co.uk";
            // 
            // bookLibrariesToolStripMenuItem
            // 
            this.bookLibrariesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gutenbergToolStripMenuItem,
            this.englishLibrarynetToolStripMenuItem,
            this.manybooksnetToolStripMenuItem,
            this.bibliomaniaToolStripMenuItem});
            this.bookLibrariesToolStripMenuItem.Name = "bookLibrariesToolStripMenuItem";
            this.bookLibrariesToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.bookLibrariesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.bookLibrariesToolStripMenuItem.Text = "&Book Libraries";
            // 
            // gutenbergToolStripMenuItem
            // 
            this.gutenbergToolStripMenuItem.Name = "gutenbergToolStripMenuItem";
            this.gutenbergToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.gutenbergToolStripMenuItem.Text = "Gutenberg";
            // 
            // englishLibrarynetToolStripMenuItem
            // 
            this.englishLibrarynetToolStripMenuItem.Name = "englishLibrarynetToolStripMenuItem";
            this.englishLibrarynetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.englishLibrarynetToolStripMenuItem.Text = "EnglishLibrary.net";
            // 
            // manybooksnetToolStripMenuItem
            // 
            this.manybooksnetToolStripMenuItem.Name = "manybooksnetToolStripMenuItem";
            this.manybooksnetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.manybooksnetToolStripMenuItem.Text = "Manybooks.net";
            // 
            // bibliomaniaToolStripMenuItem
            // 
            this.bibliomaniaToolStripMenuItem.Name = "bibliomaniaToolStripMenuItem";
            this.bibliomaniaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bibliomaniaToolStripMenuItem.Text = "bibliomania.com";
            // 
            // miPpenLocalLibrary
            // 
            this.miPpenLocalLibrary.Name = "miPpenLocalLibrary";
            this.miPpenLocalLibrary.Size = new System.Drawing.Size(148, 22);
            this.miPpenLocalLibrary.Text = "Local Library";
            this.miPpenLocalLibrary.Visible = false;
            // 
            // btSearchSubtitles
            // 
            this.btSearchSubtitles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSearchSubtitles.Name = "btSearchSubtitles";
            this.btSearchSubtitles.Size = new System.Drawing.Size(256, 22);
            this.btSearchSubtitles.Text = "Web Search for Subtitles";
            this.btSearchSubtitles.ToolTipText = "Search in internet";
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
            // miHelpRequests
            // 
            this.miHelpRequests.Image = global::f.Properties.Resources.email;
            this.miHelpRequests.Name = "miHelpRequests";
            this.miHelpRequests.Size = new System.Drawing.Size(256, 22);
            this.miHelpRequests.Text = "Help Requests";
            this.miHelpRequests.ToolTipText = "For example: How add a new dictionary www.somewebsite.com";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(256, 22);
            this.miAbout.Text = "&About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // reader
            // 
            this.reader.AllowDrop = true;
            this.reader.BackColor = System.Drawing.Color.White;
            this.reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reader.LanguageDirection = "en:ru";
            this.reader.Location = new System.Drawing.Point(4, 40);
            this.reader.Name = "reader";
            this.reader.Padding = new System.Windows.Forms.Padding(4);
            this.reader.Size = new System.Drawing.Size(1342, 629);
            this.reader.TabIndex = 1;
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 673);
            this.Controls.Add(this.reader);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "ReaderForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Easy-Lang";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EasyReaderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem startTrainerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxWating;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton ddbtOptions;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miHelpRequests;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public FullReader reader;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem btDictionaryBlendHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miResources;
        private System.Windows.Forms.ToolStripMenuItem miPpenLocalLibrary;
        private System.Windows.Forms.ToolStripMenuItem newsmultiLanguagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miInopressa_ru;
        private System.Windows.Forms.ToolStripMenuItem miTheepochtimes;
        private System.Windows.Forms.ToolStripMenuItem miBBC;
        private System.Windows.Forms.ToolStripMenuItem bookLibrariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gutenbergToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishLibrarynetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manybooksnetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bibliomaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btSearchSubtitles;
        private System.Windows.Forms.ToolStripMenuItem btShowParrallelSubtitles;
        private System.Windows.Forms.ToolStripMenuItem miVideo;
        private System.Windows.Forms.ToolStripMenuItem miTED;
    }
}