using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public static class PartSpeechUtil
    {
        public static string[] Parts = new string[] { "adj.", "adv.", "n.", "v." };

        public static string GetReadableName(EE e)
        {
            if (e == EE.adj || e == EE.adj2)
                return Parts[0];
            else if (e == EE.adv)
                return Parts[1];
            else if (e == EE.n)
                return Parts[2];
            else if (e == EE.v)
                return Parts[3];
            return "?";
        }
    }

    public enum EE
    {
        n = 'n', v = 'v', adv = 'r', adj = 'a', adj2 = 's'
    }
}