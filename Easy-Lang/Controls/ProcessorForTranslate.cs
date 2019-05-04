using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace f
{
    public class ProcessorForTranslate
    {
        Sentence Sentence;
        string m_codeFrom, m_codeTo, m_word, m_maskedWord = null;
        WaitingUIObjectWithFinish waitingUiObject;

        public ProcessorForTranslate(Sentence sentence, string word, string masked, string codeFrom, string codeTo, 
            WaitingUIObjectWithFinish waitingUiObject)
        {
            m_word = word;
            m_maskedWord = masked;
            Sentence = sentence;
            m_codeTo = codeTo;
            m_codeFrom = codeFrom;
            this.waitingUiObject = waitingUiObject;

            Thread thread = new Thread(new ThreadStart(TranslateCurrentSentence));
            thread.Name = string.Format("TranslateCurrentSentence or '{0}'", word);
            thread.Start();
        }

        private void TranslateCurrentSentence()
        {
            if (Sentence == null) return;
            try
            {
                ++waitingUiObject.WaitingProgressCounter;


                string textForTranslate = Sentence is SentenceForTutor ? ((SentenceForTutor)Sentence).ClearText : Sentence.TextValue;
                string keyForCash = null;
                // кэши все равно при смене языка почистится
                // string keyForCash = string.Format("{0}_{1} : {2}", m_codeFrom, m_codeTo, Sentence.TextValue);

                if (!string.IsNullOrEmpty(m_word)) // если пустой то переведется целиком предложение
                {
                    textForTranslate = m_word;
                    keyForCash = m_word;
                }
               
                //GoogleTranslateBase googleProvider;
                //// if( != -1) for GoogleTipDictionary
                ////if (UtilsForText.IsHaveSeveralWords(textForTranslate))
                ////    googleProvider = GoogleTranslate.Instance;
                ////else
                //    googleProvider = GoogleDictionary.Instance;

                    string translation =
                        GoogleDictionary.Instance.GetContent(textForTranslate, m_maskedWord, m_codeFrom, m_codeTo);

                Sentence.AddCashForTranslation(keyForCash, translation);
                waitingUiObject.OnFinish();
            }
            finally
            {
                //this.TwinText.pictureBoxWating.Visible = false;
                --waitingUiObject.WaitingProgressCounter;
            }
        }
    }
}
