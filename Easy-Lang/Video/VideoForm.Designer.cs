namespace f
{
    partial class VideoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoForm));
            this.videoControl1 = new f.VideoControl();
            this.paTop = new System.Windows.Forms.Panel();
            this.paLeft = new System.Windows.Forms.Panel();
            this.paRight = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // videoControl1
            // 
            this.videoControl1.AudioLanguageIndex = 0;
            this.videoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoControl1.Location = new System.Drawing.Point(5, 5);
            this.videoControl1.Name = "videoControl1";
            this.videoControl1.Size = new System.Drawing.Size(782, 468);
            this.videoControl1.SkipSynchronize = false;
            this.videoControl1.TabIndex = 0;
            // 
            // paTop
            // 
            this.paTop.BackColor = System.Drawing.Color.White;
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(0, 0);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(792, 5);
            this.paTop.TabIndex = 34;
            // 
            // paLeft
            // 
            this.paLeft.BackColor = System.Drawing.Color.White;
            this.paLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.paLeft.Location = new System.Drawing.Point(0, 5);
            this.paLeft.Name = "paLeft";
            this.paLeft.Size = new System.Drawing.Size(5, 468);
            this.paLeft.TabIndex = 35;
            // 
            // paRight
            // 
            this.paRight.BackColor = System.Drawing.Color.White;
            this.paRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.paRight.Location = new System.Drawing.Point(787, 5);
            this.paRight.Name = "paRight";
            this.paRight.Size = new System.Drawing.Size(5, 468);
            this.paRight.TabIndex = 36;
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.videoControl1);
            this.Controls.Add(this.paRight);
            this.Controls.Add(this.paLeft);
            this.Controls.Add(this.paTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(300, 0);
            this.Name = "VideoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Playing - {0}";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
        #endregion

        private VideoControl videoControl1;
        private System.Windows.Forms.Panel paTop;
        private System.Windows.Forms.Panel paLeft;
        private System.Windows.Forms.Panel paRight;



    }
}