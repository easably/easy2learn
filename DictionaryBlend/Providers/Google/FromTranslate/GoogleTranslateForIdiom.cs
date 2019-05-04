using System;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class GoogleTranslateForIdiom : GoogleTranslateBase
    {
        public override string Title { get { return "Google Translate"; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Idiom; } }
    }
}
