using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WMPLib;


namespace f
{
    public partial class VideoControl : UserControl
    {
        public VideoControl()
        {
            InitializeComponent();
            this.timerForSync.Tick += new System.EventHandler(this.timerForSync_Tick);

            this.Player.PositionChange += new AxWMPLib._WMPOCXEvents_PositionChangeEventHandler(Player_PositionChange);
            this.Player.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(Player_KeyDownEvent);
            //       this.KeyDown += new KeyEventHandler(VideoForm_KeyDown);

            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            this.Player.DomainChange += new AxWMPLib._WMPOCXEvents_DomainChangeEventHandler(Player_DomainChange);
            this.Player.ErrorEvent += new EventHandler(Player_ErrorEvent);
            // для того чтобы успеть стопнуть видио при запуске программы

            this.Player.uiMode = "mini"; // http://msdn.microsoft.com/en-us/library/windows/desktop/dd562469(v=vs.85).aspx 
            //this.MinimumSize = new Size(800, 450);
        }

        //void VideoForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //     Player_KeyDownEvent(sender, new _WMPOCXEvents_KeyDownEvent((short)e.KeyCode, (short)(e.Shift ? 1 : 0)));
        //}

        #region Player_ErrorEvent
        void Player_ErrorEvent(object sender, EventArgs e)
        {
            if (this.Player.Error.errorCount > 0)
            {
                Console.WriteLine("Errors for: " + this.Player.URL);
                for (int i = 0; i < this.Player.Error.errorCount; ++i)
                {
                    Console.WriteLine("errorCode: {0}", this.Player.Error.get_Item(i).errorCode);
                    Console.WriteLine("errorDescription: {0}", this.Player.Error.get_Item(i).errorDescription);
                    Console.WriteLine("errorDescription: {0}", this.Player.Error.get_Item(i).customUrl);
                    //Console.WriteLine("errorCode: {0}", this.Player.Error.Item[i].errorCode);
                    //Console.WriteLine("errorDescription: {0}", this.Player.Error.Item[i].errorDescription);
                    //Console.WriteLine("errorDescription: {0}", this.Player.Error.Item[i].customUrl);
                }
            }
        }
        #endregion

        #region KeyDownEvent
        void Player_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (e.nKeyCode == (short)Keys.PageDown || e.nKeyCode == (short)Keys.N || e.nKeyCode == 221) // ']' - 221
            {
                if (e.nShiftState == 1 || e.nShiftState == 2)
                    ParentList.SafeSelectedIndex += 10;
                else ++ParentList.SafeSelectedIndex;
            }
            else if (e.nKeyCode == (short)Keys.PageUp || e.nKeyCode == (short)Keys.P)
            {
                if (e.nShiftState == 1 || e.nShiftState == 2)
                    ParentList.SafeSelectedIndex -= 10;
                else --ParentList.SafeSelectedIndex;
            }
            else if (e.nKeyCode == (short)Keys.S || e.nKeyCode == (short)Keys.F11 || e.nKeyCode == (short)Keys.End)
            {
                ParentList.SyncSentenceFromVideo();
            }
            else if (e.nKeyCode == (short)Keys.R || e.nKeyCode == (short)Keys.F12 || e.nKeyCode == (short)Keys.Home || e.nKeyCode == 219) // '[' - 219
            {
                ParentList.PlayCurrentSentence();
            }
            else if (e.nKeyCode == (short)Keys.Space)
            {
                PlayOrPause();
            }
            // 33 PageUp 34 PageDown


            // http://windows.microsoft.com/en-US/windows-vista/Windows-Media-Center-keyboard-shortcuts
            // http://shortcut-keys.net/windows-media-player-11-complete-shortcut-keys/
            //Console.WriteLine((Keys)e.nKeyCode);
            //Console.WriteLine(e.nShiftState);
        } 
        #endregion

        // включает режим перемещения субтитров после перемещения позиции фильма 
        // если он включен при перемещении по субтитрам могут быть проблемы с переходом на следующую фразу (заклинивание)
        // т.е. пориходит возвращение на ту же фразу
        public bool SkipSynchronize { get; set; }

