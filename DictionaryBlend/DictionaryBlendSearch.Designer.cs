namespace f
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelUnderComboBox = new System.Windows.Forms.Panel();
            this.webBrowser1 = new f.WebBrowserForForm();
            this.panelOverBrowser = new System.Windows.Forms.Panel();
            this.pictureBoxWating = new System.Windows.Forms.PictureBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.toolStripDictionary = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.miLanguages = new System.Windows.Forms.ToolStripDropDownButton();
            this.panelMainBorder = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelUnderComboBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).BeginInit();
            this.toolStripDictionary.SuspendLayout();
            this.toolStripMainMenu.SuspendLayout();
            this.panelMainBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.toolStripDictionary);
            this.panelMain.Controls.Add(this.panel5);
            this.panelMain.Controls.Add(this.toolStripMainMenu);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(4);
            this.panelMain.Size = new System.Drawing.Size(768, 646);
            this.panelMain.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(169, 33);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(595, 609);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelUnderComboBox);
            this.panel3.Controls.Add(this.pictureBoxWating);
            this.panel3.Controls.Add(this.comboBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6);
            this.panel3.Size = new System.Drawing.Size(581, 595);
            this.panel3.TabIndex = 26;
            // 
            // panelUnderComboBox
            // 
            this.panelUnderComboBox.Controls.Add(this.webBrowser1);
            this.panelUnderComboBox.Controls.Add(this.panelOverBrowser);
            this.panelUnderComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnderComboBox.Location = new System.Drawing.Point(6, 34);
            this.panelUnderComboBox.Name = "panelUnderComboBox";
            this.panelUnderComboBox.Size = new System.Drawing.Size(569, 555);
            this.panelUnderComboBox.TabIndex = 26;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.OpenUrlInExternalWindow = true;
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(569, 551);
            this.webBrowser1.TabIndex = 25;
            // 
            // panelOverBrowser
            // 
            this.panelOverBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOverBrowser.Location = new System.Drawing.Point(0, 0);
            this.panelOverBrowser.Name = "panelOverBrowser";
            this.panelOverBrowser.Size = new System.Drawing.Size(569, 4);
            this.panelOverBrowser.TabIndex = 26;
            // 
            // pictureBoxWating
            // 
            this.pictureBoxWating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWating.Image = global::f.Properties.Resources.icon_wait;
            this.pictureBoxWating.Location = new System.Drawing.Point(637, 16);
            this.pictureBoxWating.Name = "pictureBoxWating";
            this.pictureBoxWating.Size = new System.Drawing.Size(21, 21);
            this.pictureBoxWating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWating.TabIndex = 23;
            this.pictureBoxWating.TabStop = false;
            this.pictureBoxWating.Visible = false;
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(6, 6);
            this.comboBox.MaxDropDownItems = 55;
            this.comboBox.MinimumSize = new System.Drawing.Size(220, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(569, 28);
            this.comboBox.TabIndex = 0;
            this.comboBox.Text = "Welcome";
            this.comboBox.TextChanged += new System.EventHandler(this.cb_TextChanged);
            this.comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_KeyDown);
            // 
            // toolStripDictionary
            // 
            this.toolStripDictionary.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripDictionary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.toolStripDictionary.Location = new System.Drawing.Point(4, 33);
            this.toolStripDictionary.Name = "toolStripDictionary";
            this.toolStripDictionary.Size = new System.Drawing.Size(165, 609);
            this.toolStripDictionary.TabIndex = 26;
            this.toolStripDictionary.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(162, 15);
            this.toolStripLabel1.Text = "---  Dictionaries for Search ---";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(760, 4);
            this.panel5.TabIndex = 28;
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLanguages});
            this.toolStripMainMenu.Location = new System.Drawing.Point(4, 4);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(760, 25);
            this.toolStripMainMenu.TabIndex = 27;
            this.toolStripMainMenu.Text = "toolStrip1";
            // 
            // miLanguages
            // 
            this.miLanguages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miLanguages.Image = ((System.Drawing.Image)(resources.GetObject("miLanguages.Image")));
            this.miLanguages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miLanguages.Name = "miLanguages";
            this.miLanguages.Size = new System.Drawing.Size(106, 22);
            this.miLanguages.Text = "Select Language";
            this.miLanguages.ToolTipText = "Select Language Pair";
            // 
            // panelMainBorder
            // 
            this.panelMainBorder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMainBorder.Controls.Add(this.panelMain);
            this.panelMainBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBorder.Location = new System.Drawing.Point(4, 4);
            this.panelMainBorder.Name = "panelMainBorder";
            this.panelMainBorder.Padding = new System.Windows.Forms.Padding(4);
            this.panelMainBorder.Size = new System.Drawing.Size(776, 654);
            this.panelMainBorder.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.panelMainBorder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelUnderComboBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWating)).EndInit();
            this.toolStripDictionary.ResumeLayout(false);
            this.toolStripDictionary.PerformLayout();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.panelMainBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.PictureBox pictureBoxWating;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private f.WebBrowserForForm webBrowser1;
        private System.Windows.Forms.Panel panelUnderComboBox;
        private System.Windows.Forms.ToolStrip toolStripDictionary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripDropDownButton miLanguages;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelOverBrowser;
        private System.Windows.Forms.Panel panelMainBorder;
    }
}