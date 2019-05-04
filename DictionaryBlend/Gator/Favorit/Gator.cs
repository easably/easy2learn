using System;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Diagnostics;

namespace f
{
    public class Gator
    {
        static Dictionary<string, Gator> m_GatorPool = new Dictionary<string, Gator>();
        static Dictionary<string, Gator> GatorPool
        {
            get { return m_GatorPool; }
        }

        public bool ShowArticles(string word, string codeFrom, string codeTo, IWaitingUIObject waitingUiObject)
        {
            if (GatorPool.ContainsKey(word))
            {
                return false; // waiting when was completed other gator 
            }
            else
            {
                try
                {
                    GatorPool.Add(word, this);
                    bool result = ShowArticles_body(word, codeFrom, codeTo, waitingUiObject);
                    return result;
                }
                finally
                { 
                    if( GatorPool.ContainsValue(this) )
                        GatorPool.Remove(word);
                }
            } 
        }

        bool ShowArticles_body(string word, string codeFrom, string codeTo, IWaitingUIObject waitingUiObject)
        {
            //http://www.albahari.com/threading/part2.aspx
            if (waitingUiObject != null)
                lock (waitingUiObject)
                {
                    ++waitingUiObject.WaitingProgressCounter;
                }
            string fileName = this.GetContents(word, codeFrom, codeTo);
            if (string.IsNullOrEmpty(fileName))
            {
                string mes = string.Format("Word '{0}' not founded", word);
                MessageBox.Show(mes, "DictionaryBlend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Runner.OpenURL(fileName);
            if (waitingUiObject != null)
                lock (waitingUiObject)
                {
                    --waitingUiObject.WaitingProgressCounter;
                }            
            return true;
        }

        #region for threads
        public class GatorStarter
        {
            private string m_word;
            private string m_codeFrom;
            private string m_codeTo;
            private IWaitingUIObject m_waitingUiObject;

            public GatorStarter(string word, string codeFrom, string codeTo, IWaitingUIObject waitingUiObject)
            {
                //foreach (System.Diagnostics.ProcessThread th in Process.GetCurrentProcess().Threads)
                //{ 
                //    if (th.Name.Equals(word))
                //        return;
                //}

                m_word = word;
                m_codeFrom = codeFrom;
                m_codeTo = codeTo;
                m_waitingUiObject = waitingUiObject;
                Thread thread = new Thread(new ThreadStart(Run)) { Name = word };
                thread.Start();
            }

            void Run()
            {
                (new Gator()).ShowArticles(m_word, m_codeFrom, m_codeTo, m_waitingUiObject);
            }
        }


        // working with threading http://www.andymcm.com/dotnetfaq.htm#11.1
        List<Thread> threads = new List<Thread>();

        public void WaitUntilFinished()
        {
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        // return result http://www.yoda.arachsys.com/csharp/threadstart.html
        private class ProviderInfoForThread
        {
            string m_word = "";
            string m_codeForm = "";
            string m_codeTo = "";
            private IDictionaryProvider m_Provider = null;
            public ProviderInfoForThread(string word, string codeForm, string codeTo, IDictionaryProvider provider)
            {
                m_word = word;
                m_codeForm = codeForm;
                m_codeTo = codeTo;
                m_Provider = provider;
            }

            public void Execute()
            {
                //Console.WriteLine("Time - {0}, for {1}", DateTime.Now, m_word);
                m_Provider.GetContent(m_word, m_codeForm, m_codeTo);
            }
        }
        #endregion

        public String GetContents(string word, string codeForm, string codeTo)
        {
            List<IDictionaryProvider> dictionaries = new List<IDictionaryProvider>();
            foreach (Type type in GlobalOptions.WorkedDictionaries)
            {
                IDictionaryProvider provider = (IDictionaryProvider)Activator.CreateInstance(type);
                //TODO: здесь бы вставить и проверку поддержки языка
                if( !provider.OnlyAsUrlProvider )
                    dictionaries.Add(provider);
            }

            if (string.IsNullOrEmpty(word)) return "";
            string fileName = GetFileName(word, codeForm, codeTo);
           // if (File.Exists(fileName)) return fileName;
//            if (!WWW.IsOnline()) return "";

            threads.Clear();
            string body = "";

            foreach (DictionaryProvider provider in dictionaries)
            {
                ProviderInfoForThread ex = new ProviderInfoForThread(word, codeForm, codeTo, provider);
                Thread th = new Thread(ex.Execute) {};
                th.Name = string.Format("{0} provider for word '{1}'", provider.Title, word);
                threads.Add(th);
                th.Start();
            }
            WaitUntilFinished();
            foreach (DictionaryProvider provider in dictionaries)
            {
                string content = provider.GetContent(word, codeForm, codeTo);
                if(string.IsNullOrEmpty(content)) continue;
                DictionaryProvider.ResultFromResponse res = provider.LastResultFromResponse;
                if ( res != null)
                {
                    body += string.Format(ArticleReferenceTemplate,
                        res.LastURL, provider.Title, res.Content, res.AcceptedLanguageCode);
                }
            }
            if (string.IsNullOrEmpty(body) )
            {
                if( File.Exists(fileName)) return fileName;   
                return "";
            }
            string s = HtmlFileTemplate.Replace("{0}", word);
            s = s.Replace("{1}", body);
            FileManager.CreateFile(fileName, s);
            return fileName;
        }

        private string GetFileName(string word, string codeForm, string codeTo)
        {
//            string dir = string.Format(@"{0}\history\{1}-{2}\{3}", Directory.GetCurrentDirectory(), codeForm.ToLower(), codeTo.ToLower(), word.ToLower()[0]);
            string dir = string.Format(@"{0}history\{1}-{2}\{3}", CF.GetFolderForUserFiles(), codeForm.ToLower(), codeTo.ToLower(), word.ToLower()[0]);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            string fileName = string.Format(@"{0}\{1}.htm", dir, word);
            return fileName;
        }

        /// <summary>
        /// <dt><a href=\"{0}\" title=\"{0}\">{1} ({3})</a></dt>\r\n<dd>\r\n<table><tr>{2}</tr></table>\r\n</dd>\r\n        
        /// </summary>
        public static readonly string ArticleReferenceTemplate =
            "<dt><a href=\"{0}\" title=\"{0}\">{1} ({3})</a></dt>\r\n<dd>\r\n<table><tr>{2}</tr></table>\r\n</dd>\r\n";

        private string m_HtmlFileTemplate = string.Empty;

        string HtmlFileTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(m_HtmlFileTemplate))
                {
                    if (GlobalOptions.GenerateArticlesWithJScript)
                        m_HtmlFileTemplate = f.db.Properties.html.TemplateJ;
                    else m_HtmlFileTemplate = f.db.Properties.html.Template;

                    string jFileName = CF.GetFolderForUserFiles() + @"history\jquery.js";
                    if (!File.Exists(jFileName))
                    {
                        FileManager.CreateFile(jFileName, f.db.Properties.html.jquery);
                    }
                }
                return m_HtmlFileTemplate;
            }
        }

        #region Instance
        //private static Gator m_Instance = null;

        //Gator()
        //{
        //}

        //public static Gator Instance
        //{
        //    get
        //    {
        //        if(m_Instance == null)
        //        {
        //            m_Instance = new Gator();
        //            InitDictionaries();
        //        }
        //        return m_Instance;
        //    }
        //} 
        #endregion
    }
}


//http://msdn.microsoft.com/en-us/library/system.threading.threadpool.aspx
//http://www.switchonthecode.com/tutorials/csharp-tutorial-using-the-threadpool
//http://smartthreadpool.codeplex.com/