using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public interface IWaitingUIObject
    {
        int WaitingProgressCounter { get; set; }
    }


    public interface ITextWithSelectionAndWaiting : ITextWithSelection
    {
        PictureBox Picture { get; }
        Control Control { get; }
    }

    //public interface IWaitingUIObjectWithFinish
    //{
    //    //string ReturnedText { set; }
    //    void OnFinish();
    //}
}