        void Player_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            if (SkipSynchronize)
            {
                SkipSynchronize = false; // должно сработать только раз т.к. AutoSynchronize всегда будет останавливаться 
                return;
            }
            ParentList.SyncSentenceFromVideo();
        }

        SentenceListWithVideo m_ParentList;
        SentenceListWithVideo ParentList
        {
            get
            {
                if (m_ParentList == null) m_ParentList = T.ReaderFormInstance.reader.TwinList.ListEn;
                return m_ParentList; }
        }

        //bool IsOpening = false;

        public void InitFile(string fileName)
        {
            //       this.Text = string.Format("Opening {0}", fileName); // for parent
            try
            {
                //IsOpening = true;
                this.Player.close();
                this.Player.URL = fileName; // @"wmpdvd://" + 
                m_fileName = fileName;
                this.mainMenu1.CheckButtonsState();

         //       this.Text = string.Format("Playing {0}", fileName);
                // this.Player.Ctlcontrols.pause(); // как заставить не играть сразу после открытия файла !???
            }
            catch (AccessViolationException) //  ex)
            {
                //   Console.WriteLine(ex.Message);
            }
            finally
            {
                //IsOpening = false;
            }
            //this.Player.Ctlcontrols.isAvailable(
            //this.Text = this.Player.dvd.domain;
        }

        string m_fileName = "";
        public string MoviewName
        {
            get
            {
                if (!string.IsNullOrEmpty(m_fileName))
                    return System.IO.Path.GetFileNameWithoutExtension(m_fileName);
                else return "Your's_Moview_Name";
            }
        }

        #region FileLoaded
        //public bool FileLoaded { get { this.Player.is ; set; }

        void Player_DomainChange(object sender, AxWMPLib._WMPOCXEvents_DomainChangeEvent e)
        {
            // this.FileLoaded = true;
            // Console.WriteLine(e.strDomain);
        }
        #endregion

        #region AudioLanguage
        public Dictionary<int, string> GetAudioLanguages()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();

            IWMPControls3 wmpcontrols3 = this.Player.Ctlcontrols as IWMPControls3;
            if (wmpcontrols3 != null)
            {
                for (int i = 1; i <= wmpcontrols3.audioLanguageCount; ++i)
                {
                    try
                    {
                        int ind = wmpcontrols3.getAudioLanguageID(i);

                        if (!ret.ContainsKey(ind) && ind > 0) // on Windows 7 64 was returned negative value -5
                            ret.Add(ind, wmpcontrols3.getLanguageName(ind));
                        // else Console.WriteLine("Duplicated key {0} for language {1}", ind, wmpcontrols3.getLanguageName(ind));
                    }
                    catch { return ret; }
                }
            }
            return ret;
        }

        // wmpcontrols3.currentAudioLanguageIndex работает как то инертно
        public int AudioLanguageIndex
        {
            set
            {
                IWMPControls3 wmpcontrols3 = this.Player.Ctlcontrols as IWMPControls3;
                try
                {

                    if (wmpcontrols3 != null)
                        wmpcontrols3.currentAudioLanguage = value;
                }
                catch
                {
                    Console.WriteLine("currentAudioLanguage is {0}, attempt to assign value {1}", wmpcontrols3.currentAudioLanguage, value);
                }
            }
            get
            {
                IWMPControls3 wmpcontrols3 = this.Player.Ctlcontrols as IWMPControls3;
                if (wmpcontrols3 != null)
                    return wmpcontrols3.currentAudioLanguage;
                return -1;
            }
        }
        #endregion

        #region IsPlaying
        internal void PlayOrPause()
        {
            if (this.IsPlaying)
            {
                this.Player.Ctlcontrols.pause();
            }
            else
            {
                this.ParentList.PlayAlways();
                //// for windows7 because Player_PlayStateChange not working (on XP all OK)
                //if (!VideoForm.CurrentForm.IsPlaying)
                //    _PlayState = 3;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return this.Player.playState == WMPPlayState.wmppsPlaying; //  wmppsPlaying = 3,
                // return _PlayState == 3; // 3-plaing 2-pause
            }
        }

        int _PlayState = -1; // 9 вроде загрузка

        void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            Console.WriteLine(e.newState);

            if (_PlayState == 9 && e.newState == 3) // значит это открытие после загрузки
            {
                //this.BeginInvoke(new MethodInvoker(DoDelayedPause));

                Dictionary<int, string> langs = GetAudioLanguages();
                if (langs.Count > 0)
                {
                    foreach (KeyValuePair<int, string> pair in langs)
                    {
                        int val = CF.GetValue("AudioLanguageIndex", pair.Key);
                        this.AudioLanguageIndex = val;
                        break;
                    }
                }
            }
            else if (e.newState == 3) // включили проигрывание
            {
                //if (!ParentList.timerForVideoManualControl.Enabled)
                //    this.btPauseMode.Checked = false;
            }
            _PlayState = e.newState;

            OffOnAutoSyncrForSubtitles();
        }

        void OffOnAutoSyncrForSubtitles()
        {
            if (this.ParentList != null && !this.ParentList.timerForVideoManualControl.Enabled)
                this.timerForSync.Enabled = this.IsPlaying;
        }

        private void DoDelayedPause()
        {
            this.Player.Ctlcontrols.pause();
        }
        #endregion

        private void timerForSync_Tick(object sender, EventArgs e)
        {
            if (this.ParentList.CurrentSentenceWithVideo == null) return;
            if (!this.ParentList.timerForVideoManualControl.Enabled)
                if (this.Player.Ctlcontrols.currentPosition > this.ParentList.GetEndForCurrentSentence())
                {
                    this.ParentList.SyncSentenceFromVideo();
                }
        }

        private string GetNameForSate(int state)
        {
            switch (state)
            {
                case 0:    // Undefined
                    return "Undefined";

                case 1:    // Stopped
                    return "Stopped";

                case 2:    // Paused
                    return "Paused";

                case 3:    // Playing
                    return "Playing";

                case 4:    // ScanForward
                    return "ScanForward";

                case 5:    // ScanReverse
                    return "ScanReverse";

                case 6:    // Buffering
                    return "Buffering";

                case 7:    // Waiting
                    return "Waiting";

                case 8:    // MediaEnded
                    return "MediaEnded";

                case 9:    // Transitioning
                    return "Transitioning";

                case 10:   // Ready
                    return "Ready";

                case 11:   // Reconnecting
                    return "Reconnecting";

                case 12:   // Last
                    return "Last";

                default:
                    return "Unknown State";
            }
        }

        bool m_FullScreen = false;
        public bool FullScreen { get { return m_FullScreen; } set { m_FullScreen = value; this.Player.fullScreen = m_FullScreen; } }

        public double PlaybackRate
        {
            get { return Player.settings.rate; }
            set { Player.settings.rate = value; }
        } 
    }
}
