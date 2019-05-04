using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public enum ScoreState
    {
        HasError = 0x1, 
        Warning = 0x2, 
        Complete = 0x4, 
        Unknown = 0x7
    }
}
