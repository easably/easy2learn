using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class SubtitleCreator
    {
       // old static long shiftStart = 15500; // shiftStart with advertizing
//        static long shiftStart = 11900; // shiftStart with advertizing
    //    static long shiftStart = 12000; // 18 000 ? shiftStart with advertizing
        long shiftStart = 12000; // 18 000 ? shiftStart with advertizing
        public static string dlm = " ## ";

        public static string JsSelector = WebParser.LoadResourceText("_4win.ted_parse.js");
       //     "var dlm = ' ## '; function parse() { external_result = ''; $('span.talk-transcript__para__text').each( function (i, d) { external_result += $(d).find('span.talk-transcript__fragment').last().attr('data-time') + dlm +	d.innerText + dlm + dlm; })} ;";

        string m_fileName;
        string m_firstSentence;
        WebParser m_Parser;

        public SubtitleCreator(string content, string fileName, string firstSentence)
        {
            m_firstSentence = firstSentence;
            m_fileName = fileName;
            m_Parser = new WebParser();
            m_Parser.LoadAndParse(content, SubtitleCreator.JsSelector);
            if (!string.IsNullOrEmpty(m_Parser.Result))
            {
                string[] res = m_Parser.Result.Split(new string[] { dlm + dlm }, StringSplitOptions.RemoveEmptyEntries);
                ParseAndCreateFile(res);
            }
            else throw new ApplicationException("Data from sever was not parsed");
        }

        void ParseAndCreateFile(string[] lines)
        {
            string retText = "Subtitles was not loaded";
            StringBuilder subOutput = new StringBuilder();
            string prevTime = SentenceParser.GetTimeFromSeconds(shiftStart);

            subOutput.AppendLine("0");
            subOutput.AppendLine(string.Format("{0} --> {1}", "00:00:00,000", prevTime));
            subOutput.AppendLine(m_firstSentence);
            subOutput.AppendLine();

            int counter = 1;
            long time = 0;

            foreach (string line in lines)
            {
                string[] res = line.Split(new string[] { dlm }, StringSplitOptions.RemoveEmptyEntries);

                if (long.TryParse(res[0], out time))
                {
                    subOutput.AppendLine((counter++).ToString());
                    string start = prevTime;
                    string end = prevTime = SentenceParser.GetTimeFromSeconds(time + shiftStart);
                    subOutput.AppendLine(string.Format("{0} --> {1}", start, end));
                    subOutput.AppendLine(res[1]);
                    subOutput.AppendLine();
                }
            }
            // all ok
            retText = subOutput.ToString();

            retText = retText.Replace("\\", "");
            FileManager.CreateFile(m_fileName, retText); // надо в UTF-8 для китайцев и прочего
          //  FileManager.CreateFile(fileName, retText, Encoding.Default);
        }
    }
}

