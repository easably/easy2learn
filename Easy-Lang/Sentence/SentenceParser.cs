using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Unicode;

namespace f
{
    public class SentenceParser
    {
        internal readonly static double DefaultSubtitleLength = 5.555f;

        public static List<Sentence> GetSentencesFromSubtitles(string fileName)
        {
            Encoding enc = Encoding.Default;
            if (Unicode.Utf8Checker.IsUtf8(fileName)) // для въетнамского и прочих языков из теда
                enc = Encoding.UTF8;

            if (fileName.ToLower().EndsWith(".srt"))
                return GetSentencesFromSRT(fileName, enc);
            else if (fileName.ToLower().EndsWith(".smi"))
                    return GetSentencesFromSMI(fileName, enc);
            else if (fileName.ToLower().EndsWith(".ssa"))
                return GetSentencesFromSSA(fileName, enc);
            else // txt sub and other
                try {
                    List<Sentence> ret = GetSentencesFromTXT(fileName);
                    if (ret == null)  // TODO: пока GetSentencesFromTXT даже и не возвращает null в случае неудачи
                        ret = GetSentencesFromSRT(fileName, enc);
                    return ret;
                }
                catch
                {
                    return GetSentencesFromSRT(fileName, enc);
                }
        }

        public static List<Sentence> GetSentencesFromSMI(string fileName, Encoding enc)
        {
            List<Sentence> sents = new List<Sentence>();
            using (TextReader tr = new StreamReader(fileName, enc)) //, true))
            {
                double frameStart = 0;
                SentenceVideo sentPrev = null;
                bool isBody = false;
                string line = "";

                while ((line = tr.ReadLine()) != null)
                {
                    if (!isBody)
                    {
                        if (line.Contains("<BODY>"))
                            isBody = true;
                        continue;
                    }
                    else 
                        if (line.Contains("</BODY>")) 
                        break;

                    if (line.Contains("<SYNC"))
                    {
                        int i; // <SYNC Start=67860><P Class=ENCC>
                        if (int.TryParse(line.Split(new string[] { "Start=", ">" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim(), out i))
                        {
                            frameStart = i / 1000;
                            if (sentPrev != null)
                                sentPrev.InitLength(frameStart - sentPrev.Start);
                        }
                        else System.Diagnostics.Debug.Fail(string.Format("Error on parsing line '{0}'", line));
                    }
                    else
                    {
                        line = line.Replace("<br>", Environment.NewLine);
                        sentPrev = new SentenceVideo(line, sents, frameStart, frameStart+DefaultSubtitleLength);
                        sents.Add(sentPrev);
                    }                    
                }

                // в SMI нет конца, поэтому после цикла последнее предложение остается с длиной по умолчанию
                //if (sentPrev != null)
                //    sentPrev.InitLength(sentPrev.End - sentPrev.Start);
            }
            return sents;
        }


        public static List<Sentence> GetSentencesFromSSA(string fileName, Encoding enc)
        {
            List<Sentence> sents = new List<Sentence>();
            using (TextReader tr = new StreamReader(fileName, enc)) //, true))
            {
                bool isBody = false;
                bool isFormat = false;

                string line;
                SentenceVideo sent = null;
                while ((line = tr.ReadLine()) != null)
                {
                    if (!isBody || !isFormat)
                    {
                        if (line.Contains("[Events]"))
                            isBody = true;
                        if (isBody && line.Contains("Format:"))
                            isFormat = true;                    
                        continue;
                    }

                    // do split Dialogue: Marked=0,1:55:09.19,1:55:12.94,StyleB,NTP,0000,0000,0000,!Effect,...и я не чувствую ничего,\Nкроме благодарности...

                    string[] parts = line.Split(new string[] { "=0,", ",", "Effect," }, StringSplitOptions.RemoveEmptyEntries);

                    string frameStartRaw = parts[1].Replace(".", ","); // 1:55:09.19 => 1:55:09,19
                    string frameEndRaw = parts[2].Replace(".", ","); 

                    double frameStart = ConvertTimeSpanFromString(frameStartRaw);
                    double frameEnd = ConvertTimeSpanFromString(frameEndRaw);

                    string text = parts[parts.Length - 1].Replace("\\N", Environment.NewLine);
                    sent = new SentenceVideo(text, sents, frameStart, frameEnd);
                    sent.InitLength(sent.End - sent.Start);
                    sents.Add(sent);
                }
            }
            return sents;
        }

        public static List<Sentence> GetSentencesFromTXT(string fileName)
        {
            List<Sentence> sents = new List<Sentence>();
            using (TextReader tr = new StreamReader(fileName, Encoding.Default)) //, true))
            {
                string line;
                SentenceVideo sent = null;
                while ((line = tr.ReadLine()) != null)
                {
                    if (sents.Count == 0 && line.StartsWith("[")) continue; // for [INFORMATION][AUTHOR] .... [COLF]&HFFFFFF,[STYLE]no,[SIZE]18,[FONT]Arial

                    string[] parts = line.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

                    double frameStart; // = Convert.ToDouble(parts[0]);
                    if (!Double.TryParse(parts[0], out frameStart)) 
                        throw new ApplicationException(string.Format("Error in file '{0}'", fileName));

                    frameStart = Math.Round(frameStart / 25, 3);
                    if (sent != null)
                        sent.InitLength(frameStart - sent.Start);

                    double frameEnd = Math.Round(Convert.ToDouble(parts[1]) / 25, 3);
                    //double frameEnd = Convert.ToDouble(parts[1]) / 25;
                    sent = new SentenceVideo(parts[2].Replace("|", Environment.NewLine), sents, frameStart, frameEnd);

                    sents.Add(sent);
                }
                if (sent != null)
                    sent.InitLength(sent.End - sent.Start);
            }
            return sents;
        }

        public static List<Sentence> GetSentencesFromSRT(string fileName, Encoding enc)
        {
            string[] timeDelimiters = new string[] {"-->", ","};
            List<Sentence> sents = new List<Sentence>();
            using (TextReader tr = new StreamReader(fileName, enc, true)) //, true))
           {
                bool isNumber = true;
                double frameStart = 0;
                double frameEnd = 0;
                string line, lineStore = "";
                SentenceVideo sentPrev = null;

                //while ((line = tr.ReadLine()) != null)
                while ( true )
                {
                    line = tr.ReadLine();
                    if (line == null) break;

                    if (sents.Count == 0 && line.StartsWith("[")) continue; // for [INFORMATION][AUTHOR] .... [COLF]&HFFFFFF,[STYLE]no,[SIZE]18,[FONT]Arial

                    if (isNumber && line != null && (line.Contains(timeDelimiters[0]) || line.Contains(timeDelimiters[1])) )
                    {
                        string timeDelimiter = timeDelimiters[0]; // frequently Delimiter == "-->"
                        if (!line.Contains(timeDelimiters[0])) timeDelimiter = timeDelimiters[1];

                        string[] times = line.Split(new string[] { timeDelimiter }, StringSplitOptions.RemoveEmptyEntries);
                        frameStart = ConvertTimeSpanFromString(times[0]);
                        frameEnd = ConvertTimeSpanFromString(times[1]);
                        isNumber = false;
                        continue;
                    }
                    if (isNumber && line != null) continue;
                    
                    //if (line == null && lineStore == null) 
                    //    break;

                    if (string.IsNullOrEmpty(line))
                    {
                        if (sentPrev != null)
                        {
                            sentPrev.InitLength(frameStart - sentPrev.Start);
                            //    Console.WriteLine("length - " + sent.Length.ToString());
                        }
                        sentPrev = new SentenceVideo(lineStore, sents, frameStart, frameEnd);
                        sents.Add(sentPrev);
                        //  Console.WriteLine(sents.Count.ToString() + ") " + lineStore + " frame: " + frameStart.ToString());
                        lineStore = null;
                        isNumber = true;
                    }
                    else
                    {
                        if (sents.Count == 0 && line.StartsWith("[")) continue; // for [INFORMATION][AUTHOR] .... [COLF]&HFFFFFF,[STYLE]no,[SIZE]18,[FONT]Arial
                        lineStore += Environment.NewLine + " " + line;
                        //lineStore += " " + line;
                    }

                }
                if (sentPrev != null)
                    sentPrev.InitLength(sentPrev.End - sentPrev.Start);
            }
            return sents;
        }

        private static double ConvertTimeSpanFromString(string spanAsString)
        {
            int endFirstPart = 8;
            spanAsString = spanAsString.Trim();
            string spanPart = spanAsString.Substring(0, endFirstPart);
            // maybe - "00:00:0,"
            if (spanPart.EndsWith(","))
            {
                --endFirstPart;
                spanPart = spanAsString.Substring(0, endFirstPart);
            }
            double time = 13; // any number
            try {
                TimeSpan span = TimeSpan.Parse(spanPart); // OverflowException if we get 00:07:20,242 --> 99:59:59,999
                time = span.TotalSeconds;
                // и еще приплюсуем оставшуюся часть после запятой
                int tailLength = spanAsString.Length - (endFirstPart + 1);
                time += double.Parse(spanAsString.Substring(endFirstPart + 1, tailLength)) / 1000.0;
            }
            catch(OverflowException) {
            }
            return time;
        }

        // полхой стиль
        public static bool Bad_CheckFile(ref string fileName)
        {
            if (File.Exists(fileName)) return true;
            string suggestedFileName = System.AppDomain.CurrentDomain.BaseDirectory + Path.GetFileName(fileName);
            if (File.Exists(suggestedFileName))
            {
                fileName = suggestedFileName;
                return true;
            }
            return false;
        }

        public static string GetFileByRichTextBox(string fileName)
        {
            if (File.Exists(fileName))
            {
                RichTextBox m_tx = new RichTextBox();
                if (fileName.ToLower().EndsWith(".txt") || fileName.ToLower().EndsWith(GlobalOptions.LessonFileExtension))
                    return FileManager.GetStringFrоmFile(fileName);
                else
                {
                    try
                    {
                        m_tx.LoadFile(fileName);
                    }
                    // TODO: уйти от RichEdit
                    catch(System.ArgumentException ex)
                    {
                        throw ex;
                        //if (ex.Message.Equals("File format is not valid."))
                        //    MessageBox.Show(string.Format("File '{0}' format is not valid.", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            throw new ApplicationException("The file being loaded is not an RTF document.", ex);
                    }
                }
                return m_tx.Text;
            }
            else
            {
                MessageBox.Show(string.Format("File '{0}' not found", fileName));
                return string.Empty;
            }
        }
            
        public static string Delimeter = "#~#";

        public static List<Sentence> GetListSentence(string text)
        {
            foreach (string key in SentenceEnds)
            {
                string substitute;
                if (key[1] == '\n')
                    substitute = key[0] + Delimeter + ForceListBox.SentenceTabSymbol; // т.е. уберем '\n' и добавим отступ (красную строку)
                else if (key[1] == ' ')
                    substitute = key[0] + Delimeter + ' '; // чтобы сохранить пробел вначале строки
                else substitute = key + Delimeter;
                text = text.Replace(key, substitute);
            }

            #region вставка пустых строк в конечном щёте приведет к сильной рассинхронизации текстов
            //// оставшиеся '\n' после предыдущего цикла будем считать за пустые строки
            //// но избыток этого добра нам не надо т.к. могут рассинхронизироваться тексты
            //while (text.IndexOf(" \n") > -1) // что бы вырезать вот эти куски  "\n     \n"
            //    text = text.Replace(" \n", "\n");
            //while (text.IndexOf("\n\n") > -1) // что бы вырезать вот эти куски  "\n     \n"
            //    text = text.Replace("\n\n", "\n");
            //text = text.Replace("\n", delimeter + Sentence.emptySentenceContent + delimeter);
            //while (text.IndexOf("\n\n") > 0)
            //    text = text.Replace("\n\n", "\n");
            //text = text.Replace("\n", sentenceSpace); 
            #endregion

        //    return GetListSentence2(text);
        //}
        
        //public static List<Sentence> GetListSentence2(string text)
        //{
            string[] sentenses = text.Split(new string[] { Delimeter }, StringSplitOptions.None);

            #region join with Abbreviate and etc.
            List<string> tempedSentens = new List<string>();
            foreach (string line in sentenses)
            {
                if (tempedSentens.Count != 0)
                {
                    if (IsOneSentence(tempedSentens[tempedSentens.Count - 1], line))
                    {
                        // здесь иде1т склейка предыдущего предложения с текущим строкой цикла !
                        string newSentence = tempedSentens[tempedSentens.Count - 1] + line;
                        tempedSentens[tempedSentens.Count - 1] = newSentence;
                        continue;
                    }
                }
                tempedSentens.Add(line);
            }
            #endregion

            List<Sentence> ret = new List<Sentence> { };

            #region Всё клеим
            StringBuilder sb = new StringBuilder();
            foreach (string line in tempedSentens)
            {
                if (line.Trim() != "")
                {
                    Sentence sn = new Sentence(line, ret);
                    sb.Append(sn.ToString());
                    ret.Add(sn);
                    //m_CountWords += s.CountWords;
                }
            }
            #endregion
            return ret;
        }

        #region Анализ двух строк на предмет того являются ли они одним предложением
        static bool IsOneSentence(string prevSentence, string currentLine)
        {
            if (currentLine.Trim().Length < 3) return true; // ". . . . " борьба с пустотой
            // And there was the little stir in his stomach, the faint (psychosomatic?) ... дальше надо клеить + ?? 
            if (prevSentence.Trim().EndsWith(")") && !prevSentence.Trim().StartsWith("(")) return true;

            //Хм! Мг "В уголку стоят буквы Э.X. Держу пари, что мистер Элфред едет домой. "  "#tab#— Подумать только! — воскликнула Клеменси. — Ну что ж! "  "'Сделайте Вы знаете где Вы \n? "                             
            char[] wordSeparators = new char[] { '\n', ' ', '\r' }; //'-'
            string[] prevWords = prevSentence.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (prevWords.Length == 0) 
                return false; // должно срабатывать только раз
            string lastWord = prevWords[prevWords.Length - 1];
            if (IsAbbreviate(lastWord, prevWords.Length)) return true;
            if (!IsNewSentence(currentLine))
                return false;
            return false;
        }

        static bool IsNewSentence(string line)
        {
            if (line.Trim().StartsWith(ForceListBox.SentenceTabSymbol))
                return true; // наш символ табуляции
            char[] startChars = new char[] { '"', ' ' };
            if (string.IsNullOrEmpty(line))
                return false;

            if (Array.IndexOf(startChars, line[0]) > -1 && // начинается с пробела (или другого символа) 
                line.Trim(startChars).Length > 0 && Char.IsUpper(line.Trim(startChars)[0])) // а потом заглавной буквы 
            {
                return true;
            }
            return false;
        }

        static bool IsAbbreviate(string word, int wordCount)
        {
            if (char.IsDigit(word[0])) return false; // для числительных "#tab#That was his first impression of the 2456th. "                                                
            if (!char.IsLetter(word[0])) return false; // или для такого варианта $24.
            char[] vowels = new char[] { 
                'e', 'y', 'u', 'i', 'o', 'a', // В английском алфавите 6 гласных букв, которые передают 24 звука.http://www.native-english.ru/pronounce/syllable
                'й', 'у', 'е', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю' };
            if (word.Trim('\n').Trim('\r').Trim('.').Length == 1 && wordCount == 1)
                return true;

            if (word.Split('.').Length > 2) // for "pro-U.S."
                return true; // if in one word have several dots

            bool result = (word.ToLower().IndexOfAny(vowels) == -1); // подозрительно нет гласных !!  хотя може быть и такое:	2456th
            return result;
        }
        #endregion

        #region SentenceEnds
        /// <summary>
        /// '.', '!', '?'
        /// </summary>
        // for china , '。'
        internal static char[] sentenceKeys = new char[] { '.', '!', '?' }; // , '\\' }; 
        /* конец с предложением .\r так тоже бывает */
        internal static char[] sentenceKeysEnd = new char[] { '\r', '\n', 
            (char)160, (char)32, // 32 и 160 пробелы (160 ru) 
            '\'', '"', '»', '”', ')' };
        //TODO: A-Z символы с большой буквы для распознания ситуаций .... to create and accelerate.The other term that needs  ...
        private static string[] m_Keys = new string[sentenceKeys.Length*sentenceKeysEnd.Length]; //  + sentenceKeys.Length];
        internal static string[] SentenceEnds
        {
            get
            {
                if (m_Keys[0] == null)
                {
                    string s = ""; // foo
                    int i = 0;
                    foreach (char k in sentenceKeys)
                    {
                        foreach (char ke in sentenceKeysEnd)
                        {
                            m_Keys[i++] = s + k + ke;
                            //    m_Keys[m_Keys.Length-1] = "\n\n";                            
                        }
                        // у гугла не \n == 10 а '\'+'n' где 'n' == 110
                      //  m_Keys[i++] = k + "\\n";                        
                    }
                }
                return m_Keys;
            }
        }
        #endregion

        // с подгонкой по времени
        public static string CreateSubtitles(News news)
        {
            string text = news.HTMLContent;
            int textLength = text.Length;
            float cf = (news.AllLength - news.LengthForFirstSentence) / textLength;
            StringBuilder sb = new StringBuilder();
            long time = news.LengthForFirstSentence; int counter = 0;

            // first service Sentence 
            sb.AppendLine((counter++).ToString());
            sb.AppendLine(GetTimeFromSeconds(0) + " --> " + GetTimeFromSeconds(time));
            sb.AppendLine(string.Format(VideoUnit.FirstSentence, news.URL));
//            sb.AppendLine(string.Format(VideoUnit.FirstSentence, news.URL, news.Title));
//            sb.AppendLine(news.Title + Environment.NewLine + news.Description);
            sb.AppendLine();

            foreach( Sentence sn in GetListSentence(text))
            {
                sb.AppendLine((counter++).ToString());
                long newTime = time + (long)(sn.TextValue.Length * cf);
                string newTimeStr = GetTimeFromSeconds(newTime);
                sb.AppendLine(GetTimeFromSeconds(time) + " --> " + newTimeStr);
                time = newTime;
                sb.AppendLine(sn.TextValue);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static void RewriteSubtitles(string fileName, List<Sentence> list)
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (SentenceVideo sn in list)
            {
                sb.AppendLine((counter++).ToString());
                long st = (long)(sn.Start * 1000);
                sb.AppendLine(GetTimeFromSeconds(st) + " --> " + GetTimeFromSeconds(st + (long)(sn.Length*1000)));
                sb.AppendLine(sn.TextValue);
                sb.AppendLine();
            }
            FileManager.CreateFile(fileName, sb.ToString()); // надо в UTF-8 для китайцев и прочего
        }

        public static string GetTimeFromSeconds(long val)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(val);
            string ret = string.Format("{0:00}:{1:00}:{2:00},{3:000}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
            //string ret = DateTime.FromFileTimeUtc(val).ToString("HH:mm:ss,FFF");
            return ret;
        } 
    }
}
