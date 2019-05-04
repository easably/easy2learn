using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public static class Messages
    {
        public static void ErrorOnRestoringApp(Exception ex)
        {
            string errorMSG = string.Format("An error occurred while restoring the application. {0} {1}", Environment.NewLine, ex.Message);
            MessageBox.Show(Application.ProductName, errorMSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
