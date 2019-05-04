using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }
    }

    public class History : Dictionary<string, string>
    {
        static History m_History = null;

        public static History TheHistory
        {
            get
            {
                if (m_History == null)
                    m_History = new History();
                return m_History;
            }
        }
    }
}