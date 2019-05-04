using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class IdiomService
    {
        static char[] DelimitersGroupIdioms = new char[] { ':', ',', ';', '.', '(', ')' }; // точка нужна т.к. могут присутствовать сокращения в предложении
        /// <summary>' ', '\n', '\r'</summary>
        public static char[] IdiomDelimiters = new char[] { ' ', '\n', '\r' };

        public static List<String> GetIdioms(string sentence)
        {
            int maxWord = 7; // vars
            List<String> list = new List<String>();
            List<String> maybyIdioms = GetMaybeIdioms(sentence, maxWord);
            foreach (string idiom in maybyIdioms)
            {
                if (D.Index.ContainsKey(idiom))
                {
                    list.Add(idiom);
                   // Console.WriteLine("Finded idiom: " + idiom);
                }
            }
            return list;
        }

        /// <summary>
        /// получить максимально возможное кол-во словосочетаний
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="maxWord">слов в словосочетании</param>
        /// <returns></returns>
        public static List<String> GetMaybeIdioms(string sentence, int maxWord)
        {
            List<String> list = new List<String>();
            foreach (string group in sentence.Split(DelimitersGroupIdioms)) // ':', ',', ';'
            {
                string[] words = group.Split(IdiomDelimiters, StringSplitOptions.RemoveEmptyEntries);
                for (int _start = 0; _start < words.Length; ++_start)
                {
                    // из пяти слов при условии что end == 2 "You may suppose" должен добавить 3 идиомы
                    for (int ii = _start + 1; ii < words.Length && (ii - _start < maxWord); ++ii)
                        list.Add(GetWordCombination(words, _start, ii)); // if max==5 then i-ii  0-1, 0-2, 0-3, 0-4, 0-5, 1-2 .....
                }
            }
            return list;
        }


        public static string GetWordCombination(string[] words, int start, int end)
        {
            string ret = words[start];
            for (int i = start + 1; i <= end; ++i)
            {
                if (words.Length <= i) break;
                ret += " " + words[i];
            }
            return ret.Trim(SentenceParser.sentenceKeys);
        }
    }
}