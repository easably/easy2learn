namespace f
{
    partial class FilesController
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paBorderVideo = new System.Windows.Forms.Panel();
            this.paPaddingVideo = new System.Windows.Forms.Panel();
            this.txVideoFile = new System.Windows.Forms.TextBox();
            this.btVideoOpen = new System.Windows.Forms.Button();
            this.paBorderSubt = new System.Windows.Forms.Panel();
            this.paPaddingSubt = new System.Windows.Forms.Panel();
            this.txSubtFile = new System.Windows.Forms.TextBox();
            this.btSubtitleOpen = new System.Windows.Forms.Button();
            this.paBorderVideo.SuspendLayout();
            this.paPaddingVideo.SuspendLayout();
            this.paBorderSubt.SuspendLayout();
            this.paPaddingSubt.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movie file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(20, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subtitle file:";
            // 
            // paBorderVideo
            // 
            this.paBorderVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paBorderVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paBorderVideo.Controls.Add(this.paPaddingVideo);
            this.paBorderVideo.Controls.Add(this.btVideoOpen);
            this.paBorderVideo.Location = new System.Drawing.Point(111, 5);
            this.paBorderVideo.Name = "paBorderVideo";
            this.paBorderVideo.Size = new System.Drawing.Size(506, 34);
            this.paBorderVideo.TabIndex = 6;
            // 
            // paPaddingVideo
            // 
            this.paPaddingVideo.BackColor = System.Drawing.Color.White;
            this.paPaddingVideo.Controls.Add(this.txVideoFile);
            this.paPaddingVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPaddingVideo.Location = new System.Drawing.Point(0, 0);
            this.paPaddingVideo.Name = "paPaddingVideo";
            this.paPaddingVideo.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.paPaddingVideo.Size = new System.Drawing.Size(451, 32);
            this.paPaddingVideo.TabIndex = 4;
            // 
            // txVideoFile
            // 
            this.txVideoFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txVideoFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txVideoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txVideoFile.Location = new System.Drawing.Point(8, 7);
            this.txVideoFile.Name = "txVideoFile";
            this.txVideoFile.Size = new System.Drawing.Size(438, 16);
            this.txVideoFile.TabIndex = 3;
            this.txVideoFile.Text = "11-_22";
            // 
            // btVideoOpen
            // 
            this.btVideoOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btVideoOpen.ForeColor = System.Drawing.Color.Black;
            this.btVideoOpen.Location = new System.Drawing.Point(451, 0);
            this.btVideoOpen.Name = "btVideoOpen";
            this.btVideoOpen.Size = new System.Drawing.Size(53, 32);
            this.btVideoOpen.TabIndex = 6;
            this.btVideoOpen.Text = ". . . ";
            this.btVideoOpen.UseVisualStyleBackColor = true;
            // 
            // paBorderSubt
            // 
            this.paBorderSubt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paBorderSubt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paBorderSubt.Controls.Add(this.paPaddingSubt);
            this.paBorderSubt.Controls.Add(this.btSubtitleOpen);
            this.paBorderSubt.Location = new System.Drawing.Point(122, 106);
            this.paBorderSubt.Name = "paBorderSubt";
            this.paBorderSubt.Size = new System.Drawing.Size(317, 34);
            this.paBorderSubt.TabIndex = 7;
            // 
            // paPaddingSubt
            // 
            this.paPaddingSubt.BackColor = System.Drawing.Color.White;
            this.paPaddingSubt.Controls.Add(this.txSubtFile);
            this.paPaddingSubt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPaddingSubt.Location = new System.Drawing.Point(0, 0);
            this.paPaddingSubt.Name = "paPaddingSubt";
            this.paPaddingSubt.Padding = new System.Windows.Forms.Padding(8, 7, 5, 5);
            this.paPaddingSubt.Size = new System.Drawing.Size(263, 32);
            this.paPaddingSubt.TabIndex = 4;
            // 
            // txSubtFile
            // 
            this.txSubtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txSubtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSubtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txSubtFile.Location = new System.Drawing.Point(8, 7);
            this.txSubtFile.Name = "txSubtFile";
            this.txSubtFile.Size = new System.Drawing.Size(250, 16);
            this.txSubtFile.TabIndex = 3;
            this.txSubtFile.Text = "11-_22";
            // 
            // btSubtitleOpen
            // 
            this.btSubtitleOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSubtitleOpen.ForeColor = System.Drawing.Color.Black;
            this.btSubtitleOpen.Location = new System.Drawing.Point(263, 0);
            this.btSubtitleOpen.Name = "btSubtitleOpen";
            this.btSubtitleOpen.Size = new System.Drawing.Size(52, 32);
            this.btSubtitleOpen.TabIndex = 6;
            this.btSubtitleOpen.Text = ". . . ";
            this.btSubtitleOpen.UseVisualStyleBackColor = true;
            // 
            // FilesController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paBorderSubt);
            this.Controls.Add(this.paBorderVideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FilesController";
            this.Size = new System.Drawing.Size(813, 423);
            this.paBorderVideo.ResumeLayout(false);
            this.paPaddingVideo.ResumeLayout(false);
            this.paPaddingVideo.PerformLayout();
            this.paBorderSubt.ResumeLayout(false);
            this.paPaddingSubt.ResumeLayout(false);
            this.paPaddingSubt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel paBorderVideo;
        private System.Windows.Forms.Panel paPaddingVideo;
        private System.Windows.Forms.TextBox txVideoFile;
        private System.Windows.Forms.Button btVideoOpen;
        private System.Windows.Forms.Panel paBorderSubt;
        private System.Windows.Forms.Panel paPaddingSubt;
        private System.Windows.Forms.TextBox txSubtFile;
        private System.Windows.Forms.Button btSubtitleOpen;
    }
}
