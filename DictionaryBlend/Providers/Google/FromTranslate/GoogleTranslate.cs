using System;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleTranslate : GoogleTranslateBase
    {
        #region Instance
        private static GoogleTranslate instance = new GoogleTranslate();
        // Protected constructor.
        protected GoogleTranslate() { }
        public static GoogleTranslate Instance { get { return instance; } }
        #endregion

        //public override bool IsHtmlMode { get { return false; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Trans; } }
        
        // for debug
        public override string GetContent(string word, string codeForm, string codeTo)
        { 
            return base.GetContent(word, codeForm, codeTo);
        }
    }
}
