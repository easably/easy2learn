namespace f
{
    partial class Tutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutor));
            this.splitterHorizontal = new System.Windows.Forms.Splitter();
            this.paForKeyBoard = new System.Windows.Forms.Panel();
            this.keyBoards = new f.KeyBoard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.paForText = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btNext = new System.Windows.Forms.ToolStripButton();
            this.scoreCurrent = new f.ScoreProgress();
            this.textArea = new f.TextWithTranslate();
            this.menuForSelected = new f.MenuForSelected();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scoreProgressForAllSentences = new f.ScoreProgress();
            this.tutorList1 = new f.TutorList();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.miLanguages = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbtOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btSendFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.btExit = new System.Windows.Forms.ToolStripMenuItem();
            this.paTop = new System.Windows.Forms.Panel();
            this.paForKeyBoard.SuspendLayout();
            this.paForText.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.paTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterHorizontal
            // 
            this.splitterHorizontal.BackColor = System.Drawing.Color.White;
            this.splitterHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterHorizontal.Location = new System.Drawing.Point(4, 172);
            this.splitterHorizontal.Name = "splitterHorizontal";
            this.splitterHorizontal.Size = new System.Drawing.Size(748, 10);
            this.splitterHorizontal.TabIndex = 1;
            this.splitterHorizontal.TabStop = false;
            // 
            // paForKeyBoard
            // 
            this.paForKeyBoard.BackColor = System.Drawing.Color.White;
            this.paForKeyBoard.Controls.Add(this.keyBoards);
            this.paForKeyBoard.Controls.Add(this.panel2);
            this.paForKeyBoard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paForKeyBoard.Location = new System.Drawing.Point(4, 459);
            this.paForKeyBoard.Name = "paForKeyBoard";
            this.paForKeyBoard.Padding = new System.Windows.Forms.Padding(4);
            this.paForKeyBoard.Size = new System.Drawing.Size(748, 132);
            this.paForKeyBoard.TabIndex = 2;
            // 
            // keyBoards
            // 
            this.keyBoards.BackColor = System.Drawing.Color.White;
            this.keyBoards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyBoards.Location = new System.Drawing.Point(4, 6);
            this.keyBoards.MinimumSize = new System.Drawing.Size(664, 123);
            this.keyBoards.Name = "keyBoards";
            this.keyBoards.Padding = new System.Windows.Forms.Padding(7);
            this.keyBoards.Size = new System.Drawing.Size(740, 123);
            this.keyBoards.TabIndex = 0;
            this.keyBoards.TabStop = false;
            this.keyBoards.YesLetter = ' ';
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 2);
            this.panel2.TabIndex = 1;
            // 
            // paForText
            // 
            this.paForText.BackColor = System.Drawing.SystemColors.Window;
            this.paForText.Controls.Add(this.panel3);
            this.paForText.Controls.Add(this.scoreCurrent);
            this.paForText.Controls.Add(this.textArea);
            this.paForText.Controls.Add(this.menuForSelected);
            this.paForText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paForText.Location = new System.Drawing.Point(4, 182);
            this.paForText.Name = "paForText";
            this.paForText.Padding = new System.Windows.Forms.Padding(7);
            this.paForText.Size = new System.Drawing.Size(748, 277);
            this.paForText.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Location = new System.Drawing.Point(4, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4, 6, 0, 1);
            this.panel3.Size = new System.Drawing.Size(72, 35);
            this.panel3.TabIndex = 31;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btPrev,
            this.toolStripSeparator2,
            this.btNext});
            this.toolStrip2.Location = new System.Drawing.Point(4, 6);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(68, 25);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btPrev
            // 
            this.btPrev.Image = global::EL.Properties.Resources.PrevSent;
            this.btPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(23, 22);
            this.btPrev.ToolTipText = "ShortKey - \'PageUp\'";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btNext
            // 
            this.btNext.Image = global::EL.Properties.Resources.NextSent;
            this.btNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(23, 22);
            this.btNext.ToolTipText = "ShortKey - \'PageDown\'";
            // 
            // scoreCurrent
            // 
            this.scoreCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreCurrent.Errors = 0;
            this.scoreCurrent.Hints = 0;
            this.scoreCurrent.Location = new System.Drawing.Point(558, 10);
            this.scoreCurrent.Maximum = 100;
            this.scoreCurrent.Name = "scoreCurrent";
            this.scoreCurrent.Passes = 0;
            this.scoreCurrent.ScoreData = null;
            this.scoreCurrent.Size = new System.Drawing.Size(180, 21);
            this.scoreCurrent.TabIndex = 30;
            this.scoreCurrent.TabStop = false;
            // 
            // textArea
            // 
            this.textArea.BackColor = System.Drawing.SystemColors.Window;
            this.textArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textArea.Location = new System.Drawing.Point(7, 37);
            this.textArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textArea.MinimumSize = new System.Drawing.Size(150, 77);
            this.textArea.Name = "textArea";
            this.textArea.Sentence = null;
            this.textArea.ShowParrallelText = false;
            this.textArea.Size = new System.Drawing.Size(734, 233);
            this.textArea.TabIndex = 0;
            // 
            // menuForSelected
            // 
            this.menuForSelected.BackColor = System.Drawing.Color.White;
            this.menuForSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuForSelected.IsAddWordToTutor = false;
            this.menuForSelected.IsAutoHideTranslation = false;
            this.menuForSelected.IsListenByClick = true;
            this.menuForSelected.IsShowPopupWindow = true;
            this.menuForSelected.IsWordAavailable = false;
            this.menuForSelected.LastDictName = "Google dictionary";
            this.menuForSelected.Location = new System.Drawing.Point(7, 7);
            this.menuForSelected.Margin = new System.Windows.Forms.Padding(0);
            this.menuForSelected.Name = "menuForSelected";
            this.menuForSelected.Padding = new System.Windows.Forms.Padding(73, 0, 190, 0);
            this.menuForSelected.Size = new System.Drawing.Size(734, 30);
            this.menuForSelected.TabIndex = 29;
            this.menuForSelected.TextsForMenu = null;
            this.menuForSelected.UseGoogleAsMonoDictionary = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scoreProgressForAllSentences);
            this.panel1.Controls.Add(this.tutorList1);
            this.panel1.Controls.Add(this.splitterHorizontal);
            this.panel1.Controls.Add(this.paForText);
            this.panel1.Controls.Add(this.paForKeyBoard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 37);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(756, 595);
            this.panel1.TabIndex = 3;
            // 
            // scoreProgressForAllSentences
            // 
            this.scoreProgressForAllSentences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreProgressForAllSentences.BackColor = System.Drawing.Color.White;
            this.scoreProgressForAllSentences.Errors = 0;
            this.scoreProgressForAllSentences.Hints = 0;
            this.scoreProgressForAllSentences.Location = new System.Drawing.Point(565, 14);
            this.scoreProgressForAllSentences.Maximum = 50;
            this.scoreProgressForAllSentences.Name = "scoreProgressForAllSentences";
            this.scoreProgressForAllSentences.Passes = 0;
            this.scoreProgressForAllSentences.ScoreData = null;
            this.scoreProgressForAllSentences.Size = new System.Drawing.Size(180, 21);
            this.scoreProgressForAllSentences.TabIndex = 3;
            this.scoreProgressForAllSentences.TabStop = false;
            // 
            // tutorList1
            // 
            this.tutorList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tutorList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tutorList1.FontSize = 11.5F;
            this.tutorList1.Location = new System.Drawing.Point(4, 4);
            this.tutorList1.Name = "tutorList1";
            this.tutorList1.SafeSelectedIndex = -1;
            this.tutorList1.Size = new System.Drawing.Size(748, 168);
            this.tutorList1.TabIndex = 0;
            this.tutorList1.TimeShift = 0D;
            this.tutorList1.VideoFileName = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLanguages,
            this.toolStripSeparator1,
            this.ddbtOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(756, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // ddbtOptions
            // 
            this.ddbtOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAbout,
            this.btSendFeedback,
            this.toolStripMenuItem3,
            this.btExit});
            this.ddbtOptions.Image = global::EL.Properties.Resources.Options;
            this.ddbtOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtOptions.Name = "ddbtOptions";
            this.ddbtOptions.Size = new System.Drawing.Size(29, 22);
            this.ddbtOptions.Text = "Options, Feedback, DictionaryBlend, Resources, About ....";
            this.ddbtOptions.ToolTipText = "Options";
            // 
            // btAbout
            // 
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(153, 22);
            this.btAbout.Text = "&About";
            // 
            // btSendFeedback
            // 
            this.btSendFeedback.Name = "btSendFeedback";
            this.btSendFeedback.Size = new System.Drawing.Size(153, 22);
            this.btSendFeedback.Text = "Send Feedback";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(150, 6);
            // 
            // btExit
            // 
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(153, 22);
            this.btExit.Text = "Exit";
            // 
            // paTop
            // 
            this.paTop.Controls.Add(this.toolStrip1);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(4, 4);
            this.paTop.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(756, 33);
            this.paTop.TabIndex = 6;
            this.paTop.Visible = false;
            // 
            // Tutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 636);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "Tutor";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Memory Pucher";
            this.paForKeyBoard.ResumeLayout(false);
            this.paForText.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.paTop.ResumeLayout(false);
            this.paTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TutorList tutorList1;
        private System.Windows.Forms.Splitter splitterHorizontal;
        internal TextWithTranslate textArea;
        private System.Windows.Forms.Panel paForKeyBoard;
        private KeyBoard keyBoards;
        private System.Windows.Forms.Panel paForText;
        internal MenuForSelected menuForSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton ddbtOptions;
        private System.Windows.Forms.ToolStripMenuItem btSendFeedback;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem btAbout;
        private System.Windows.Forms.ToolStripMenuItem btExit;
        private System.Windows.Forms.Panel paTop;
        private System.Windows.Forms.ToolStripDropDownButton miLanguages;
        private f.ScoreProgress scoreProgressForAllSentences;
        private System.Windows.Forms.Panel panel2;
        private ScoreProgress scoreCurrent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton btPrev;
        internal System.Windows.Forms.ToolStripButton btNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}