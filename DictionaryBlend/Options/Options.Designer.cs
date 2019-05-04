namespace f
{
    partial class Options
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
            this.components = new System.ComponentModel.Container();
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.cbGenerateArticlesWithJScript = new System.Windows.Forms.CheckBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listDict = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(799, 10);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Cancel";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 45);
            this.panel1.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(718, 10);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Ok";
            // 
            // cbGenerateArticlesWithJScript
            // 
            this.cbGenerateArticlesWithJScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbGenerateArticlesWithJScript.AutoSize = true;
            this.cbGenerateArticlesWithJScript.Location = new System.Drawing.Point(22, 405);
            this.cbGenerateArticlesWithJScript.Name = "cbGenerateArticlesWithJScript";
            this.cbGenerateArticlesWithJScript.Size = new System.Drawing.Size(145, 17);
            this.cbGenerateArticlesWithJScript.TabIndex = 4;
            this.cbGenerateArticlesWithJScript.Text = "Auto expandable articles ";
            this.helpToolTip.SetToolTip(this.cbGenerateArticlesWithJScript, "Generate Article With JScript");
            this.cbGenerateArticlesWithJScript.UseVisualStyleBackColor = true;
            this.cbGenerateArticlesWithJScript.Visible = false;
            // 
            // listDict
            // 
            this.listDict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listDict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDict.FormattingEnabled = true;
            this.listDict.HorizontalScrollbar = true;
            this.listDict.Location = new System.Drawing.Point(22, 31);
            this.listDict.Name = "listDict";
            this.listDict.Size = new System.Drawing.Size(869, 362);
            this.listDict.TabIndex = 5;
            this.listDict.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listDict_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search in favorit Dictionaries:";
            // 
            // Options
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(901, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDict);
            this.Controls.Add(this.cbGenerateArticlesWithJScript);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbGenerateArticlesWithJScript;
        private System.Windows.Forms.CheckedListBox listDict;
    }
}