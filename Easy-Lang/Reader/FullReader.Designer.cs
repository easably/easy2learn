namespace f
{
    partial class FullReader
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TwinList = new f.TwinList();
            this.TwinText = new f.TwinText();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Window;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 320);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1095, 10);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            this.splitter1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter1_Paint);
            // 
            // TwinList
            // 
            this.TwinList.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TwinList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TwinList.Location = new System.Drawing.Point(0, 0);
            this.TwinList.Name = "TwinList";
            this.TwinList.ShowParrallelSubtitles = false;
            this.TwinList.Size = new System.Drawing.Size(1095, 330);
            this.TwinList.TabIndex = 0;
            // 
            // TwinText
            // 
            this.TwinText.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TwinText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TwinText.Location = new System.Drawing.Point(0, 330);
            this.TwinText.MinimumSize = new System.Drawing.Size(200, 200);
            this.TwinText.Name = "TwinText";
            this.TwinText.Size = new System.Drawing.Size(1095, 256);
            this.TwinText.TabIndex = 1;
            // 
            // FullReader
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TwinList);
            this.Controls.Add(this.TwinText);
            this.Name = "FullReader";
            this.Size = new System.Drawing.Size(1095, 586);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        public TwinList TwinList;
        public TwinText TwinText;
    }
}
