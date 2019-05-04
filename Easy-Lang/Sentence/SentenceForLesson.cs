using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace f
{
    public class SentenceForLesson : Sentence
    {
        public const string CharHided = "●";
        public const char MaskedChar = '●';

        public const char DelimiterForWord = '¢'; // ►◄
        public const string DelimiterForTranslComment = "◄►"; // ►◄

        public static char[] Excludes = new char[] { ' ', '-', '\'', '_', (char)160 }; //(char)32 == ' ' 160 тоже

        public int NumberSentence { get; private set; }
        public double Start { get; private set; }
        public double End { get; private set; }
        //public double StartToString() { return ; }
        //public double EndToString() { return ; }
        public double Length { get; private set; }

        public SentenceForLesson(string text, List<Sentence> parentList)
            // int numberSentence, double start, double end)
            : base(ClearToOnlySymbols(text), parentList)
        {
            List<string> list = GetWordsForLearn(this.TextValue);
            if (list.Count > 0)
                this.AddAllWordsToLearn(list);
            
            // this.TextValue = GetProcessedText()); // auto assign for Placard 
            
            // time processing
            string[] parts = text.Split(';');

            int numberSentence;
            if (!int.TryParse(parts[0], out numberSentence)) throw new ApplicationException(string.Format("Error in lesson file"));
            this.NumberSentence = numberSentence;
            // this.NumberSentence = int.Parse(parts[0]); numberSentence

            double dS, dE;
            if (double.TryParse(parts[1], out dS) && double.TryParse(parts[2], out dE))
            {
                this.Start = dS;
                this.End = dE;
                this.Length = this.End - this.Start;
            }
            // else IsHaveMedia = false;
        }

        //string _TranslComment = "";
        public string TranslComment
        {
            get { return "";
            //    this._TranslComment; 
            }
        }

        public static List<string> GetWordsForLearn(string text)
        {
            List<string> ret = new List<string>();
            bool odd = true;
            foreach (string s in text.Split(new char[] { DelimiterForWord }))
            {
                if (odd)
                    odd = false;
                else
                {
                    odd = true;
                    ret.Add(s);
                }
            }
            return ret;
        }

        static protected string ClearToOnlySymbols(string text)
        {
            string[] parts = text.Split(';');
            if (parts.Length >= 3) // TODO: что делать по поводу неправильных данных
                return parts[3].Replace("\n", "").Replace("\r", "");
            else return "";
        }

        public static List<Sentence> GetLessonSentences(string fileName)
        {
            string[] sentenses = FileManager.GetStringFrоmFile(fileName).Split(new string[] { SentenceParser.Delimeter }, StringSplitOptions.None);
            List<Sentence> sents = new List<Sentence> { };
            foreach (string line in sentenses)
            {
                if (!string.IsNullOrEmpty(line.Trim('\n')))
                {
                    sents.Add(new SentenceForLesson(line, sents));
                }
            }
            return sents;
        }
    }
}
