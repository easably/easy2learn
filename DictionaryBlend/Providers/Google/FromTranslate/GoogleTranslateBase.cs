using System;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public abstract class GoogleTranslateBase : DictionaryProvider
    {
        #region override props
        public override string Title { get { return "Translate"; } }
        public override string Copyright { get { return @"©2009 Google"; } }
        public override string[] RequestParameters { get { return new string[] { "text=" }; } }
        public override string[] StartTags { get { return new string[] {string.Empty}; } }
        public override string[] Languages { get { return new string[] { AllLanguages }; } }
        // for better speed returned in initial state
        protected override string DoCorrectionForUrl(string response, string prefix, string newPrefix) {
            return response;
        }

        public override string URL {
            get {
                return @"http://translate.google.com/translate_a/t?client=t&hl=en&sl={1}&tl={2}&text={0}";
            }
        }

        public override string GetPublicUrl(string word, LangPair langPair)
        {
            // TODO: разный перевод при наличии переноса строки
            //Jersey?	 Do you have	 any idea what	 the traffic	 's gonna	 be like ?
            //Jersey ? Do you have
            //any idea what the traffic's gonna be like ?

            // full version string url = @"http://translate.google.com/translate_a/t?client=t&text=%0A{0}&hl={1}&sl=auto&tl={2}&multires=1&prev=btn&ssel=0&tsel=0&uptl={2}&sc=1";
            string url = @"http://translate.google.com/#{1}|{2}|{0}%0A";
            return string.Format(url, word, langPair.From, langPair.To);
        }
        #endregion

        public virtual bool IsOnlyCaption { get { return false; } }
        public virtual bool IsHtmlMode { get { return true; } }
        bool m_IsReadingMode = true; // IsShowForeingText
        public bool IsReadingMode { set { m_IsReadingMode = value; } get { return m_IsReadingMode; } }
        
        bool m_IsHidedTrans = false;
        public bool IsHidedTrans { set { ClearCash();  m_IsHidedTrans = value; } get { return m_IsHidedTrans; } }

        public override string GetContent(string word, string codeForm, string codeTo)
        { 
            // word - из этого метода можно и не передавать
            return this.GetContent(word, "", codeForm, codeTo);
        }

        public string GetContent(string word, string maskedWord, string codeForm, string codeTo)
        {
            string baseResponse = base.GetContent(word, codeForm, codeTo);
            if (!string.IsNullOrEmpty(this.ExceptionMessage))
                return this.ExceptionMessage;
            else
                return this.GetVariants(baseResponse, word, maskedWord);
        }

        // TODO: here modificator of access public only for testing
        public virtual string GetVariants(string jsonString, string word, string maskedWord)
        {
            string result = "";
            JNode node = JNode.Parse(jsonString);
         //   Console.WriteLine("--- jsonString ----" + jsonString);
            if (node != null)
            {
                try
                {
                  //  Console.WriteLine("GetDictArticleCaption - " + GetDictArticleCaption(node));
                    
                    // this is a translation
                    if (jsonString.Contains("]],,\"")) 
                    {   //Console.WriteLine("translation");
                        if (IsOnlyCaption)
                        {
                            result = GetTranslateCaption(node);
                            if (string.IsNullOrEmpty(result)) // example - the (определенный артикль)
                                result = GetTranslate(node);
                            if (string.IsNullOrEmpty(result))
                                result = dataNotFound;
                        }
                        else
                        {
                            result = GetTranslate(node);
                        }
                    }
                    //Console.WriteLine("dictionary");
                    else
                    {
                        if (IsOnlyCaption) //only for tipDictionary 
                        {
                            result = GetDictArticleCaption(node); // , Environment.NewLine);
                            if (string.IsNullOrEmpty(result)) // example - the (определенный артикль)
                                result = GetDictArticle(node, word, maskedWord).Replace(Environment.NewLine, ", ");
                        }
                        else
                            result = GetDictArticle(node, word, maskedWord);
                    }
                }
                catch
                {
                    result = "Unknown format";
                }
            }
            else result = "Wrong response";
            return result;
        }

        const string dataNotFound = "Data not found";

        #region GetTranslate

        private string GetTranslate(JNode node)
        {
            string newLine = this.IsHtmlMode ? "<br />" : Environment.NewLine;
            StringBuilder bulder = new StringBuilder();
         //   bool isTranslation = this.DictType == DictionaryProviderType.Trans;
         //   if (isTranslation)
            {
                if (this.IsReadingMode && !this.IsHidedTrans)
                    bulder.Append(GetTranslateCaption(node));
            }
            // иначе непоказываем в тренажере перевод строкой

            //else bulder.Append("<span></span>"); // working with <br /> 8(

            if (node.ChildNodes.Count > 3)
            {
                List<string> tc1 = new List<string>();
                List<string> tc2 = new List<string>();
                List<string> tc3 = new List<string>();

                int indRoot = 2; // isTranslation ? 2 : 1; // by index 1 we are getting part with noun, verb, adj
                foreach (JNode part in node.ChildNodes[indRoot].ChildNodes)
                {
                    #region header of column
                    if (this.IsReadingMode)
                    {
                        if (part.Values.Length > 0)
                        {
                            string val = part.ValuesExt2[0].Trim('"');
                            // do it for example 
                            // Why work around the clock to build an a company in a declining industry when you could have a much easier ride in one that's booming? Or, to paraphrase the great investor Warren Buffett, if you put a brilliant manager with a business with lousy economics, it's the business that tends to keep its reputation. That's why many savvy entrepreneurs make sure the wind is at their backs before taking the plunge.
                            if (string.IsNullOrEmpty(val) && part.ValuesExt2.Count > 1)
                            {
                                val = part.ValuesExt2[1].Trim('"');
                                // at the end we are getting -- if you put"7
                                if (val.LastIndexOf("") > 0)
                                    val = val.Substring(0, val.LastIndexOf("") - 1);
                            }

                            int foo; // [Note] Then you can repeat the lesson in program "Easy-Learn". See menu item "Lesson File (My Dictionary)".
                            if (int.TryParse(val, out foo))
                            {
                                if (part.HasChild && part.ChildNodes[0].Values.Length > 0)
                                    val = part.ChildNodes[0].Values[0];
                            }
                            tc1.Add(val);
                        }
                        else
                            tc1.Add("");
                    } 
                    #endregion

                    string tcVal2 = "";
                    string tcVal3 = "";
                    if (part.HasChild)
                    {
                        #region  //if (!isTranslation)
                        //if (!isTranslation)
                        //#region if (!isTranslation)
                        //{
                        //    bool isFirst = true;
                        //    foreach (string var in part.ChildNodes[0].Values)
                        //    {
                        //        if (isFirst)
                        //        {
                        //            isFirst = false;
                        //            tcVal2 = var.Trim('"');
                        //        }
                        //        else
                        //            tcVal3 += var.Trim('"') + newLine;
                        //    }
                        //} 
                        //#endregion
                        //else 
                        #endregion
                        #region for translation
                        {
                            bool isFirst = true;
                            foreach (JNode variant in part.ChildNodes[0].ChildNodes)
                            {
                                if (variant.ValuesExt2.Count > 0)
                                {
                                    string value = variant.ValuesExt2[0].Trim('"');
                                    if (string.IsNullOrEmpty(value) && variant.Values.Length > 1)
                                    {
                                        value = variant.Values[1].Trim('"');
                                        int foo; // for example article the will do it value==417
                                        if (int.TryParse(value, out foo))
                                            value = "";
                                    }
                                    if (string.IsNullOrEmpty(value))
                                        Console.WriteLine(variant.ToString(" -> "));
                                    if (isFirst)
                                        tcVal2 = value;
                                    else
                                        tcVal3 += value + newLine;
                                }
                                else
                                {
                                }
                                isFirst = false;
                            } 
                        }
                        #endregion
                    }
                    tc2.Add(tcVal2);
                    tc3.Add(tcVal3);

                    // на случай если ничего не нашло в нодах
                    //if (string.IsNullOrEmpty(tcVal3) && node.ChildNodes[indRoot].ChildNodes.Count == 1)
                    //{
                    //    if (node.ChildNodes.Count > 2 && node.ChildNodes[2].HasChild && node.ChildNodes[2].ChildNodes[0].HasChild)
                    //    {
                    //      //  result = string.Format("<b>{0}</b>",
                    //        tc3.Add(GetFirstValues(node.ChildNodes[2].ChildNodes[0].ChildNodes[0].ChildNodes, newLine));
                    //    }
                    //}
                }

                #region javascript
                if (IsHidedTrans)
                {
                    bulder.Append(Environment.NewLine + " <script language=\"javascript\">" +
                       " function expandAll() { var tds = document.getElementsByTagName(\"td\"); for (var i=0;i<tds.length;i++) if( tds[i].style != null ) tds[i].style.visibility = \"visible\"; } "
                    //   " function expandAll() { var tds = document.getElementsByTagName(\"td\"); for (var el in tds) if( el.style != null ) el.style.visibility = \"visible\"; } "
                       + Environment.NewLine + 
                       " function toggle(arg) {" +
                        //  " alert(arg);" +
                        " var el = document.getElementById(arg+'f');" +
                        //  " alert(el);" +
                        " if (el.style.visibility == \"visible\") {" +
                        "  el.style.visibility = \"hidden\";" +
                        "  el = document.getElementById(arg + 's');" +
                        "  el.style.visibility = \"hidden\";" + //if( el != null) 
                        " }" +
                        " else {" +
                        "  el.style.visibility = \"visible\";" +
                        "  el = document.getElementById(arg + 's');" +
                        "  el.style.visibility = \"visible\";" +
                        "  } }  </script> " + Environment.NewLine
                    );
                }
                #endregion

                #region formatting in table
                if (this.IsHtmlMode)
                {
                    bool odd;;
                    string str1 = "";
                    string str2 = "";
                    string str3 = "";


                    for (int i = 0; tc2.Count > i; i++)
                    {
                        odd = i%2 != 0;
                        if (this.IsReadingMode)
                            str1 += string.Format("<td {0} nowrap=\"nowrap\" >{1}</td>", // nowrap=\"nowrap\" - only direct in td
                                (odd ? "class=\"odd\"" : "") + (IsHidedTrans ? " title=\"Show/Hide Translation\" onclick=\"toggle('" + i.ToString() + "')\"" : ""), 
                                tc1.Count > i ? tc1[i] : "");

                        str2 += string.Format("<td {0}>{1}</td>",
                            (odd ? "class=\"odd\"" : "") + (IsHidedTrans && IsReadingMode ? " id=\"" + i.ToString() + "f\" style=\"visibility:hidden\"" : ""), 
                            tc2.Count > i ? tc2[i] : "");

                        str3 += string.Format("<td {0}>{1}</td>",
                            (odd ? "class=\"odd\"" : "") + (IsHidedTrans && IsReadingMode ? " id=\"" + i.ToString() + "s\" style=\"visibility:hidden\"" : ""), 
                            tc3.Count > i ? tc3[i] : "");
                    }
                    string formatForTable = "cellpadding=\"0\" cellspacing=\"0\"";
                    if (IsHidedTrans)
                    {
                        if (!this.IsReadingMode) // learn mode
                        {
                            bulder.Append("<script language=\"javascript\">function showTransl() { ");
                            bulder.Append(" var el = document.getElementById('transl');" + Environment.NewLine);
                            bulder.Append(" el.style.visibility = \"visible\";" + Environment.NewLine);
                            bulder.Append(" el = document.getElementById('h');" + Environment.NewLine);
                            bulder.Append(" el.style.display = \"none\";" + Environment.NewLine);
                            bulder.Append(" } </script>");
                            bulder.Append("<h3 id=\"h\" class=\"hrefStyle\" onclick=\"showTransl()\">Show Translation</h3>");
                            bulder.AppendFormat("<table id=\"transl\" style=\"visibility:hidden\" {0}>", formatForTable);
                        }
                        else
                        {
                            bulder.Append("<h6 class=\"hrefStyle\" onclick=\"expandAll()\"> Expand All </h6>");
                            bulder.AppendFormat("<table {0}>", formatForTable);
                        }
                    }
                    else
                    {
                        bulder.AppendFormat("<table {0}>", formatForTable);
                    }
                    if (this.IsReadingMode) // will add first row
                    {
                        bulder.AppendFormat("<tr {0}>{1}</tr>",
                            (IsHidedTrans ? " class=\"hrefStyle firstRow\"" : ""),
                            str1.Replace("\\", "")
                       );
                    }
                    bulder.AppendFormat("<tr class=\"bold\">{0}</tr>", str2.Replace("\\", ""));
                    bulder.AppendFormat("<tr>{0}</tr></table>", str3.Replace("\\", ""));
                }
                #endregion

                #region style
                // 8( styles in not <head>
                bulder.Append(string.Format(// Environment.NewLine + 
                    " \n<style type=\"text/css\">{0} {1} {2} {3} {4} </style>\n", // + Environment.NewLine,
                        " table {border: none;} ",
                        "td { vertical-align:top; padding-left: 13px; vertical-align: top; padding-bottom: 10px; padding-right: 10px; } ",
                        ".bold {color: #333333; font-weight: bold; } ", // text-decoration: underline;
                        ".odd { background-color: #EAEAEA; } ",
                        ".hrefStyle { color: #1122CC; text-decoration: underline; cursor: pointer; user-select: none; } "
                       // only direct in td ".firstRow { nowrap=\"nowrap\"} "
                    ));
                #endregion
            }
            return bulder.ToString();
        }

        #region GetTranslateCaption
        public string GetTranslateCaption(JNode node)
        {
            string result = "";
            if (node.HasChild && node.ChildNodes[0].HasChild)
            {
//  здесь берется вс строка и получается перевод без пробелов 8( 
                //foreach (JNode translNode in node.ChildNodes[0].ChildNodes)
                //{
                //    if (translNode.ValuesExt2.Count > 0)
                //        result += translNode.ValuesExt2[0].Trim('"');
                //}

//  а здесь можно компоновать
                int ind = node.ChildNodes.Count > 1 ? 1 : 0; // before the value was 1 

                foreach (JNode translNode in node.ChildNodes[ind].ChildNodes)
                {
                    if (translNode.ValuesExt2.Count > 0)
                    {
                        if(!string.IsNullOrEmpty(result)) result += " ";
                        result += translNode.ValuesExt2[0].Trim('"').Replace("\r\n", "<br />");
                    }
                }

                if (this.IsHtmlMode)
                {
                    //                result = "<h4>" + result + "</h4>";// "<br />";
                    // result = "<font color='#303030'><h4>" + result + "</h4></font>";// "<br />";
                    result = string.Format("<span class=\"bold\">{0}</span><br /><br />",
                        result.Replace("\\r", "").Replace("\\n", "").Replace("\\", ""));
                    //                    result = string.Format("<span class=\"bold\">{0}</span><br /><br />", result.Replace("\\r\\n", "<br />"));
                }
                else result = result + Environment.NewLine;
            }
            return result;
        }  
        #endregion
        #endregion

        #region DictArticle
        private string GetDictArticle(JNode node, string word, string maskedWord)
        {
            if (this.IsHtmlMode)
            {
                // string result = GoogleTipDictionary.GetResultFromJSONDictionary(jsonString, "<br /><br /> <b>", "</b>", "<br />", "", "<br />");
                string result = GetDictArticle(node, false,
                    "<b>", "</b>", // captionStart, captionEnd, 
                    "<br /><br /><font color='#009966'><b>", "</b></font><br/>", // partStart, partEnd, 
                    "<font color='#303030'>", "</font>", // noteStart, noteEnd, GRAY - color
                    ", ", "<br/>", word, maskedWord); // betweenWords, nextLine)

                // result = "<table width=100% ><tr valign=top>" + result + "</tr></table>";
                return result;
            }
            else
            {
                string result = GetDictArticle(node, false,
                    "", Environment.NewLine + Environment.NewLine,         // captionStart, captionEnd, RTF - "\b ", "\b0 " + Environment.NewLine,  
                    "", ":" + Environment.NewLine, // partStart, partEnd,   + "\r\n\r\n"
                    "", "",   // noteStart, noteEnd,              + "\r\n\t"
                    ", ", Environment.NewLine, word, maskedWord);          // betweenWords, nextLine)
                return result;
            }
        }

        static string GetDictArticle(JNode node, bool isCompact,
            string captionStart, string captionEnd,
            string partStart, string partEnd,
            string noteStart, string noteEnd,
            string betweenWords, string nextLine, string word, string maskedWord)
        {
            string res = "";
            string caption = GetDictArticleCaption(node); // , nextLine);
            if (!string.IsNullOrEmpty(caption))
                res = captionStart + caption + captionEnd;
            
            bool doHidingWord = !string.IsNullOrEmpty(maskedWord);
            //string _wordMask = "";
            //if( !string.IsNullOrEmpty(word) )
            //{
            //    for (int i = 0; i < word.Length; i++)
            //        _wordMask += "●";
            //    doHidingWord = true;
            //}

            if (node.ChildNodes.Count > 1)
            {
                foreach (JNode partNode in node.ChildNodes[1].ChildNodes)
                {
                    if (partNode.Values.Length > 0)
                        res += partStart + partNode.Values[0] + partEnd;
                    if (partNode.ChildNodes.Count > 1)
                    {
                        bool first = true;
                        foreach (JNode wordMean in partNode.ChildNodes[1].ChildNodes)
                        {
                            if (!first)
                                res += (isCompact ? betweenWords : nextLine);
                            first = false;

                            res += wordMean.Values[0];
                            if (!isCompact)
                            {
                                if (wordMean.HasChild)
                                {
                                    string val = wordMean.ChildNodes[0].Text;
                                    if (doHidingWord)
                                        val = val.Replace(word, maskedWord);
                                    res += noteStart + " - " + val + noteEnd;
                                }
                                else
                                {
                                }
                            }
                        }
                        // for debug ->> partNode.ChildNodes[1].ToString("  ");
                    }
                }
            }
            if (string.IsNullOrEmpty(res)) 
                return dataNotFound;
            return res.Replace("\",\"", betweenWords).Replace("\"", "");
        }

        public static string GetDictArticleCaption(JNode node) // bool isCompactView, string nextLine)
        {
            if (node.ChildNodes.Count > 3 && 
                node.ChildNodes[3].HasChild && 
                node.ChildNodes[3].ChildNodes[0].HasChild )
            {
                return GetFirstValues(node.ChildNodes[3].ChildNodes[0].ChildNodes[0].ChildNodes, ", ");
            }
            return "";
        }

        private static string GetFirstValues(List<JNode> nodes, string delimiter)
        {
            string res = "";
            foreach (JNode nd in nodes)
            {
                string val = nd.Values[0];
                if (!string.IsNullOrEmpty(val.Trim('"')))
                {
                    //if (isCompactView)
                    //    res += (string.IsNullOrEmpty(res) ? "" : ", ") + nd.Values[0].Trim('"');
                    //else 
                    //res += (string.IsNullOrEmpty(res) ? "" : nextLine) + nd.Values[0].Trim('"');
                    res += (string.IsNullOrEmpty(res) ? "" : delimiter) + val.Trim('"');
                }
            }
            return res;
        } 
        #endregion
    }
}
