using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class RunDictContent
    {
        public RunDictContent(ITextWithSelection textWithSelection, List<DictionaryProvider> providers, WebBrowserForForm UITarget)
        {
            m_textWithSelection = textWithSelection;
            m_providers = providers;
            m_UITarget = UITarget;
        }

        ITextWithSelection m_textWithSelection;
        public ITextWithSelection TextWithSelection { get { return m_textWithSelection; } }

        List<DictionaryProvider> m_providers;
        public List<DictionaryProvider> Providers { get { return GetProviders(); } }

        public virtual List<DictionaryProvider> GetProviders()
        {
            return m_providers;
        }

        WebBrowserForForm m_UITarget;
        public WebBrowserForForm UITarget { get { return m_UITarget; } }
    }
}
