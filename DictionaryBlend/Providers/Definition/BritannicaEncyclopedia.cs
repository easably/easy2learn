using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class BritannicaEncyclopedia : Britannica
    {
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Definition; } }        
        public override string URL { get { return @"http://britannica.com/bps/search?query={0}"; } }
    }
}
