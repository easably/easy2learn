using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace f
{
    public class SD
    {
        #region инициализация
        public SD()
        {
            if (Index == null) return;
            //           Queue
        }

        string m_Index = null;
        string Index
        {
            get
            {
                if (m_Index == null)
                {
                    if (!string.IsNullOrEmpty(this.SoundFileName))
                    {
                        using (FileStream dic = new FileStream(this.SoundFileName, FileMode.Open))
                        {
                            byte[] indexContent = new byte[l];
                            dic.Read(indexContent, 0, l);
                            indexContent = ZipUtil.DeCompress(indexContent);
                            m_Index = UnicodeEncoding.UTF8.GetString(indexContent);
                        }
                    }
                }
                return m_Index;
            }
        }
        #endregion

        const string fileNameSoundWords = "SoundWordsE.dat";
        string SoundFileName
        {
            get
            {
                if (File.Exists(fileNameSoundWords))
                    return fileNameSoundWords;
                else if (File.Exists(@"\dict\" + fileNameSoundWords))
                    return @"\dict\" + fileNameSoundWords;
                else if (File.Exists(@"c:\" + fileNameSoundWords))
                    return @"c:\" + fileNameSoundWords;
                else return null;
            }
        }

        public void PlayWord(string word)
        {
            string filename = GetFileNameByWord(word);
            PlayFile(filename);
        }

        #region PlayFile
        //CharSet = CharSet.Auto, ExactSpelling = true, 
        //[DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        //private static extern int mciSendString2(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        // http://stackoverflow.com/questions/15025626/playing-a-mp3-file-in-a-winform-application
        public static void PlayFile(string fileName)
        {
            try
            {

                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = fileName;
                wplayer.controls.play();

                //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                //player.SoundLocation = fileName;
                //player.Play();
            }
            catch { }
        }

        #region old
        //[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //private static extern int mciSendString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrCommand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrReturnString, int uReturnLength, int hwndCallback);

        ////[DllImport("winmm.dll", EntryPoint = "mciGetErrorStringA")]
        ////private static extern long mciGetErrorString(long fdwError, ref string lpszErrorText, long cchErrorText);

        //[DllImport("winmm.dll", EntryPoint = "mciGetErrorStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        ////[MarshalAs(UnmanagedType.VBByRefStr)]
        //private static extern int mciGetErrorString(int dwError, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrBuffer, int uLength);

        //public static string PlayFileOld(string fileName)
        //{
        //    string result = "";
        //    try
        //    {
        //        if (string.IsNullOrEmpty(fileName)) return "Parameter fileName is empty";
        //        string foo = "";
        //        //      Status();

        //        string command = "close Mp3File";
        //        mciSendString(ref command, ref foo, 0, 0);

        //        command = string.Format("open \"{0}\" type MPEGVideo alias Mp3File", fileName);
        //        //      Status();
        //        mciSendString(ref command, ref foo, 0, 0);
        //        // command = "seek Mp3File to 3000799";
        //        command = "play Mp3File";
        //        //     Status();
        //        int longResult = mciSendString(ref command, ref foo, 0, 0);
        //        long errorSuccess = mciGetErrorString(longResult, ref result, 128);
        //    }
        //    catch (AccessViolationException)
        //    {
        //        Console.WriteLine("Error in function 'PlayFile' fo file '{0}'", fileName);
        //    }
        //    return result;
        //}
        //[DllImport("winmm.dll", EntryPoint = "mciGetErrorStringA")]
        //private static extern long mciSendString2(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// Получение текущего статуса
        /// </summary>
        //public static String Status()
        //{
        //    int i = 128;
        //    System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(i);
        //    mciSendString2("status MediaFile mode", stringBuilder, i, IntPtr.Zero);
        //    Console.WriteLine(stringBuilder.ToString());
        //    return stringBuilder.ToString();
        //}
        #endregion

        #endregion

        #region GetWordIndex
        public string GetWordIndex(string word)
        {
            word = '\n' + word.ToLower().Trim() + ';';
            if (this.Index == null)
                return "";
            int i = this.Index.IndexOf(word);
            if (i != -1)
            {
                int iLength = this.Index.IndexOf('\r', i) - i;
                string ret = this.Index.Substring(i, iLength);
                return ret;
            }
            return "";
        }
        #endregion

        string procId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();

        #region GetFileNameByWord
        //TODO: quene для скорости
        string GetFileNameByWord(string word)
        {
            if (Index == null) return null;
            string index = GetWordIndex(word);
            if (string.IsNullOrEmpty(index)) return null;


            int pos = int.Parse(index.Split(';')[1]) + l;
            int length = int.Parse(index.Split(';')[2]);

            using (FileStream dic = new FileStream(this.SoundFileName, FileMode.Open))
            {
                dic.Position = pos;
                byte[] content = new byte[length];
                dic.Read(content, 0, length);
                string fileName = Utils.TempDir + procId + "180414B2EE0D.wav";
                //while (File.Exists(fileName))
                //{
                //    try
                //    {
                //        File.Delete(fileName);
                //    }
                //    catch (IOException)
                //    {
                //        fileName = tempDir + Guid.NewGuid();
                //    }
                //    catch (UnauthorizedAccessException)
                //    {
                //        fileName = tempDir + Guid.NewGuid();
                //    }
                //}
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    if (File.Exists(fileName))
                        fileName = Utils.TempDir + procId + "CD4FEC9D.wav";
                }
                FileStream wordFile = new FileStream(fileName, FileMode.Create);
                wordFile.Write(content, 0, length);
                wordFile.Close();
                return wordFile.Name;
            }
        }
        #endregion

        internal const int l = 201484;

        ~SD()
        {
            //if (Directory.Exists(tempDir))
            //{
            foreach (string fileName in Directory.GetFiles(Utils.TempDir, "*.wav"))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch
                {
                }
            }
            //  }
        }
    }
}