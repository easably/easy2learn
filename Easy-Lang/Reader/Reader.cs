using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class ReaderForm : Form
    {
        public ReaderForm()
        {
            InitializeComponent();
            this.Visible = false;
            this.BackColor = CF.ExternalBorder;

            //IWaitingUIObject waitingUIObject = new WaitingUIObjectWithFinish(this, this.pictureBoxWating, null);
            //this.reader.TwinText.Initialize(this.reader.TwinList.ListEn, this.reader.TwinList.ListNative, waitingUIObject);
            this.reader.TwinText.Initialize(this.reader.TwinList.ListEn, this.reader.TwinList.ListNative, null);

            this.FormClosing += new FormClosingEventHandler(ReaderForm_FormClosing);

            //this.btDictionaryBlendHistory.Image = global::f.button_images.WordsCatalog;
            //this.ddbtOptions.Image = global::f.button_images.Options;

            this.miHelpRequests.Image = global::f.button_images.Email;
            this.miHelpRequests.Click += new EventHandler(miHelpRequests_Click);

            #region gutenbergToolStripMenuItem_Click
            // -------- library -------- 
            this.gutenbergToolStripMenuItem.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.manybooksnetToolStripMenuItem.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.englishLibrarynetToolStripMenuItem.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.bibliomaniaToolStripMenuItem.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.miPpenLocalLibrary.Click += new System.EventHandler(this.miPpenLocalLibrary_Click);

            // -------- video -------- 
            this.miTED.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);

            // -------- news -------- 
            this.miTheepochtimes.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.miBBC.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click);
            this.miInopressa_ru.Click += new System.EventHandler(this.gutenbergToolStripMenuItem_Click); 
            #endregion

            //this.miVideo.ImageScaling = ToolStripItemImageScaling.None;
            //this.miVideo.Image = button_images._new;  
            // this.miVideo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            

            this.exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);

            // -------- dictionaryBlend -------- 
            this.btDictionaryBlendHistory.Click += new EventHandler(btHistory_Click);
            this.FormClosed += delegate { FileSelector.VideoUnit = null; Application.Exit(); };
            actionPlayerHost = this.reader.TwinList.videoControl1.mainMenu1;
        }

        IActionPlayerHost actionPlayerHost;

        public void InitData()
        {
            this.RestoreState();
            //if (IsFirstRun && !T.NoScreen)
            //{
            //    // Application. if (args.Length > 0 && Array.IndexOf(args, no_screen) != -1) 
            //    {
            //        MenuForSelected.OpenInDictionaryBlend("Welcome " + DictionaryBlend.MinimizeForm);
            //    }

            //}

            this.Load += new System.EventHandler(this.LoadMainForm);

            // ---------- VideoFormFocus ----------
            // не получается фокус контролы забирают
            this.reader.TwinList.ListEn.List.LostFocus += new EventHandler(ReaderForm_LostFocus);
            this.reader.TwinList.ListNative.List.LostFocus += new EventHandler(ReaderForm_LostFocus);

            this.reader.TwinText.textForeignAndTran.ForeignText.LostFocus += new EventHandler(ReaderForm_LostFocus);
            this.reader.TwinText.textForeignAndTran.translatedText.LostFocus += new EventHandler(ReaderForm_LostFocus);
            this.reader.TwinText.textNative.LostFocus += new EventHandler(ReaderForm_LostFocus);

            this.reader.TwinList.ListEn.List.GotFocus += new EventHandler(ReaderForm_GotFocus);
            this.reader.TwinList.ListNative.List.GotFocus += new EventHandler(ReaderForm_GotFocus);

            this.reader.TwinText.textForeignAndTran.ForeignText.GotFocus += new EventHandler(ReaderForm_GotFocus);
            this.reader.TwinText.textForeignAndTran.translatedText.GotFocus += new EventHandler(ReaderForm_GotFocus);
            this.reader.TwinText.textNative.GotFocus += new EventHandler(ReaderForm_GotFocus);

            this.reader.TwinList.ListEn.TextReloaded += new SentenceList.ListContentUpdated(ListEn_TextOrVideoReloaded);
            this.reader.TwinList.ListEn.VideoReloaded += new SentenceList.ListContentUpdated(ListEn_TextOrVideoReloaded);

            this.btSearchSubtitles.Click += new EventHandler(btSearchSubtitles_Click);

            RedirectAllKeyDown();
        }

        void btSearchSubtitles_Click(object sender, EventArgs e)
        {
            SearchSubtitles ss = new SearchSubtitles();
            if (VideoForm.IsVideoControlAccesible)
                ss.MovieName = VideoForm.CurrentVideoContrl.MoviewName;
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                if (ss.ShowDialog() == DialogResult.Yes && !string.IsNullOrEmpty(ss.MovieName))
                {
                    f.Runner.RunBulk(f.Runner.SubSearch, new string[] { ss.MovieName });
                }
            }
           // this.Focus();
        }

        #region KeyProcess
        private void RedirectAllKeyDown()
        {
            this.reader.TwinList.ListEn.List.KeyDown += new KeyEventHandler(KeyProcess);
            this.reader.TwinList.ListNative.List.KeyDown += new KeyEventHandler(KeyProcess);
            this.reader.TwinText.textForeignAndTran.KeyDown += new KeyEventHandler(KeyProcess);
            this.reader.TwinText.textNative.KeyDown += new KeyEventHandler(KeyProcess);
        }

        private void KeyProcess(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("KeyCode {0}", e.KeyCode);
            //Console.WriteLine("KeyValue {0}", e.KeyValue);
            //Console.WriteLine("KeyData {0}", e.KeyData);

            //if (e.KeyData == (Keys.PageUp | Keys.Control) || e.KeyData == (Keys.P | Keys.Control))
            //    CurrentListBy(sender).SafeSelectedIndex -= 10;
            //else if (e.KeyData == (Keys.PageDown | Keys.Control) || e.KeyData == (Keys.N | Keys.Control))
            //    CurrentListBy(sender).SafeSelectedIndex += 10;

            bool isReadOnly = !IsEditableSender(sender);

            if (e.Control)
            {
                if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.P)
                    CurrentListBy(sender).SafeSelectedIndex -= 10;
                else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.N)
                    CurrentListBy(sender).SafeSelectedIndex += 10;

                else if (e.KeyCode == Keys.O)
                    this.VideoList.OpenFileUI();
                else if (e.KeyCode == Keys.V)
                    CurrentListBy(sender).Paste();

                if (sender is RichTextBox)
                {
                    if (e.KeyCode == Keys.Up) // + 107 
                        ChangeFont(true, (RichTextBox)sender);
                    else if (e.KeyCode == Keys.Down) // -  109
                        ChangeFont(false, (RichTextBox)sender);
                    else return;
                }
                else
                {
                    if (e.KeyCode == Keys.Up) // + 
                        CurrentListBy(sender).ChangeFont(true);
                    else if (e.KeyCode == Keys.Down) // -  
                        CurrentListBy(sender).ChangeFont(false);
                    else return;
                }
            }
            // до этого если с Keys.Control то текст не редактируется
            else if (e.KeyData == Keys.P && isReadOnly) // e.KeyData == Keys.PageUp || 
                actionPlayerHost.PlayPrev();
            //CurrentListBy(sender).SafeSelectedIndex -= 1;

            else if ((e.KeyData == Keys.N || e.KeyValue == 221) // ']' - 219
                && isReadOnly) // e.KeyData == Keys.PageDown ||
                actionPlayerHost.PlayNext();
            //CurrentListBy(sender).SafeSelectedIndex += 1;

            else if (e.KeyData == (Keys.S) && isReadOnly)
                this.VideoList.SyncSentenceFromVideo();
            else if ((e.KeyData == (Keys.R) || e.KeyValue == 219) // '[' - 219
                && isReadOnly)
                actionPlayerHost.RePlay();
            else if (e.KeyData == Keys.Space && isReadOnly)
                this.VideoList.PlayOrPause();
            else if (e.KeyData == (Keys.F1))
                this.reader.TwinText.MenuForSelected.OpenInLast();
            else if (e.KeyData == (Keys.F1) && e.Alt)
                CurrentListBy(sender).EstimateTest();
            else if (e.KeyData == (Keys.F3))
                CurrentListBy(sender).FindCitationsForWordAndShow();
            else return;

            // раз сюда попало то значит выше по коду не сработал else return; (т.е. была отработка)
            e.SuppressKeyPress =
            e.Handled = true; // else was return above
        }

        RichTextBox TextNative
        {
            get { return this.reader.TwinText.textNative; }
        }

        ListBox ListNative
        {
            get { return this.reader.TwinList.ListNative.List; }
        }

        SentenceListWithVideo VideoList
        {
            get { return this.reader.TwinList.ListEn; }
        }

        ListBox ListEn
        {
            get { return this.reader.TwinList.ListEn.List; }
        }

        bool IsEditableSender(object editor)
        {
            return editor is RichTextBox && !((RichTextBox)editor).ReadOnly;
        }

        public static void ChangeFont(bool isIncrease, RichTextBox sender)
        {
            if (sender == null) return;
            float step = 0.1f;
            // float step = 1; 
            //sender.Font = new Font(sender.Font.Name, sender.Font.Size + (isIncrease ? step : -1 * step));
            // this.List.Font = new Font(this.Font.Name, this.List.Font.Size + (isIncrease ? step : -1 * step));
            sender.ZoomFactor = Math.Abs((isIncrease ? step : -1 * step) + sender.ZoomFactor);
        }

        SentenceList CurrentListBy(object sender)
        {
            if (sender == TextNative || sender == ListNative)
                return this.reader.TwinList.ListNative;
            else return this.reader.TwinList.ListEn;
        }
        #endregion

        void ListEn_ChangeLanguageDirection(object sender, EventArgs e)
        {
            this.reader.LanguageDirection = (string)sender;
        }

        const string hintForOpenFile = "Please open allFiles with video and subtitles";
        void UpdateTitle()
        {

            string fileName = hintForOpenFile;

            if (VideoForm.IsVideoControlAccesible && !string.IsNullOrEmpty(reader.TwinList.ListEn.VideoFileName))
                fileName = Utils.GetShortFileName(reader.TwinList.ListEn.VideoFileName);
            else if (!string.IsNullOrEmpty(reader.TwinList.ListEn.FileName))
                fileName = Utils.GetShortFileName(reader.TwinList.ListEn.FileName);

            this.Text = string.Format("{0} - {1}", T.AppName, fileName);
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ListEn_TextOrVideoReloaded(SentenceList sender, EventArgs e)
        {
            UpdateTitle();
            if( VideoForm.IsVideoControlAccesible )
                VideoForm.CurrentVideoContrl.mainMenu1.CheckButtonsState();
        }

        #region Top for video form
        bool tempkip;
        void ReaderForm_LostFocus(object sender, EventArgs e)
        {
            if (tempkip) return;
            if (VideoForm.IsFormAccesible)
            {
                if (VideoForm.CurrentVideoContrl.Player.Focused) return; // чтобы не приходилось переключатся дважы при возврате на форму 
                // в VideoForm используется вариант оптсанный ниже
                // 2 вариант
                // в этом варианте, если форма в топе и уйти из приложения то форма отанется висеть 8(

                if (!this.MainFormIsFocused)
                {
                    VideoForm.CurrentForm.TopMost = false;
                    //    Console.WriteLine("LostFocus - " + ((Control)sender).Name + " TopMost - " + VideoForm.CurrentForm.TopMost.ToString());
                }
            }
        }

        void ReaderForm_GotFocus(object sender, EventArgs e)
        {
            if (VideoForm.IsFormAccesible)
            {
                if (!VideoForm.CurrentForm.TopMostManualExplicit) return;
                if (!VideoForm.CurrentForm.TopMost)
                {
                    tempkip = true;
                    VideoForm.CurrentForm.TopMost = true;
                    // Console.WriteLine("GotFocus - " + ((Control)sender).Name);
                    tempkip = false;
                    // т.к. приходится переключатся дважы чтобы вернутся на форму, отбомбим
                    ((Control)sender).Focus();
                    ((Control)sender).Select();
                    ((Control)sender).Focus();
                }
            }
        }

        bool MainFormIsFocused
        {
            get
            {
                return
                    this.reader.TwinList.ListEn.List.Focused ||
                    this.reader.TwinList.ListNative.List.Focused ||

                    this.reader.TwinText.textForeignAndTran.ForeignText.Focused ||
                    this.reader.TwinText.textForeignAndTran.translatedText.Focused ||
                    this.reader.TwinText.textNative.Focused;
            }
        }
        #endregion

        public void LoadMainForm(object sender, EventArgs e)
        {
            // обновим для перевода (типа аналога ListEn.SafeSelectedIndex = ListEn.SafeSelectedIndex; или ListEn.PlayCurrentSentence();)
            this.reader.RefreshSelectedSentence(); // не работает т.к. this.Created == false
            // this.reader.TwinText.timer.Start(); // this.timer.Enabled = true;
            this.reader.TwinList.ListEn.PlayCurrentSentence();

        }

        void ReaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.reader.TwinList.ListEn.CheckFilesOnSave() == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void EasyReaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveState();
        }

        #region Resources
        //www.subtitles.com.br/search-subtitles-test-0-all-all-1.htm
        // telesubtitles.com/
        private void gutenbergToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            //throw new ApplicationException("!!!");
            //int ii = 0;
            //int i = 4 / ii;

            if (sender == this.gutenbergToolStripMenuItem)
                // марк твен www.gutenberg.org/browse/authors/t#a53
                Runner.OpenURL("http://www.gutenberg.org/catalog/"); // www.gutenberg.org/browse/authors/a
            else if (sender == this.manybooksnetToolStripMenuItem)
                Runner.OpenURL("http://manybooks.net/language.php");
            else if (sender == this.englishLibrarynetToolStripMenuItem)
                Runner.OpenURL("http://www.davidappleyard.com/library/");
            else if (sender == this.bibliomaniaToolStripMenuItem)
                Runner.OpenURL("http://bibliomania.com/0/-/frameset.html");
            // news
            else if (sender == this.miBBC)
                Runner.OpenURL("http://news.bbc.co.uk/");
            else if (sender == this.miTheepochtimes)
                Runner.OpenURL("http://www.theepochtimes.com/n2/other-languages.html");
            else if (sender == this.miInopressa_ru)
                Runner.OpenURL("http://inopressa.ru");
            else if (sender == this.miTED)
                Runner.OpenURL("http://www.ted.com/OpenTranslationProject");
                

            // http://thenextweb.com/
            // Subtitles
            else if (!string.IsNullOrEmpty(mi.Tag as string))
                Runner.OpenURL((string)mi.Tag);
            else Runner.OpenURL((string)mi.Text);
        }
        #endregion

        public static FileSelector FileSelectorInstance = null;

        #region State (RestoreState & SaveState)
        public void RestoreState()
        {
            try
            {
                string _videoFileName = CF.GetValue("VideoFileName", @"\Sample\Episode\Video.avi");
                if (!Utils.IsURL(_videoFileName))
                    _videoFileName = FileManager.FindPath(_videoFileName, @"Please select a video file");
                //         _videoFileName = FileManager.FindPathAndReturnFullFileName(_videoFileName, @"\my_video\movie.avi - specify a file with downloaded video");

                string _subtFileName = CF.GetValue("ListEn_FileName", @"\Sample\Episode\Video.EN.srt");
                _subtFileName = FileManager.FindPath(_subtFileName, @"\my_video\subtitle_for_my_movie.sub - specify a file with downloaded subtitles");
                _subtFileName = FileManager.FindPath(_subtFileName, @"Please select a video file");

                string _lessonFileName = CF.GetValue("Lesson_FileName", CF.GetFolderForUserFiles() + @"\Video.EN.srt.lesson");


                string _subtNativeFileName = CF.GetValue("ListNative_FileName", @"\Sample\Episode\video.ru.srt");

                if (string.IsNullOrEmpty(CF.GetValue(CF.installation_date, "")))
                {
                    m_IsFirstRun = true;
                    CF.SetValue(CF.installation_date, DateTime.Today.ToString("dd-MM-yyyy"));
                }

                #region FileSelectorDialog
                // bool skipFileSelectorDialog = CF.GetValue("IsSkipFileSelectorDialog", false);
                bool skipFileSelectorDialog = false;
                if (!skipFileSelectorDialog && !T.NoScreen)
                {
                    #region working with Args
                    foreach (string arg in T.Args)
                    {
                        if (!File.Exists(arg)) continue;
                        if (GlobalOptions.IsVideo(arg))
                        {
                            _videoFileName = arg;
                            // SuggestTextFile(this.VideoFileName);
                            //break;
                        }
                        else if (GlobalOptions.IsSubtitle(arg) || GlobalOptions.IsText(arg))
                        {
                            _subtFileName = arg;
                            // SuggestVideoFile(this.FileName);
                            //break;
                        }
                    } 
                    #endregion
                    FileSelectorInstance = new FileSelector() { VideoFileName = _videoFileName, SubtitleFileName = _subtFileName, 
                        LessonFileName = _lessonFileName, SubtitleNativeFileName = _subtNativeFileName };
                    if (IsFirstRun)
                        FileSelectorInstance.DoUseSample();
                    FileSelectorInstance.Show(); // поскольку this.Visible = false;
                } 
                #endregion

                this.reader.TwinList.ListEn.TimeShift = CF.GetValue(CF.timeshift_video, 0.0D);
                this.reader.TwinList.ListEn.RefreshLabelIndent();
          
                this.RestoreState(this.reader.TwinList.ListEn, false);

                // т.к. после перезапуска программы не подсвечивается текущее предложение, оно где то внизу
                this.reader.TwinList.ListEn.List.ScrollSelectedToCenter();

                this.RestoreState(this.reader.TwinList.ListNative, string.IsNullOrEmpty(_subtNativeFileName));

                if (VideoForm.CurrentVideoContrl != null)
                    VideoForm.CurrentVideoContrl.mainMenu1.CheckButtonsState();

                #region LanguageDirection
                //CurrentLangInfo.InitLanguagesMenu(this.toolStrip1);
                CurrentLangInfo.LanguageDirection =
                this.reader.LanguageDirection = CF.GetValue("LanguageDirection", CurrentLangInfo.DefaultLangDir);

                CurrentLangInfo.ChangedLanguageDirection += new EventHandler(ListEn_ChangeLanguageDirection);
                #endregion

                // auto ListEn_ChangeLanguageDirection(this.reader.LanguageDirection, EventArgs.Empty);                
                // this.reader.TwinText.textEn.Font = new Font(this.reader.TwinText.textEn.Font.Name, float.Parse(CF.GetValue(sentenceList.Name + "FontSize", 9)));

                this.reader.TwinText.MenuForSelected.IsListenByClick = CF.GetValue("ListenByClick", true);
                this.reader.TwinText.MenuForSelected.IsShowPopupWindow = CF.GetValue("ShowPopupWindow", true);
                this.reader.TwinText.MenuForSelected.IsAddWordToTutor = CF.GetValue("AddWordToTutorOnDoubleClick", false);

                // --- false ---
                //this.reader.TwinText.menuForSelected1.miPopupAsMonoDictionary.Checked = CF.GetValue("PopupAsMonoDictionary", false);

                this.reader.TwinText.MenuForSelected.LastDictName = CF.GetValue("LastDictionary", GoogleDictionary.MainTitle);

                // http://tech.onliner.by/2012/04/12/resolution
                // весной 2012 года разрешение мониторов 1024×768 впервые перестало быть самым популярным среди пользователей PC, уступив пальму первенства 1366×768. 
                // В США самым популярным разрешением пока остается 1024×768.
                CF.AssignValues("MainForm", this, new Point(10, 20), new Size(1200, 728)); 


                this.reader.TwinText.Height = CF.GetValue("TextTwin", 364);
                // если так то хрень -
                // 100); // 
                this.reader.TwinText.textForeignAndTran.paForeignText.Height =
                    CF.GetValue("TextForeign_Heigh", 62);
                
                // this.reader.TwinText.textWithTranslate.SetAccommodativeHeight(true);
                // this.reader.TwinText.textNative.Width = CF.GetValue("TextNative", 250);

                // for TwinList
                this.reader.TwinList.ListNative.Width = CF.GetValue("ListNative", 252);
                this.reader.TwinList.paLists.Width = CF.GetValue(text_lists_width, this.Width / 2);

                // for TwinText
                this.reader.TwinText.textForeignAndTran.ForeignText.ZoomFactor = CF.GetValue("TextForeign_FontSize", 1f);
                //TODO this.reader.TwinText.textForeignAndTran.translatedText.ZoomFactor = CF.GetValue("TextTranslate_FontSize", 1f);
                this.reader.TwinText.textNative.ZoomFactor = CF.GetValue("TextNative_FontSize", 1f);

                this.reader.TwinText.MenuForSelected.miHideTranslation.Checked = CF.GetValue("IsHidedTranslation", false);
            }
            catch (Exception ex) {
                Messages.ErrorOnRestoringApp(ex);
            }

            // здесь видно неправильное положение
            //if (Utils.VideoForm != null && !Utils.VideoForm.IsDisposed && !Utils.VideoForm.Disposing)
            //    CF.AssignValues("VideoForm", Utils.VideoForm);
        }

        public void AssignFiles()
        {
            if (FileSelector.VideoUnit == null) return;
            VideoUnit vu = FileSelector.VideoUnit;
            AssignFiles(vu.GetPathDOS(vu.video),
                   vu.GetPathDOS(vu.target),
                    vu.GetPathDOS(vu.native),
                    vu.GetPathDOS(vu.lesson));
        }

        public void AssignFiles(string _videoFileName, string _subtFileName, string _subtNativeFileName, string _lessonFileName)
        {
            //TODO: А что если видео нет а только текст??!
            if (string.IsNullOrEmpty(_videoFileName))
                this.reader.TwinList.ListEn.VideoFileName = "";
            else this.reader.TwinList.ListEn.VideoFileName = _videoFileName;

            if (string.IsNullOrEmpty(_subtFileName))
                this.reader.TwinList.ListEn.FileName = "";
            else this.reader.TwinList.ListEn.FileName = _subtFileName;

            if (string.IsNullOrEmpty(_subtNativeFileName))
                this.reader.TwinList.ListNative.FileName = "";
            else this.reader.TwinList.ListNative.FileName = _subtNativeFileName;

            if (string.IsNullOrEmpty(_lessonFileName))
                this.reader.TwinList.ListEn.LessonFileName = "";
            else this.reader.TwinList.ListEn.LessonFileName = _lessonFileName;

            if (!this.Visible) 
                this.Visible = true;
        }

        static bool m_IsFirstRun = false;
        public static bool IsFirstRun { get { return m_IsFirstRun; } }

        // ---------- For SentenceList ----------
        private void SaveState()
        {
            SaveState(this.reader.TwinList.ListEn);
            SaveState(this.reader.TwinList.ListNative);
            CF.SetValue(CF.timeshift_video, this.reader.TwinList.ListEn.TimeShift);
            CF.SetValue("ShowParrallelSubtitles", this.btShowParrallelSubtitles.Checked);
            CF.SetValue("LanguageDirection", this.reader.LanguageDirection);

            //            if (!string.IsNullOrEmpty(this.reader.TwinList.ListEn.VideoFileName))
            CF.SetValue("VideoFileName", this.reader.TwinList.ListEn.VideoFileName);
            //CF.SetValue("ListEn_FileName", this.reader.TwinList.ListEn.FileName);            
            CF.SetValue("Lesson_FileName", this.reader.TwinList.ListEn.LessonFileName);
            // --- bool ----
            //CF.SetValue("ShowLeftText", this.reader.TwinText.menuForSelected1.miShowLeftText.Checked);
            //CF.SetValue("ShowMenuOnTextSelection", this.reader.TwinText.menuForSelected1.miShowMenuOnTextSelection.Checked);
            //CF.SetValue("PopupAsMonoDictionary", this.reader.TwinText.menuForSelected1.IsShowPopupWindow);
            CF.SetValue("ListenByClick", this.reader.TwinText.MenuForSelected.IsListenByClick);
            CF.SetValue("AddWordToTutorOnDoubleClick", this.reader.TwinText.MenuForSelected.IsAddWordToTutor);
            CF.SetValue("ShowPopupWindow", this.reader.TwinText.MenuForSelected.IsShowPopupWindow);

            CF.SetValue("MainForm", this);
            CF.SetValue("TextTwin", this.reader.TwinText.Height);
            CF.SetValue("TextForeign_Heigh", this.reader.TwinText.textForeignAndTran.paForeignText.Height);
            CF.SetValue("TextNative", this.reader.TwinText.textForeignAndTran.Width);
            CF.SetValue("ListNative", this.reader.TwinList.ListNative.Width);

            CF.SetValue("TextForeign_FontSize", this.reader.TwinText.textForeignAndTran.ForeignText.ZoomFactor);
            // TODO: so-so ZOOM
            // CF.SetValue("TextTranslate_FontSize", this.reader.TwinText.textForeignAndTran.TranslateText_del.ZoomFactor);
            CF.SetValue("TextNative_FontSize", this.reader.TwinText.textNative.ZoomFactor);

            CF.SetValue("LastDictionary", this.reader.TwinText.MenuForSelected.LastDictName);
            CF.SetValue("IsHidedTranslation", this.reader.TwinText.MenuForSelected.miHideTranslation.Checked);


            if (VideoForm.IsFormAccesible && VideoForm.CurrentForm.Visible) //TODO: можно закрыть видео форму раньше .. и тогда настройки не сохранятся
            {
                CF.SetValue("VideoFormTopMost", VideoForm.CurrentForm.TopMostManualExplicit);
                CF.SetValue("AudioLanguageIndex", VideoForm.CurrentVideoContrl.AudioLanguageIndex);

                CF.SetValue("VideoFormShowInTaskbar", VideoForm.CurrentForm.ShowInTaskbar);
                CF.SetValue("StretchVideoToFit", VideoForm.CurrentForm.StretchVideoToFit);
                CF.SetValue("VideoForm", VideoForm.CurrentForm);
            }
            //else
            //{
            //    if (VideoForm.IsVideoControlAccesible)
            //        CF.SetValue(video_contrl_width, VideoForm.CurrentVideoContrl.Width);                
            //}
            CF.SetValue(text_lists_width, this.reader.TwinList.paLists.Width);
        }

        #region config_const
        const string text_lists_width = "text_lists_width";
        #endregion 

        #region State sentenceList
        const string _FileName = "_FileName";
        const string _SentenceNumber = "_SentenceNumber";
        const string _FontSize = "_FontSize";

        void SaveState(f.SentenceList sentenceList)
        {
            CF.SetValue(sentenceList.Name + _FileName, sentenceList.FileName);
            CF.SetValue(sentenceList.Name + _SentenceNumber, sentenceList.SafeSelectedIndex.ToString());
            CF.SetValue(sentenceList.Name + _FontSize, sentenceList.FontSize.ToString());
            // CF.SetValue(sentenceList.Name + "ZoomFactor", sentenceList.TextBox.ZoomFactor.ToString());
        }

        private void RestoreState(f.SentenceList sentenceList, bool isRestoreFileName)
        {
            if (isRestoreFileName)
                sentenceList.FileName = CF.GetValue(sentenceList.Name + _FileName, "");
            sentenceList.SafeSelectedIndex = CF.GetValue(sentenceList.Name + _SentenceNumber, 0);
            sentenceList.FontSize = CF.GetValue(sentenceList.Name + _FontSize, 11.5f); // 9
            //sentenceList.TextBox.ZoomFactor = CF.GetValue(sentenceList.Name + "ZoomFactor", 1);
        } 
        #endregion
        #endregion

        #region About Settings and etc.
        void miHelpRequests_Click(object sender, EventArgs e)
        {
            Utils.AddDictionary();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            using (new AbandonTopPosition(VideoForm.CurrentForm))
            {
                X form = new X();
                form.ShowDialog(this);
            }
        }
        #endregion

        #region dictionaryBlend

        private void btHistory_Click(object sender, EventArgs e)
        {
            WordHistory wb = new WordHistory();

            wb.FillByWords(this.reader.TwinText.textForeignAndTran.ForeignText.LangDir.ToString());
            // or perhaps so
            //            wb.FillByWords(this.reader.TwinText.LangDirBySelectedText);
            wb.ShowDialog(this);
        }
        #endregion

        private void miPpenLocalLibrary_Click(object sender, EventArgs e)
        {
            string folder = Directory.GetCurrentDirectory() + "\\Library";
            if (Directory.Exists(folder))
                Runner.OpenURL(folder);
        }

    }
}