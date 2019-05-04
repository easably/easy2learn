using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace f
{
    public partial class VideoForm : Form
    {
        #region static
        public static VideoForm m_CurrentForm = null;

        public static VideoForm CurrentForm 
        { get { return m_CurrentForm; } }

        public static void InitVideoForm(VideoForm form, VideoControl control)
        {
            m_CurrentForm = form;
            if (form != null && control != null)
                InitCurrentVideoContrl(m_CurrentForm.videoControl1);
            else InitCurrentVideoContrl(control);
        }

        #region VideoControl
        static VideoControl m_CurrentVideoContrl = null;
        public static VideoControl CurrentVideoContrl { get { return m_CurrentVideoContrl; } }
        public static void InitCurrentVideoContrl(VideoControl cntrl) { m_CurrentVideoContrl = cntrl; } 
        #endregion

        public static bool IsVideoControlAccesible
        {
            get { return m_CurrentVideoContrl != null && m_CurrentVideoContrl.Visible; }
        }

        public static bool IsFormAccesible
        {
            get { return CurrentForm != null && !CurrentForm.IsDisposed && !CurrentForm.Disposing; }
        }
        #endregion

        public VideoForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.VideoForm_Load);

            // this.ShowInTaskbar = false; // тогда не открывается во весь экран видео
            this.TopMostManualExplicit =
            this.TopMost = CF.GetValue("VideoFormTopMost", true);
            this.ShowInTaskbar = CF.GetValue("VideoFormShowInTaskbar", false);
            this.StretchVideoToFit = CF.GetValue("StretchVideoToFit", true);
            CF.AssignValues("VideoForm", this, new Point(526, 109), new Size(588, 380));
        }

        // for FORM
        #region SystemMenu
        public bool StretchVideoToFit {
            set { this.videoControl1.Player.stretchToFit = value; }
            get { return this.videoControl1.Player.stretchToFit; } }

        public bool TopMostManualExplicit { set; get; }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            ResetMenuStates(false);
        }


        private SystemMenu m_SystemMenu = null;

        // ID's of the entries
        private const int m_SeparateWindow = 0x100;
        private const int m_TopMode = 0x101;
        private const int m_StretchVideoToFit = 0x103;

        void ResetMenuStates(bool doReset)
        {
            try
            {
                if (doReset) SystemMenu.ResetSystemMenu(this);

                m_SystemMenu = SystemMenu.FromForm(this);
                
                m_SystemMenu.AppendSeparator();
                //TODO: позволяет переключится в full screen только после пересоздания формы
                m_SystemMenu.AppendMenu(m_SeparateWindow, "Allow full screen (and show the form in task bar)", this.ShowInTaskbar ? ItemFlags.mfChecked : ItemFlags.mfUnchecked);
                m_SystemMenu.AppendMenu(m_TopMode, "Keep the form \"On Top\" mode", this.TopMost ? ItemFlags.mfChecked : ItemFlags.mfUnchecked);
                m_SystemMenu.AppendMenu(m_StretchVideoToFit, "Stretch Video to Fit", this.StretchVideoToFit ? ItemFlags.mfChecked : ItemFlags.mfUnchecked);
//                m_SystemMenu.InsertSeparator(0);  
//                m_SystemMenu.InsertMenu(0, m_TopMode, "Enable \"On Top\" mode", (this.TopMostManualExplicit ? ItemFlags.mfChecked : ItemFlags.mfUnchecked));
            }
            catch (NoSystemMenuException /* err */ )
            {
                // Do some error handling
            }
        }

        protected override void WndProc(ref Message msg)
        {
            // Now we should catch the WM_SYSCOMMAND message
            // and process it.

            // We override the WndProc to catch the WM_SYSCOMMAND message.
            // You don't have to look this message up in the MSDN it is defined
            // in WindowMessages enumeration.
            // The WParam of the message contains the ID which was pressed. It is the
            // same value you have passed through InsertMenu() or AppendMenu() member
            // functions of my class.

            // Just check for them and do the proper action.
            //
            if (msg.Msg == (int)WindowMessages.wmSysCommand)
            {
                switch (msg.WParam.ToInt32())
                {
                    case m_TopMode:
                        {
                            // 1 вариант
                            //this.TopMostManualExplicit = !this.TopMostManualExplicit;
                            //// this.TopMost = !this.TopMost;  т.к. когда здесь фокус TopMost всегда равен False

                            // 2 вариант
                            // в этом варианте, если форма в топе и уйти из приложения то форма отанется висеть 8(
                            this.TopMostManualExplicit = 
                            this.TopMost = !this.TopMost;
                            ResetMenuStates(true);
                        }
                        break;

                    case m_SeparateWindow:
                        {
                            this.ShowInTaskbar = !this.ShowInTaskbar;
                            ResetMenuStates(true);
                        }
                        break;

                    case m_StretchVideoToFit:
                        {
                            this.StretchVideoToFit = !this.StretchVideoToFit;
                            ResetMenuStates(true);
                        }
                        break;
                    // TODO: Add more handles, for more menu items

                    default:
                        { // Do nothing
                        } break;
                }
            }
            // Call base class function
            base.WndProc(ref msg);
        } 
        #endregion

        #region ShowWithoutActivation
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;
                baseParams.ExStyle |= (int)(
                  ExtendedWindowStyles.WS_EX_NOACTIVATE |
                  ExtendedWindowStyles.WS_EX_TOOLWINDOW);

                return baseParams;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        class ExtendedWindowStyles
        {
            public const int WS_EX_NOACTIVATE = 0x08000000;
            public const int WS_EX_TOOLWINDOW = 0x00000080;
        }
        #endregion
    }
}
