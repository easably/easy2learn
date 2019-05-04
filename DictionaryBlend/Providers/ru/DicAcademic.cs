using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class DicAcademic : DictionaryProvider
    {
        public override Encoding DefaultEncoding { get { return Encoding.UTF8; } }
        public override string Title { get { return "Академик"; } }
        public override string Copyright { get { return @"© Академик, 2000-2010"; } }
        public override string[] Languages { get
        {
                return new string[] {                   
            //TODO: китайский латинский                                           
            // "x:ru"
            "en:ru", "fr:ru", "de:ru", "it:ru", "es:ru", 
            //"ru:x", 
            "ru:en", "ru:fr", "ru:de", "ru:it", "ru:es",
                                                              };
            }
        }
        public override string URL
        {
            get
            {
                return @"http://dic.academic.ru/searchall.php?SWord={0}&stype=1";
            }
        }

        public override string[] StartTags { get { return new string[] { "<div class=\"content\"" }; } }
    }
}
