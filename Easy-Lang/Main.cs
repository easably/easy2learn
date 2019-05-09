using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace f
{
    static class P
    {

        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                Utils.SetProcessDPIAware();
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                T.ContextInstance = new T(args);
                using (new ConfigSaver())
                    Application.Run(T.ContextInstance);
            }
            catch (Exception ex)
            {
                Utils.PublicException(ex);
            }
        }
    }
}
