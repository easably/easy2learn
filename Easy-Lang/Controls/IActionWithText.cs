using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public interface IActionsWithText
    {
        void AddToLesson();
    }

    public interface ITextsForMenu
    {
        TipTextBox ActiveTextBox { get; }
        TipTextBox ForeingTextBox { get; }
        TipTextBox[] TranslTextBoxs { get; }
        TipTextBox[] AllTextBox { get; }
    }
}
