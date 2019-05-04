using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class UrbanDictionary : DictionaryProvider
    {
        public override string Title { get { return "Urban Dictionary"; } }
        public override string Copyright { get { return @"Urban Dictionary ©1999-2011"; } }
        public override string[] Languages { get { return new string[] { "en" }; } }
        public override string URL
        {
            get
            {
                return @"http://www.urbandictionary.com/define.php?term={0}";
            }
        }

        public override string[] StartTags { get { return new string[] { "<dic id='content'",  "<table id='entries'",
                "<dic id=\"content\"",  "<table id=\"entries\"" }; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.MonoEn; } }
    }
}
