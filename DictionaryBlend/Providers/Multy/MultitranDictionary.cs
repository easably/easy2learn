using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class MultitranDictionary : DictionaryProvider
    {
        public override string Title { get { return "Multitran"; } }
        public override string Copyright { get { return @"©2009 Multitran"; } }
        public override string URL { get { return @"http://multitran.ru/c/m.exe?CL=1&l1={1}&l2={2}&s={0}"; } }
        public override string CorrectionURL { get { return @"http://multitran.ru/c/"; } }
        public override string CorrectionURLForImage { get { return @"http://multitran.ru/"; } }
        public override Encoding DefaultEncoding { get { return Encoding.Default; } }

        public override string[] StartTags
        {
            get
            {
                return new string[] { 
            "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\"",            
            "<table cellpadding=\"0\" ",            
            "<table border=\"0\"",         
   
            "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"",            
            "<table cellspacing=\"0\"",
            "<table cellpadding=\"0\"",
            "<table border=\"0\"" }; } }

        public override string BookmarkForStarTag { get {return "document.translation.s.focus()"; }}

        public override string[] Languages
        {
            get
            {
                return new string[] {                                                              
            //"en:x", 
            "en:de",
            //"de:x", 
            "de:en",

            // "x:ru"
            "en:ru", "fr:ru", "de:ru", "it:ru", "es:ru", "nl:ru",
            //"ru:x", 
            "ru:en", "ru:fr", "ru:de", "ru:it", "ru:es", "ru:nl",
                                                              };
            }
        }

        public override string GetUrl(string word, LangPair langPair)
        {
            if (string.IsNullOrEmpty(word)) return "";

            word = PrepareWord(word);
            return base.GetUrl(word, new LangPair(GetLangCode(langPair.From), GetLangCode(langPair.To)));
        }

        string GetLangCode(string code)
        {
                 if (code == "en") return "1";
            else if (code == "ru") return "2";
            else if (code == "de") return "3";
            else if (code == "fr") return "4";
            else if (code == "es") return "5";
            else if (code == "it") return "23";
            else if (code == "nl") return "24";
            return code;
        }
    }
}


/*
 
 
 http://multitran.ru/c/m.exe?l1=1&l2=3&CL=1&a=0 Англо-немецкий словарь
http://multitran.ru/c/m.exe?l1=3&l2=1&CL=1&a=0 Немецко-английский словарь
http://multitran.ru/c/m.exe?l1=1&     CL=2&s=test Англо-rus
http://multitran.ru/c/m.exe?l1=5&l2=2&CL=1&a=0 Испанско-русский и русско-испанский словарь
Испанско = 5 ("Spanish", "es");
немецкий 3
ru 2
en - 1
fr - 4
it - 23
нидерланды 24 ("Dutch", "nl");

http://multitran.ru/c/m.exe?CL=2&l1=1&s=test Англо-rus
  
 */