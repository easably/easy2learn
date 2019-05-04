using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Babylon : DictionaryProvider
    {
        public override Encoding DefaultEncoding { get { return Encoding.UTF8; } }
        public override DictionaryProviderType DictType { get { return DictionaryProviderType.Simple | DictionaryProviderType.Idiom; } }
        public override string Title { get { return "Babylon"; } }
        public override string Copyright { get
        {
            return @"Copyright © 1997-2007 Babylon.com LTD All right reserved | Babylon online dictionary";
        } }
        public override string URL { get
        {
            return @"http://www.babylon.com/definition/{0}/{2}";
        } }
        // они указывают полный путь
        public override string CorrectionURL { get { return @"http://www.babylon.com/definition/"; } }
        public override string[] StartTags { get { return new string[] {"<div id=\"results-col\""}; } }
        public override string[] Languages { get { return new string[]
        {
            "en", "es", "de", "fr", "it", "zh", 
            "pt", "nl", "no", "el", "ru",
            "nu", "ja", "ko", "tr", "ar", 
            "pl", "ro", "th", "hi", "uk", 
            "fa", "el"
        }; } }
    }
}

/*
    English</a></li><li><a href="http://deutsch.babylon.com/index"><div class="flag ger"></div>    
    Deutsch</a></li><li><a href="http://francais.babylon.com/index"><div class="flag fre"></div>    
    Francais</a></li><li><a href="http://espanol.babylon.com/index"><div class="flag spa"></div>    
    Espanol</a></li><li><a href="http://italiano.babylon.com/index"><div class="flag ita"></div>    
     
    Italiano</a></li><li><a href="http://nederlands.babylon.com/index"><div class="flag dut"></div>    
     
    Nederlands</a></li><li><a href="http://portugues.babylon.com/index"><div class="flag ptg"></div>    
    Portugues</a></li><li><a href="http://hebrew.babylon.com/index"><div class="flag heb"></div>    
    hebrew?????</a></li><li><a href="http://svenska.babylon.com/index"><div class="flag swe"></div>    
!nu    Svenska</a></li></ul><ul style="border-left: medium none; border-right: medium none;   
    japanese???</a></li><li><a href="http://chs.babylon.com/index"><div class="flag chs"></div>    
!    chs????</a></li><li><a href="http://chinese.babylon.com/index"><div class="flag cht"></div>    
    chinese????</a></li><li><a href="http://russian.babylon.com/index"><div class="flag rus"></div>    
    Русский</a></li><li><a href="http://korean.babylon.com/index"><div class="flag kor"></div>    
    korean???</a></li><li><a href="http://turkce.babylon.com/index"><div class="flag tur"></div>    
    Turkce</a></li><li><a href="http://arabic.babylon.com/index"><div class="flag ara"></div>    
    arabic???????</a></li><li><a href="http://magyar.babylon.com/index"><div class="flag hun"></div>    
!    Magyar</a></li><li><a href="http://norsk.babylon.com/index"><div class="flag nor"></div>    
    Norsk</a></li></ul><ul style="border-right: medium none; height: 171px; position: 
    Polski</a></li><li><a href="http://romana.babylon.com/index"><div class="flag rom"></div>    
    Romana</a></li><li><a href="http://thai.babylon.com/index"><div class="flag tha"></div>    
    thai???????</a></li><li><a href="http://hindi.babylon.com/index"><div class="flag ind"></div>    
    hindi??????</a></li><li><a href="http://dansk.babylon.com/index"><div class="flag den"></div>    
!   Dansk</a></li><li><a href="http://ukranian.babylon.com/index"><div class="flag ukr"></div>    
    Українська</a></li><li><a href="http://persian.babylon.com/index"><div class="flag far"></div>    
    persian?????</a></li><li><a href="http://greek.babylon.com/index"><div class="flag gre"></div>    
    greek????????</a></li></ul>
 */
