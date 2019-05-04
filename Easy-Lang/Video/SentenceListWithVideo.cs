using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Diagnostics;
//using Istrib.Sound;

namespace f
{
    public partial class SentenceListWithVideo : SentenceList
    {
        public SentenceListWithVideo()
        {
            InitializeComponent();
            this.btLesson.Visible = true;
            this.btLesson.MouseMove += new MouseEventHandler(btLesson_MouseMove);

            // -------------- Video -------------------
            this.btVideo.Visible = true;
            this.btVideo.DropDownOpening += new System.EventHandler(this.btVideo_DropDownOpening);
            this.miCloseVideo.Click += new EventHandler(btCloseVideo_Click);
            this.miOpenVideo.Click += new EventHandler(btOpenVideo_Click);
            this.miOopenURL.Click += new EventHandler(miOopenURL_Click);
            this.miTimeShift.Click += new EventHandler(miTimeShift_Click);

            this.toolStripLabelIndent.Click += new EventHandler(miTimeShift_Click);
            this.toolStripLabelIndent.ToolTipText = "Time Shift for Video";


            this.miPauseVideo.Click += new EventHandler(miPauseVideo_Click);
            this.miSynchronizeVideo.Click += new EventHandler(miSynchronizeVideo_Click);

            
//            this.miOpenVideo.Image = global::f.res.button_images.NewBeta;
            //            this.miOpenVideo.Image = global::f.res.button_images._new;
            this.miVideoRate.Image = global::f.button_images.turtle_side_view;
            this.List.SelectedIndexChanged += new EventHandler(List_SelectedIndexChanged);

//            this.miRepeatVideo.Visible = true;
//            this.miRepeatVideo.Image = global::f.res.button_images.Repeat;
            this.miRepeatVideo.Click += new EventHandler(miRepeatVideo_Click);
            
//            this.miSynchronizeWithVideo.Visible = true;
            this.miSynchronizeWithVideo.Click += new EventHandler(miFindFromVideo_Click);

            this.btText.DropDownOpening += new EventHandler(moreMenuButton_Click);
  //          this.menuForList.Opening += new CancelEventHandler(menuForList_Opening);

            // --- lesson
            this.miWriteAllSounds.Click += new System.EventHandler(this.miWriteAllSounds_Click);
            this.btLesson.DropDownOpening += new System.EventHandler(this.lessonMenuButton_DropDownOpening);
            this.miSaveLesson.Click += new EventHandler(this.miSaveLesson_Click);
            this.miSaveAsLesson.Click += new System.EventHandler(this.miSaveAsLesson_Click);
            this.miCloseLesson.Click += new System.EventHandler(this.miCloseLesson_Click);
            this.miOpenLesson.Click += new System.EventHandler(this.miOpenLesson_Click);
            this.miSaveAndRunVocabularyTutor.Click += new EventHandler(miSaveAndRunVocabularyTutor_Click);
            this.miAboutLesson.Click += new System.EventHandler(this.miAboutLesson_Click);

            this.miHowtoAdd.Click += new System.EventHandler(this.miAboutLesson_Click);
            this.miHowtoAddFunctionalities.Click += new System.EventHandler(this.miAboutLesson_Click);

            // --- common
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            this.miAudioLanguage.DropDownOpening += new EventHandler(miAudioLanguage_Click);

            GlobalOptions.ChangedLesson += new EventHandler(GlobalOptions_ChangedLesson);

#region for share
#if PRO
            const bool isFullVersion = true;
#else
            const bool isFullVersion = false;

#endif
            
            this.btFind.Visible = 
            this.btEstimate.Visible =
            this.miTimeShift.Visible =
            this.miAudioLanguage.Visible = isFullVersion;

            this.miHowtoAdd.Visible =
            this.miAboutLesson.Visible =
            //this.stripAboveAboutVT.Visible =
            this.miHowtoAddFunctionalities.Visible = !isFullVersion;

            SetBoldStily(this.miHowtoAddFunctionalities);
            SetBoldStily(this.miHowtoAdd);
            SetBoldStily(this.miAboutLesson);
            SetBoldStily(this.miSaveAndRunVocabularyTutor); 
#endregion
            toolStripSeparator1.Visible = 
            toolStripSeparator3.Visible = true;
        }

