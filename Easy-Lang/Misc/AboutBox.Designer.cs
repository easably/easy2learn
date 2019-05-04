namespace f
{
    partial class X
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X));
            this.linkLabelSite = new System.Windows.Forms.LinkLabel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.lbMain = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelMail = new System.Windows.Forms.LinkLabel();
            this.btGetEasyLearn = new System.Windows.Forms.Button();
            this.boxInitial = new System.Windows.Forms.PictureBox();
            this.boxDemo = new System.Windows.Forms.PictureBox();
            this.boxProLabel = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxInitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxProLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelSite
            // 
            this.linkLabelSite.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.linkLabelSite.AutoSize = true;
            this.linkLabelSite.LinkColor = System.Drawing.Color.Black;
            this.linkLabelSite.Location = new System.Drawing.Point(52, 468);
            this.linkLabelSite.Name = "linkLabelSite";
            this.linkLabelSite.Size = new System.Drawing.Size(62, 13);
            this.linkLabelSite.TabIndex = 2;
            this.linkLabelSite.TabStop = true;
            this.linkLabelSite.Text = "Home page";
            this.linkLabelSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.Location = new System.Drawing.Point(31, 42);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(470, 78);
            this.textBoxDescription.TabIndex = 9;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            this.textBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMain.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMain.Location = new System.Drawing.Point(50, 410);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(164, 25);
            this.lbMain.TabIndex = 7;
            this.lbMain.Text = "Easy-Lang 2.5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "© 2008-2013 ForceMem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thanks:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Font = new System.Drawing.Font("Arial", 8F);
            this.okButton.Location = new System.Drawing.Point(253, 460);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(197, 41);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            this.okButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(663, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 134);
            this.panel2.TabIndex = 0;
            this.panel2.Visible = false;
            // 
            // linkLabelMail
            // 
            this.linkLabelMail.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.linkLabelMail.AutoSize = true;
            this.linkLabelMail.LinkColor = System.Drawing.Color.Black;
            this.linkLabelMail.Location = new System.Drawing.Point(52, 488);
            this.linkLabelMail.Name = "linkLabelMail";
            this.linkLabelMail.Size = new System.Drawing.Size(125, 13);
            this.linkLabelMail.TabIndex = 14;
            this.linkLabelMail.TabStop = true;
            this.linkLabelMail.Tag = "mailto:dictionaryblend@gmail.com?subject=About Easy-Lang&body=Yours Suggestions a" +
    "nd Complaints.";
            this.linkLabelMail.Text = "easy4learn.com@gmail.com";
            this.linkLabelMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMail_LinkClicked);
            // 
            // btGetEasyLearn
            // 
            this.btGetEasyLearn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btGetEasyLearn.Location = new System.Drawing.Point(456, 460);
            this.btGetEasyLearn.Name = "btGetEasyLearn";
            this.btGetEasyLearn.Size = new System.Drawing.Size(197, 41);
            this.btGetEasyLearn.TabIndex = 18;
            this.btGetEasyLearn.Text = "Get Easy-Learn";
            // 
            // boxInitial
            // 
            this.boxInitial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxInitial.Image = global::f.OtherImages._initial;
            this.boxInitial.Location = new System.Drawing.Point(549, 28);
            this.boxInitial.Name = "boxInitial";
            this.boxInitial.Size = new System.Drawing.Size(89, 25);
            this.boxInitial.TabIndex = 17;
            this.boxInitial.TabStop = false;
            this.boxInitial.Visible = false;
            // 
            // boxDemo
            // 
            this.boxDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxDemo.Image = global::f.OtherImages._Demo;
            this.boxDemo.Location = new System.Drawing.Point(500, 100);
            this.boxDemo.Name = "boxDemo";
            this.boxDemo.Size = new System.Drawing.Size(89, 32);
            this.boxDemo.TabIndex = 16;
            this.boxDemo.TabStop = false;
            this.boxDemo.Visible = false;
            // 
            // boxProLabel
            // 
            this.boxProLabel.Image = global::f.OtherImages._Extended;
            this.boxProLabel.Location = new System.Drawing.Point(549, 28);
            this.boxProLabel.Name = "boxProLabel";
            this.boxProLabel.Size = new System.Drawing.Size(120, 33);
            this.boxProLabel.TabIndex = 15;
            this.boxProLabel.TabStop = false;
            this.boxProLabel.Visible = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.ErrorImage = null;
            this.logoPictureBox.Image = global::f.OtherImages.SplashMovieSubtitler8bit;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(45, 2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(589, 388);
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // X
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(687, 519);
            this.Controls.Add(this.btGetEasyLearn);
            this.Controls.Add(this.boxInitial);
            this.Controls.Add(this.boxDemo);
            this.Controls.Add(this.boxProLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.linkLabelMail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.linkLabelSite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "X";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Easy-Lang";
            this.Load += new System.EventHandler(this.X_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxInitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxProLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelSite;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabelMail;
        private System.Windows.Forms.PictureBox boxProLabel;
        private System.Windows.Forms.PictureBox boxDemo;
        private System.Windows.Forms.PictureBox boxInitial;
        private System.Windows.Forms.Button btGetEasyLearn;
    }
}