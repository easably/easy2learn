using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace f
{
    public interface ISentence
    {
        /// <summary>
        /// Строка с переносами
        /// </summary>
        string TextValue {set; get;}

        /// <summary>
        /// Строка для вида в списке
        /// </summary>
        string TextValueAsLine  {set; get;}

        string[] Idioms  { get;}

        List<string> WordsToLearn  { get;}

        string TextAsRTF  { get; }

        string TranslAndComment { get; }
    }
}