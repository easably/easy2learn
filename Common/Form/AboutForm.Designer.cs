namespace f
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lbMain = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.linkHomePage = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbIAgree = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGoToHomePage = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbDictionaryBlendAddition = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMain.Location = new System.Drawing.Point(31, 21);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(150, 18);
            this.lbMain.TabIndex = 3;
            this.lbMain.Text = "DictionaryBlend vX";
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Font = new System.Drawing.Font("Arial", 8F);
            this.btOK.Location = new System.Drawing.Point(363, 454);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.okButton_Click);
            this.btOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);
            // 
            // linkHomePage
            // 
            this.linkHomePage.AutoSize = true;
            this.linkHomePage.Location = new System.Drawing.Point(102, 71);
            this.linkHomePage.Name = "linkHomePage";
            this.linkHomePage.Size = new System.Drawing.Size(139, 13);
            this.linkHomePage.TabIndex = 1;
            this.linkHomePage.TabStop = true;
            this.linkHomePage.Tag = "http://www.forcemem.com/";
            this.linkHomePage.Text = "http://www.forcemem.com/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "© Forcemem 2008-2013";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(102, 95);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(139, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.Text = "easy4learn.com@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomePage_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "e-mail:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(434, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Program Producer:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(427, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(378, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // cbIAgree
            // 
            this.cbIAgree.AutoSize = true;
            this.cbIAgree.Location = new System.Drawing.Point(34, 421);
            this.cbIAgree.Name = "cbIAgree";
            this.cbIAgree.Size = new System.Drawing.Size(110, 17);
            this.cbIAgree.TabIndex = 11;
            this.cbIAgree.Text = "I Read and Agree";
            this.cbIAgree.UseVisualStyleBackColor = true;
            this.cbIAgree.Visible = false;
            this.cbIAgree.CheckedChanged += new System.EventHandler(this.cbIAgree_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(393, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(11, 417);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // cbGoToHomePage
            // 
            this.cbGoToHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGoToHomePage.AutoSize = true;
            this.cbGoToHomePage.Checked = true;
            this.cbGoToHomePage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGoToHomePage.Location = new System.Drawing.Point(437, 314);
            this.cbGoToHomePage.Name = "cbGoToHomePage";
            this.cbGoToHomePage.Size = new System.Drawing.Size(142, 17);
            this.cbGoToHomePage.TabIndex = 14;
            this.cbGoToHomePage.Text = "Open the producer page";
            this.cbGoToHomePage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Home page:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(24, 131);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(343, 190);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tbDictionaryBlendAddition
            // 
            this.tbDictionaryBlendAddition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDictionaryBlendAddition.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDictionaryBlendAddition.Location = new System.Drawing.Point(24, 327);
            this.tbDictionaryBlendAddition.Multiline = true;
            this.tbDictionaryBlendAddition.Name = "tbDictionaryBlendAddition";
            this.tbDictionaryBlendAddition.ReadOnly = true;
            this.tbDictionaryBlendAddition.Size = new System.Drawing.Size(364, 88);
            this.tbDictionaryBlendAddition.TabIndex = 17;
            this.tbDictionaryBlendAddition.Text = resources.GetString("tbDictionaryBlendAddition.Text");
            this.tbDictionaryBlendAddition.Visible = false;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btOK;
            this.ClientSize = new System.Drawing.Size(830, 489);
            this.Controls.Add(this.tbDictionaryBlendAddition);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGoToHomePage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbIAgree);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.linkHomePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AboutForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.LinkLabel linkHomePage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOK;
        internal System.Windows.Forms.CheckBox cbGoToHomePage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbDictionaryBlendAddition;
        public System.Windows.Forms.CheckBox cbIAgree;
    }
}