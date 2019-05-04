namespace f
{
    partial class FilesControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesControllerForm));
            this.filesController1 = new f.FilesController();
            this.SuspendLayout();
            // 
            // filesController1
            // 
            this.filesController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesController1.Location = new System.Drawing.Point(0, 0);
            this.filesController1.Name = "filesController1";
            this.filesController1.Size = new System.Drawing.Size(903, 488);
            this.filesController1.TabIndex = 0;
            // 
            // FilesControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 488);
            this.Controls.Add(this.filesController1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilesControllerForm";
            this.Text = "FilesControllerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private FilesController filesController1;
    }
}