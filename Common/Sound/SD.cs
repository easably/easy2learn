using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

    public class SD
    {
        const string fileNameSoundWords = "SoundWordsE.dat";

        #region инициализация
        public SD()
        {
            if (Index == null) return;
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
                            byte[] indexContent = new byte[T.l];
                            dic.Read(indexContent, 0, T.l);
                            indexContent = ZipUtil.DeCompress(indexContent);
                            m_Index = UnicodeEncoding.UTF8.GetString(indexContent);
                        }
                    }
                }
                return m_Index;
            }
        }
        #endregion

        string SoundFileName
        {
            get
            {               
                if( File.Exists(fileNameSoundWords) )
                    return fileNameSoundWords;
                else if( File.Exists(@"\dict\" + fileNameSoundWords) )
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
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        private static extern long mciSendString2(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        static void PlayFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            string command = "close Mp3File";
            mciSendString2(command, null, 0, 0);
            command = "open " + "\"" + fileName + "\"" + " type MPEGVideo alias Mp3File";
            mciSendString2(command, null, 0, 0);
            // command = "seek Mp3File to 3000799";
            command = "play Mp3File";
            mciSendString2(command, null, 0, 0);
        } 
        #endregion

        #region GetWordIndex
        string GetWordIndex(string word)
        {
            word = '\n' + word.ToLower().Trim() + ';';
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

        #region GetFileNameByWord
		string GetFileNameByWord(string word)
        {
            if (Index == null) return null;
            string index = GetWordIndex(word);
            if( string.IsNullOrEmpty(index)) return null;


            int pos = int.Parse(index.Split(';')[1]) + T.l;
            int length = int.Parse(index.Split(';')[2]);
            
            using (FileStream dic = new FileStream(this.SoundFileName, FileMode.Open))
            {
                dic.Position = pos;
                byte[] content = new byte[length];
                dic.Read(content, 0, length);
                string tempDir = Environment.CurrentDirectory + "\\dict\\";
                string fileName = tempDir + "180414B2EE0D.wav";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    if( File.Exists(fileName) )
                        fileName = tempDir + "CD4FEC9D.wav";
                }
                FileStream wordFile = new FileStream(fileName, FileMode.Create);
                wordFile.Write(content, 0, length);
                wordFile.Close();
                return wordFile.Name;
            }
        }
	    #endregion    
    }