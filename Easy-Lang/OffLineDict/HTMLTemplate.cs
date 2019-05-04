using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public static class HTML
    {
        public const string ColorNote = "#990000";
        public const string ColorService = "#009966";
        public const string ColorNumber = "#FF0000"; // red 
        //public const string ColorNumber = "#7F0000"; // dark red 
        public const string ColorSynon = "color='#666666'";

        public const string BR = "<br/>";
        public const string NewLine = "\r\n";
 //       public const string NewLine = "<br/>";
        public const string Bold = "<b>{0}</b>";
        public const string Cursive = "<i>{0}</i>";

        public const string Font = "<font {0}>{1}</font>";
        public const string Color = "color='{0}'";
        public const string Size = "size='{0}'";
        public const string AlignCenter = "align='center'";
        public const string Paragraph = "<p{0}>{1}</p>";


        /*
         * 
test = "<P align='left'><FONT face='MS Reference Sans Serif' size='13' color='#990000'>come   / kʌm /</FONT></P>";
test += "	<P align='LEFT' style='color: #990000'><font size='8'>come   / kʌm /</font></P>";
test += "<br /> <b><i>more</i></b>"
         */
    }
}
