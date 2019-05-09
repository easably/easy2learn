namespace f
{
    partial class FileSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSelector));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txVideoFile = new System.Windows.Forms.TextBox();
            this.paPaddingVideo = new System.Windows.Forms.Panel();
            this.btVideoOpen = new System.Windows.Forms.Button();
            this.paBorderVideo = new System.Windows.Forms.Panel();
            this.paBorderSubt = new System.Windows.Forms.Panel();
            this.paPaddingSubt = new System.Windows.Forms.Panel();
            this.txSubtFile = new System.Windows.Forms.TextBox();
            this.btSubtitleOpen = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btRun = new System.Windows.Forms.Button();
            this.btDownloadfromURL = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnSpace = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpHistory = new System.Windows.Forms.TabPage();
            this.historyListUC1 = new f.HistoryListUC();
            this.tpEuronewsArchive = new System.Windows.Forms.TabPage();
            this.euronewsArchiveView1 = new f.EuronewsArchiveView();
            this.tpEuronews = new System.Windows.Forms.TabPage();
            this.euronewsBrowser1 = new f.EuronewsBrowser();
            this.tpTedCom = new System.Windows.Forms.TabPage();
            this.tedBrowser1 = new f.TedBrowser();
            this.tpVideoFiles = new System.Windows.Forms.TabPage();
            this.cbUseSamples = new System.Windows.Forms.CheckBox();
            this.lbIntrodaction = new System.Windows.Forms.Label();
            this.tpParents = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tpReadingText = new System.Windows.Forms.TabPage();
            this.createAndReadControl1 = new f.Misc.CreateAndReadControl();
            this.tpFromURL = new System.Windows.Forms.TabPage();
            this.lbURLforVideo = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txURLforDownload = new System.Windows.Forms.TextBox();
            this.paTop = new System.Windows.Forms.Panel();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.miLanguages = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBoxWating = new System.Windows.Forms.PictureBox();
            this.paPaddingVideo.SuspendLayout();
            this.paBorderVideo.SuspendLayout();
            this.paBorderSubt.SuspendLayout();
            this.paPaddingSubt.SuspendLayout();
            this.pnBorder.SuspendLayout();
            this.pnSpace.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpHistory.SuspendLayout();
            this.tpEuronewsArchive.SuspendLayout();
            this.tpEuronews.SuspendLayout();
            this.tpTedCom.SuspendLayout();
            this.tpVideoFiles.SuspendLayout();
            this.tpParents.SuspendLayout();
            this.tpReadingText.SuspendLayout();
            this.tpFromURL.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.paTop.SuspendLayout();
            this.toolStripMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movie file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(24, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subtitle file:";
            // 
            // txVideoFile
            // 
            this.txVideoFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txVideoFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txVideoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txVideoFile.Location = new System.Drawing.Point(8, 7);
            this.txVideoFile.Name = "txVideoFile";
            this.txVideoFile.Size = new System.Drawing.Size(820, 16);
            this.txVideoFile.TabIndex = 3;
            this.txVideoFile.Text = "11-_22";
            // 
            // paPaddingVideo
            // 
            this.paPaddingVideo.BackColor = System.Drawing.Color.White;
            this.paPaddingVideo.Controls.Add(this.txVideoFile);
            this.paPaddingVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPaddingVideo.Location = new System.Drawing.Point(0, 0);
            this.paPaddingVideo.Name = "paPaddingVideo";
            this.paPaddingVideo.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.paPaddingVideo.Size = new System.Drawing.Size(833, 32);
            this.paPaddingVideo.TabIndex = 4;
            // 
            // btVideoOpen
            // 
            this.btVideoOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btVideoOpen.ForeColor = System.Drawing.Color.Black;
            this.btVideoOpen.Location = new System.Drawing.Point(833, 0);
            this.btVideoOpen.Name = "btVideoOpen";
            this.btVideoOpen.Size = new System.Drawing.Size(53, 32);
            this.btVideoOpen.TabIndex = 6;
            this.btVideoOpen.Text = ". . . ";
            this.toolTip1.SetToolTip(this.btVideoOpen, "Select file");
            this.btVideoOpen.UseVisualStyleBackColor = true;
            // 
            // paBorderVideo
            // 
            this.paBorderVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paBorderVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paBorderVideo.Controls.Add(this.paPaddingVideo);
            this.paBorderVideo.Controls.Add(this.btVideoOpen);
            this.paBorderVideo.Location = new System.Drawing.Point(18, 54);
            this.paBorderVideo.Name = "paBorderVideo";
            this.paBorderVideo.Size = new System.Drawing.Size(888, 34);
            this.paBorderVideo.TabIndex = 5;
            // 
            // paBorderSubt
            // 
            this.paBorderSubt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paBorderSubt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paBorderSubt.Controls.Add(this.paPaddingSubt);
            this.paBorderSubt.Controls.Add(this.btSubtitleOpen);
            this.paBorderSubt.Location = new System.Drawing.Point(17, 139);
            this.paBorderSubt.Name = "paBorderSubt";
            this.paBorderSubt.Size = new System.Drawing.Size(888, 34);
            this.paBorderSubt.TabIndex = 6;
            // 
            // paPaddingSubt
            // 
            this.paPaddingSubt.BackColor = System.Drawing.Color.White;
            this.paPaddingSubt.Controls.Add(this.txSubtFile);
            this.paPaddingSubt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPaddingSubt.Location = new System.Drawing.Point(0, 0);
            this.paPaddingSubt.Name = "paPaddingSubt";
            this.paPaddingSubt.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.paPaddingSubt.Size = new System.Drawing.Size(834, 32);
            this.paPaddingSubt.TabIndex = 4;
            // 
            // txSubtFile
            // 
            this.txSubtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txSubtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSubtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txSubtFile.Location = new System.Drawing.Point(8, 7);
            this.txSubtFile.Name = "txSubtFile";
            this.txSubtFile.Size = new System.Drawing.Size(821, 16);
            this.txSubtFile.TabIndex = 3;
            this.txSubtFile.Text = "11-_22";
            // 
            // btSubtitleOpen
            // 
            this.btSubtitleOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSubtitleOpen.ForeColor = System.Drawing.Color.Black;
            this.btSubtitleOpen.Location = new System.Drawing.Point(834, 0);
            this.btSubtitleOpen.Name = "btSubtitleOpen";
            this.btSubtitleOpen.Size = new System.Drawing.Size(52, 32);
            this.btSubtitleOpen.TabIndex = 6;
            this.btSubtitleOpen.Text = ". . . ";
            this.toolTip1.SetToolTip(this.btSubtitleOpen, "Select file");
            this.btSubtitleOpen.UseVisualStyleBackColor = true;
            // 
            // btRun
            // 
            this.btRun.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.BackColor = System.Drawing.Color.White;
            this.btRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btRun.Image = global::f.Buttons.green_arrow_next_48;
            this.btRun.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRun.Location = new System.Drawing.Point(630, 191);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(274, 70);
            this.btRun.TabIndex = 9;
            this.btRun.Text = "                   Run";
            this.btRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btRun, "Watching video step by step");
            this.btRun.UseVisualStyleBackColor = false;
            // 
            // btDownloadfromURL
            // 
            this.btDownloadfromURL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btDownloadfromURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDownloadfromURL.BackColor = System.Drawing.Color.White;
            this.btDownloadfromURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDownloadfromURL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btDownloadfromURL.Image = global::f.Buttons.green_arrow_next_48;
            this.btDownloadfromURL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDownloadfromURL.Location = new System.Drawing.Point(630, 191);
            this.btDownloadfromURL.Name = "btDownloadfromURL";
            this.btDownloadfromURL.Size = new System.Drawing.Size(274, 70);
            this.btDownloadfromURL.TabIndex = 10;
            this.btDownloadfromURL.Text = "     Download and Open";
            this.btDownloadfromURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btDownloadfromURL, "Watching video step by step");
            this.btDownloadfromURL.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnBorder
            // 
            this.pnBorder.BackColor = System.Drawing.Color.White;
            this.pnBorder.Controls.Add(this.pnSpace);
            this.pnBorder.Controls.Add(this.paTop);
            this.pnBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBorder.Location = new System.Drawing.Point(4, 4);
            this.pnBorder.Name = "pnBorder";
            this.pnBorder.Padding = new System.Windows.Forms.Padding(4);
            this.pnBorder.Size = new System.Drawing.Size(946, 739);
            this.pnBorder.TabIndex = 7;
            // 
            // pnSpace
            // 
            this.pnSpace.BackColor = System.Drawing.Color.White;
            this.pnSpace.Controls.Add(this.tabControl);
            this.pnSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSpace.Location = new System.Drawing.Point(4, 36);
            this.pnSpace.Name = "pnSpace";
            this.pnSpace.Padding = new System.Windows.Forms.Padding(4);
            this.pnSpace.Size = new System.Drawing.Size(938, 699);
            this.pnSpace.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpHistory);
            this.tabControl.Controls.Add(this.tpEuronewsArchive);
            this.tabControl.Controls.Add(this.tpEuronews);
            this.tabControl.Controls.Add(this.tpTedCom);
            this.tabControl.Controls.Add(this.tpVideoFiles);
            this.tabControl.Controls.Add(this.tpParents);
            this.tabControl.Controls.Add(this.tpReadingText);
            this.tabControl.Controls.Add(this.tpFromURL);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(930, 691);
            this.tabControl.TabIndex = 9;
            // 
            // tpHistory
            // 
            this.tpHistory.Controls.Add(this.historyListUC1);
            this.tpHistory.Location = new System.Drawing.Point(4, 22);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistory.Size = new System.Drawing.Size(922, 665);
            this.tpHistory.TabIndex = 6;
            this.tpHistory.Text = "     Video on disk      ";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // historyListUC1
            // 
            this.historyListUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyListUC1.Location = new System.Drawing.Point(3, 3);
            this.historyListUC1.Name = "historyListUC1";
            this.historyListUC1.Size = new System.Drawing.Size(916, 659);
            this.historyListUC1.TabIndex = 0;
            // 
            // tpEuronewsArchive
            // 
            this.tpEuronewsArchive.Controls.Add(this.euronewsArchiveView1);
            this.tpEuronewsArchive.Location = new System.Drawing.Point(4, 22);
            this.tpEuronewsArchive.Name = "tpEuronewsArchive";
            this.tpEuronewsArchive.Size = new System.Drawing.Size(922, 697);
            this.tpEuronewsArchive.TabIndex = 7;
            this.tpEuronewsArchive.Text = "   Video from Euronews   ";
            this.tpEuronewsArchive.UseVisualStyleBackColor = true;
            // 
            // euronewsArchiveView1
            // 
            this.euronewsArchiveView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.euronewsArchiveView1.Location = new System.Drawing.Point(0, 0);
            this.euronewsArchiveView1.Name = "euronewsArchiveView1";
            this.euronewsArchiveView1.Size = new System.Drawing.Size(922, 697);
            this.euronewsArchiveView1.TabIndex = 0;
            // 
            // tpEuronews
            // 
            this.tpEuronews.Controls.Add(this.euronewsBrowser1);
            this.tpEuronews.Location = new System.Drawing.Point(4, 22);
            this.tpEuronews.Name = "tpEuronews";
            this.tpEuronews.Padding = new System.Windows.Forms.Padding(3);
            this.tpEuronews.Size = new System.Drawing.Size(922, 697);
            this.tpEuronews.TabIndex = 5;
            this.tpEuronews.Text = "    Programs from euronews    ";
            this.tpEuronews.UseVisualStyleBackColor = true;
            // 
            // euronewsBrowser1
            // 
            this.euronewsBrowser1.BackColor = System.Drawing.Color.White;
            this.euronewsBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.euronewsBrowser1.Location = new System.Drawing.Point(3, 3);
            this.euronewsBrowser1.Name = "euronewsBrowser1";
            this.euronewsBrowser1.Size = new System.Drawing.Size(916, 691);
            this.euronewsBrowser1.TabIndex = 0;
            // 
            // tpTedCom
            // 
            this.tpTedCom.Controls.Add(this.tedBrowser1);
            this.tpTedCom.Location = new System.Drawing.Point(4, 22);
            this.tpTedCom.Name = "tpTedCom";
            this.tpTedCom.Size = new System.Drawing.Size(922, 697);
            this.tpTedCom.TabIndex = 2;
            this.tpTedCom.Text = "     Video from TED.com      ";
            this.tpTedCom.UseVisualStyleBackColor = true;
            // 
            // tedBrowser1
            // 
            this.tedBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tedBrowser1.Location = new System.Drawing.Point(0, 0);
            this.tedBrowser1.MinimumSize = new System.Drawing.Size(500, 300);
            this.tedBrowser1.Name = "tedBrowser1";
            this.tedBrowser1.Size = new System.Drawing.Size(922, 697);
            this.tedBrowser1.TabIndex = 1;
            // 
            // tpVideoFiles
            // 
            this.tpVideoFiles.Controls.Add(this.cbUseSamples);
            this.tpVideoFiles.Controls.Add(this.btRun);
            this.tpVideoFiles.Controls.Add(this.lbIntrodaction);
            this.tpVideoFiles.Controls.Add(this.label1);
            this.tpVideoFiles.Controls.Add(this.label2);
            this.tpVideoFiles.Controls.Add(this.paBorderSubt);
            this.tpVideoFiles.Controls.Add(this.paBorderVideo);
            this.tpVideoFiles.ForeColor = System.Drawing.Color.White;
            this.tpVideoFiles.Location = new System.Drawing.Point(4, 22);
            this.tpVideoFiles.Name = "tpVideoFiles";
            this.tpVideoFiles.Size = new System.Drawing.Size(922, 697);
            this.tpVideoFiles.TabIndex = 0;
            this.tpVideoFiles.Text = "    Specify files    ";
            this.tpVideoFiles.UseVisualStyleBackColor = true;
            // 
            // cbUseSamples
            // 
            this.cbUseSamples.AutoSize = true;
            this.cbUseSamples.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbUseSamples.Location = new System.Drawing.Point(26, 244);
            this.cbUseSamples.Name = "cbUseSamples";
            this.cbUseSamples.Size = new System.Drawing.Size(88, 17);
            this.cbUseSamples.TabIndex = 10;
            this.cbUseSamples.Text = "Use Samples";
            this.cbUseSamples.UseVisualStyleBackColor = true;
            this.cbUseSamples.Visible = false;
            this.cbUseSamples.CheckedChanged += new System.EventHandler(this.cbUseSamples_CheckedChanged);
            // 
            // lbIntrodaction
            // 
            this.lbIntrodaction.AutoSize = true;
            this.lbIntrodaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIntrodaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbIntrodaction.Location = new System.Drawing.Point(23, 201);
            this.lbIntrodaction.Name = "lbIntrodaction";
            this.lbIntrodaction.Size = new System.Drawing.Size(281, 20);
            this.lbIntrodaction.TabIndex = 8;
            this.lbIntrodaction.Text = "Specify two files video and subtitles";
            // 
            // tpParents
            // 
            this.tpParents.Controls.Add(this.label3);
            this.tpParents.Location = new System.Drawing.Point(4, 22);
            this.tpParents.Name = "tpParents";
            this.tpParents.Size = new System.Drawing.Size(922, 697);
            this.tpParents.TabIndex = 3;
            this.tpParents.Text = "       Child Learning       ";
            this.tpParents.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(137, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coming Soon in version of Easy-Lang 2.7\r\nBased on Voice Recognition";
            // 
            // tpReadingText
            // 
            this.tpReadingText.Controls.Add(this.createAndReadControl1);
            this.tpReadingText.Location = new System.Drawing.Point(4, 22);
            this.tpReadingText.Name = "tpReadingText";
            this.tpReadingText.Padding = new System.Windows.Forms.Padding(3);
            this.tpReadingText.Size = new System.Drawing.Size(922, 697);
            this.tpReadingText.TabIndex = 1;
            this.tpReadingText.Text = "       Read Text       ";
            this.tpReadingText.UseVisualStyleBackColor = true;
            // 
            // createAndReadControl1
            // 
            this.createAndReadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createAndReadControl1.Location = new System.Drawing.Point(3, 3);
            this.createAndReadControl1.Name = "createAndReadControl1";
            this.createAndReadControl1.Padding = new System.Windows.Forms.Padding(5);
            this.createAndReadControl1.Size = new System.Drawing.Size(916, 691);
            this.createAndReadControl1.TabIndex = 0;
            // 
            // tpFromURL
            // 
            this.tpFromURL.Controls.Add(this.lbURLforVideo);
            this.tpFromURL.Controls.Add(this.label4);
            this.tpFromURL.Controls.Add(this.panel1);
            this.tpFromURL.Controls.Add(this.btDownloadfromURL);
            this.tpFromURL.Location = new System.Drawing.Point(4, 22);
            this.tpFromURL.Name = "tpFromURL";
            this.tpFromURL.Size = new System.Drawing.Size(922, 697);
            this.tpFromURL.TabIndex = 4;
            this.tpFromURL.Text = "Downloading by web-address";
            this.tpFromURL.UseVisualStyleBackColor = true;
            // 
            // lbURLforVideo
            // 
            this.lbURLforVideo.AutoSize = true;
            this.lbURLforVideo.Location = new System.Drawing.Point(24, 100);
            this.lbURLforVideo.Name = "lbURLforVideo";
            this.lbURLforVideo.Size = new System.Drawing.Size(72, 13);
            this.lbURLforVideo.TabIndex = 13;
            this.lbURLforVideo.TabStop = true;
            this.lbURLforVideo.Text = "www.ted.com";
            this.lbURLforVideo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(24, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address for a video from www.ted.com";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(18, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 34);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txURLforDownload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.panel2.Size = new System.Drawing.Size(886, 32);
            this.panel2.TabIndex = 4;
            // 
            // txURLforDownload
            // 
            this.txURLforDownload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txURLforDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txURLforDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txURLforDownload.Location = new System.Drawing.Point(8, 7);
            this.txURLforDownload.Name = "txURLforDownload";
            this.txURLforDownload.Size = new System.Drawing.Size(873, 16);
            this.txURLforDownload.TabIndex = 3;
            this.txURLforDownload.Text = "http://www.ted.com/talks/lang/ru/ramsey_musallam_3_rules_to_spark_learning.html";
            // 
            // paTop
            // 
            this.paTop.BackColor = System.Drawing.Color.White;
            this.paTop.Controls.Add(this.toolStripMainMenu);
            this.paTop.Controls.Add(this.pictureBoxWating);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(4, 4);
            this.paTop.Name = "paTop";
            this.paTop.Padding = new System.Windows.Forms.Padding(3, 3, 33, 0);
            this.paTop.Size = new System.Drawing.Size(938, 32);
            this.paTop.TabIndex = 29;
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLanguages,
            this.toolStripSeparator1});
            this.toolStripMainMenu.Location = new System.Drawing.Point(3, 3);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(902, 25);
            this.toolStripMainMenu.TabIndex = 27;
            this.toolStripMainMenu.Text = "toolStrip1";
            // 
            // miLanguages
            // 
            this.miLanguages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miLanguages.Image = ((System.Drawing.Image)(resources.GetObject("miLanguages.Image")));
            this.miLanguages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miLanguages.Name = "miLanguages";
            this.miLanguages.Size = new System.Drawing.Size(106, 22);
            this.miLanguages.Text = "Select Language";
            this.miLanguages.ToolTipText = "Select Language Pair";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pictureBoxWating
            // 
            this.pictureBoxWating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWating.Location = new System.Drawing.Point(909, 2);
            this.pictureBoxWating.Name = "pictureBoxWating";
            this.pictureBoxWating.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxWating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWating.TabIndex = 23;
            this.pictureBoxWating.TabStop = false;
            this.pictureBoxWating.Visible = false;
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 747);
            this.Controls.Add(this.pnBorder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(970, 786);
            this.MinimumSize = new System.Drawing.Size(970, 786);
            this.Name = "FileSelector";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select allFiles with video and subtitles";
            this.paPaddingVideo.ResumeLayout(false);
            this.paPaddingVideo.PerformLayout();
            this.paBorderVideo.ResumeLayout(false);
            this.paBorderSubt.ResumeLayout(false);
            this.paPaddingSubt.ResumeLayout(false);
            this.paPaddingSubt.PerformLayout();
            this.pnBorder.ResumeLayout(false);
            this.pnSpace.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpHistory.ResumeLayout(false);
            this.tpEuronewsArchive.ResumeLayout(false);
            this.tpEuronews.ResumeLayout(false);
            this.tpTedCom.ResumeLayout(false);
            this.tpVideoFiles.ResumeLayout(false);
            this.tpVideoFiles.PerformLayout();
            this.tpParents.ResumeLayout(false);
            this.tpParents.PerformLayout();
            this.tpReadingText.ResumeLayout(false);
            this.tpFromURL.ResumeLayout(false);
            this.tpFromURL.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.paTop.ResumeLayout(false);
            this.paTop.PerformLayout();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txVideoFile;
        private System.Windows.Forms.Panel paPaddingVideo;
        private System.Windows.Forms.Panel paBorderVideo;
        private System.Windows.Forms.Button btVideoOpen;
        private System.Windows.Forms.Panel paBorderSubt;
        private System.Windows.Forms.Panel paPaddingSubt;
        private System.Windows.Forms.TextBox txSubtFile;
        private System.Windows.Forms.Button btSubtitleOpen;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnSpace;
        private System.Windows.Forms.Label lbIntrodaction;
        private System.Windows.Forms.TabPage tpVideoFiles;
        private System.Windows.Forms.TabPage tpReadingText;
        private System.Windows.Forms.TabPage tpTedCom;
        private System.Windows.Forms.TabPage tpParents;
        private TedBrowser tedBrowser1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btRun;
        internal System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.CheckBox cbUseSamples;
        private f.Misc.CreateAndReadControl createAndReadControl1;
        private System.Windows.Forms.TabPage tpFromURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txURLforDownload;
        private System.Windows.Forms.Button btDownloadfromURL;
        private System.Windows.Forms.LinkLabel lbURLforVideo;
        private System.Windows.Forms.TabPage tpEuronews;
        private EuronewsBrowser euronewsBrowser1;
        private System.Windows.Forms.TabPage tpHistory;
        internal HistoryListUC historyListUC1;
        private System.Windows.Forms.TabPage tpEuronewsArchive;
        private EuronewsArchiveView euronewsArchiveView1;
        private System.Windows.Forms.Panel paTop;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripDropDownButton miLanguages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pictureBoxWating;
    }
}