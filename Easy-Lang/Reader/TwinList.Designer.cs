namespace f
{
    partial class TwinList
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.paVideo = new System.Windows.Forms.Panel();
            this.videoControl1 = new f.VideoControl();
            this.splitterVerticalForVideo = new System.Windows.Forms.Splitter();
            this.paLists = new System.Windows.Forms.Panel();
            this.ListEn = new f.SentenceListWithVideo();
            this.splitterHor = new System.Windows.Forms.Splitter();
            this.ListNative = new f.SentenceListWithIndent();
            this.panelMain.SuspendLayout();
            this.paVideo.SuspendLayout();
            this.paLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.paVideo);
            this.panelMain.Controls.Add(this.splitterVerticalForVideo);
            this.panelMain.Controls.Add(this.paLists);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(4);
            this.panelMain.Size = new System.Drawing.Size(1363, 514);
            this.panelMain.TabIndex = 0;
            // 
            // paVideo
            // 
            this.paVideo.Controls.Add(this.videoControl1);
            this.paVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paVideo.Location = new System.Drawing.Point(4, 4);
            this.paVideo.Name = "paVideo";
            this.paVideo.Size = new System.Drawing.Size(679, 506);
            this.paVideo.TabIndex = 8;
            // 
            // videoControl1
            // 
            this.videoControl1.AudioLanguageIndex = 0;
            this.videoControl1.BackColor = System.Drawing.Color.White;
            this.videoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoControl1.FullScreen = false;
            this.videoControl1.Location = new System.Drawing.Point(0, 0);
            this.videoControl1.Name = "videoControl1";
            this.videoControl1.Padding = new System.Windows.Forms.Padding(5);
            this.videoControl1.Size = new System.Drawing.Size(679, 506);
            this.videoControl1.SkipSynchronize = false;
            this.videoControl1.TabIndex = 0;
            // 
            // splitterVerticalForVideo
            // 
            this.splitterVerticalForVideo.BackColor = System.Drawing.SystemColors.Window;
            this.splitterVerticalForVideo.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterVerticalForVideo.Location = new System.Drawing.Point(683, 4);
            this.splitterVerticalForVideo.Name = "splitterVerticalForVideo";
            this.splitterVerticalForVideo.Size = new System.Drawing.Size(13, 506);
            this.splitterVerticalForVideo.TabIndex = 7;
            this.splitterVerticalForVideo.TabStop = false;
            // 
            // paLists
            // 
            this.paLists.Controls.Add(this.ListEn);
            this.paLists.Controls.Add(this.splitterHor);
            this.paLists.Controls.Add(this.ListNative);
            this.paLists.Dock = System.Windows.Forms.DockStyle.Right;
            this.paLists.Location = new System.Drawing.Point(696, 4);
            this.paLists.Name = "paLists";
            this.paLists.Size = new System.Drawing.Size(663, 506);
            this.paLists.TabIndex = 7;
            // 
            // ListEn
            // 
            this.ListEn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListEn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListEn.FontSize = 11.5F;
            this.ListEn.Location = new System.Drawing.Point(0, 0);
            this.ListEn.Name = "ListEn";
            this.ListEn.SafeSelectedIndex = -1;
            this.ListEn.Size = new System.Drawing.Size(663, 227);
            this.ListEn.TabIndex = 5;
            this.ListEn.TimeShift = 0D;
            this.ListEn.VideoFileName = "";
            // 
            // splitterHor
            // 
            this.splitterHor.BackColor = System.Drawing.SystemColors.Window;
            this.splitterHor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterHor.Location = new System.Drawing.Point(0, 227);
            this.splitterHor.Name = "splitterHor";
            this.splitterHor.Size = new System.Drawing.Size(663, 13);
            this.splitterHor.TabIndex = 7;
            this.splitterHor.TabStop = false;
            this.splitterHor.Visible = false;
            // 
            // ListNative
            // 
            this.ListNative.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListNative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListNative.FontSize = 11.5F;
            this.ListNative.Indent = 0;
            this.ListNative.Location = new System.Drawing.Point(0, 240);
            this.ListNative.Name = "ListNative";
            this.ListNative.SafeSelectedIndex = -1;
            this.ListNative.Size = new System.Drawing.Size(663, 266);
            this.ListNative.TabIndex = 7;
            this.ListNative.TabStop = false;
            this.ListNative.TimeIndent = 0D;
            this.ListNative.Visible = false;
            // 
            // TwinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "TwinList";
            this.Size = new System.Drawing.Size(1363, 514);
            this.panelMain.ResumeLayout(false);
            this.paVideo.ResumeLayout(false);
            this.paLists.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel paVideo;
        public SentenceListWithVideo ListEn;
        private System.Windows.Forms.Splitter splitterHor;
        public SentenceListWithIndent ListNative;
        internal VideoControl videoControl1;
        internal System.Windows.Forms.Panel paLists;
        internal System.Windows.Forms.Splitter splitterVerticalForVideo;
    }
}
