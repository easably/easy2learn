using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class SoundStarter
    {
        public SoundStarter(string word, string lang)
        {

            word = word.ToLower().Trim();
            // old sounds
            // string prefixGoogleForSound = @"http://www.gstatic.com/dictionary/static/sounds/de/0/{0}.mp3";

            // http://translate.google.com/translate_tts?ie=UTF-8&q=%D1%80%D0%BE%D1%82%0A&tl=ru&prev=input
            if (string.IsNullOrEmpty(word)) return;
//            string prefixGoogleForSound = @"http://translate.google.com/translate_tts?ie=UTF-8&q={0}&tl={1}";
            string prefixGoogleForSound = @"http://translate.google.com/translate_tts?q={0}&tl={1}";
         //   word = "%D1%80%D0%BE%D1%82%0A"; // рот
            string url = string.Format(prefixGoogleForSound, word, lang);
            string alternativeUrl = "";

            if (lang.Contains("en") && !word.Contains(" "))
            {
                alternativeUrl = url;
                url = string.Format(@"https://ssl.gstatic.com/dictionary/static/sounds/de/0/{0}.mp3", word);
            }
            try
            {
                play(url);
            }
            catch (Exception)
            {
                if (!string.IsNullOrEmpty(alternativeUrl))
                    try
                    {
                        play(alternativeUrl);
                    }
                    catch (Exception)
                    {
                    }
            }
        }

        private string m_Url;
        void play(string url)
        {
            m_Url = url;
            try
            {
                Thread thread = new Thread(new ThreadStart(PlayUrl)) { Name = url };
                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        void PlayUrl()
        {
            try
            {
                //    lock (wplayer)
                // if(wplayer.status.)
                {
                    // WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    //  wplayer.StatusChange += new WMPLib._WMPOCXEvents_StatusChangeEventHandler(wplayer_StatusChange);
                    //  wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
                    wplayer.URL = m_Url;
                    wplayer.controls.play();

                }
                //SD.PlayFile(m_Url);
            }
            catch (Exception) // for com exception
            {
            }
        }

        void wplayer_PlayStateChange(int NewState)
        {
            Console.WriteLine(NewState);
        }

        void wplayer_StatusChange()
        {
            Console.WriteLine("wplayer_StatusChange");
        }


        static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
    }
}
