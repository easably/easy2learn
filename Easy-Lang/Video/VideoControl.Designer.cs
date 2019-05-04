namespace f
{
    partial class VideoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoControl));
            this.timerForSync = new System.Windows.Forms.Timer(this.components);
            this.mainMenu1 = new f.key.MainMenu();
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.BackColor = System.Drawing.Color.White;
            this.mainMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenu1.Location = new System.Drawing.Point(5, 5);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Padding = new System.Windows.Forms.Padding(5);
            this.mainMenu1.Size = new System.Drawing.Size(1147, 36);
            this.mainMenu1.TabIndex = 34;
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(5, 41);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(1147, 403);
            this.Player.TabIndex = 3;
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Player);
            this.Controls.Add(this.mainMenu1);
            this.Name = "VideoControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1157, 449);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerForSync;
        public AxWMPLib.AxWindowsMediaPlayer Player;
        internal key.MainMenu mainMenu1;
    }
}