        void SetBoldStily(ToolStripMenuItem menuItem)
        {
            //menuItem.Font = new System.Drawing.Font(menuItem.Font, System.Drawing.FontStyle.Bold);
            //menuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        #region btLesson.ToolTipText
        protected int GetWordsCount()
        {
            int res = 0;
            if (this.Sentences == null) return 0;
            foreach (Sentence sent in this.Sentences)
            {
                res += sent.WordsToLearn.Count; // неуникальные слова тоже считаем т.к. могут быть разные словозначения
            }
            return res;
        }

        void btLesson_MouseMove(object sender, MouseEventArgs e)
        {
            this.btLesson.ToolTipText = string.Format("Actions for file with lesson (words in this lesson - {0})", GetWordsCount());
        } 
        #endregion

        #region AudioLanguages
        bool IsVideoChanged = false;

        void miAudioLanguage_Click(object sender, EventArgs e)
        {
            if (VideoForm.IsVideoControlAccesible && IsVideoChanged)
            {
                Dictionary<int, string> langs = VideoForm.CurrentVideoContrl.GetAudioLanguages();
                if (langs.Count > 0)
                {
                    this.miAudioLanguage.DropDownItems.Clear();
                    foreach (KeyValuePair<int, string> pair in langs)
                    {
                        ToolStripMenuItem mi = new ToolStripMenuItem()
                        {
                            Checked = pair.Key == VideoForm.CurrentVideoContrl.AudioLanguageIndex,
                            CheckOnClick = true,
                            // CheckState = System.Windows.Forms.CheckState.Checked,
                            Name = "miUnknown",
                            Size = new System.Drawing.Size(152, 22),
                            Tag = pair.Key,
                            Text = pair.Value,
                        };
                        if (string.IsNullOrEmpty(mi.Text)) mi.Text = "";
                        mi.Click += new EventHandler(miSelectAudio_Click);
                        this.miAudioLanguage.DropDownItems.Add(mi);                      
                    }
                }
            }
        }

        void miSelectAudio_Click(object sender, EventArgs e)
        {
            if (VideoForm.IsVideoControlAccesible)
                VideoForm.CurrentVideoContrl.AudioLanguageIndex = (int)((ToolStripMenuItem)sender).Tag;
        }

        private void ClearAudioLanguages()
        {
            this.miAudioLanguage.DropDownItems.Clear();
            this.miAudioLanguage.DropDownItems.Add(this.miUnknown);
            IsVideoChanged = true;
        } 
        #endregion

        void GlobalOptions_ChangedLesson(object sender, EventArgs e)
        {
            CheckImageByLessonState();
        }
        
        void CheckImageByLessonState()
        {
            if (this.IsHaveLesson)
            {
                if (string.IsNullOrEmpty(this.LessonFileName))
                {
                    this.btLesson.Image = global::f.button_images.YellowDotSmall;
                }
                else if (GlobalOptions.IsChangedLesson)
                {
                    this.btLesson.Image = global::f.button_images.GreenYellowDotSmall;
                }
                else
                {
                    this.btLesson.Image = global::f.button_images.GreenDotSmall;
                }
            }
            else this.btLesson.Image = null;
        }

        void miPauseVideo_Click(object sender, EventArgs e)
        {
            if (VideoForm.IsVideoControlAccesible)
                VideoForm.CurrentVideoContrl.PlayOrPause();            
        }

        #region common file open
        private void btOpen_Click(object sender, EventArgs e)
        {
            this.OpenFileUI();
        }

        // common open for all allFiles
        internal override void OpenFileUI()
        {
            this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                using (new FilterFileDialog(this.openFileDialog))
                {
                    this.openFileDialog.Filter = GlobalOptions.GetFileFilterForVideo(false);
                    this.openFileDialog.Filter += "|" + GlobalOptions.GetFileFilterForSubtitles(false);
                    this.openFileDialog.Filter += "|" + GlobalOptions.GetFileFilterForLesson(false);
                    this.openFileDialog.Filter += "|" + GlobalOptions.GetFileFilterForText(false);
                    this.openFileDialog.Filter += GlobalOptions.Allfiles;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        CheckAndAssignFileNameFormUI(openFileDialog.FileName);
                }
            }
        }

        internal void CheckAndAssignFileNameFormUI(string fileName)
        {
            if (GlobalOptions.IsVideo(fileName))
            {
                this.VideoFileName = fileName;
                SuggestTextFile(this.VideoFileName);
            }
            else if (GlobalOptions.IsSubtitle(fileName) || GlobalOptions.IsText(fileName))
            {
                this.FileName = fileName;
                SuggestVideoFile(this.FileName);                
                SuggestLessonFile();
            }
            else if (GlobalOptions.IsLesson(fileName))
            {
                this.LessonFileName = fileName;
            }
        }
        #endregion

