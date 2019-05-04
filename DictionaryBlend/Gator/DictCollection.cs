using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace f
{
    public static class DictCollection
    {
        static public void CheckDictionariesForLanguage(string lp, ToolStripItemCollection collection)
        {
            foreach (ToolStripItem item in collection)
            {
                if (((ToolStripItem)item).Tag == null) continue; // for delimiter with text "-"
                RunDictContent dictContent = item.Tag as RunDictContent;

                if (dictContent.Providers.Count == 1) // ordinary item
                {
                    item.Enabled = dictContent.Providers[0].IsSupport(lp);
                }
                else // actions for headerItem e.g. {Search in All Idioms:}
                {
                    foreach (DictionaryProvider provider in dictContent.Providers)
                    {
                        if (provider.IsSupport(lp))
                        {
                            item.Enabled = true;
                            break;
                        }
                        //else Console.WriteLine();
                    }
                }
            }
        }

        #region InitMenuForProviders
        // ToolStripItemCollection <==> IList
        static public void InitMenuForProviders(IList collection, ITextWithSelection textWithSelection, WebBrowserForForm UITarget)
        {
            AddProvidersByType(collection, DictionaryProviderType.Simple, textWithSelection, UITarget, "dictionaries");

            AddBtFindinFavorits(collection, textWithSelection, UITarget);

            collection.Add(new ToolStripSeparator()); // "-"));
            AddProvidersByType(collection, DictionaryProviderType.MonoEn, textWithSelection, UITarget, "mono english");

            collection.Add(new ToolStripSeparator()); // "-"));
                AddProvidersByType(collection, DictionaryProviderType.Idiom, textWithSelection, UITarget, "idiom");

            collection.Add(new ToolStripSeparator()); // "-"));            
            AddProvidersByType(collection, DictionaryProviderType.Definition, textWithSelection, UITarget, "definition");
        }

        public static Color BoldColor = System.Drawing.Color.FromArgb(50, 50, 50);

        static void AddProvidersByType(IList collection, DictionaryProviderType type, ITextWithSelection textWithSelection, WebBrowserForForm UITarget, string title)
        {
//            string titleStart = "In all ";
            string titleStart = "in all ";
            string titleEnd = " ... ";

            List<DictionaryProvider> allProviders = new List<DictionaryProvider>();

            title = titleStart + title.ToUpper() + titleEnd;
            ToolStripItem miAllProviders = new ToolStripButton(title, null, Dict_Click);
            miAllProviders.Font = new Font(miAllProviders.Font, FontStyle.Bold); // | FontStyle.Underline);
            miAllProviders.ForeColor = BoldColor; //  Color.Gray;
            collection.Add(miAllProviders);
            miAllProviders.ToolTipText = "Search in all Dictionaries for this group";
            miAllProviders.Tag = new RunDictContent(textWithSelection, allProviders, UITarget);

            foreach (Type tp in GlobalOptions.AllDictionaries)
            {
                DictionaryProvider dp = (DictionaryProvider)Activator.CreateInstance(tp);
                if ((dp.DictType & type) == type) // dp.Type.HasFlag( because  WordNet simple dictionary and idiom dictionary
                {
                    ToolStripItem miDict = null;
                    if (UITarget != null) // or != null
                        miDict = new ToolStripButton(" - " + dp.Title, null, Dict_Click);
                    else
                    {
                        miDict = new ToolStripMenuItem(" - " + dp.Title, null, Dict_Click);
                        if (UITarget != null)
                            ((ToolStripMenuItem)miDict).CheckOnClick = true;
                    }
                    //miDict.Font = new Font(miDict.Font.FontFamily, miDict.Font.Size - 1);
                    //                    miAllProviders.ToolTipText = "Click here for search in " + dp.Title;

                    string toolTipText = "";
                    foreach (string langPair in dp.Languages)
                    {
                        if (!string.IsNullOrEmpty(toolTipText))
                            toolTipText += ", ";
                        else if (DictionaryProvider.AllLanguages.Equals(langPair))
                        {
                            toolTipText = "All languages";
                            break;
                        }
                        toolTipText += langPair;
                    }
                    miDict.ToolTipText = toolTipText; // dp.CorrectionURL; 
                    miDict.Tag = new RunDictContent(textWithSelection, new List<DictionaryProvider>() { dp }, UITarget);
                    miDict.TextAlign = ContentAlignment.MiddleLeft;
                    #region add google image
                    if (dp.GetType().Name.ToLower().Contains("google"))
                    {
                       // miDict.TextAlign = ContentAlignment.MiddleRight;
                        miDict.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        miDict.ImageScaling = ToolStripItemImageScaling.None;
                        miDict.ImageTransparentColor = Color.White;
                        miDict.Image = f.db.Properties.Resources.google;
                        miDict.TextImageRelation = TextImageRelation.ImageBeforeText;
                        //miDict.TextImageRelation = TextImageRelation.TextBeforeImage;

                        //                        miDict.TextImageRelation = TextImageRelation.TextBeforeImage;

                        //miDict.Image = f.db.Properties.Resources.redAsterisk8_;
                        miDict.ToolTipText = "Google - " + miDict.ToolTipText;

                    }
                    #endregion
                    collection.Add(miDict);
                    allProviders.Add(dp);
                }
            }
        }        
        #endregion

        #region btFindinFavorits

        private static void AddBtFindinFavorits(IList collection, ITextWithSelection textWithSelection, WebBrowserForForm UITarget)
        {
            collection.Add(new ToolStripSeparator()); // "-"));
            ToolStripButton btFavList = new ToolStripButton();
            btFavList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            btFavList.Text = "Find in FavoritList";
            btFavList.Text = "in all FAVORIT ...";
            btFavList.Font = new Font(btFavList.Font, FontStyle.Bold);
            btFavList.ForeColor = BoldColor;
            btFavList.ToolTipText = "Search in Dictionaries from 'Favorit List'"; //  (Alt-D)";
//            btFavList.Tag = new RunDictContent(textWithSelection, new List<DictionaryProvider>() { new FavoritProvider() }, UITarget);
            btFavList.Tag = new RunFavoritDictContent(textWithSelection, UITarget);
            btFavList.Click += new EventHandler(Dict_Click);
            collection.Add(btFavList);
        } 
        #endregion

        #region Top For ArticleTemplate
        static readonly string topForArticleTemplate =
        "<table style=\"margin: 5px\"  width=\"100%\"><tr>"
            + "<td  align=center style=\"background-color: #F9F9F9; padding: 10px \">"
            + "This is preview of "
            + "<a href=\"{0}\" title=\"Open the full article from this preview on the website {1}\">"
            + "article from {1}</a><br />"
            + "<span style=\"font-size: xx-small\">{2}</span> </td></tr></table>";

        //            "<table><tr><td class=\"topForArticle\"><a href=\"{0}\" title=\"{1}\">{2} ({3})</a></td></tr></table>";
        /*                 
        .topForArticle
        {
        	background-color: #C0C0C0; padding-right: 50px; padding-left: 50px;
        }         
       
        static readonly string TopForArticleTemplate = "{0}\r\n<table><tr>{0}</tr></table>\r\n";        
        */
        #endregion

        public static void Dict_Click(object sender, EventArgs e)
        {
            RunDictContent dictContent = ((ToolStripItem)sender).Tag as RunDictContent;
            if (dictContent == null) return;
            string word = dictContent.TextWithSelection.CurrentLowerWord;

            if (string.IsNullOrEmpty(word))
            {
                string message = "A word is not specified";
                // if (Application.ProductName  == DictionaryBlend message += " (Drag-n-drop supported)." // "You must type a word
                MessageBox.Show(message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LangPair lp = dictContent.TextWithSelection.LangDir;
                if (dictContent.UITarget != null)
                {
                    #region for async calling
                    WaitingUIObjectWithFinish waitObject = null;
                    //if ((dictContent.Providers.Count == 1) && !(dictContent.Providers[0] is FavoritProvider))
                    if (dictContent.TextWithSelection is ITextWithSelectionAndWaiting)
                    {
                        MethodInvoker onFinish = new MethodInvoker(AssignTextToControl);
                        waitObject = new WaitingUIObjectWithFinish(((ITextWithSelectionAndWaiting)dictContent.TextWithSelection).Control,
                            ((ITextWithSelectionAndWaiting)dictContent.TextWithSelection).Picture, onFinish);
                        lastUITarget = dictContent.UITarget;
                        foreach (AsyncProvider provider in currentRequests)
                        {
                            if (provider.CurrentThread.IsAlive)
                                provider.CurrentThread.Abort();
                        }
                        currentRequests.Clear();
                        lock (resultContainer)
                            resultContainer.Clear();
                    }
                    #endregion

                    using (new WaitCursor(waitObject == null))
                    {
                        // System.Threading.Thread.Sleep(3000);

                        string dictBodies = "";
                        foreach (DictionaryProvider provider in dictContent.Providers)
                        {
                            //if (provider is FavoritProvider)
                            //{
                            //    new Gator.GatorStarter(word, lp.From, lp.To, null); // waitingUIObject
                            //    dictBodies = "See result in an external window";
                            //}
                            //else
                            {
                                if (!provider.IsSupport(lp.ToString())) continue;
                                string url = provider.GetPublicUrl(word, lp);
                                string providerTitle = provider.Title;
                                if (provider.GetType().Name.ToLower().Contains("google"))
                                    providerTitle = "Google " + providerTitle;
                                string title = string.Format(topForArticleTemplate, url, providerTitle, provider.Copyright);
                                if (waitObject != null)
                                {
                                    currentRequests.Add(new AsyncProvider(word, lp, provider, waitObject, resultContainer, title));
                                }
                                else
                                {
                                    dictBodies += title;
                                    string content = provider.GetContent(word, lp);
                                    dictBodies += content;
                                }
                            }
                        }
                        if (waitObject == null)
                            dictContent.UITarget.TempContent = dictBodies;
                            dictContent.UITarget.AssignText(dictBodies);
                    }
                }
                else // here just working with urls and external browser
                {
                    #region Runner.OpenURL
                    foreach (DictionaryProvider provider in dictContent.Providers)
                    {
                        if (provider is FavoritProvider)
                            new Gator.GatorStarter(word, lp.From, lp.To, null); // waitingUIObject
                        else
                        {
                            if (!provider.IsSupport(lp.ToString())) continue;
                            Runner.OpenURL(provider.GetPublicUrl(word, lp));
                        }
                    }
                    #endregion
                }
            }
        }

        static WebBrowserForForm lastUITarget;

        static List<AsyncProvider> currentRequests = new List<AsyncProvider>();
        static Dictionary<string, string> resultContainer = new Dictionary<string, string>();

        private static void AssignTextToControl()
        {
            string dictBodies = "";
            foreach (System.Collections.Generic.KeyValuePair<string, string> pair in resultContainer)
            {
                dictBodies += pair.Key + pair.Value;
            }
            if (lastUITarget != null)
                lastUITarget.TempContent = dictBodies;
                lastUITarget.AssignText(dictBodies);
        }
    }
}
