using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class DictionaryProviderViewForList
    {
        IDictionaryProvider dictionaryProvider;

        //            ViewForDictionary(IDictionaryProvider dictionaryProvider)
        public DictionaryProviderViewForList(Type dictionaryProvider)
        {
            this.dictionaryProvider = (IDictionaryProvider)Activator.CreateInstance(dictionaryProvider);
        }

        public string Code { get { return dictionaryProvider.GetType().FullName; } }

        public override string ToString()
        {
            string langs = "";
            foreach (string lang in this.dictionaryProvider.Languages)
                langs += lang + ";";
            return string.Format("{0} ({1})", this.dictionaryProvider.Title, langs);
        }
    }
}
