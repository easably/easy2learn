namespace f
{
    partial class RunForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCommon = new System.Windows.Forms.Panel();
            this.panelWhite = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelCommon.SuspendLayout();
            this.panelWhite.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btSelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 21);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(68, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(437, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "File name:  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSelectFile
            // 
            this.btSelectFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSelectFile.Location = new System.Drawing.Point(505, 0);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(39, 21);
            this.btSelectFile.TabIndex = 3;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Arial", 8F);
            this.okButton.Location = new System.Drawing.Point(401, 36);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(136, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Next -->>";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Arial", 8F);
            this.button1.Location = new System.Drawing.Point(259, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            // 
            // panelCommon
            // 
            this.panelCommon.BackColor = System.Drawing.Color.Gray;
            this.panelCommon.Controls.Add(this.panelWhite);
            this.panelCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommon.Location = new System.Drawing.Point(0, 0);
            this.panelCommon.Name = "panelCommon";
            this.panelCommon.Padding = new System.Windows.Forms.Padding(5);
            this.panelCommon.Size = new System.Drawing.Size(568, 79);
            this.panelCommon.TabIndex = 5;
            // 
            // panelWhite
            // 
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Controls.Add(this.panel1);
            this.panelWhite.Controls.Add(this.okButton);
            this.panelWhite.Controls.Add(this.button1);
            this.panelWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWhite.Location = new System.Drawing.Point(5, 5);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Padding = new System.Windows.Forms.Padding(7);
            this.panelWhite.Size = new System.Drawing.Size(558, 69);
            this.panelWhite.TabIndex = 5;
            // 
            // RunForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 79);
            this.Controls.Add(this.panelCommon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(584, 118);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(584, 118);
            this.Name = "RunForm";
            this.ShowInTaskbar = false;
            this.Text = "Choose a file name for estimating";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCommon.ResumeLayout(false);
            this.panelWhite.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCommon;
        private System.Windows.Forms.Panel panelWhite;
    }
}