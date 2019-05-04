namespace f
{
    partial class FindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.txNote = new System.Windows.Forms.RichTextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paSearch = new System.Windows.Forms.Panel();
            this.txWord = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.paSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // txNote
            // 
            this.txNote.BackColor = System.Drawing.Color.White;
            this.txNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txNote.Location = new System.Drawing.Point(7, 40);
            this.txNote.Name = "txNote";
            this.txNote.ReadOnly = true;
            this.txNote.Size = new System.Drawing.Size(831, 190);
            this.txNote.TabIndex = 1;
            this.txNote.Text = "";
            this.txNote.WordWrap = false;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btClose.Location = new System.Drawing.Point(743, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 47);
            this.panel1.TabIndex = 3;
            // 
            // paSearch
            // 
            this.paSearch.Controls.Add(this.txWord);
            this.paSearch.Controls.Add(this.splitter1);
            this.paSearch.Controls.Add(this.btFind);
            this.paSearch.Controls.Add(this.label1);
            this.paSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.paSearch.Location = new System.Drawing.Point(7, 7);
            this.paSearch.Name = "paSearch";
            this.paSearch.Padding = new System.Windows.Forms.Padding(6);
            this.paSearch.Size = new System.Drawing.Size(831, 33);
            this.paSearch.TabIndex = 4;
            // 
            // txWord
            // 
            this.txWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txWord.Location = new System.Drawing.Point(50, 6);
            this.txWord.Name = "txWord";
            this.txWord.Size = new System.Drawing.Size(690, 20);
            this.txWord.TabIndex = 2;
            this.txWord.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txWord_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(740, 6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 21);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // btFind
            // 
            this.btFind.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.btFind.Location = new System.Drawing.Point(750, 6);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 21);
            this.btFind.TabIndex = 4;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(845, 284);
            this.Controls.Add(this.txNote);
            this.Controls.Add(this.paSearch);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(853, 311);
            this.Name = "FindForm";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.panel1.ResumeLayout(false);
            this.paSearch.ResumeLayout(false);
            this.paSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txNote;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paSearch;
        private System.Windows.Forms.TextBox txWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btFind;
    }
}