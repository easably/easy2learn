namespace f
{
    partial class MenuForSelected
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForSelected));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btAddWordToLesson = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btListenSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btOpenInLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorForSearchInLast = new System.Windows.Forms.ToolStripSeparator();
            this.btOpenIn = new System.Windows.Forms.ToolStripDropDownButton();
            this.btFindInDictionaryBlend = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btFindSynonyms = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbtOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.miHideTranslation = new System.Windows.Forms.ToolStripMenuItem();
            this.miListenByClick = new System.Windows.Forms.ToolStripMenuItem();
            this.miPopupWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.miPopupAsMonoDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetWordToTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditDictionaryBlendOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAddWordToLesson,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.btListenSelected,
            this.toolStripSeparator2,
            this.btOpenInLast,
            this.toolStripSeparatorForSearchInLast,
            this.btOpenIn,
            this.toolStripSeparator5,
            this.btFindSynonyms,
            this.toolStripSeparator3,
            this.ddbtOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAddWordToLesson
            // 
            this.btAddWordToLesson.Image = global::f.Buttons.green16;
            this.btAddWordToLesson.ImageTransparentColor = System.Drawing.Color.White;
            this.btAddWordToLesson.Name = "btAddWordToLesson";
            this.btAddWordToLesson.Size = new System.Drawing.Size(167, 22);
            this.btAddWordToLesson.Text = "Add selected text to lesson";
            this.btAddWordToLesson.ToolTipText = "You can select any text for addition in lesson (Alt-A)";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(129, 22);
            this.toolStripLabel1.Text = "     Actions for selected:";
            this.toolStripLabel1.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btListenSelected
            // 
            this.btListenSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btListenSelected.Image = global::f.button_images.speaker1;
            this.btListenSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btListenSelected.Name = "btListenSelected";
            this.btListenSelected.Size = new System.Drawing.Size(23, 22);
            this.btListenSelected.Text = "Hear Selected Word";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btOpenInLast
            // 
            this.btOpenInLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btOpenInLast.Image = ((System.Drawing.Image)(resources.GetObject("btOpenInLast.Image")));
            this.btOpenInLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpenInLast.Name = "btOpenInLast";
            this.btOpenInLast.Size = new System.Drawing.Size(70, 22);
            this.btOpenInLast.Text = "Find in \'{0}\'";
            this.btOpenInLast.ToolTipText = "Find in the last used dictionary";
            this.btOpenInLast.Visible = false;
            // 
            // toolStripSeparatorForSearchInLast
            // 
            this.toolStripSeparatorForSearchInLast.Name = "toolStripSeparatorForSearchInLast";
            this.toolStripSeparatorForSearchInLast.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparatorForSearchInLast.Visible = false;
            // 
            // btOpenIn
            // 
            this.btOpenIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btOpenIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFindInDictionaryBlend,
            this.toolStripMenuItem1});
            this.btOpenIn.Image = ((System.Drawing.Image)(resources.GetObject("btOpenIn.Image")));
            this.btOpenIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpenIn.Name = "btOpenIn";
            this.btOpenIn.Size = new System.Drawing.Size(71, 22);
            this.btOpenIn.Text = "Find in  ...";
            this.btOpenIn.ToolTipText = "Select a Dictionary for Search";
            // 
            // btFindInDictionaryBlend
            // 
            this.btFindInDictionaryBlend.Image = global::f.button_images.DictionaryBlend;
            this.btFindInDictionaryBlend.Name = "btFindInDictionaryBlend";
            this.btFindInDictionaryBlend.Size = new System.Drawing.Size(250, 22);
            this.btFindInDictionaryBlend.Text = "Open Selected in DictionaryBlend";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btFindSynonyms
            // 
            this.btFindSynonyms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFindSynonyms.Image = ((System.Drawing.Image)(resources.GetObject("btFindSynonyms.Image")));
            this.btFindSynonyms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFindSynonyms.Name = "btFindSynonyms";
            this.btFindSynonyms.Size = new System.Drawing.Size(96, 22);
            this.btFindSynonyms.Text = "Picture for word";
            this.btFindSynonyms.ToolTipText = "Show pictures for Selected Word";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ddbtOptions
            // 
            this.ddbtOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHideTranslation,
            this.miListenByClick,
            this.miPopupWindow,
            this.miPopupAsMonoDictionary,
            this.miGetWordToTutor,
            this.toolStripMenuItem2,
            this.miEditDictionaryBlendOptions});
            this.ddbtOptions.Image = global::f.button_images.Options;
            this.ddbtOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtOptions.Name = "ddbtOptions";
            this.ddbtOptions.Size = new System.Drawing.Size(29, 20);
            this.ddbtOptions.Text = "Options, Feedback, DictionaryBlend, Resources, About ....";
            this.ddbtOptions.ToolTipText = "Options";
            // 
            // miHideTranslation
            // 
            this.miHideTranslation.CheckOnClick = true;
            this.miHideTranslation.Name = "miHideTranslation";
            this.miHideTranslation.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.miHideTranslation.Size = new System.Drawing.Size(320, 22);
            this.miHideTranslation.Text = "Hide Translation (for advanced)";
            this.miHideTranslation.ToolTipText = "Auto-hide Translation for Text";
            // 
            // miListenByClick
            // 
            this.miListenByClick.Checked = true;
            this.miListenByClick.CheckOnClick = true;
            this.miListenByClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miListenByClick.Name = "miListenByClick";
            this.miListenByClick.Size = new System.Drawing.Size(320, 22);
            this.miListenByClick.Text = "Listen a Word on Mouse Click";
            // 
            // miPopupWindow
            // 
            this.miPopupWindow.Checked = true;
            this.miPopupWindow.CheckOnClick = true;
            this.miPopupWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miPopupWindow.Name = "miPopupWindow";
            this.miPopupWindow.Size = new System.Drawing.Size(320, 22);
            this.miPopupWindow.Text = "Pop-up Window on Move Cursor";
            this.miPopupWindow.ToolTipText = "when hover cursor on the word to show translation";
            // 
            // miPopupAsMonoDictionary
            // 
            this.miPopupAsMonoDictionary.CheckOnClick = true;
            this.miPopupAsMonoDictionary.Name = "miPopupAsMonoDictionary";
            this.miPopupAsMonoDictionary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.miPopupAsMonoDictionary.Size = new System.Drawing.Size(320, 22);
            this.miPopupAsMonoDictionary.Text = "Pop-up Window with Mono Dictionary";
            this.miPopupAsMonoDictionary.Visible = false;
            // 
            // miGetWordToTutor
            // 
            this.miGetWordToTutor.CheckOnClick = true;
            this.miGetWordToTutor.Name = "miGetWordToTutor";
            this.miGetWordToTutor.Size = new System.Drawing.Size(320, 22);
            this.miGetWordToTutor.Text = "Add/Remove to lesson on DoubleClick";
            this.miGetWordToTutor.ToolTipText = "Add/Remove selected text to lesson on DoubleClick";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(317, 6);
            // 
            // miEditDictionaryBlendOptions
            // 
            this.miEditDictionaryBlendOptions.Name = "miEditDictionaryBlendOptions";
            this.miEditDictionaryBlendOptions.Size = new System.Drawing.Size(320, 22);
            this.miEditDictionaryBlendOptions.Text = "Edit Favorit List";
            this.miEditDictionaryBlendOptions.ToolTipText = "Options for DictionaryBlend";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 153);
            this.panel1.TabIndex = 6;
            // 
            // MenuForSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuForSelected";
            this.Size = new System.Drawing.Size(633, 141);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miEditDictionaryBlendOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparatorForSearchInLast;
        private System.Windows.Forms.ToolStripMenuItem miListenByClick;
        private System.Windows.Forms.ToolStripMenuItem miPopupWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miPopupAsMonoDictionary;
        private System.Windows.Forms.ToolStripButton btAddWordToLesson;
        private System.Windows.Forms.ToolStripMenuItem miGetWordToTutor;
        private System.Windows.Forms.ToolStripButton btListenSelected;
        internal System.Windows.Forms.ToolStripButton btOpenInLast;
        private System.Windows.Forms.ToolStripButton btFindSynonyms;
        private System.Windows.Forms.ToolStripMenuItem btFindInDictionaryBlend;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton btOpenIn;
        public System.Windows.Forms.ToolStripDropDownButton ddbtOptions;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripMenuItem miHideTranslation;
    }
}