        #region Time Shift
        SentennceShiftForm m_SentennceShiftForm = null;

        void miTimeShift_Click(object sender, EventArgs e)
        {
            if (this.m_SentennceShiftForm == null)
                this.m_SentennceShiftForm = new SentennceShiftForm();
            m_SentennceShiftForm.TimeShift = this.TimeShift;
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                if (m_SentennceShiftForm.ShowDialog() == DialogResult.Yes)
                    m_TimeShift = m_SentennceShiftForm.TimeShift;
            }
            RefreshLabelIndent();
        }

        Double m_TimeShift = 0;
        public Double TimeShift
        {
            get { return m_TimeShift; }
            set { m_TimeShift = value; }
        }

        internal void RefreshLabelIndent()
        {
            //if (string.IsNullOrEmpty(this.FileName))
            //{
            //    this.toolStripLabelIndent.Visible = false;
            //    return;
            //}

            if (this.TimeShift != 0)
                this.toolStripLabelIndent.Text = string.Format("{0}{1} sec.", (this.TimeShift > 0 ? "+ " : ""), TimeShift.ToString("0.00"));

            this.toolStripLabelIndent.Visible = this.TimeShift != 0;
        }
        #endregion

        #region VideoFile & Open
        string m_VideoFileName = null;
        // свойство только для сохранения имени .. 
        // пользователь изменяет видео через метод CheckAndAssignFileName
        [Browsable(false)]
        public string VideoFileName
        {
            get { return m_VideoFileName; }
            set
            {
                m_VideoFileName = value;

                m_VideoFileName = FileManager.FindPathAndReturnFullFileName(value);
                
                // TODO: do common mashine
                // Application.CommonAppDataPath
                // "C:\\ProgramData\\Easy-Lang\\Easy-Lang\\2.1.0.0"
//                Path.GetTempPath()
//"C:\\Users\\Siarhei\\AppData\\Local\\Temp\\"

                if (File.Exists(m_VideoFileName) || ((m_VideoFileName!=null) && Utils.IsURL(m_VideoFileName)))
                {
                    try
                    {
                        if (!VideoForm.IsVideoControlAccesible)
                        {
                            VideoForm.InitVideoForm(null, ((TwinList)this.Parent.Parent.Parent).videoControl1);
//                            VideoForm.InitVideoForm(new VideoForm(), null);
//                            VideoForm.CurrentForm.FormClosed += new FormClosedEventHandler(m_VideoForm_FormClosed);
                        }
                        VideoForm.CurrentVideoContrl.InitFile(m_VideoFileName); //TODO: файл может назначится но не открытся

                  //      if (VideoForm.IsAccesibleCurrent) {
                        this.btVideo.Image = f.button_images.GreenDotSmall;
                        this.miCloseVideo.Text = string.Format("Close {0}", Utils.GetShortFileName(m_VideoFileName));
                        if (VideoForm.IsFormAccesible)
                        {
                            VideoForm.CurrentForm.Text = string.Format("Playing - {0}", m_VideoFileName);
                            VideoForm.CurrentForm.Show();
                        }
                        this.miCloseVideo.Enabled = true;
                        m_TimeShift = 0;
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(string.Format("File for video '{0}' not found.", m_VideoFileName),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_VideoFileName = "";
                        this.OnCloseVideoFile();
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("File for video '{0}' could not be opened.", m_VideoFileName),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_VideoFileName = "";
                        this.OnCloseVideoFile();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_VideoFileName))
                        MessageBox.Show(string.Format("File '{0}' not found.", m_VideoFileName),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // else TODO: ?? close file
                    this.m_VideoFileName = "";
                    this.OnCloseVideoFile();
                }
                if (VideoReloaded != null)
                    VideoReloaded.Invoke(this, new EventArgs());
            }
        }

        public event ListContentUpdated VideoReloaded;

        private void OnCloseVideoFile()
        {
            this.btVideo.Image = null;
            this.miCloseVideo.Text = "Close";
            this.miCloseVideo.Enabled = false;
            this.ClearAudioLanguages();
        }

        void m_VideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.VideoFileName = null;
        }

        OpenURLForm m_OpenURLForm = null;

