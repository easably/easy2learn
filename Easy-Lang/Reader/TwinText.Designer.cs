namespace f
{
    partial class TwinText
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textForeignAndTran = new f.TextWithTranslate();
            this.paTop = new System.Windows.Forms.Panel();
            this.MenuForSelected = new f.MenuForSelected();
            this.panel1.SuspendLayout();
            this.paTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textForeignAndTran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(876, 322);
            this.panel1.TabIndex = 0;
            // 
            // textForeignAndTran
            // 
            this.textForeignAndTran.BackColor = System.Drawing.SystemColors.Window;
            this.textForeignAndTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textForeignAndTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textForeignAndTran.Location = new System.Drawing.Point(4, 4);
            this.textForeignAndTran.MinimumSize = new System.Drawing.Size(100, 50);
            this.textForeignAndTran.Name = "textForeignAndTran";
            this.textForeignAndTran.Sentence = null;
            this.textForeignAndTran.ShowParrallelText = false;
            this.textForeignAndTran.Size = new System.Drawing.Size(868, 314);
            this.textForeignAndTran.TabIndex = 30;
            // 
            // paTop
            // 
            this.paTop.BackColor = System.Drawing.Color.White;
            this.paTop.Controls.Add(this.MenuForSelected);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(0, 0);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(876, 38);
            this.paTop.TabIndex = 31;
            // 
            // MenuForSelected
            // 
            this.MenuForSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuForSelected.BackColor = System.Drawing.Color.White;
            this.MenuForSelected.IsAddWordToTutor = false;
            this.MenuForSelected.IsAutoHideTranslation = false;
            this.MenuForSelected.IsListenByClick = true;
            this.MenuForSelected.IsShowPopupWindow = true;
            this.MenuForSelected.IsWordAavailable = false;
            this.MenuForSelected.LastDictName = "Google dictionary";
            this.MenuForSelected.Location = new System.Drawing.Point(3, 3);
            this.MenuForSelected.Margin = new System.Windows.Forms.Padding(0);
            this.MenuForSelected.Name = "MenuForSelected";
            this.MenuForSelected.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.MenuForSelected.Size = new System.Drawing.Size(675, 35);
            this.MenuForSelected.TabIndex = 28;
            this.MenuForSelected.TextsForMenu = null;
            this.MenuForSelected.UseGoogleAsMonoDictionary = false;
            // 
            // TwinText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paTop);
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "TwinText";
            this.Size = new System.Drawing.Size(876, 360);
            this.panel1.ResumeLayout(false);
            this.paTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal MenuForSelected MenuForSelected;
        private System.Windows.Forms.Panel paTop;
        public TextWithTranslate textForeignAndTran;
    }
}
