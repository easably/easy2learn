namespace f
{
    partial class OpenURLForm
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
            this.btYes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txURLforDownload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.llbHowGetURL = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btYes
            // 
            this.btYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btYes.Location = new System.Drawing.Point(414, 211);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(195, 39);
            this.btYes.TabIndex = 4;
            this.btYes.Text = "Download";
            this.btYes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(22, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 148);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txURLforDownload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.panel2.Size = new System.Drawing.Size(992, 146);
            this.panel2.TabIndex = 4;
            // 
            // txURLforDownload
            // 
            this.txURLforDownload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txURLforDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txURLforDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txURLforDownload.Location = new System.Drawing.Point(8, 7);
            this.txURLforDownload.Multiline = true;
            this.txURLforDownload.Name = "txURLforDownload";
            this.txURLforDownload.Size = new System.Drawing.Size(979, 134);
            this.txURLforDownload.TabIndex = 3;
            this.txURLforDownload.Text = "http://download.ted.com/talks/AndrewSolomon_2013P.mp4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(28, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "URL from internet (MP4, FLV4):";
            // 
            // llbHowGetURL
            // 
            this.llbHowGetURL.AutoSize = true;
            this.llbHowGetURL.Location = new System.Drawing.Point(31, 31);
            this.llbHowGetURL.Name = "llbHowGetURL";
            this.llbHowGetURL.Size = new System.Drawing.Size(269, 13);
            this.llbHowGetURL.TabIndex = 14;
            this.llbHowGetURL.TabStop = true;
            this.llbHowGetURL.Text = "How get URL for downloading video fromYouTube.com";
            this.llbHowGetURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbHowGetURL_LinkClicked);
            // 
            // OpenURLForm
            // 
            this.AcceptButton = this.btYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 262);
            this.Controls.Add(this.llbHowGetURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btYes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenURLForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Specify video-URL for opening video directly from the Internet";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btYes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txURLforDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llbHowGetURL;
    }
}