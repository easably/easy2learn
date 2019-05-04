namespace f
{
    partial class VideoRateForm
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lbShowInSeconds = new System.Windows.Forms.Label();
            this.btYes = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1070, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 100;
            // 
            // lbShowInSeconds
            // 
            this.lbShowInSeconds.AutoSize = true;
            this.lbShowInSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbShowInSeconds.Location = new System.Drawing.Point(470, 38);
            this.lbShowInSeconds.Name = "lbShowInSeconds";
            this.lbShowInSeconds.Size = new System.Drawing.Size(81, 25);
            this.lbShowInSeconds.TabIndex = 9;
            this.lbShowInSeconds.Text = "{0} rate";
            // 
            // btYes
            // 
            this.btYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btYes.Location = new System.Drawing.Point(516, 111);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(184, 42);
            this.btYes.TabIndex = 7;
            this.btYes.Text = "Apply";
            this.btYes.UseVisualStyleBackColor = true;
            // 
            // btReset
            // 
            this.btReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReset.Location = new System.Drawing.Point(316, 111);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(184, 42);
            this.btReset.TabIndex = 10;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "increase or decrease rate for the video";
            // 
            // VideoRateForm
            // 
            this.AcceptButton = this.btYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 167);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.lbShowInSeconds);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.trackBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoRateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Playback speed";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lbShowInSeconds;
        private System.Windows.Forms.Button btYes;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Label label1;
    }
}