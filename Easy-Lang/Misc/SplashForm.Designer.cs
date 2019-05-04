namespace f
{
    partial class H
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.boxDemo = new System.Windows.Forms.PictureBox();
            this.boxProLabel = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxProLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(672, 427);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbVersion);
            this.panel2.Controls.Add(this.boxDemo);
            this.panel2.Controls.Add(this.boxProLabel);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 421);
            this.panel2.TabIndex = 4;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbVersion.ForeColor = System.Drawing.Color.DimGray;
            this.lbVersion.Location = new System.Drawing.Point(589, 24);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(36, 13);
            this.lbVersion.TabIndex = 21;
            this.lbVersion.Text = "v 2.8";
            // 
            // boxDemo
            // 
            this.boxDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxDemo.Image = global::f.OtherImages._Demo;
            this.boxDemo.Location = new System.Drawing.Point(41, 24);
            this.boxDemo.Name = "boxDemo";
            this.boxDemo.Size = new System.Drawing.Size(89, 32);
            this.boxDemo.TabIndex = 19;
            this.boxDemo.TabStop = false;
            this.boxDemo.Visible = false;
            // 
            // boxProLabel
            // 
            this.boxProLabel.Image = global::f.OtherImages._Extended;
            this.boxProLabel.Location = new System.Drawing.Point(523, 91);
            this.boxProLabel.Name = "boxProLabel";
            this.boxProLabel.Size = new System.Drawing.Size(120, 33);
            this.boxProLabel.TabIndex = 18;
            this.boxProLabel.TabStop = false;
            this.boxProLabel.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::f.OtherImages.SplashMovieSubtitler8bit;
            this.pictureBox2.Location = new System.Drawing.Point(41, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(584, 374);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 427);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "H";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxProLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox boxDemo;
        private System.Windows.Forms.PictureBox boxProLabel;
        private System.Windows.Forms.Label lbVersion;
    }
}