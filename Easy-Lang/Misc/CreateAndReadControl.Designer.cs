namespace f.Misc
{
    partial class CreateAndReadControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAndReadControl));
            this.textBox = new System.Windows.Forms.TextBox();
            this.btPasteTextForReading = new System.Windows.Forms.Button();
            this.btRunText = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.paText = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.paText.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(10, 10);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(565, 409);
            this.textBox.TabIndex = 12;
            this.textBox.Text = resources.GetString("textBox.Text");
            // 
            // btPasteTextForReading
            // 
            this.btPasteTextForReading.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btPasteTextForReading.BackColor = System.Drawing.Color.White;
            this.btPasteTextForReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btPasteTextForReading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btPasteTextForReading.Image = ((System.Drawing.Image)(resources.GetObject("btPasteTextForReading.Image")));
            this.btPasteTextForReading.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPasteTextForReading.Location = new System.Drawing.Point(30, 53);
            this.btPasteTextForReading.Name = "btPasteTextForReading";
            this.btPasteTextForReading.Size = new System.Drawing.Size(274, 70);
            this.btPasteTextForReading.TabIndex = 14;
            this.btPasteTextForReading.Text = "     Paste Text";
            this.btPasteTextForReading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btPasteTextForReading, "Ctrl + V");
            this.btPasteTextForReading.UseVisualStyleBackColor = false;
            // 
            // btRunText
            // 
            this.btRunText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btRunText.BackColor = System.Drawing.Color.White;
            this.btRunText.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btRunText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRunText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btRunText.Image = global::f.Buttons.green_arrow_next_48;
            this.btRunText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRunText.Location = new System.Drawing.Point(30, 182);
            this.btRunText.Name = "btRunText";
            this.btRunText.Size = new System.Drawing.Size(274, 70);
            this.btRunText.TabIndex = 13;
            this.btRunText.Text = "     Read Text";
            this.btRunText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btRunText, "Read text by sentences");
            this.btRunText.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btPasteTextForReading);
            this.panel1.Controls.Add(this.btRunText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(592, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 431);
            this.panel1.TabIndex = 15;
            // 
            // paText
            // 
            this.paText.BackColor = System.Drawing.Color.White;
            this.paText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paText.Controls.Add(this.textBox);
            this.paText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paText.Location = new System.Drawing.Point(5, 5);
            this.paText.Name = "paText";
            this.paText.Padding = new System.Windows.Forms.Padding(10);
            this.paText.Size = new System.Drawing.Size(587, 431);
            this.paText.TabIndex = 16;
            // 
            // CreateAndReadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paText);
            this.Controls.Add(this.panel1);
            this.Name = "CreateAndReadControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(911, 441);
            this.panel1.ResumeLayout(false);
            this.paText.ResumeLayout(false);
            this.paText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPasteTextForReading;
        private System.Windows.Forms.Button btRunText;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paText;
    }
}
