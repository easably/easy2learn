using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace f
{
    public class TipHelper
    {
        #region Instance
        private ToolTip toolTip = null;
        TipHelper()
        { 
            this.toolTip = new ToolTip();
            this.toolTip.UseFading = true;
        }

        static TipHelper m_Instance;

        public static TipHelper Instance
        {
            get
            {
                if (m_Instance == null) m_Instance = new TipHelper();
                return m_Instance;
            }
        } 
        #endregion

        Thread m_thread;
        public Thread CurrentThread {
            get { return m_thread; }
            set { m_thread = value; }
        }

        bool debugInfo = false;

        TipTextBox currentSender = null;
        Point currentPoint;
        string currentMaskedWord, currentWord = null;

        public void PopupDictionaryArticle(TipTextBox sender, Point point, int charIndexUnderCursor)
        {
            //Console.WriteLine("!");

            //word = GetClearWordValue(word);
            string word = sender.GetStringUnderCursor(charIndexUnderCursor, ref this.currentMaskedWord);
            if (string.IsNullOrEmpty(word)) return;

            this.currentPoint = point;
            this.currentSender = sender;
            if (word.Equals(this.currentWord))
            {
                if ((CurrentThread != null && CurrentThread.IsAlive))
                {
                    return;
                }
                else // if(!this.toolTip.Active) // is showed
                {
                    this.TipArticleCallBack = this.TipArticleCallBack;
                    if (debugInfo) Console.WriteLine("Recall");
                    return;
                }
            }

            if (this.TipArticleCallBack != null)
            {
                lock (this.TipArticleCallBack)
                {
                    if (CurrentThread != null && CurrentThread.IsAlive)
                    {
                        if (debugInfo) Console.WriteLine("Abort " + CurrentThread.Name);
                        CurrentThread.Abort();
                    }
                }
            }
            else // be made only once
            {
                if (CurrentThread != null && CurrentThread.IsAlive)
                {
                    if (debugInfo) Console.WriteLine("First Abort " + CurrentThread.Name);
                    CurrentThread.Abort();
                }
            }

            if (debugInfo) Console.WriteLine("GetInfo for: " + word);

            this.currentWord = word;
            LangPair lp = sender.LangDir;
            if (lp.From.Equals(lp.To) || sender.IsMonoRegim)
            {
                GoogleMonoDictionary monoDict = new GoogleMonoDictionary();
                // TODO: здесь приходит HTML возможно надо свое окно а не парсинг
                //if ( Array.IndexOf(monoDict.Languages, this.LangDir.From) != -1 )
                //{
                //    string article = monoDict.GetContent(word, this.LangDir);
                //    tipArticle = GoogleTipDictionary.GetTipArticle(word, article);
                //}
                //else
                TipHelper.Instance.TipArticleCallBack = new GoogleTipDictionary.TipArticle(string.Format("Mono dictionary for '{0}' is not supported", lp), " ");
                //tipArticle = new GoogleTipDictionary.TipArticle(string.Format("Change language pair '{0}'", LangDir), " ");
            }
            else
            {
                new Starter(this.currentWord, lp); //, new DelegateSetTipArticle(SetTipArticle));
            }
        }

        #region Starter
        class Starter
        {
            string word;
            LangPair lp;
            //DelegateSetTipArticle invoker;

            public Starter(string word, LangPair lp) // , DelegateSetTipArticle invoker)
            {
                this.word = word;
                this.lp = lp;
                //this.invoker = invoker;
                // Execute();
                TipHelper.Instance.CurrentThread = new Thread(new ThreadStart(Execute));
                TipHelper.Instance.CurrentThread.Name = string.Format("{0} - {1}", this.word, lp);
                TipHelper.Instance.CurrentThread.Start();
            }

            void Execute()
            {
                string article = GoogleTipDictionary.Instance.GetContent(this.word, this.lp);
                if (string.IsNullOrEmpty(article)) 
                    GoogleTipDictionary.Instance.GetContent(this.word, this.lp);
                TipHelper.Instance.TipArticleCallBack = new GoogleTipDictionary.TipArticle(article, " ");
                //TipHelper.Instance.TipArticleCallBack = GoogleTipDictionary.GetTipArticle(this.word, article);
                
                //invoker.Invoke(GoogleTipDictionary.GetTipArticle(this.word, article));
            }
        }

        //delegate void DelegateSetTipArticle(GoogleTipDictionary.TipArticle tipArticleCallBack);
        //    private void SetTipArticle(GoogleTipDictionary.TipArticle tipArticleCallBack)
        //    {
        ////        ShowTipArticle(this.currentSender, this.currentPoint, this.currentMaskedWord, this.currentWord, tipArticleCallBack);
        //        TipHelper.Instance.TipArticleCallBack = tipArticleCallBack;
        //    } 
        #endregion

        #region TipArticleCallBack
        GoogleTipDictionary.TipArticle m_TipArticleCallBack;
        internal GoogleTipDictionary.TipArticle TipArticleCallBack
        {
            get { return m_TipArticleCallBack; }
            set
            {
                m_TipArticleCallBack = value;
                if (m_TipArticleCallBack != null)
                {
                    ShowTipArticle(this.currentSender, this.currentPoint, this.currentMaskedWord, this.currentWord, m_TipArticleCallBack);
                }
            }
        }

        private void ShowTipArticle(TipTextBox sender, Point point, string maskedWord, string word, GoogleTipDictionary.TipArticle tipArticle)
        {
            toolTip.ToolTipTitle = tipArticle.Caption; // +" = " + word;
            string body = Utils.ShrinkLines(tipArticle.Body);
            if (!string.IsNullOrEmpty(maskedWord))
                body = body.Replace(word, maskedWord);

            //  Point point = sender.PointToClient(Cursor.Position);
            //  ttForCurrentDisplay.Show(body, sender, point.X, point.Y + 15, 15000);

            if (!sender.IsDisposed && !sender.Disposing)
            {
                //if(sender.InvokeRequired)
                sender.Invoke(new ShowTooTip(toolTip.Show), body, sender, point.X, point.Y + 15, 10000);
                //else toolTip.Show(body, sender, point.X, point.Y + 15, 15000);
            }
        }

        delegate void ShowTooTip(string text, IWin32Window window, int x, int y, int duration);
        #endregion

        internal void Hide(TipTextBox tipTextBox)
        {
            this.toolTip.Hide(tipTextBox);
            if (debugInfo) Console.WriteLine("Hide");
        }
    }
}
