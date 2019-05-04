using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace f
{
    public static class CurrentLangInfo
    {
        #region InitLanguagesMenu

        #region InitLanguagesMenu
        //static Dictionary<ToolStripMenuItem, ToolStripMenuItem> menus = new Dictionary<ToolStripMenuItem, ToolStripMenuItem>();
        static Dictionary<ToolStripDropDownItem, ToolStripDropDownItem> menus = new Dictionary<ToolStripDropDownItem, ToolStripDropDownItem>();

        public static void InitLanguagesMenu(ToolStripDropDownButton button)
        {
            ToolStripMenuItem from = new ToolStripMenuItem();
            ToolStripMenuItem to = new ToolStripMenuItem();
            menus.Add(from, to);
            button.DropDownItems.Add(from);
            button.DropDownItems.Add(to);
        }

        public static void InitLanguagesMenu(ToolStrip toolStrip, int index)
        {
            ToolStripDropDownButton from = new ToolStripDropDownButton();
            ToolStripDropDownButton to = new ToolStripDropDownButton();
            menus.Add(from, to);
            toolStrip.Items.Insert(index, to);
            toolStrip.Items.Insert(index, from);
        }

        //ToolStripMenuItem itFrom = FillLanguages(CurrentLangInfo.GoogleLanguagesFrom, from, true);
        //ToolStripMenuItem itTo = FillLanguages(CurrentLangInfo.GoogleLanguagesTo, to, false);
        //// refresh caption on parent item for from and to
        //ChangedLangDirOnClick(itFrom, EventArgs.Empty);
        //ChangedLangDirOnClick(itTo, EventArgs.Empty); 
        #endregion

        public static char PairSeparator = ':';

        static ToolStripMenuItem FillLanguages(Dictionary<string, string> source, ToolStripDropDownItem btLanguage, bool isFrom)
        {
            #region commonLangs
            //<option selected="selected" dir="ltr" style="text-align:left" lang="en" value="/">English</option>
            //<option dir="ltr" style="text-align:left" lang="gr" value="http://gr.euronews.com/">Ελληνικά</option>
            //<option dir="ltr" style="text-align:left" lang="hu" value="http://hu.euronews.com/">Magyar</option>
            //<option dir="ltr" style="text-align:left" lang="fr" value="http://fr.euronews.com/">Français</option>
            //<option dir="ltr" style="text-align:left" lang="de" value="http://de.euronews.com/">Deutsch</option>
            //<option dir="ltr" style="text-align:left" lang="it" value="http://it.euronews.com/">Italiano</option>
            //<option dir="ltr" style="text-align:left" lang="es" value="http://es.euronews.com/">Español</option>
            //<option dir="ltr" style="text-align:left" lang="pt" value="http://pt.euronews.com/">Português</option>
            //<option dir="ltr" style="text-align:left" lang="pl" value="http://pl.euronews.com/">Polski</option>
            //<option dir="ltr" style="text-align:left" lang="ru" value="http://ru.euronews.com/">Pусский</option>
            //<option dir="ltr" style="text-align:left" lang="ua" value="http://ua.euronews.com/">Українська</option>
            //<option dir="ltr" style="text-align:left" lang="tr" value="http://tr.euronews.com/">Türkçe</option>
            //<option dir="rtl" style="text-align:right" lang="ar" value="http://arabic.euronews.com/">عــربي</option> ar
            //<option dir="rtl" style="text-align:right" lang="pe" value="http://persian.euronews.com/">فارسی</option> fa

            string[] commonLangs = new string[] { "en", "gr", "hu", "fr", "de", "it", "es", "pt", "pl", "ru", "ua", "tr", "ar", "fa" }; 
            #endregion

            string dir = isFrom ?
                    LanguageDirection.Split(PairSeparator)[0] :
                    LanguageDirection.Split(PairSeparator)[1];

            ToolStripMenuItem currentItem = null;
            ToolStripMenuItem miOther = new ToolStripMenuItem("Other languages");

            foreach (KeyValuePair<string, string> pair in source)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(pair.Key + " : " + pair.Value);
                mi.CheckOnClick = true;
                mi.Tag = isFrom; // indication From or To
                mi.Click += new EventHandler(ChangedLangDirOnClick);
                if (dir == pair.Value)
                {
                    currentItem = mi;
                    mi.Checked = true; 
                }
                if (Array.IndexOf(commonLangs, pair.Value) != -1)
                    btLanguage.DropDownItems.Add(mi);
                else miOther.DropDownItems.Add(mi);
            }

            btLanguage.DropDownItems.Add(miOther);

            btLanguage.DropDownOpening += new EventHandler(btLanguage_DropDownOpening);
            return currentItem;
        } 
        #endregion

        #region Behavior
        static void btLanguage_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripItemCollection coll = sender is ToolStripDropDownButton ? ((ToolStripDropDownButton)sender).DropDownItems : ((ToolStripMenuItem)sender).DropDownItems;
            foreach (ToolStripMenuItem item in coll)
            {
                if (item.Checked)
                {
                    item.Select();
                    break;
                }
            }
        }

        static void ChangedLangDirOnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem miSender = (ToolStripMenuItem)sender;
            string lang = miSender.Text.Split(':')[1].Trim();
            if ((Boolean)miSender.Tag) // isFrom
                LanguageDirection = lang + PairSeparator + LanguageDirection.Split(PairSeparator)[1];
            else LanguageDirection = LanguageDirection.Split(PairSeparator)[0] + PairSeparator + lang;
        }
        #endregion

        #region LanguageDirection
        public static readonly string DefaultLangDir = "en" + PairSeparator + Utils.GetDefaultToLanguageForceDefault();
        static string m_LangDirec = DefaultLangDir;

        public static LangPair CurrentLangPair
        {
            get { return new LangPair(m_LangDirec); }
        }

        public static string LanguageDirection
        {
            get { return m_LangDirec; }
            set
            {
                m_LangDirec = value.Trim();
                RefreshByCurrentState();
                if (ChangedLanguageDirection != null)
                    ChangedLanguageDirection.Invoke(m_LangDirec, EventArgs.Empty);
            }
        }

        private static void RefreshByCurrentState()
        {
            foreach (KeyValuePair<ToolStripDropDownItem, ToolStripDropDownItem> pair in menus)
            {
                pair.Key.DropDownItems.Clear();
                pair.Value.DropDownItems.Clear();
                ToolStripMenuItem itFrom = FillLanguages(CurrentLangInfo.GoogleLanguagesFrom, pair.Key, true);
                ToolStripMenuItem itTo = FillLanguages(CurrentLangInfo.GoogleLanguagesTo, pair.Value, false);
                // refresh caption on parent item for from and to
                RefreshStateOnLanguage(itFrom, (new LangPair(LanguageDirection)).From);
                RefreshStateOnLanguage(itTo, (new LangPair(LanguageDirection)).To);
            }
        }

        private static void RefreshStateOnLanguage(ToolStripMenuItem miSender, string lang)
        {
            ToolStripDropDownMenu parentItem = (ToolStripDropDownMenu)miSender.Owner; // GetCurrentParent();
            foreach (ToolStripMenuItem item in parentItem.Items)
            {
                if (item.Checked && item != miSender)
                    item.Checked = false;
            }
            ToolStripItem parentItem2 = parentItem.OwnerItem;
            if ((Boolean)miSender.Tag)
                parentItem2.Text = string.Format("You learn: {0} ({1})", CurrentLangInfo.GoogleLanguagesSourceReverted[lang], lang);
            else parentItem2.Text = string.Format("Your native language: {0} ({1})", CurrentLangInfo.GoogleLanguagesToReverted[lang], lang);            //    parentItem2.Text = string.Format("From: {0}", CurrentLangInfo.GoogleLanguagesSourceReverted[lang]);
     
            //else parentItem2.Text = string.Format("To: {0}", CurrentLangInfo.GoogleLanguagesToReverted[lang]);

            // TODO: short name do for application title "Белое Солнце пустыни en-ru"
            //    // From: Russian (ru) 


            ToolStripItem parentOfParent = parentItem2.OwnerItem;
            if (parentOfParent != null)
            {
                //// from en:ru => en : ru
                //parentOfParent.Text = LanguageDirection.Replace(PairSeparator.ToString(), " " + PairSeparator + " ");

                parentOfParent.Text = string.Format(" {0} : {1} ",
                    CurrentLangInfo.GoogleLanguagesSourceReverted[LanguageDirection.Split(PairSeparator)[0]],
                    CurrentLangInfo.GoogleLanguagesToReverted[LanguageDirection.Split(PairSeparator)[1]]);

                parentOfParent.ToolTipText = string.Format("Language from: {0} >> Language to: {1}",
                    CurrentLangInfo.GoogleLanguagesSourceReverted[LanguageDirection.Split(PairSeparator)[0]],
                    CurrentLangInfo.GoogleLanguagesToReverted[LanguageDirection.Split(PairSeparator)[1]]);
            }
        }
        #endregion
        
        #region Dictionary<string, string>
        static Dictionary<string, string> googleLanguagesTo = null;
        public static Dictionary<string, string> GoogleLanguagesTo
        {
            get
            {
                if (googleLanguagesTo == null)
                {
                    googleLanguagesTo = new Dictionary<string, string>();
                    InitGoogleLanguagesTo();
                }
                return googleLanguagesTo;
            }
        }

        static Dictionary<string, string> googleLanguagesToReverted = null;
        public static Dictionary<string, string> GoogleLanguagesToReverted
        {
            get
            {
                if (googleLanguagesToReverted == null)
                {
                    googleLanguagesToReverted = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, string> pair in GoogleLanguagesTo)
                        googleLanguagesToReverted.Add(pair.Value, pair.Key);
                }
                return googleLanguagesToReverted;
            }
        }
        #endregion

        #region Init Language directions
        /// <summary>
        /// New sorted list
        /// </summary>
        static void InitGoogleLanguagesTo()
        {
            googleLanguagesTo.Add("Afrikaans", "af");
            googleLanguagesTo.Add("Albanian", "sq");
            googleLanguagesTo.Add("Arabic", "ar");
            googleLanguagesTo.Add("Armenian ALPHA", "hy");
            googleLanguagesTo.Add("Azerbaijani ALPHA", "az");
            googleLanguagesTo.Add("Basque ALPHA", "eu");
            googleLanguagesTo.Add("Belarusian", "be");
            googleLanguagesTo.Add("Bulgarian", "bg");
            googleLanguagesTo.Add("Catalan", "ca");
            googleLanguagesTo.Add("Chinese (Simplified)", "zh-CN");
            googleLanguagesTo.Add("Chinese (Traditional)", "zh-TW");
            googleLanguagesTo.Add("Croatian", "hr");
            googleLanguagesTo.Add("Czech", "cs");
            googleLanguagesTo.Add("Danish", "da");
            googleLanguagesTo.Add("Dutch", "nl");
            googleLanguagesTo.Add("English", "en");
            googleLanguagesTo.Add("Estonian", "et");
            googleLanguagesTo.Add("Filipino", "tl");
            googleLanguagesTo.Add("Finnish", "fi");
            googleLanguagesTo.Add("French", "fr");
            googleLanguagesTo.Add("Galician", "gl");
            googleLanguagesTo.Add("Georgian ALPHA", "ka");
            googleLanguagesTo.Add("German", "de");
            googleLanguagesTo.Add("Greek", "el");
            googleLanguagesTo.Add("Haitian Creole ALPHA", "ht");
            googleLanguagesTo.Add("Hebrew", "iw");
            googleLanguagesTo.Add("Hindi", "hi");
            googleLanguagesTo.Add("Hungarian", "hu");
            googleLanguagesTo.Add("Icelandic", "is");
            googleLanguagesTo.Add("Indonesian", "id");
            googleLanguagesTo.Add("Irish", "ga");
            googleLanguagesTo.Add("Italian", "it");
            googleLanguagesTo.Add("Japanese", "ja");
            googleLanguagesTo.Add("Korean", "ko");
            googleLanguagesTo.Add("Latvian", "lv");
            googleLanguagesTo.Add("Lithuanian", "lt");
            googleLanguagesTo.Add("Macedonian", "mk");
            googleLanguagesTo.Add("Malay", "ms");
            googleLanguagesTo.Add("Maltese", "mt");
            googleLanguagesTo.Add("Norwegian", "no");
            googleLanguagesTo.Add("Persian", "fa");
            googleLanguagesTo.Add("Polish", "pl");
            googleLanguagesTo.Add("Portuguese", "pt");
            googleLanguagesTo.Add("Romanian", "ro");
            googleLanguagesTo.Add("Russian", "ru");
            googleLanguagesTo.Add("Serbian", "sr");
            googleLanguagesTo.Add("Slovak", "sk");
            googleLanguagesTo.Add("Slovenian", "sl");
            googleLanguagesTo.Add("Spanish", "es");
            googleLanguagesTo.Add("Swahili", "sw");
            googleLanguagesTo.Add("Swedish", "sv");
            googleLanguagesTo.Add("Thai", "th");
            googleLanguagesTo.Add("Turkish", "tr");
            googleLanguagesTo.Add("Ukrainian", "uk");
            googleLanguagesTo.Add("Urdu ALPHA", "ur");
            googleLanguagesTo.Add("Vietnamese", "vi");
            googleLanguagesTo.Add("Welsh", "cy");
            googleLanguagesTo.Add("Yiddish", "yi");
        }

        static void InitGoogleLanguagesSource()
        {
            googleLanguagesFrom.Add("Afrikaans", "af");
            googleLanguagesFrom.Add("Albanian", "sq");
            googleLanguagesFrom.Add("Arabic", "ar");
            googleLanguagesFrom.Add("Armenian ALPHA", "hy");
            googleLanguagesFrom.Add("Azerbaijani ALPHA", "az");
            googleLanguagesFrom.Add("Basque ALPHA", "eu");
            googleLanguagesFrom.Add("Belarusian", "be");
            googleLanguagesFrom.Add("Bulgarian", "bg");
            googleLanguagesFrom.Add("Catalan", "ca");
            googleLanguagesFrom.Add("Chinese", "zh-CN");
            googleLanguagesFrom.Add("Croatian", "hr");
            googleLanguagesFrom.Add("Czech", "cs");
            googleLanguagesFrom.Add("Danish", "da");
            googleLanguagesFrom.Add("Dutch", "nl");
            googleLanguagesFrom.Add("English", "en");
            googleLanguagesFrom.Add("Estonian", "et");
            googleLanguagesFrom.Add("Filipino", "tl");
            googleLanguagesFrom.Add("Finnish", "fi");
            googleLanguagesFrom.Add("French", "fr");
            googleLanguagesFrom.Add("Galician", "gl");
            googleLanguagesFrom.Add("Georgian ALPHA", "ka");
            googleLanguagesFrom.Add("German", "de");
            googleLanguagesFrom.Add("Greek", "el");
            googleLanguagesFrom.Add("Haitian Creole ALPHA", "ht");
            googleLanguagesFrom.Add("Hebrew", "iw");
            googleLanguagesFrom.Add("Hindi", "hi");
            googleLanguagesFrom.Add("Hungarian", "hu");
            googleLanguagesFrom.Add("Icelandic", "is");
            googleLanguagesFrom.Add("Indonesian", "id");
            googleLanguagesFrom.Add("Irish", "ga");
            googleLanguagesFrom.Add("Italian", "it");
            googleLanguagesFrom.Add("Japanese", "ja");
            googleLanguagesFrom.Add("Korean", "ko");
            googleLanguagesFrom.Add("Latvian", "lv");
            googleLanguagesFrom.Add("Lithuanian", "lt");
            googleLanguagesFrom.Add("Macedonian", "mk");
            googleLanguagesFrom.Add("Malay", "ms");
            googleLanguagesFrom.Add("Maltese", "mt");
            googleLanguagesFrom.Add("Norwegian", "no");
            googleLanguagesFrom.Add("Persian", "fa");
            googleLanguagesFrom.Add("Polish", "pl");
            googleLanguagesFrom.Add("Portuguese", "pt");
            googleLanguagesFrom.Add("Romanian", "ro");
            googleLanguagesFrom.Add("Russian", "ru");
            googleLanguagesFrom.Add("Serbian", "sr");
            googleLanguagesFrom.Add("Slovak", "sk");
            googleLanguagesFrom.Add("Slovenian", "sl");
            googleLanguagesFrom.Add("Spanish", "es");
            googleLanguagesFrom.Add("Swahili", "sw");
            googleLanguagesFrom.Add("Swedish", "sv");
            googleLanguagesFrom.Add("Thai", "th");
            googleLanguagesFrom.Add("Turkish", "tr");
            googleLanguagesFrom.Add("Ukrainian", "uk");
            googleLanguagesFrom.Add("Urdu ALPHA", "ur");
            googleLanguagesFrom.Add("Vietnamese", "vi");
            googleLanguagesFrom.Add("Welsh", "cy");
            googleLanguagesFrom.Add("Yiddish", "yi");
        }
        #endregion

        #region event Language Direction
        public static event EventHandler ChangedLanguageDirection;

        // for dictionary with arrays one-to-one and necessity sorting by keys
        static string GetKeyByValue(Dictionary<string, string> dictionary, string value)
        {
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                if (pair.Value.Equals(value)) return pair.Key;
            }
            return string.Empty;
        }

        static void SetUICurrentLanguage(string langID, ToolStripMenuItem btLanguage)
        {
            foreach (ToolStripMenuItem item in btLanguage.DropDownItems)
            {
                if (item.Text.Split(':')[1].Trim().Equals(langID))
                {
                    item.Select();
                    item.Checked = true;
                    //  break;
                }
                else item.Checked = false;
            }
        }

        //public class LangDirArgs : EventArgs
        //{
        //    private readonly bool isFrom;

        //    public LangDirArgs(bool isFrom)
        //    {
        //        this.isFrom = isFrom;
        //    }

        //    public bool IsFrom { get { return isFrom; } }
        //}
        #endregion

        #region GoogleLanguagesSourceReverted
        static Dictionary<string, string> googleLanguagesFrom = null;
        public static Dictionary<string, string> GoogleLanguagesFrom
        {
            get
            {
                if (googleLanguagesFrom == null)
                {
                    googleLanguagesFrom = new Dictionary<string, string>();
                    InitGoogleLanguagesSource();
                }
                return googleLanguagesFrom;
            }
        }

        static Dictionary<string, string> googleLanguagesSourceReverted = null;
        public static Dictionary<string, string> GoogleLanguagesSourceReverted
        {
            get
            {
                if (googleLanguagesSourceReverted == null)
                {
                    googleLanguagesSourceReverted = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, string> pair in GoogleLanguagesFrom)
                        googleLanguagesSourceReverted.Add(pair.Value, pair.Key);
                }
                return googleLanguagesSourceReverted;
            }
        }
        #endregion
    }
}