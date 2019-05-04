using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace f
{
    public class VideoUnit
    {
        [Obsolete("Not for used (конструктор оствлен только для того чтобы не ругался JSON сериализатор)", true)]
        public VideoUnit() {}
        public VideoUnit(string path)
        {
          //  this.path = path + (path.EndsWith("\\") ? "" : "\\"); // path mybe as C:/Users/serg/Documents/Easy4Learn/euronews/2014_05_13_Unpaid bills pile pressure on European firms/
            this.path = path;
        }

        public string path { get; set; }
        public string title { get; set; }

        public string description { get; set; }
        public string target { get; set; }

        // allFiles
        public string native { get; set; }
        public string lesson { get; set; }
        public string video { get; set; }
        public string img { get; set; }

        public static string FirstSentence = "Source: {0}";
//        public static string FirstSentence = "This video was downloaded from: {0}";
//        public static string FirstSentence = "This video was downloaded from: {0}" + Environment.NewLine + "Title: {1}";

        #region ToJSON ---- depricated --- 
        public const string JSONTemplate = "\"path\":\"{0}\", \"title\":\"{1}\", {2}";
        public string ToJSONString()
        {
            return "{" + string.Format(JSONTemplate, this.path, this.title,
                      (string.IsNullOrEmpty(path) ? "" : "\"path\":\"" + path + "\", ")
                    + (string.IsNullOrEmpty(title) ? "" : "\"title\":\"" + title + "\", ")
                    + (string.IsNullOrEmpty(description) ? "" : "\"description\":\"" + description + "\", ")
                    + (string.IsNullOrEmpty(target) ? "" : "\"target\":\"" + target + "\", ")
                    + (string.IsNullOrEmpty(native) ? "" : "\"native\":\"" + native + "\", ")
                    + (string.IsNullOrEmpty(lesson) ? "" : "\"lesson\":\"" + lesson + "\", ")
                    + (string.IsNullOrEmpty(video) ? "" : "\"video\":\"" + video + "\", ")
                    + (string.IsNullOrEmpty(img) ? "" : "\"video\":\"" + img + "\", ")
                ) + "}";
        } 
        #endregion

        #region GetUnit
        /// <summary>
        /// При использовании полагать что может быть исключение
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static VideoUnit GetUnit(string path)
        {
            VideoUnit vu = new VideoUnit(path.Replace(@"\", @"/"));// http://jsonformatter.curiousconcept.com/ "path":"C://Users\\serg\\
            string[] allFiles = Directory.GetFiles(path); // когда директория не найдена вернет будет исключение DirectoryNotFoundException (могут быть и другие исключения)
            vu.video = GetFile(path, CurrentLangInfo.CurrentLangPair.From + ".mp4", allFiles, ".ogv", null); // ogv ...
            vu.target = GetFile(path, CurrentLangInfo.CurrentLangPair.From + ".srt", allFiles, ".txt", vu.native); // ... sub
            vu.native = GetFile(path, CurrentLangInfo.CurrentLangPair.To + ".srt", allFiles, ".txt", vu.target);
            vu.lesson = GetFile(path, ".lesson", allFiles, "", null);
            vu.img = GetFile(path, "thumb.jpg", allFiles, ".png", null);
            int startInd = path.LastIndexOf(@"\", path.Length - 2) + 1;
            vu.title = path.Substring(startInd).TrimEnd('\\');
            if ( vu.title[4] == '_' && vu.title[7] == '_' && vu.title[10] == '_') // cut part 2014_05_22_ from 2014_05_22_Morocco makes renewable energy progress while the sun shines
                vu.title = vu.title.Substring(11);
            return vu;
        }

        private static string GetFile(string path, string defaultFile, string[] allFiles, string elseWhereMask, string excludePattern)
        {
            if (File.Exists(path + defaultFile))
                return defaultFile;
            string ext = defaultFile.Substring(defaultFile.LastIndexOf('.'));
            string res = allFiles.Where(f => f.EndsWith(ext)
                && (excludePattern == null || !f.EndsWith(excludePattern))).FirstOrDefault();
            if (string.IsNullOrEmpty(res) && !string.IsNullOrEmpty(elseWhereMask))
            {
                res = allFiles.Where(f => f.EndsWith(elseWhereMask) 
                    && (excludePattern == null || !f.EndsWith(excludePattern))).FirstOrDefault();
            }
            if(!string.IsNullOrEmpty(res) && res.LastIndexOf(@"\")>0)
                res = res.Substring(res.LastIndexOf(@"\")+1);
            return res;
        } 
        #endregion

        public static string GetUnitsJSON(List<VideoUnit> lists)
        {
            string result = "[";
            bool isStart = true;
            string comma = "";
            foreach (VideoUnit vu in lists)
            {
               // result += comma + vu.ToJSONString();
                result += comma + vu.ToJson();
                if (isStart) { comma = ", "; isStart = false; }
            }
            return result + "]";
        }

        public static List<VideoUnit> GetUnits()
        {
            List<VideoUnit> result = new List<VideoUnit>();
            string path = CF.GetFolderForUserFiles() + "\\" + EuronewsBrowser.rootFolderName + "\\";
            try
            {
                if (Directory.Exists("path")) {
                    foreach (string p in Directory.GetDirectories(path).Reverse())
                    {
                        result.Add(GetUnit(p + "\\"));
                        // break;
                    }
                }
            }
            catch {
                Console.WriteLine(path);
                //TODO: working with paths
            }
            return result;
        }

        public string GetPathDOS()
        {
            return this.path.Replace(@"/", @"\");
        }

        internal string GetPathDOS(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;
            if (Path.IsPathRooted(path)) return path;
            else return GetPathDOS() + path;
        }
    }
}
