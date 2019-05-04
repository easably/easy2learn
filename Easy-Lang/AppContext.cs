using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace f
{
    class T : ApplicationContext
    {
        public static ApplicationContext ContextInstance = null;
        public static ReaderForm ReaderFormInstance = null;

        static string m_Title = "";
        public static string Title
        {
            get
            {
                return m_Title;
            }
        }

        internal const string autoFocus = "autoFocus";
        static bool m_AutoFocus = CF.GetValue(autoFocus, bool.FalseString) == bool.TrueString;
        static internal bool AutoFocus
        {
            get
            {
                return m_AutoFocus;
            }
            set
            {
                m_AutoFocus = value;
                CF.SetValue(autoFocus, m_AutoFocus.ToString());
            }
        }

        //public const string wordTutor = "WordTutor";
        //public const string worldThesaurus = "WorldThesaurus";
        //public const string easyReading1 = "EasyReading";
        //public const string dictionaryBlend = "DictionaryBlend";
        // "Bilingual Reader"

        #if !PRO
            internal const string AppName = "Easy-Lang";
        #else
            internal const string AppName = "Easy-Lang Extended";                    
        #endif


        const string no_screen = "noscreen";

        static string[] m_Args = new string[] { };
        internal static string[] Args { get { return m_Args; } }

        static internal bool NoScreen = false;
        static internal H splash = null;

        public T(string[] args)
        {
            m_Args = args;
            NoScreen = (args.Length > 0 && Array.IndexOf(args, no_screen) != -1);
            if (!NoScreen)
            {
                splash = new H();
                splash.Text = Title;
                splash.Show();
                splash.Refresh();
            }

            //int i = 0; // 147249 (получилось 147183)
            //foreach (string key in SearchIndex.Keys)
            //{
            //    Console.WriteLine(key + " - " + SearchIndex[key].Count.ToString());
            //    i += SearchIndex[key].Count;
            //}

            D.BuildIndex();
            //if (args.Length > 0 && Array.IndexOf(args, worldThesaurus) != -1)
            //{
            //    // TODO: test word
            //    WorldThesaurusForm dict = new WorldThesaurusForm();
            //    m_Title = worldThesaurus;
            //    dict.y1.txWord.Text = (args.Length > 1) ? args[1] : "Example";
            //    dict.y1.txWord.SelectAll();
            //    this.MainForm = dict;
            //}
            //else
            {
                ReaderFormInstance = new ReaderForm();
                m_Title = AppName;
                ReaderFormInstance.InitData(); // здесь же и будет создан FileSelectorInstance с последними открытым файлом
                ReaderFormInstance.reader.TwinList.videoControl1.mainMenu1.SubscribeOnEvents();

              //  ReaderFormInstance.WindowState = FormWindowState.Minimized;
                this.MainForm = ReaderForm.FileSelectorInstance;
            }
            this.MainForm.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            if (splash != null)
                splash.Close();
        }
    }
}