namespace f
{
    partial class EuronewsBrowser
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
            this.WWindow = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // WWindow
            // 
            this.WWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WWindow.Location = new System.Drawing.Point(0, 0);
            this.WWindow.Name = "WWindow";
            this.WWindow.Size = new System.Drawing.Size(963, 524);
            this.WWindow.TabIndex = 8;
            this.WWindow.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::f.OtherImages.icon_wait;
            this.pictureBox1.Location = new System.Drawing.Point(408, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 118);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // EuronewsBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WWindow);
            this.Name = "EuronewsBrowser";
            this.Size = new System.Drawing.Size(963, 524);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WWindow;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
