namespace f
{
    partial class TextWithTranslate
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
            this.splitterHorizontal = new System.Windows.Forms.Splitter();
            this.pictureBoxWating = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.translatedText = new f.WebBrowserForText();
            this.paForeignText = new System.Windows.Forms.Panel();
            this.splitterVertical = new System.Windows.Forms.Splitter();
            this.ForeignText = new f.TipTextBox();
            this.textNative = new f.TipTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).BeginInit();
            this.paForeignText.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterHorizontal
            // 
            this.splitterHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.splitterHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterHorizontal.Location = new System.Drawing.Point(0, 90);
            this.splitterHorizontal.Name = "splitterHorizontal";
            this.splitterHorizontal.Size = new System.Drawing.Size(768, 17);
            this.splitterHorizontal.TabIndex = 9;
            this.splitterHorizontal.TabStop = false;
            // 
            // pictureBoxWating
            // 
            this.pictureBoxWating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxWating.Image = global::f.OtherImages.icon_wait;
            this.pictureBoxWating.Location = new System.Drawing.Point(3, 248);
            this.pictureBoxWating.Name = "pictureBoxWating";
            this.pictureBoxWating.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxWating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWating.TabIndex = 24;
            this.pictureBoxWating.TabStop = false;
            this.pictureBoxWating.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            // 
            // translatedText
            // 
            this.translatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translatedText.Location = new System.Drawing.Point(0, 107);
            this.translatedText.MinimumSize = new System.Drawing.Size(20, 20);
            this.translatedText.Name = "translatedText";
            this.translatedText.Size = new System.Drawing.Size(768, 168);
            this.translatedText.TabIndex = 25;
            // 
            // paForeignText
            // 
            this.paForeignText.Controls.Add(this.splitterVertical);
            this.paForeignText.Controls.Add(this.ForeignText);
            this.paForeignText.Controls.Add(this.textNative);
            this.paForeignText.Dock = System.Windows.Forms.DockStyle.Top;
            this.paForeignText.Location = new System.Drawing.Point(0, 0);
            this.paForeignText.Name = "paForeignText";
            this.paForeignText.Size = new System.Drawing.Size(768, 90);
            this.paForeignText.TabIndex = 26;
            // 
            // splitterVertical
            // 
            this.splitterVertical.BackColor = System.Drawing.SystemColors.Window;
            this.splitterVertical.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterVertical.Location = new System.Drawing.Point(580, 0);
            this.splitterVertical.Name = "splitterVertical";
            this.splitterVertical.Size = new System.Drawing.Size(13, 90);
            this.splitterVertical.TabIndex = 35;
            this.splitterVertical.TabStop = false;
            this.splitterVertical.Visible = false;
            // 
            // ForeignText
            // 
            this.ForeignText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ForeignText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForeignText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeignText.IsHidedTranslation = false;
            this.ForeignText.IsMonoRegim = false;
            this.ForeignText.IsShowPopup = true;
            this.ForeignText.IsSystemTextChaghed = false;
            this.ForeignText.Location = new System.Drawing.Point(0, 0);
            this.ForeignText.Name = "ForeignText";
            this.ForeignText.Sentence = null;
            this.ForeignText.Size = new System.Drawing.Size(593, 90);
            this.ForeignText.TabIndex = 0;
            this.ForeignText.Text = "19999999999999999999999999999999999999999999999999999999999999999999999999999\n2\n3" +
    "";
            // 
            // textNative
            // 
            this.textNative.BackColor = System.Drawing.SystemColors.Window;
            this.textNative.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNative.Dock = System.Windows.Forms.DockStyle.Right;
            this.textNative.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNative.IsHidedTranslation = false;
            this.textNative.IsMonoRegim = false;
            this.textNative.IsShowPopup = true;
            this.textNative.IsSystemTextChaghed = false;
            this.textNative.Location = new System.Drawing.Point(593, 0);
            this.textNative.Name = "textNative";
            this.textNative.Sentence = null;
            this.textNative.Size = new System.Drawing.Size(175, 90);
            this.textNative.TabIndex = 28;
            this.textNative.TabStop = false;
            this.textNative.Text = "";
            this.textNative.Visible = false;
            // 
            // TextWithTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pictureBoxWating);
            this.Controls.Add(this.translatedText);
            this.Controls.Add(this.splitterHorizontal);
            this.Controls.Add(this.paForeignText);
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "TextWithTranslate";
            this.Size = new System.Drawing.Size(768, 275);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).EndInit();
            this.paForeignText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitterHorizontal;
        public TipTextBox ForeignText;
        public System.Windows.Forms.PictureBox pictureBoxWating;
        private System.Windows.Forms.Timer timer;
        public f.WebBrowserForText translatedText;
        internal TipTextBox textNative;
        public System.Windows.Forms.Panel paForeignText;
        internal System.Windows.Forms.Splitter splitterVertical;
    }
}
