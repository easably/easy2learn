using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class HH : Form
    {
        string m_ParentControlName = "";
        const string m_KeyPrefix = "HelpShowed_";

        public HH()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        static Hashtable ht = new Hashtable();
        public static void ShowHelp(Control control, string text, bool controlFirstStart)
        {
            if (controlFirstStart)
            {
                if (CF.GetValue(m_KeyPrefix + control.Name, bool.FalseString) == bool.TrueString)
                    return;
            }
            ShowHelp(control, text);
        }

        public static void ShowHelp(Control control, string text)
        {
            if (control == null) throw new ArgumentNullException("control");
            Control parent = control.Parent;
            int savingX = control.Location.X;
            int savingY = control.Location.Y;
            while (!(parent is Form))
            {
                if (!(parent is Form))
                {
                    savingX += parent.Location.X;
                    savingY += parent.Location.Y;
                    parent = parent.Parent;
                }
                if (parent == null)
                    throw new ApplicationException("Control hasn't valid parent.");
            }
            HH h = ht[control] as HH;
            if (h == null)
            {
                h = new HH();
                ht.Add(control, h);
            }
            if (h.IsDisposed)
            {
                h = new HH();
                ht[control] = h;
            }
            h.m_ParentControlName = control.Name;
            int borderX = 10;
            int borderY = 10;
            h.StartPosition = FormStartPosition.Manual;
            h.Location = new Point(parent.Location.X + savingX + borderX + 3,
                parent.Location.Y + savingY + borderY + 21);
            h.Width = control.Width - borderX * 2;
            h.Height = control.Height - borderY * 2;
            h.Owner = (Form)parent;
            h.TopLevel = true;
            //            h.Text = "Help window (for repeated call press F1)";
            h.Text = "Help window (repeated call - F1)";
            //            h.TransparencyKey = ;

            #region assing texts
            string[] texts = text.Split(new string[] { "***" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <= texts.Length / 2; i += 2)
            {
                RichContainer container = new RichContainer();
                container.ToggleTitle = texts[i];
                container.RichText = texts[i + 1];
                h.Controls.Add(container);
                // if (i != texts.Length / 2)
                {
                    container.Dock = DockStyle.Top;
                    container.Height = container.OptimalHeight;
                    Splitter splitter = new Splitter();
                    splitter.Dock = DockStyle.Top;
                    h.Controls.Add(splitter);
                }
                //else
                //{
                //    container.Dock = DockStyle.Top;
                //}
                container.IsOn = false;
            }
            #endregion

            h.Show();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void HH_FormClosed(object sender, FormClosedEventArgs e)
        {
            CF.SetValue(m_KeyPrefix + m_ParentControlName, bool.TrueString);
        }
    }
}