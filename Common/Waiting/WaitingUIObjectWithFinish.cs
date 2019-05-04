using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class WaitingUIObjectWithFinish : IWaitingUIObject //, IWaitingUIObjectWithFinish
    {
        PictureBox m_PictureBox;
        Control Owner;
        MulticastDelegate FinishDelegate;
        //WaitingProgressCallback waitingProgressCallback;

        public WaitingUIObjectWithFinish(Control owner, PictureBox pictureBox, MulticastDelegate finishDelegate)
        {
            m_PictureBox = pictureBox;
            Owner = owner;
            FinishDelegate = finishDelegate;
        }

        public void OnFinish()
        {
            if (Owner.Disposing || Owner.IsDisposed) return;
            if (!Owner.Created) return;
            Owner.Invoke(FinishDelegate);
        }

        #region WaitingProgress
        int m_WaitingProgressCounter = 0;

        public int WaitingProgressCounter
        {
            get { return m_WaitingProgressCounter; }
            set
            {
                m_WaitingProgressCounter = value;
                if (Owner.Disposing || Owner.IsDisposed) return;
                WaitingProgressCallback waitingProgressCallback = new WaitingProgressCallback(CheckWatingState);
                if (Owner.Created && !Owner.Disposing && !Owner.IsDisposed)
                    Owner.Invoke(waitingProgressCallback);
            }
        }

        delegate void WaitingProgressCallback();

        void CheckWatingState()
        {
            this.m_PictureBox.Visible = WaitingProgressCounter > 0;
        }
        #endregion
    }
}
