using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace f
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                GoogleDictionary.Instance.IsReadingMode = false;
                Tutor frm = new Tutor();
                if (args.Length > 0)
                {
                    if (File.Exists(args[0]))
                    {
                        frm.LessonFileName = args[0]; //  @"F:\Video\American Beauty\less.lesson";
                    }
                    else MessageBox.Show(string.Format("File '{0}' not found ", args[0]),
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                frm.RestoreState();
                using (new ConfigSaver())
                    Application.Run(frm);
            }
            catch (Exception ex)
            {
                Utils.PublicException(ex);
            }
        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //e.IsTerminating = false;
            throw new NotImplementedException();
        }

    }
}
