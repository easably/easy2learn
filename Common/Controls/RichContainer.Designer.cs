namespace f
{
    partial class RichContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RichContainer));
            this.togglePanel = new System.Windows.Forms.Panel();
            this.pictureBoxPlus = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBoxMinus = new System.Windows.Forms.PictureBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.togglePanel.Location = new System.Drawing.Point(8, 4);
            this.togglePanel.Name = "togglePanel";
            this.togglePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.togglePanel.Size = new System.Drawing.Size(441, 29);
            this.togglePanel.TabIndex = 3;
            this.togglePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // pictureBoxPlus
            // 
            this.pictureBoxPlus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlus.Image")));
            this.pictureBoxPlus.Location = new System.Drawing.Point(16, 8);
            this.pictureBoxPlus.Name = "pictureBoxPlus";
            this.pictureBoxPlus.Size = new System.Drawing.Size(10, 16);
            this.pictureBoxPlus.TabIndex = 4;
            this.pictureBoxPlus.TabStop = false;
            this.pictureBoxPlus.Click += new System.EventHandler(this.pictureBoxSwitcher_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(30, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(62, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Example";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBoxMinus
            // 
            this.pictureBoxMinus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinus.Image")));
            this.pictureBoxMinus.Location = new System.Drawing.Point(16, 8);
            this.pictureBoxMinus.Name = "pictureBoxMinus";
            this.pictureBoxMinus.Size = new System.Drawing.Size(10, 16);
            this.pictureBoxMinus.TabIndex = 3;
            this.pictureBoxMinus.TabStop = false;
            this.pictureBoxMinus.Visible = false;
            this.pictureBoxMinus.Click += new System.EventHandler(this.pictureBoxSwitcher_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(8, 33);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(441, 352);
            this.richTextBox.TabIndex = 4;
            this.richTextBox.Text = resources.GetString("richTextBox.Text");
            this.richTextBox.DoubleClick += new System.EventHandler(this.richTextBox_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "untitled+.bmp");
            this.imageList1.Images.SetKeyName(1, "untitled-.bmp");
            // 
            // RichContainer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.togglePanel);
            this.Name = "RichContainer";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.Size = new System.Drawing.Size(453, 389);
            this.BackColorChanged += new System.EventHandler(this.RichContainer_BackColorChanged);
            this.togglePanel.ResumeLayout(false);
            this.togglePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel togglePanel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBoxMinus;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxPlus;
        internal System.Windows.Forms.RichTextBox richTextBox;
    }
}