namespace f
{
    partial class Accordion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accordion));
            this.togglePanel = new System.Windows.Forms.Panel();
            this.pictureBoxPlus = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBoxMinus = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.togglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinus)).BeginInit();
            this.SuspendLayout();
            // 
            // togglePanel
            // 
            this.togglePanel.Controls.Add(this.pictureBoxPlus);
            this.togglePanel.Controls.Add(this.linkLabel1);
            this.togglePanel.Controls.Add(this.pictureBoxMinus);
            this.togglePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.togglePanel.Location = new System.Drawing.Point(0, 0);
            this.togglePanel.Name = "togglePanel";
            this.togglePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.togglePanel.Size = new System.Drawing.Size(559, 29);
            this.togglePanel.TabIndex = 4;
            // 
            // pictureBoxPlus
            // 
            this.pictureBoxPlus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlus.Image")));
            this.pictureBoxPlus.Location = new System.Drawing.Point(508, 4);
            this.pictureBoxPlus.Name = "pictureBoxPlus";
            this.pictureBoxPlus.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPlus.TabIndex = 4;
            this.pictureBoxPlus.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(30, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(62, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Example";
            // 
            // pictureBoxMinus
            // 
            this.pictureBoxMinus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinus.Image")));
            this.pictureBoxMinus.Location = new System.Drawing.Point(508, 4);
            this.pictureBoxMinus.Name = "pictureBoxMinus";
            this.pictureBoxMinus.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMinus.TabIndex = 3;
            this.pictureBoxMinus.TabStop = false;
            this.pictureBoxMinus.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 29);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(559, 336);
            this.webBrowser1.TabIndex = 5;
            // 
            // Accordion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.togglePanel);
            this.Name = "Accordion";
            this.Size = new System.Drawing.Size(559, 365);
            this.togglePanel.ResumeLayout(false);
            this.togglePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel togglePanel;
        private System.Windows.Forms.PictureBox pictureBoxPlus;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBoxMinus;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
