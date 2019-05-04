using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleDictionary : GoogleTranslateBase
    {
        #region Instance
        private static GoogleDictionary instance = new GoogleDictionary();
        // Protected constructor.
        public GoogleDictionary() { }
        public static GoogleDictionary Instance { get { return instance; } }
        #endregion

        public static string MainTitle { get { return "Google dictionary"; } }
        public override string Title { get { return MainTitle; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Simple; } }
    }
}