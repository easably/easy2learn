using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace f
{
    public class AsyncProvider
    {
        string m_text, m_keyForResult = null;
        LangPair m_langPair;
        DictionaryProvider m_provider;
        WaitingUIObjectWithFinish m_waitingUiObject;
        Dictionary<string, string> m_containerCollection;

        public AsyncProvider(string text, LangPair langPair, DictionaryProvider provider,
            WaitingUIObjectWithFinish waitingUiObject, Dictionary<string, string> containerCollection, string keyForResult)
        {
            m_text = text;
            m_langPair = langPair;
            m_provider = provider;
            m_waitingUiObject = waitingUiObject;
            m_containerCollection = containerCollection;
            m_keyForResult = keyForResult;

            this.m_thread = new Thread(new ThreadStart(Translate));
            this.m_thread.Name = string.Format("Getting from: '{0}' data: '{1}'", provider.Title, text);
            if (provider.IsDoFullLoading)
                this.m_thread.SetApartmentState(ApartmentState.STA);
            this.m_thread.Start();
        }

        Thread m_thread;
        public Thread CurrentThread
        {
            get { return m_thread; }
        }

        private void Translate()
        {
            if (this.CurrentThread.ThreadState != ThreadState.Running)
            {
                Console.Write("Exit from thread with state");
                Console.WriteLine(this.CurrentThread.ThreadState);
                return;
            }
            try
            {
                ++m_waitingUiObject.WaitingProgressCounter;
                string result = m_provider.GetContent(m_text, m_langPair);
                lock (m_containerCollection)
                    m_containerCollection.Add(m_keyForResult, result);
                m_waitingUiObject.OnFinish();
            }
            catch(Exception ex) 
            {
                // коллекция в DictCollection уже изменена т.е. пошли другие запросы
                // TODO: try word "discipline" from google synonims
                // может проявлятся на медленном интенете
                Utils.PublicException(ex);
                //Console.WriteLine(ex);
            }
            finally
            {
                //this.TwinText.pictureBoxWating.Visible = false;
                --m_waitingUiObject.WaitingProgressCounter;
            }
        }

        // string m_result = null;
        //public string Result { get { return m_result; } }
    }
}