        void miOopenURL_Click(object sender, EventArgs e)
        {
            if (m_OpenURLForm == null)
                m_OpenURLForm = new OpenURLForm();
            // m_OpenURLForm = new OpenURLForm(Utils.IsURL(this.VideoFileName) ? "this.VideoFileName" : "");
            if (Utils.IsURL(this.VideoFileName))
                m_OpenURLForm.URL = this.VideoFileName;
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                if (m_OpenURLForm.ShowDialog() == DialogResult.Yes)
                    this.VideoFileName = m_OpenURLForm.URL;
            }
        }

        void btOpenVideo_Click(object sender, EventArgs e)
        {
            OpenVideoUI();
        }
        // http://download.ted.com/talks/AbigailWashburn_2012-320k.mp4
        // C:\Users\siarhei_fedarenka\AppData\Local\Microsoft\Windows\Temporary Internet Files\Content.IE5\2SD50S60\AbigailWashburn_2012-320k[1].mp4
        
        void OpenVideoUI()
        {
            if (!Utils.IsURL(this.VideoFileName))
                this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);

            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                using (new FilterFileDialog(this.openFileDialog))
                {
                    this.openFileDialog.Filter = GlobalOptions.GetFileFilterForVideo(true);
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.VideoFileName = openFileDialog.FileName;
                        // TODO: неплохо бы знать валидный ли файл
                        SuggestTextFile(this.VideoFileName);
                    }
                }
            }
        }

        void btCloseVideo_Click(object sender, EventArgs e)
        {
            this.VideoFileName = null;
            this.CloseVideoForm();
        }

        private void btVideo_DropDownOpening(object sender, EventArgs e)
        {
            this.miPauseVideo.Enabled = // ??
            this.miVideoRate.Enabled =
            this.miTimeShift.Enabled =
            this.miSynchronizeVideo.Enabled = 
                VideoForm.CurrentVideoContrl != null && !string.IsNullOrEmpty(this.FileName);
        }  
        #endregion

        #region Open file and VideoForm
        void CloseVideoForm()
        {
            VideoForm.CurrentVideoContrl.Player.close();
            if ( VideoForm.IsFormAccesible )
            {
                VideoForm.CurrentForm.Close();
            }
        }
        #endregion

        void menuForList_Opening(object sender, CancelEventArgs e)
        {
            this.menuForList.Enabled = !(this.CurrentSentence is SentenceVideo);
        }

        void miFindFromVideo_Click(object sender, EventArgs e)
        {
            this.SyncSentenceFromVideo();
        }

        void moreMenuButton_Click(object sender, EventArgs e)
        {
            miSynchronizeWithVideo.Enabled =
            miRepeatVideo.Enabled = this.IsVideoMode;
        }

        bool IsVideoMode
        {
            get { return VideoForm.IsVideoControlAccesible && CurrentSentenceWithVideo != null; }
        }

        #region Pause
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckOnStop();
        }

        int restCountRepeat = 0;

        void CheckOnStop()
        {
           // Console.WriteLine(timer1.Interval + " - end " + DateTime.Now.Second + " ml: " + DateTime.Now.Millisecond);
            SentenceVideo sent = this.CurrentSentenceWithVideo;
            if (VideoForm.IsVideoControlAccesible && sent != null)
            {

                if (VideoForm.CurrentVideoContrl.Player.Ctlcontrols.currentPosition > GetEndForCurrentSentence())
                {
                    if (restCountRepeat > 0)
                    {
                        this.PlayCurrentSentence();
                    }
                    else Pause();
                }
                else
                {// начинаем часто проверять не подошел ли конец предложения, т.к. по управлению теряются доли секунд
                    if (this.timerForVideoManualControl.Interval != 100)
                        this.timerForVideoManualControl.Interval = 100; // но правда это приводит к показу следующего субтира
                }
            }
            if (isRecordingSound)
            {
              //  SoundCapture.Stop();
                WriteNext();
            }
        }

        internal double GetEndForCurrentSentence()
        {
            double endForCurrentSentence = this.CurrentSentenceWithVideo.Start + this.TimeShift + this.CurrentSentenceWithVideo.Length;
            if (ReaderForm.IsFirstRun) endForCurrentSentence -= 0.400;
            return endForCurrentSentence;
        }

        public void PlayOrPause()
        {
            if (IsVideoMode && VideoForm.IsVideoControlAccesible) // форма может закрытся а таймер все еще работать
            {
                VideoForm.CurrentVideoContrl.PlayOrPause();
            }
        }

        public void PlayAlways()
        {
            this.timerForVideoManualControl.Enabled = false;
            if (IsVideoMode) // форма может закрытся а таймер все еще работать
            {
                VideoForm.CurrentVideoContrl.Player.Ctlcontrols.play();
            }
        }

        private void Pause()
        {
            this.timerForVideoManualControl.Enabled = false;
            if (IsVideoMode) // форма может закрытся а таймер все еще работать
            {
                VideoForm.CurrentVideoContrl.Player.Ctlcontrols.pause();
                // отмотаем назад чтобы поставить текущий субтитр
                // но к сожалению субтитры не прорисовываются *((
                //this.VideoForm.ScipSynchronize = true;
                //this.VideoForm.Player.Ctlcontrols.currentPosition -= 2;
            }
            // здесь управлять VideoForm.AutoSynchronize нельзя т.к. пользователь может переключатся во время фразы
        //    this.VideoForm.AutoSynchronize = true;
        } 
        #endregion

        #region PlayCurrentSentence
        public void PlayCurrentSentence(int i) { this.restCountRepeat = i;  this.PlayCurrentSentence(); }

        public void PlayCurrentSentence()
        {
            if (IsOnlySynch) return;
            if (this.IsVideoMode)
            {
                if (this.timerForVideoManualControl.Enabled) this.Pause();
                VideoForm.CurrentVideoContrl.SkipSynchronize = true;
                double newPosition = this.CurrentSentenceWithVideo.Start + this.TimeShift;
                if (newPosition - VideoForm.CurrentVideoContrl.Player.Ctlcontrols.currentPosition <= 0 &&
                    newPosition - VideoForm.CurrentVideoContrl.Player.Ctlcontrols.currentPosition > -1)
                { } // empty 
                else
                    VideoForm.CurrentVideoContrl.Player.Ctlcontrols.currentPosition = newPosition; // установили старт предложения

                if (this.restCountRepeat == 22)
                {
                    VideoForm.CurrentVideoContrl.PlaybackRate = .8;
                    this.restCountRepeat = 1;
                }
                else
                {
                    if (this.restCountRepeat == 3)
                        VideoForm.CurrentVideoContrl.PlaybackRate = .7;
                    else if (this.restCountRepeat == 2)
                        VideoForm.CurrentVideoContrl.PlaybackRate = .8;
                    else if (this.restCountRepeat == 1)
                        VideoForm.CurrentVideoContrl.PlaybackRate = .9;
                    else
                        VideoForm.CurrentVideoContrl.PlaybackRate = 1;
                    --this.restCountRepeat;
                }

                VideoForm.CurrentVideoContrl.Player.Ctlcontrols.play();

                //  Console.WriteLine(" - start " + DateTime.Now.Second + " ml: " + DateTime.Now.Millisecond);

                // это не последний титр?
              //  if (this.Sentences.Count != this.Sentences.IndexOf(this.CurrentSentenceWithVideo) + 1)
                {
                    if (this.CurrentSentenceWithVideo.Length != 0)
                    {
                        this.timerForVideoManualControl.Interval = (int)(this.CurrentSentenceWithVideo.Length * 1000.0);
                        if (ReaderForm.IsFirstRun) this.timerForVideoManualControl.Interval -= 400;

                        this.timerForVideoManualControl.Enabled = true;
                    }
                }
                // else последнюю фразу будет просто играть до конца 
            }
        }

        internal SentenceVideo CurrentSentenceWithVideo
        {
            get { return this.CurrentSentence as SentenceVideo; }
        }

        void miRepeatVideo_Click(object sender, EventArgs e)
        {
            this.PlayCurrentSentence();
        }

        void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayCurrentSentence();
        }
        #endregion

        #region SyncSentence
        public bool IsOnlySynch = false;

        public void SyncSentenceFromVideo()
        {
            if (this.IsVideoMode)
            {
                if (this.timerForVideoManualControl.Enabled) 
                    Pause();

                int ind = GetIndexByVideoTime(VideoForm.CurrentVideoContrl.Player.Ctlcontrols.currentPosition - this.TimeShift, this.Sentences);
                if (ind != -1 && this.SafeSelectedIndex != ind)
                {
                    // здесь не должно происходить проигрывания
                    try
                    {
                        IsOnlySynch = true;
                        this.SafeSelectedIndex = ind;
                    }
                    finally
                    {
                        IsOnlySynch = false;
                    }
                }
            }
        }

        static public int GetIndexByVideoTime(double position, List<Sentence> sentences)
        {
            foreach (SentenceVideo sen in sentences)
            {
                if (sen.Start < position)
                {
                    if ((sen.Start + sen.Length) > position)
                    {
                        return sentences.IndexOf(sen);
                    }
                }
            }
            return -1;
        }

        void miSynchronizeVideo_Click(object sender, EventArgs e)
        {
            this.SyncSentenceFromVideo();
        }
        #endregion

        #region SoundCapture
        List<Sentence>.Enumerator sentencesForWrite;
        bool isRecordingSound = false;
        string FolderForOutPut = @"c:\";

        private void miWriteAllSounds_Click(object sender, EventArgs e)
        {
            if (!this.IsOpenWithSubtitles) return; //TODO:
            sentencesForWrite = this.Sentences.GetEnumerator();
            isRecordingSound = true;
            FolderForOutPut = Path.GetDirectoryName(this.VideoFileName) + "\\MEDIA.LESSON\\";
            if(!Directory.Exists(FolderForOutPut))
                Directory.CreateDirectory(FolderForOutPut);
            WriteNext();
        }

        int MAX_LENGTH_FILE_NAME = 45;
        private void WriteNext()
        {
            sentencesForWrite.MoveNext();
            SentenceVideo sen = sentencesForWrite.Current as SentenceVideo;
            if (sen == null)
            {
                isRecordingSound = false;
                return;
            }
            if (sen.WordsToLearn.Count > 0)
            {
                int ind = this.Sentences.IndexOf(sen);
                this.SafeSelectedIndex = ind;
                string fileName = string.Format("{0} {1}{2}", ind+1,
                    ((sen.TextValue.Length > MAX_LENGTH_FILE_NAME+1) ? sen.TextValue.Substring(0, MAX_LENGTH_FILE_NAME) : sen.TextValue),
                    "... .mp3");
              //  SoundCapture.Start(FolderForOutPut + fileName);
            }
            else WriteNext();
        }


        //public static Mp3SoundCapture mp3SoundCapture = null;

        //Mp3SoundCapture SoundCapture
        //{
        //    get
        //    {
        //        if (mp3SoundCapture == null)
        //        {
        //            mp3SoundCapture = new Mp3SoundCapture();
        //            // mp3SoundCapture.CaptureDevice = (SoundCaptureDevice)devicesCmb.SelectedItem;
        //            mp3SoundCapture.NormalizeVolume = true; // normalizeChk.Checked;
        //            mp3SoundCapture.OutputType = Mp3SoundCapture.Outputs.Mp3;
        //            //mp3SoundCapture.WaveFormat = (PcmSoundFormat)formatsCmb.SelectedItem;
        //            //mp3SoundCapture.Mp3BitRate = (Mp3BitRate)bitRateCmb.SelectedItem; // 128
        //            mp3SoundCapture.WaitOnStop = false; // !asyncStopChk.Checked;
        //        }
        //        return mp3SoundCapture;
        //    }
        //}
        #endregion
        
        #region all for lesson
        private void lessonMenuButton_DropDownOpening(object sender, EventArgs e)
        {
            this.miSaveAndRunVocabularyTutor.Enabled = 
            this.miSaveAsLesson.Enabled = IsHaveLesson;
            this.miSaveLesson.Enabled = GlobalOptions.IsChangedLesson;

            if( GlobalOptions.IsChangedLesson )
                this.miSaveAndRunVocabularyTutor.Text = "Save and Open in 'Easy4Learn-Tutor'";
            else
                this.miSaveAndRunVocabularyTutor.Text = "Run this lesson in 'Easy4Learn-Tutor'";


            this.miWriteAllSounds.Enabled = !string.IsNullOrEmpty(this.VideoFileName);
//            this.miSaveAndRunVocabularyTutor.Enabled = !string.IsNullOrEmpty(this.LessonFileName); // IsHaveLesson;
            this.miSaveAndRunVocabularyTutor.Enabled = this.IsHaveLesson;
        }

        #region save
        public bool SaveLessonForce()
        {
            return SaveLesson(true);
        }

        void miSaveLesson_Click(object sender, EventArgs e)
        {
            SaveLesson(false);
        }

        bool SaveLesson(bool doForce) // TODO: тут с возвратом булева ерунда т.к. внутри просто имя файла возвращает
        {
            if (!string.IsNullOrEmpty(this.LessonFileName))
            {
                SaveLessonFile(this.LessonFileName);
                return true;
            }
            else if (doForce)
            {
                string fileName = this.FileName + GlobalOptions.LessonFileExtension;
                // TODO: здесь урок переоткроется (пока так)
                this.LessonFileName = SaveLessonFile(fileName);
                return !string.IsNullOrEmpty(this.LessonFileName);
            }
            else
            {
                return SaveAsLesson();
            }
        }
 
        void miSaveAsLesson_Click(object sender, EventArgs e)
        {
            SaveAsLesson();
        }

        bool SaveAsLesson()
        {
            this.saveFileDialog.FileName = this.LessonFileName;
            this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);

            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                using (new FilterFileDialog(this.saveFileDialog))
                {
                    this.saveFileDialog.Filter = GlobalOptions.GetFileFilterForLesson(true);
                    DialogResult dr = this.saveFileDialog.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        if (!this.IsHaveLesson)
                        {
                            MessageBox.Show("You not have words for lessons. To add words, double-click on a word.");
                            return true;
                        }
                        // TODO: здесь урок переоткроется (пока так)
                        this.LessonFileName = SaveLessonFile(this.saveFileDialog.FileName);
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string SaveLessonFile(string fileName)
        {
            string lessons = GetLessonContent();
            if (!fileName.ToLower().EndsWith(GlobalOptions.LessonFileExtension))
                fileName += GlobalOptions.LessonFileExtension;
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.Write(lessons);
                GlobalOptions.IsChangedLesson = false;
            }
            CheckImageByLessonState();           
            return fileName;
        }
        #endregion

        #region Lessons contentFull
        protected bool IsHaveLesson
        {
            get
            {
                if (!string.IsNullOrEmpty(this.LessonFileName)) return true;
                if (this.Sentences!= null)
                    foreach (Sentence sen in this.Sentences)
                    {
                        if (sen.WordsToLearn.Count > 0)
                            return true;
                    }
                return false;
            }
        }

        string GetLessonContent()
        {
            string ret = "";
            foreach (Sentence sen in this.Sentences)
            {
                if (sen.WordsToLearn.Count == 0) continue;
                if (sen is SentenceVideo)
                {
                    ret += string.Format("{0};{1};{2};{3}", this.Sentences.IndexOf(sen)+1,
                        ((SentenceVideo)sen).Start, ((SentenceVideo)sen).Length,
                        sen.GetTextLesson() + SentenceParser.Delimeter + Environment.NewLine);
                }
                else
                {
                    ret += string.Format("{0};{1};{2};{3}", this.Sentences.IndexOf(sen)+1,
                       string.Empty, string.Empty,
                       sen.GetTextLesson() + SentenceParser.Delimeter + Environment.NewLine);
                }
            }
            return ret;
        }

        private void ReadLesson(string fileName)
        {
            List<Sentence> lessons = SentenceForLesson.GetLessonSentences(fileName);
            if (lessons.Count == 0) return;

            int shiftForOldLesson = 0;
            if (Form.ModifierKeys == Keys.Shift || ((SentenceForLesson)lessons[0]).NumberSentence == 0)
                shiftForOldLesson = 1;

            foreach (SentenceForLesson sen in lessons)
            {
                if (this.Sentences.Count > sen.NumberSentence - 1 + shiftForOldLesson)
                    //TODO: урок и субтитры могут отличатся поэтому надо сверка хэш кода текста
                    this.Sentences[sen.NumberSentence - 1+shiftForOldLesson].AddAllWordsToLearn(sen.WordsToLearn);
            }
        }

        void RemoveAllWordsToLearn()
        {
            if (this.Sentences != null)
                foreach (Sentence sen in this.Sentences)
                {
                    sen.RemoveAllWordsToLearn();
                }
        }
        #endregion

        #region open, close
        private void miOpenLesson_Click(object sender, EventArgs e)
        {
            OpenLessonUI();
        }

        private void OpenLessonUI()
        {
            this.openFileDialog.InitialDirectory = FileSelector.GetFolderForFileSelection(this.FileName);
            using (new FilterFileDialog(this.openFileDialog))
            {
                this.openFileDialog.Filter = GlobalOptions.GetFileFilterForLesson(true);
                using (new AbandonTopPosition(VideoForm.CurrentForm))
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.LessonFileName = this.openFileDialog.FileName;
                    }
                }
            }
        }

        private void miCloseLesson_Click(object sender, EventArgs e)
        {
            this.LessonFileName = null;
        }
        #endregion

        #region LessonFileName
        string m_LessonFileName = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LessonFileName
        {
            get { return m_LessonFileName; }
            set
            {
                if (CheckLessonOnSave() == DialogResult.Cancel)
                    return;
                try
                {
                    if (m_LessonFileName != value)
                        RemoveAllWordsToLearn();

                    //System.Diagnostics.Debugger.Launch();
                    m_LessonFileName = FileManager.FindPathAndReturnFullFileName(value);

                    if ( File.Exists(m_LessonFileName))
                    {
                        try
                        {
                            ReadLesson(m_LessonFileName);
                            this.btLesson.Image = button_images.GreenDotSmall;
                            this.miCloseLesson.Text = string.Format("Close {0}", Utils.GetShortFileName(m_LessonFileName));
                            this.miCloseLesson.Enabled = true;
                        }
                        //catch (FileNotFoundException)
                        //{
                        //    MessageBox.Show(string.Format("File '{0}' not found.", m_LessonFileName),
                        //        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    this.OnCloseLessonFile();
                        //    m_LessonFileName = "";
                        //}
                        catch
                        {
                            MessageBox.Show(string.Format("Lesson file '{0}' could not be opened.", m_LessonFileName),
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.OnCloseLessonFile();
                            this.m_LessonFileName = "";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(m_LessonFileName))
                            MessageBox.Show(string.Format("Lesson file '{0}' not found.", m_LessonFileName), 
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.m_LessonFileName = "";
                        this.OnCloseLessonFile();
                    }
                }
                finally
                {
                    this.List.Refresh();
                    GlobalOptions.IsChangedLesson = false;
                }
            }
        }

        void OnCloseLessonFile()
        {
            this.miCloseLesson.Text = "Close {0}";
            this.miCloseLesson.Enabled = false;
            this.btLesson.Image = null;
        }

        public override DialogResult CheckFilesOnSave()
        {
            return CheckLessonOnSave();
        }

        protected virtual DialogResult CheckLessonOnSave()
        {
            if (GlobalOptions.IsChangedLesson)
            {
                using (new AbandonTopPosition(VideoForm.CurrentForm))
                {
                        DialogResult dialRes = MessageBox.Show(this,
                            "The lesson has changed." +
                            Environment.NewLine + Environment.NewLine +
                            "Do you want save changes?",
                                Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialRes == DialogResult.Yes)
                        {
                            if (!SaveLesson(false))
                                return DialogResult.Cancel;
                        }
                        // if (dialRes == DialogResult.No) continue
                        return dialRes; // cancel or NO
                }
            }
            return DialogResult.None;
        }
        #endregion

        protected override void OnOpenOtherText()
        {
            base.OnOpenOtherText();
            this.LessonFileName = "";
        }


        private void miAboutLesson_Click(object sender, EventArgs e)
        {
            ShowLearnWordsArticle();
        }

        public static void ShowLearnWordsArticle()
        {
            Runner.OpenURL(string.Format("http://easy4learn.com/{0}/purchase.htm", Utils.GetLocaleForUI()));
            Runner.OpenURL(Utils.GetLocalizedPrefix() + "easy4learn.com/advices/learn-words.htm");
        }

        void miSaveAndRunVocabularyTutor_Click(object sender, EventArgs e)
        {
            if (!this.IsHaveLesson)
            {
                MessageBox.Show("You have not a words for learning", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.SaveLesson(true);

            if (string.IsNullOrEmpty(this.LessonFileName)) 
            {
                MessageBox.Show("The lesson is not saved", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RunLessson(this.LessonFileName);
        }

        public static void RunLessson(string lessonFileName)
        {
            string fileName = FileManager.FindPathAndReturnFullFileName("Easy4LearnTutor.exe");
            if (File.Exists(fileName))
            {
                ProcessStartInfo info = new ProcessStartInfo(fileName, "\"" + lessonFileName + "\"");

                // убираем негативный момент при запуске своих приложений
                // using(new AbandonTopPosition(VideoForm.CurrentForm)) {
                if (VideoForm.CurrentForm != null
                    && !VideoForm.CurrentForm.IsDisposed
                    && !VideoForm.CurrentForm.Disposing
                    && VideoForm.CurrentForm.TopMost)
                {
                    VideoForm.CurrentForm.TopMost = false;
                }
                Process.Start(info);
            }
            else MessageBox.Show("The program 'Easy-Learn' was not found", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
