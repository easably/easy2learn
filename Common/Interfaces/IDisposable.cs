using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class ConfigSaver : IDisposable
    {
        public ConfigSaver()
        {
        }

        public void Dispose()
        {
            try
            {
                CF.Config.Save(); //  (System.Configuration.ConfigurationSaveMode.Full);                
            }
            catch { }

                //try
                //{
                //    // тут при двух экземплярах не сработает
                //    CF.Config.Save(System.Configuration.ConfigurationSaveMode.Full);
                //}
                //catch (System.Configuration.ConfigurationException ex)
                //{
                //    MessageBox.Show(ex.Message, T.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
        }
    }

    public class FilterFileDialog : IDisposable
    {
        private string oldFileter = "";
        FileDialog dialog;

        public FilterFileDialog(FileDialog dialog)
        {
            this.dialog = dialog;
            this.oldFileter = dialog.Filter;
        }

        public void Dispose()
        {
            this.dialog.Filter = this.oldFileter;
        }
    }

    public class AbandonTopPosition : IDisposable
    {
        private bool NeedReturnToTop = false;
        private Form Form = null;
        //private Control backForm = null;

        //public AbandonTopPosition(Form form)
        //    : base(form, null)
        //{
        //}

        public AbandonTopPosition(Form form)// , Control backForm)
        {
            if (form != null && !form.IsDisposed && !form.Disposing)
            {
                if (form.TopMost)
                {
                    this.Form = form;
                    this.Form.TopMost = false;
                    NeedReturnToTop = true;
                }
            }
            //this.backForm = backForm;
        }

        public void Dispose()
        {
            if (NeedReturnToTop)
            {
                this.Form.TopMost = true;
                //if (this.backForm != null)
                //    this.backForm.Focus();
            }
        }
    }

    public class WaitCursor : IDisposable
    {
        private Cursor m_OldCursor;
        bool doWait = true;

        public WaitCursor(bool doWait)
        {
            this.doWait = doWait;
            if (doWait)
            {
                m_OldCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        public WaitCursor()
        {
            m_OldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            if (doWait)
                Cursor.Current = m_OldCursor;
        }
    }
}
