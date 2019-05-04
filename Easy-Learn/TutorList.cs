using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class TutorList : SentenceListWithVideo
    {
        public TutorList()
        {
            InitializeComponent();

            this.openFileDialog.Filter = GlobalOptions.GetFileFilterForLesson(true);

         //   this.ReadOnly = 
            this.toolStripSeparator1.Visible =
            this.toolStripSeparator3.Visible =
            this.toolStripSeparator2.Visible =

            this.btEstimate.Visible =
            this.btFind.Visible =
            this.toolStripMenuItem4.Visible =

            this.miPasteText.Visible =
            this.btOpen.Visible =  //  here file with extension .lesson will be opened how lesson to subtitles
            this.btVideo.Visible =
            this.btTranslate.Visible =

            this.miHowtoAdd.Visible =
            this.miPaste.Visible =
            this.btLesson.Visible = false;

            this.btText.Text = "Lesson File";
            this.btText.Image = null;
        
            this.btText.Visible = true;
            this.menuForList.Visible = false;
            this.btText.DropDownOpening += new EventHandler(btText_DropDownOpening);
            AddExtensions();
            this.Load += new EventHandler(TutorList_Load);
        }

        void TutorList_Load(object sender, EventArgs e)
        {
            this.btText.ToolTipText = "Actions for file with lesson";
            this.miOpenText.ToolTipText = "Оpen file with extension *.lesson"; ;
        }

        #region Extensions
        void btText_DropDownOpening(object sender, EventArgs e)
        {
            this.itemResetLesson.Enabled = !string.IsNullOrEmpty(this.FileName);
        }

        ToolStripMenuItem itemResetLesson = new ToolStripMenuItem("Reopen Lesson");

        private void AddExtensions()
        {
            itemResetLesson.ToolTipText = "To bring the lesson in the initial state";
            this.btText.DropDownItems.Insert(3, itemResetLesson);
            itemResetLesson.Click += new EventHandler(itemResetLessons_Click);
        } 
        #endregion

        void itemResetLessons_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.FileName)) return;
            string fileName = this.FileName;
            this.FileName = "";
            this.FileName = fileName;
        }

        protected override void LoadFile()
        {
            this.ReadOnly = true; //TODO: почему тут непонятно 8(
            try
            {
                List<Sentence> sentences = SentenceForTutor.GetSentencesForTutor(this.FileName);
                this.Sentences = sentences;
                this.btText.ToolTipText = string.Format("Actions for file with lessons (words in lesson - {0})", this.GetWordsCount());
            }
            catch (Exception ex) //(FileNotFoundException)
            {
                string mess = string.Format("File '{0}' could not be opened." + Environment.NewLine + "This file may be corrupted or not suitable", this.FileName);
                this.btText.ToolTipText = mess;
                MessageBox.Show(mess, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.OnClosingText();
                this.OnClosedText();

                // Console.WriteLine(ex);
                Utils.PublicException(ex);
                // продолжаем дальше работать, пользователь может открыть другой файл!
                //throw ex;
            }
        }

        protected override void AssignFilterForTextFile()
        {
            this.openFileDialog.Filter = GlobalOptions.GetFileFilterForLesson(true);
        }

        protected override DialogResult CheckLessonOnSave()
        {
            return DialogResult.None;
        }
    }
}
