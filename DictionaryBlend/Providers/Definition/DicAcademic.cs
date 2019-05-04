using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class DicAcademicDef : DicAcademic
    {
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }
        public override string URL
        {
            get
            {
                return @"http://dic.academic.ru/searchall.php?SWord={0}&stype=0";
            }
        }
    }
}