/* old
 
 *         //private static int GetIndexForText(List<string> list)
        //{
        //    int i = 0;
        //    foreach (string s in list)
        //    {
        //        if (!s.Contains("duration\":") && !s.Contains("startOfParagraph\":") ) // && long.TryParse(s, )
        //            return i;
        //        else ++i;
        //    }
        //    return 1;
        //}

        //private static string GetTimeFromSeconds(long val)
        //{
        //    TimeSpan time = TimeSpan.FromMilliseconds(val);
        //    string ret = string.Format("{0:00}:{1:00}:{2:00},{3:000}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
        //    //string ret = DateTime.FromFileTimeUtc(val).ToString("HH:mm:ss,FFF");
        //    return ret;
        //} 
 * 
        static void ParseAndCreateFile(string contentFull, string fileName, string firstSentence)
        {
            string retText = "Subtitles was not loaded";
            if (!string.IsNullOrEmpty(contentFull))
            {
                contentFull = contentFull.Replace("\"contentFull\":", "").Replace("\"startTime\":", "");
                JNode node = JNode.Parse2(contentFull);
                if (node != null && 
                    node.ChildNodes.Count > 0 && 
                    node.ChildNodes[0].ChildNodes.Count > 0 )
                {
                    StringBuilder subOutput = new StringBuilder();
                    try
                    {
                        subOutput.AppendLine("0");
                        subOutput.AppendLine(string.Format("{0} --> {1}", "00:00:00,000", GetTimeFromSeconds(shiftStart)));
                        subOutput.AppendLine(firstSentence);
                        subOutput.AppendLine();

                        int counter = 1;
                        long prevTime = 0; long time = 0;
                        string prevLine = null;

                        int indexForText = 1;
                        // examples
                        // "duration":3000,"contentFull":"what is inside your dental plaque?","startOfParagraph":false,"startTime":2000
                        // "duration":3000,"contentFull":"You can learn a lot about ancient diet and intestinal disease,","startOfParagraph":false,"startTime":114000
                        foreach (JNode nd in node.ChildNodes[0].ChildNodes)
                        {
                            if (nd.ValuesExt2.Count < 4) { Console.WriteLine("Warning for node: {0}", nd.Text); continue; }
                            // nd.Values.Length < 4 int shift = nd.Values.Length - 4;

                            indexForText = GetIndexForText(nd.ValuesExt2);
                            string text = nd.ValuesExt2[indexForText].Trim('"');

                            if (long.TryParse(nd.ValuesExt2[3], out time))
                            {
                                if (prevLine != null)
                                {
                                    subOutput.AppendLine((counter++).ToString());
                                    string start = GetTimeFromSeconds(prevTime + shiftStart);
                                    string end = GetTimeFromSeconds(time + shiftStart);
                                    subOutput.AppendLine(string.Format("{0} --> {1}", start, end));
                                    subOutput.AppendLine(prevLine);
                                    subOutput.AppendLine();
                                }
                                prevTime = time;
                                prevLine = text;
                            }
                            else Console.WriteLine("Warning for node: {0}", nd.Text); 
                        }
                        // all ok
                        retText = subOutput.ToString();
                    }
                    catch
                    {
                        retText = subOutput.ToString() + retText;
                    }
                }
                else
                    retText += Environment.NewLine + "JSON Parsing Error";
            }
            retText = retText.Replace("\\", "");
            FileManager.CreateFile(fileName, retText); // надо в UTF-8 для китайцев и прочего
          //  FileManager.CreateFile(fileName, retText, Encoding.Default);
        }

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
        public static void CreateFile(string contentFull, string fileName, string firstSentence)
        {
            string retText = "Subtitles was not loaded";
            if (!string.IsNullOrEmpty(contentFull))
            {
                contentFull = contentFull.Replace("\"contentFull\":", "").Replace("\"startTime\":", "");
                JNode node = JNode.Parse2(contentFull);
                if (node != null && 
                    node.ChildNodes.Count > 0 && 
                    node.ChildNodes[0].ChildNodes.Count > 0 )
                {
                    StringBuilder subOutput = new StringBuilder();
                    try
                    {
                        subOutput.AppendLine("0");
                        subOutput.AppendLine(string.Format("{0} --> {1}", "00:00:00,000", GetTimeFromSeconds(shiftStart)));
                        subOutput.AppendLine(firstSentence);
                        subOutput.AppendLine();

                        int counter = 1;
                        long prevTime = 0; long time = 0;
                        string prevLine = null;

                        int indexForText = 1;
                        // examples
                        // "duration":3000,"contentFull":"what is inside your dental plaque?","startOfParagraph":false,"startTime":2000
                        // "duration":3000,"contentFull":"You can learn a lot about ancient diet and intestinal disease,","startOfParagraph":false,"startTime":114000
                        foreach (JNode nd in node.ChildNodes[0].ChildNodes)
                        {
                            if (nd.ValuesExt2.Count < 4) { Console.WriteLine("Warning for node: {0}", nd.Text); continue; }
                            // nd.Values.Length < 4 int shift = nd.Values.Length - 4;

                            indexForText = GetIndexForText(nd.ValuesExt2);
                            string text = nd.ValuesExt2[indexForText].Trim('"');

                            if (long.TryParse(nd.ValuesExt2[3], out time))
                            {
                                if (prevLine != null)
                                {
                                    subOutput.AppendLine((counter++).ToString());
                                    string start = GetTimeFromSeconds(prevTime + shiftStart);
                                    string end = GetTimeFromSeconds(time + shiftStart);
                                    subOutput.AppendLine(string.Format("{0} --> {1}", start, end));
                                    subOutput.AppendLine(prevLine);
                                    subOutput.AppendLine();
                                }
                                prevTime = time;
                                prevLine = text;
                            }
                            else Console.WriteLine("Warning for node: {0}", nd.Text); 
                        }
                        // all ok
                        retText = subOutput.ToString();
                    }
                    catch
                    {
                        retText = subOutput.ToString() + retText;
                    }
                }
                else
                    retText += Environment.NewLine + "JSON Parsing Error";
            }
            retText = retText.Replace("\\", "");
            FileManager.CreateFile(fileName, retText); // надо в UTF-8 для китайцев и прочего
          //  FileManager.CreateFile(fileName, retText, Encoding.Default);
        }

 
 */
