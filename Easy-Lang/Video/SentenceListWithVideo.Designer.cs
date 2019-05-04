namespace f
{
    partial class SentenceListWithVideo
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
            this.openFileDialogForVideo = new System.Windows.Forms.OpenFileDialog();
            this.timerForVideoManualControl = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // openFileDialogForVideo
            // 
            this.openFileDialogForVideo.Filter = "Video allFiles (*.avi)|*.avi|All allFiles (*.*)|*.*";
            // 
            // timerForVideoManualControl
            // 
            this.timerForVideoManualControl.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SentenceListWithVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "SentenceListWithVideo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogForVideo;
        internal System.Windows.Forms.Timer timerForVideoManualControl;
    }
}
