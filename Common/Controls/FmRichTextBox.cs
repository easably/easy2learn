using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class FmRichTextBox : RichTextBox
    {
        public event EventHandler ManualTextChanged;

        public FmRichTextBox()
        {
            TextChanged += new EventHandler(FmRichTextBox_TextChanged);
        }

        void FmRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsSystemTextChaghed) return;
            if (ManualTextChanged != null)
                ManualTextChanged.Invoke(sender, e);
        }

        bool m_IsSystemTextChaghed = false;
        // when text was changed after change sentence
        public bool IsSystemTextChaghed
        {
            get { return m_IsSystemTextChaghed; }
            set { m_IsSystemTextChaghed = value; }
        }
    }
}
