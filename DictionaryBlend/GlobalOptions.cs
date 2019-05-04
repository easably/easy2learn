using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public static class GlobalOptions
    {
        static bool m_IsChangedLesson = false;
        public static event EventHandler ChangedLesson;


        public static bool IsChangedLesson 
        {
            get { return m_IsChangedLesson; }
            set {
               // незя свойство как сигнал if(m_IsChangedLesson != value)
                {
                    m_IsChangedLesson = value;
                    if (ChangedLesson != null)
                        ChangedLesson.Invoke(null, EventArgs.Empty);
                } 
            }
        }

        public static bool IsChangedText = false;

        #region FileExtensions
        public static string Allfiles = "|All files (*.*)|*.*";

        static string[] commonDVDExt = new string[] { ".ifo" }; // , ".VOB"
        static string[] commonVideoExt = new string[] { ".DivX", ".XviD", ".3GP", ".WMV", ".ASF", ".MOV", ".QT", ".VOB", ".MPEG", ".AVI", ".MP4", ".MKV", ".ifo" };
        public static string[] AllVideoExt = new string[] {
        ".mp4", ".m4v", ".mp4v", ".mpv4", ".hdmov", ".3gp", ".3gpp", ".dat", ".avi", ".wmv", ".wmp", ".wm", ".asf",
".mpg", ".mpeg", ".mpe", ".m1v", ".m2v", ".mpv2", ".mp2v", ".ts", ".tp", ".tpr", ".pva", ".m2ts", ".m2t", ".mts", ".evo", ".m2p",
".drc", ".mpls", ".bdmv", ".dsm", ".dsv", ".dsa", ".dss", ".vob", ".ifo", ".d2v", ".flv", ".iflv", ".f4v",
".ogm", ".ogv", ".mov", ".3g2", ".3gp2", ".ratdvd", ".rm", ".ram", ".rpm", ".rmm", ".rt", ".rp", ".smi", ".smil",
".fli", ".flc", ".flic", ".ivf", ".mkv", ".divx", ".vp6", ".rmvb", ".amv", ".roq", ".swf", ".smk", ".bik",
".ifo"
        };

        // got from http://www.fileinfo.com/filetypes/video
        //public static string[] allVideoFiles = new string[] {".dvdmedia", ".mpgindex", ".sfvidcap", ".rcproject", ".playlist",
        //    ".264", ".3g2", ".3gp", ".3gp2", ".3gpp", ".3gpp2", ".3mm", ".3p2", ".60d", ".aep", ".ajp", ".amv", ".amx", ".arf", ".asf", ".asx", ".avb", ".avd", ".avi", ".avs", ".avs", ".axm", ".bdm", ".bdmv", ".bik", ".bin", ".bix", ".bmk", ".box", ".bs4", ".bsf", ".byu", ".camrec", ".clpi", ".cpi", ".cvc", ".d2v", ".d3v", ".dat", ".dav", ".dce", ".dck", ".ddat", ".dif", ".dir", ".divx", ".dlx", ".dmb", ".dmsm", ".dmss", ".dnc", ".dpg", ".dream", ".dsy", ".dv	", ".dv-avi", ".dv4", ".dvr-ms", ".dvx", ".dxr", ".evo", ".eye", ".f4v", ".fbr", ".fbr", ".fbz", ".fcp", ".flc", ".flh", ".fli", ".flv", ".flx", ".gl	", ".grasp", ".gts", ".gvi", ".gvp", ".hdmov", ".hkm", ".ifo", ".imoviep", ".imoviep", ".iva", ".ivf", ".ivr", ".ivs", ".izz", ".izzy", ".jts", ".lsf", ".lsx", ".m15", ".m1pg", ".m1v", ".m21", ".m21", ".m2a", ".m2p", ".m2t", ".m2ts", ".m2v", ".m4e", ".m4u", ".m4v", ".m75", ".meta", ".mgv", ".mj2", ".mjp", ".mjpg", ".mkv", ".mmv", ".mnv", ".mod", ".modd", ".moff", ".moi", ".moov", ".mov", ".movie", ".mp21", ".mp21", ".mp2v", ".mp4", ".mp4v", ".mpe", ".mpeg", ".mpeg4", ".mpf", ".mpg", ".mpg2", ".mpl", ".mpls", ".mpv", ".mpv2", ".mqv", ".msdvd", ".msh", ".mswmm", ".mts", ".mtv", ".mvb", ".mvc", ".mvd", ".mve", ".mvp", ".mxf", ".mys", ".ncor", ".nsv", ".nvc", ".ogm", ".ogv", ".ogx", ".osp", ".par", ".pds", ".pgi", ".piv", ".pmf", ".prel", ".pro", ".prproj", ".psh", ".pva", ".pvr", ".pxv", ".qt", ".qtch", ".qtl", ".qtm", ".qtz", ".rdb", ".rec", ".rm", ".rmd", ".rmp", ".rms", ".rmvb", ".roq", ".rp", ".rts", ".rts", ".rv	", ".sbk", ".scm", ".scm", ".scn", ".sec", ".seq", ".smi", ".smil", ".smk", ".sml", ".smv", ".spl", ".ssm", ".str", ".stx", ".svi", ".swf", ".swi", ".swt", ".tda3mt", ".tivo", ".tix", ".tod", ".tp", ".tp0", ".tpd", ".tpr", ".trp", ".ts	", ".tvs", ".vc1", ".vcr", ".vcv", ".vdo", ".vdr", ".veg", ".vem", ".vf	", ".vfw", ".vfz", ".vgz", ".vid", ".viewlet", ".viv", ".vivo", ".vlab", ".vob", ".vp3", ".vp6", ".vp7", ".vpj", ".vro", ".vsp", ".wcp", ".webm", ".wm	", ".wmd", ".wmmp", ".wmv", ".wmx", ".wp3", ".wpl", ".wtv", ".wvx", ".xfl", ".xvid", ".yuv", ".zm1", ".zm2", ".zm3", ".zmv" };
        public static string GetFileFilterForVideo(bool addAllFilter)
        {
            string commonVideoNames = "";
            string commonVideoFilters = "";
            foreach (string s in commonVideoExt)
            {
                commonVideoNames += (commonVideoNames == "" ? "" : ", ") + s.ToLower();
                commonVideoFilters += "*" + s.ToLower() + ";";
            }

            string allVideoNames = "";
            string allVideoFilters = "";
            foreach (string s in AllVideoExt)
            {
                allVideoNames += (allVideoNames == "" ? "" : ", ") + s;
                allVideoFilters += "*" + s + ";";
            }

            string commonDVDExtNames = "";
            foreach (string s in commonDVDExt)
            {
                commonDVDExtNames += "*" + s + ";";
            }

//            string ret = string.Format("Common video ({0})|{1}|DVD Files |{4}|All video ({2})|{3}",
            string ret = string.Format("All video |{1}|DVD Files |{2}|Common video |{4}",
                    allVideoNames, allVideoFilters,
                    commonDVDExtNames, 
                    commonVideoNames, commonVideoFilters
                    );
            
            if (addAllFilter)
                return ret + Allfiles;
            return ret;
        }

        public static bool IsVideo(string fileName)
        {
            return IsContainExt(fileName, AllVideoExt);
        }

         
        //        string[] allSubTitlesFiles = new string[] { ".srt", ".rum", ".sbt", ".w32", };
        // from media player
        public static string[] SubtitlesFileExtensions = new string[] { ".srt", ".sub", ".txt", ".smi", ".ssa", ".ass", ".psb", ".idx", ".usf", ".xss"};
        public static string GetFileFilterForSubtitles(bool addAllFilter)
        {
            string allSubFilters = "";
            string allSubNames = "";
            foreach (string s in SubtitlesFileExtensions)
            {
                allSubNames += (allSubNames == "" ? "" : ", ") + s;
                allSubFilters += "*" + s + ";";
            }
            string ret = string.Format("SubTitles files ({0})|{1}", allSubNames, allSubFilters);
            if (addAllFilter)
                return ret + Allfiles;
            return ret;
        }
        public static bool IsSubtitle(string fileName)
        {
            return IsContainExt(fileName, SubtitlesFileExtensions);
        }

        public static string LessonFileExtension = ".lesson";
        public static string GetFileFilterForLesson(bool addAllFilter)
        {
            string ret = string.Format("Lesson files (*{0})|*{0}", GlobalOptions.LessonFileExtension);
            if (addAllFilter)
                return ret + Allfiles;
            return ret;
        }

        public static bool IsLesson(string fileName)
        {
            return fileName.EndsWith(LessonFileExtension);
        }

        public static string[] TextFileExtensions = new string[] { ".rtf", ".txt" };
        public static string GetFileFilterForText(bool addAllFilter)
        {
            string ret = string.Format("Text files (*{0},*{1})|*{0};*{1}", TextFileExtensions[0], TextFileExtensions[1]);
            if (addAllFilter)
                return  ret + Allfiles;
            return ret;
        }
        public static bool IsText(string fileName)
        {
            return IsContainExt(fileName, TextFileExtensions);
        }
    
        public static bool IsContainExt(string fileName, Array array)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            if (string.IsNullOrEmpty(ext))
            {
                MessageBox.Show(string.Format("File '{0}' without extension.", fileName));
                return false;
            }
            foreach (string s in array)
                if (ext.Equals(s.ToLower()))
                    return true;
            return false;
        }
        #endregion

        #region WorkedDictionaries
        static GlobalOptions()
        {
            InitDictionaries();
        }

        public static void InitDictionaries()
        {
            dictionaries.Clear();
            string[] includedDictionaries = AvailableDictionaries.Split(splitterForAvailableDictionaries);
            foreach (Type type in AllDictionaries)
            {
                if (Array.IndexOf(includedDictionaries, type.FullName) != -1)
                    dictionaries.Add(type);
            }
        }

        static internal List<Type> dictionaries = new List<Type>();

        public static Type[] WorkedDictionaries
        {
            get { return (Type[])dictionaries.ToArray(); }
        } 
        #endregion

        private const string nameGenerateArticlesWithJScript = "GenerateArticleWithJScript";

        public static bool GenerateArticlesWithJScript
        {
            get { return bool.Parse(CF.GetValue(nameGenerateArticlesWithJScript, bool.TrueString)); }
            set { CF.SetValue(nameGenerateArticlesWithJScript, value.ToString());} 
        }

        private const string nameAvailableDictionaries = "AvailableDictionaries";
        const char splitterForAvailableDictionaries = ';';
        
        public static string AvailableDictionaries
        {
            get {
                string res = CF.GetValue(nameAvailableDictionaries, AllDefaulfDictionariesAsString());
                #region check and add requred dictionary
                if (Array.IndexOf(res.Split(splitterForAvailableDictionaries), DictionaryProvider.RequiredDictionary) == -1)
                    res += splitterForAvailableDictionaries + DictionaryProvider.RequiredDictionary;
                
                #endregion                
                return  res;
            }
            set { CF.SetValue(nameAvailableDictionaries, value); }
        }

        public static bool IsContainsConfig
        {
            get { return CF.Config.HasFile; }
        }

        public static Type[] AllDictionaries = new Type[] { 
            typeof(GoogleDictionary), 
        //    typeof(GoogleTranslate), 
            typeof(GoogleWebDefinition), 
            typeof(GoogleMonoDictionary), 
            typeof(GoogleSynonymsDictionary), 
            typeof(GoogleTranslateForIdiom), 

            typeof(Lingvo), 
            typeof(MultitranDictionary), 
            typeof(Babylon), 
            typeof(DicAcademic),  
            typeof(Leo_org),
            typeof(Thefreedictionary), 
            typeof(WordreferenceCom),

            typeof(Synonymizer),

            typeof(DicAcademicDef),     

            // typeof(Freeopendictionary), 
            // typeof(CambridgeIdioms),

            // en mono 
            typeof(Oxford), 
            typeof(WordNet), 
            typeof(Dictionary_com), 

            typeof(UrbanDictionary), 
            typeof(MerriamWebster),
                        
            typeof(Britannica),
            typeof(BritannicaEncyclopedia),     
            typeof(Longman),

            typeof(Dictionary_Encyclopedia),       
            typeof(MerriamWebsterThesaurus),



            typeof(Wikipedia), 
            typeof(Wiktionary),

            // idioms
            typeof(IdiomThefreedictionary),
            typeof(Wikidioms),
            typeof(Idiomcenter),

// typeof(),
        };

        static string AllDefaulfDictionariesAsString()
        {
            string res = "";
            foreach (Type type in AllDictionaries)
            {
                if (type.Equals(typeof(GoogleDictionary))
                 || type.Equals(typeof(Lingvo))
                 || type.Equals(typeof(Wiktionary))
                //     ||  (type.Equals(typeof(MultitranDictionary)))
                )
                res += type.FullName + splitterForAvailableDictionaries;
            }
            return res;
        }
    }
}
