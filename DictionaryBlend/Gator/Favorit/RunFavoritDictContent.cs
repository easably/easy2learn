using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class RunFavoritDictContent : RunDictContent
    {
        public RunFavoritDictContent(ITextWithSelection textWithSelection, WebBrowserForForm UITarget)
            :base(textWithSelection, null, UITarget)
        {
        }

        public override List<DictionaryProvider> GetProviders()
        {
            List<DictionaryProvider> m_providers = new List<DictionaryProvider>();
            foreach (Type type in GlobalOptions.WorkedDictionaries)
            {
                DictionaryProvider provider = (DictionaryProvider)Activator.CreateInstance(type);
                //TODO: здесь бы вставить и проверку поддержки языка
                if (!provider.OnlyAsUrlProvider)
                    m_providers.Add(provider);
            }
            return m_providers;
        }
    }
}
