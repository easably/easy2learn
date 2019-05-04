namespace f
{
    partial class ScoreProgress
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 400;
            this.toolTip1.AutoPopDelay = 6000;
            this.toolTip1.InitialDelay = 400;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 80;
            // 
            // ScoreProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ScoreProgress";
            this.Size = new System.Drawing.Size(619, 93);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScoreProgress_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScoreProgress_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
    }
}
