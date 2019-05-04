using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public static class UtilsForText
    {
        /// <summary>Если есть хоть одна буква</summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsWord(string word)
        {
            foreach (char c in word)
            {
                if (Char.IsLetter(c)) return true;
            }
            return false;
        }

        public static bool IsHaveSeveralWords(string text) 
        {
            // Console.WriteLine("!!");
            string[] words = text.Trim().Split(' ', '\r', '\n'); // '-'???
            int i = 0;
            foreach (string w in words)
            {
                if (IsWord(w)) ++i;
                if (i > 1) return true;
            }
            return false; // text.Trim().IndexOf(' ') != -1
        }

        public static bool IsInSelectedText(int index, RichTextBox sender)
        {
            return sender.SelectedText.Length > 0 &&
                sender.SelectionStart < index && // т.е. курсор находится в выделенном диапазоне текста
                (sender.SelectionStart + sender.SelectionLength) > index;
        }

        private static bool IsLetter(char c)
        {
            return char.IsLetter(c) && !char.IsPunctuation(c) && !char.IsSeparator(c);
        }
    }
}
