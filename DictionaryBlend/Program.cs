using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace f
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                Utils.SetProcessDPIAware();
            }

            // JavaScriptSerializer from System.Web.Extensions.dll http://stackoverflow.com/questions/401756/parsing-json-using-json-net (.NET 3.5 SP1)

            //string word = "[[[\"тест\",\"test\",\"test\",\"\"]],[[\"noun\",[\"тест\",\"испытание\",\"проверка\",\"анализ\",\"критерий\",\"проба\",\"исследование\",\"опыт\",\"реакция\",\"контрольная работа\",\"мерило\",\"проверочная работа\",\"реактив\"],[[\"тест\",[\"test\",\"reaction\",\"test paper\"]],[\"испытание\",[\"test\",\"trial\",\"experience\",\"probation\",\"assay\",\"experiment\"]],[\"проверка\",[\"check\",\"verification\",\"test\",\"inspection\",\"review\",\"audit\"]],[\"анализ\",[\"analysis\",\"test\",\"assay\",\"parsing\",\"breakdown\",\"scan\"]],[\"критерий\",[\"criterion\",\"test\",\"standard\",\"measure\",\"yardstick\",\"touchstone\"]],[\"проба\",[\"sample\",\"test\",\"trial\",\"probe\",\"fineness\",\"assay\"]],[\"исследование\",[\"study\",\"research\",\"investigation\",\"survey\",\"examination\",\"test\"]],[\"опыт\",[\"experience\",\"experiment\",\"practice\",\"attempt\",\"skill\",\"test\"]],[\"реакция\",[\"reaction\",\"response\",\"test\",\"answer\",\"anticlimax\"]],[\"контрольная работа\",[\"test\"]],[\"мерило\",[\"measure\",\"standard\",\"yardstick\",\"criterion\",\"test\",\"metewand\"]],[\"проверочная работа\",[\"test\"]],[\"реактив\",[\"reagent\",\"agent\",\"chemical agent\",\"test\"]]]],[\"adjective\",[\"испытательный\",\"пробный\",\"контрольный\",\"проверочный\"],[[\"испытательный\",[\"test\",\"trial\",\"probationary\",\"probatory\"]],[\"пробный\",[\"trial\",\"test\",\"pilot\",\"tentative\",\"experimental\",\"specimen\"]],[\"контрольный\",[\"control\",\"controlling\",\"check\",\"test\",\"pilot\",\"checking\"]],[\"проверочный\",[\"test\",\"check\",\"checking\",\"checkup\"]]]],[\"verb\",[\"тестировать\",\"испытать\",\"проверять\",\"испытывать\",\"опробовать\",\"подвергать испытанию\",\"производить опыты\",\"удостоверять\",\"подвергать проверке\",\"подвергать тесту\"],[[\"тестировать\",[\"test\"]],[\"испытать\",[\"test\"]],[\"проверять\",[\"check\",\"verify\",\"test\",\"examine\",\"inspect\",\"review\"]],[\"испытывать\",[\"experience\",\"feel\",\"have\",\"test\",\"suffer\",\"undergo\"]],[\"опробовать\",[\"test\",\"try out\",\"check\",\"assay\"]],[\"подвергать испытанию\",[\"try\",\"test\",\"put to test\",\"essay\",\"put to the proof\",\"tax\"]],[\"производить опыты\",[\"experiment\",\"test\",\"experimentalize\",\"experimentalise\"]],[\"удостоверять\",[\"certify\",\"attest\",\"verify\",\"authenticate\",\"prove\",\"test\"]],[\"подвергать проверке\",[\"test\"]],[\"подвергать тесту\",[\"put to the test\",\"test\"]]]],[\"\",[\"исследовать\"],[[\"исследовать\"]]]],\"en\",,[[\"тест\",[5],1,0,743,0,1,0]],[[\"test\",4,,,\"\"],[\"test\",5,[[\"тест\",743,1,0],[\"испытание\",232,1,0],[\"проверка\",23,1,0],[\"теста\",0,1,0],[\"тесте\",0,1,0]],[[0,4]],\"test\"]],,,[[\"en\"]],50]";
            //string[] words = word.Split(new string[] {",[[\""}, StringSplitOptions.RemoveEmptyEntries);


            //JNode node = JNode.Parse(word);


            //node.ChildNodes[1].ToString("   ")
            //node.ChildNodes[3].ChildNodes[1].ChildNodes[0].ToString("   ")

            //            string word = "чудо";
            //            Console.WriteLine(System.Web.HttpUtility.UrlEncode(word));
            //            byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(word);
            //      //      byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(word);
            // //           byte[] bytes = System.Text.Encoding.GetEncoding("windows-1251").GetBytes(word);
            ////            byte[] bytes = System.Text.Encoding.GetEncoding("koi8-r").GetBytes(word);
            //            string convertedWord = System.Text.Encoding.Unicode.GetString(bytes);
            //            Console.WriteLine(System.Web.HttpUtility.UrlEncode(convertedWord));
            //            Console.WriteLine(System.Web.HttpUtility.UrlEncode("чудо", System.Text.Encoding.Default));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!CF.AgreeFormWasShown && !Utils.IsWitheasy4learn) 
                {
                    AboutForm aboutForm = new AboutForm();
                    aboutForm.cbIAgree.Visible = true;
                    if (aboutForm.ShowDialog() != DialogResult.OK)
                        return; // global exit
                    else CF.AgreeFormWasShown = true;
                }

                DictionaryBlend frm = new DictionaryBlend();
                if (args.Length > 0)
                {
                    frm.Word = args[0];
                    //   frm.comboBox.Items.Insert(0, frm.Word);
                    frm.StartInMinimizeForm = Array.IndexOf(args, DictionaryBlend.MinimizeForm) != -1;
                }
                else if (Clipboard.ContainsText() && Clipboard.GetText().Length < 255)
                {
                    string text = Clipboard.GetText();
                    text = text.Trim('.', '!', '?');
                    if (!text.Contains(".") && UtilsForText.IsWord(text)) // for exclude urls and too long sentences
                    {
                        //frm.comboBox.Items.Insert(0, text);
                        frm.Word = text;
                    }
                }
                using (new ConfigSaver())
                    Application.Run(frm);
            }
            catch (Exception ex)
            {
                Utils.PublicException(ex);
            }
        }
    }
}
