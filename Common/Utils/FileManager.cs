using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace f
{
    public static class FileManager
    {
        public static string CheckAndCreateFolder(string targetFolder)
        {
            // C:\Users\serg\Documents\easy4learn\Euronews
            string folder = CF.GetFolderForUserFiles() + "\\" + targetFolder;
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            return folder;
        }

        public static string FindPath(string fileName, string altResult)
        {
            string result = FindPathAndReturnFullFileName(fileName);
            if (!File.Exists(result))
                return altResult;
            return result;
        }
        
        public static string FindPathAndReturnFullFileName(string fileName)
        {
            if ( string.IsNullOrEmpty(fileName) || File.Exists(fileName))
                return fileName;

            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + fileName))
                fileName = Path.GetDirectoryName(Application.ExecutablePath) + fileName;
            else
            {
                string slesh = "";
                if (!fileName.StartsWith("\\")) slesh = "\\";

                if (File.Exists(Application.StartupPath + slesh + fileName))
                {
                    fileName = Application.StartupPath + slesh + fileName;
                    return fileName;
                }
                if (File.Exists(Directory.GetCurrentDirectory() + slesh + fileName))
                {
                    fileName = Directory.GetCurrentDirectory() + slesh + fileName;
                    return fileName;
                }
                string location = Assembly.GetExecutingAssembly().Location;
                location = Path.GetDirectoryName(location);
                if (File.Exists(location + slesh + fileName))
                {
                    fileName = location + slesh + fileName;
                    return fileName;
                }
            }
            return fileName;
        }

      //  public static string GetStringFrоmFile(string fileName, params string pr)
        public static string GetStringFrоmFile(string fileName, string param)
        {
            return GetStringFrоmFile(string.Format(fileName, param), Encoding.UTF8);
        }

        public static string GetStringFrоmFile(string fileName)
        {
            return GetStringFrоmFile(fileName, Encoding.UTF8);
        }

        public static string GetStringFrоmFile(string fileName, Encoding encoding)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("File '{0}' not found", fileName);
            using(TextReader tr = new StreamReader(fileName, encoding))
            {
                string result = tr.ReadToEnd();
                result = result.Replace("\r\n", "\n");
                return result;
            }
        }

        public static void CreateFile(string fileName, string param, string text)
        { 
            CreateFile(string.Format(fileName, param), text);
        }
        
        public static string CreateFile(string fileName, string text)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(fileName)) // by default UTF-8
                {
                    sw.Write(text);
                }
            }
            //  System.NotSupportedException: path is in an invalid format. {"The given path's format is not supported."}
            catch (NotSupportedException)
            {
                string path = Path.GetFullPath(fileName); 
                string file = Path.GetFileName(fileName);
                fileName = path + TuneFileName(file);
                using (StreamWriter sw = File.CreateText(fileName)) // by default UTF-8
                {
                    sw.Write(text);
                }
            }
            return fileName;
        }

        public static string TuneFileName(string file)
        {
            return file.Replace(@"\", "_").Replace(@"/", "_") // symbols from http://support.microsoft.com/kb/177506
                .Replace(':', '_').Replace('*', '_').Replace('"', '_')
                .Replace('?', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_');
        }

        //public static void CreateFile(string fileName, string text, Encoding enc)
        //{
        //    using (StreamWriter sw = new StreamWriter(fileName, false, enc)) // by default UTF-8
        //    {
        //        sw.Write(text);
        //    }
        //}

        #region action with names
        public static string GetFileName(string dirWithFileName)
        {
            string fileName = GetLastDirName(dirWithFileName);

            int i = fileName.LastIndexOf('.');
            return fileName.Substring(0, i);
        }

        public static string GetFileExtension(string dirWithFileName)
        {
            string fileName = GetLastDirName(dirWithFileName);

            int i = fileName.LastIndexOf('.');
            return fileName.Substring(i + 1, fileName.Length - i - 1);
        }

        public static string GetLastDirName(string dir)
        {
            if (string.IsNullOrEmpty(dir)) return "";
            int i = dir.LastIndexOf('\\');
            if (i == -1) return dir;
            return dir.Trim('\\').Substring(i + 1, dir.Length - i - 1);
        }

        public static string GetDirectory(string fullfileName)
        {
            if (string.IsNullOrEmpty(fullfileName)) return "";
            int i = fullfileName.LastIndexOf('\\');
            if (i == -1) return fullfileName;
            return fullfileName.Substring(0, i);
        } 
        #endregion
    }
}
