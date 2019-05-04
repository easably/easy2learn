namespace f
{
    partial class TedBrowser
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
            this.wbTedView = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbHint = new System.Windows.Forms.Label();
            this.lbNoInternet = new System.Windows.Forms.Label();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbTranslation = new System.Windows.Forms.RadioButton();
            this.cmbTags = new System.Windows.Forms.ComboBox();
            this.cmbNativeLanguage = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbTedView
            // 
            this.wbTedView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbTedView.Location = new System.Drawing.Point(3, 69);
            this.wbTedView.Name = "wbTedView";
            this.wbTedView.ScriptErrorsSuppressed = true;
            this.wbTedView.ScrollBarsEnabled = false;
            this.wbTedView.Size = new System.Drawing.Size(913, 370);
            this.wbTedView.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::f.OtherImages.icon_wait;
            this.pictureBox1.Location = new System.Drawing.Point(350, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 118);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbHint);
            this.panel1.Controls.Add(this.lbNoInternet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 442);
            this.panel1.TabIndex = 7;
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbHint.ForeColor = System.Drawing.Color.Black;
            this.lbHint.Location = new System.Drawing.Point(21, 17);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(252, 31);
            this.lbHint.TabIndex = 5;
            this.lbHint.Text = "Click on any video";
            // 
            // lbNoInternet
            // 
            this.lbNoInternet.AutoSize = true;
            this.lbNoInternet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNoInternet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNoInternet.Location = new System.Drawing.Point(13, 27);
            this.lbNoInternet.Name = "lbNoInternet";
            this.lbNoInternet.Size = new System.Drawing.Size(214, 20);
            this.lbNoInternet.TabIndex = 6;
            this.lbNoInternet.Text = "No connection to the internet";
            this.lbNoInternet.Visible = false;
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(395, 40);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(114, 17);
            this.rbCategory.TabIndex = 16;
            this.rbCategory.Text = "Show by Category:";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // rbTranslation
            // 
            this.rbTranslation.AutoSize = true;
            this.rbTranslation.Checked = true;
            this.rbTranslation.Location = new System.Drawing.Point(395, 17);
            this.rbTranslation.Name = "rbTranslation";
            this.rbTranslation.Size = new System.Drawing.Size(124, 17);
            this.rbTranslation.TabIndex = 13;
            this.rbTranslation.TabStop = true;
            this.rbTranslation.Text = "Show by Translation:";
            this.rbTranslation.UseVisualStyleBackColor = true;
            // 
            // cmbTags
            // 
            this.cmbTags.FormattingEnabled = true;
            this.cmbTags.Location = new System.Drawing.Point(552, 40);
            this.cmbTags.Name = "cmbTags";
            this.cmbTags.Size = new System.Drawing.Size(224, 21);
            this.cmbTags.TabIndex = 15;
            // 
            // cmbNativeLanguage
            // 
            this.cmbNativeLanguage.FormattingEnabled = true;
            this.cmbNativeLanguage.Location = new System.Drawing.Point(552, 17);
            this.cmbNativeLanguage.Name = "cmbNativeLanguage";
            this.cmbNativeLanguage.Size = new System.Drawing.Size(224, 21);
            this.cmbNativeLanguage.TabIndex = 14;
            // 
            // TedBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbCategory);
            this.Controls.Add(this.rbTranslation);
            this.Controls.Add(this.cmbTags);
            this.Controls.Add(this.cmbNativeLanguage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wbTedView);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(595, 300);
            this.Name = "TedBrowser";
            this.Size = new System.Drawing.Size(919, 442);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbTedView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Label lbNoInternet;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbTranslation;
        private System.Windows.Forms.ComboBox cmbTags;
        private System.Windows.Forms.ComboBox cmbNativeLanguage;
    }
}
