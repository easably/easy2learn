using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;

namespace f
{
    public static class Utils
    {
        public static string GetDateForFolderName()
        {
            DateTime t = DateTime.Today;
            return t.Year.ToString() + "_" + (t.Month < 10 ? "0" : "") + t.Month.ToString() + "_" + (t.Day < 10 ? "0" : "") + t.Day.ToString() + "_";
        }


        public static void PublicException(Exception ex)
        {
            // вариант с сообщением текста ошибки
            //string message = string.Format(
            //    "{0} has encountered porblem: \n" +
            //    "{1}\n\n\n We are sorry for the inconvenience.\n\n Please tell about this problem.",
            //    Application.ProductName, ex.Message);

            string message = string.Format(
                "{0} has encountered porblem \n" + Environment.NewLine + 
                "We are sorry for the inconvenience. Please tell about this problem." + Environment.NewLine +
                "Send a bug report?",
                Application.ProductName, ex.Message);
            //if (MessageBox.Show(message, T.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            if (MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Utils.SendMail("Error in " + Application.ProductName, ex.ToString());
            }
        }

        public static bool IsWitheasy4learn
        {
            get
            {
                return File.Exists(FileManager.FindPathAndReturnFullFileName("easy4learn.exe"));
            }
        }

        //public static bool IsWithConfig
        //{
        //    get
        //    {
        //        string exeName = Assembly.GetCallingAssembly().GetName().Name;

        //        return File.Exists(FileManager.FindPathAndReturnFullFileName(exeName + ".config"));
        //        //return File.Exists(FileManager.FindPathAndReturnFullFileName(Application.ProductName + ".config"));
        //    }
        //}

        private static RichTextBox m_EditorRTF = null;
        public static bool doResetPreviousColorState = true;

        public static RichTextBox EditorRTF
        {
            get
            {
                if (m_EditorRTF == null)
                {
                    m_EditorRTF = new RichTextBox();
                    m_EditorRTF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                return m_EditorRTF;
            }
        }

        static string m_TempDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ForceMem\\";
        public static string TempDir
        {
            get
            {
                if (!Directory.Exists(m_TempDir))
                    Directory.CreateDirectory(m_TempDir);
                return m_TempDir;
            }
        }

    //    public const string ForceMemII = "http://www.forcemem.com/ForceMemTrainer.htm";
    //    public const string Forum = "http://www.forcemem.com/forum/";

        public static void Support()
        {
            SendMail("About " + Application.ProductName, "");
        }

        public static void AddDictionary()
        {
            string subject = "Please add a new feature or new dictionary to DictionaryBlend";
            string body = "Hello" 
                + Environment.NewLine + subject + " from http://some_site.com "
                + Environment.NewLine + "I want to get full version of software instead my review or feedback obout new version."
                + Environment.NewLine
                + Environment.NewLine + "Thank's";
            if (GetLocaleForUI().Equals("ru"))
            {
                subject = "Пожалуйста добавьте новую возможность или новый словарь к DictionaryBlend";
                body = "Hello"
                    + Environment.NewLine + subject + " по адресу http://some_site.com "
                    + Environment.NewLine + "Я хочу получить полную версию за обзор или тестирование новой версии программы."
                    + Environment.NewLine
                    + Environment.NewLine + "Спасибо";
            }
            Utils.SendMail(subject, body);
        }

        public static void SendFeedback()
        {
            string subject = string.Format("Feedback for: {0} v{1}", Application.ProductName, Application.ProductVersion);
            string body = "<< Enter your feedback or bug report here. >>";

            Utils.SendMail(subject, body);
        }

       // http://msdn.microsoft.com/en-us/library/office/jj220499(v=exchg.80).aspx
        //static void Main(string[] args)
//{
//   ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
//   ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
//   service.Credentials = new WebCredentials("user1@contoso.com", "password");

//   service.TraceEnabled = true;
//   service.TraceFlags = TraceFlags.All;   

//   service.AutodiscoverUrl("user1@contoso.com", RedirectionUrlValidationCallback);

//   EmailMessage email = new EmailMessage(service);
//   email.ToRecipients.Add("user1@contoso.com ");
//   email.Subject = "HelloWorld";
//   email.Body = new MessageBody("This is the first email I've sent by using the EWS Managed API");
//   email.Send();
//}
        public static void SendMail(string subject, string body)
        {
            try
            {
                string command = string.Format("mailto:easy4learn.com@gmail.com?subject={0}&body={1}", subject, body.Replace("\"", "'"));
                Process.Start(command);
            }
            catch (Win32Exception)
            {
                // TODO: скопировать  subject
                // MessageBox.Show("Problem using 'MailTo' shell command." + Environment.NewLine +
                if ( MessageBox.Show("Default mail client was not found on you computer." + Environment.NewLine +
                    "Please send a letter by web-mail." + Environment.NewLine +
                    "Copy entire mail body to clipboard for sending by webmail?" + Environment.NewLine +
                    " To: easy4learn.com@gmail.com", "'MailTo' command not found", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                { 
                    Clipboard.SetText(subject + Environment.NewLine + body);
                }
            }
        }

        public const string Root = "http://www.forcemem.com/";
        public const string Download = "http://www.forcemem.com/DictionaryBlend.msi";

        public static string ShrinkLines(string val)
        {
            int step = 150;
            if (val.Length < step) return val;
            string res = "";
            string carriage = "\r\n";
            foreach (string part in val.Split(new string[] { carriage }, StringSplitOptions.None))
            {
                if (part.Length > step)
                {
                    string store = "";
                    for (int i = 0; i * step < part.Length; ++i)
                    {
                        int end = step;
                        if (part.Length < (i * step + end))
                            end = part.Length - i * step;
                        store += part.Substring(i * step, end) + carriage;
                    }
                    res += store;
                }
                else res += part + carriage;
            }
            return res;
        }

        //private void CreateDesktopIcon()
        //{
        //    //ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

        //    //if (ad.IsFirstRun)
        //    //{
        //    //    Assembly assembly = Assembly.GetEntryAssembly();
        //    //    string company = string.Empty;
        //    //    string description = string.Empty;

        //    //    if (Attribute.IsDefined(assembly, typeof(AssemblyCompanyAttribute)))
        //    //    {
        //    //        AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute));
        //    //        company = ascompany.Company;
        //    //    }
        //    //    if (Attribute.IsDefined(assembly, typeof(AssemblyDescriptionAttribute)))
        //    //    {
        //    //        AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute));
        //    //        description = asdescription.Description;
        //    //    }
        //    //    if (!string.IsNullOrEmpty(company))
        //    //    {
        //    //        string desktopPath = string.Empty;
        //    //        desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");

        //    //        string shortcutName = string.Empty;
        //    //        shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");

        //    //        System.IO.File.Copy(shortcutName, desktopPath, true);
        //    //    }
        //    //}
        //}

        public static string GetShortFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return "";
            if (fileName.Length > 33)
            {
                int startEnd = fileName.LastIndexOf('\\');
                if (startEnd == -1 && Utils.IsURL(fileName))
                    startEnd = fileName.LastIndexOf('/');
                if (startEnd == -1) return fileName;                
                fileName = fileName.Substring(0, 7) + " ... " + fileName.Substring(startEnd, fileName.Length - startEnd);
            }
            return fileName;
        }

        #region for OS
        public static string GetOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        public static int getOSArchitecture()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }

        //public static bool IsNiceOSForSimpleButton
        //{
        //    get
        //    {
        //        //Get Operating system information.
        //        OperatingSystem os = Environment.OSVersion;
        //        //Get version information about the os.
        //        Version vs = os.Version;

        //        return (os.Platform == PlatformID.Win32NT) && (vs.Major == 6);
        //    }
        //}
        #endregion

        #region get DefaultLang
        static int[] rusAvailable = new int[] {
                1088, //Kyrgyz - Cyrillic			
                2092, // Azeri - Cyrillic	
                1049, // Russian	
                1087, // Kazakh	
                1058, // Ukrainian	
                1092, // Tatar
	            1059, // Belarusian
                2115, // Uzbek - Cyrillic	uz	uz-uz	

                1063, // Lithuanian	lt	lt	427	1257
                1062, // Latvian	lv	lv		426	1257
                1061, // Estonian	et	et		425	1257

            };

        public static string GetDefaultToLanguageForceDefault()
        {
            string res = GetDefaultToLanguage();
            if (res.Equals("en"))
                return "ru";
            else return res;
        }

        public static string GetDefaultToLanguage()
        {
            string res = "ru";
            try{
                CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
                res = ci.TwoLetterISOLanguageName;
                if (!CurrentLangInfo.GoogleLanguagesTo.ContainsValue(res))
                {
                    res = ci.Name;
                    if (!CurrentLangInfo.GoogleLanguagesTo.ContainsValue(res))
                        res = "ru";
                }
            }
            catch{
            }
            return res;
        }

        #region LocaleForUI
        public static string GetLocaleForUI()
        {
            //            string res = GetDefaultToLanguage();
            if (IsCIS) return "ru";
            return "en";
        }

        static bool IsCIS // это СНГ?
        {
            get
            {
                int DefaultLang = GetSystemDefaultLCID();
                return Array.IndexOf(rusAvailable, DefaultLang) != -1;
            }
        } 

        public static string GetLocalizedPrefix()
        {
            if (IsCIS) return @"http://ru.";
            return @"http://www.";
        }
        #endregion

        public static bool IsURL(string val)
        {
            //Uri result;
            //if (Uri.TryCreate(val, UriKind.RelativeOrAbsolute, out result))
            //    return true;
            //return false;

            return Uri.IsWellFormedUriString(val, UriKind.Absolute);

           // return val.StartsWith("http:");
        }

        #region GetSystemDefaultLCID

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetSystemDefaultLCID();

        /*
         
         * http://www.science.co.il/language/locale-codes.asp?s=codepage
         * 
         
         Locale	Language
code	LCID
string	Decimal	Hexadecimal	Codepage
Gujarati	gu	gu	1095	447	
Syriac			1114		
Konkani			1111	457	
Sanskrit	sa	sa	1103		
Marathi	mr	mr	1102		
Kannada	kn	kn	1099		
Tamil	ta	ta	1097	449	
Divehi; Dhivehi; Maldivian	dv	dv	1125	465	
Punjabi	pa	pa	1094	446	
Hindi	hi	hi	1081	439	
Georgian	ka		1079	437	
Armenian	hy	hy	1067		
Telugu	te	te	1098		
Thai	th	th	1054		
Japanese	ja	ja	1041	411	
Chinese - Singapore	zh	zh-sg	4100	1004	
Chinese - China	zh	zh-cn	2052	804	
Korean	ko	ko	1042	412	
Chinese - Taiwan	zh	zh-tw	1028	404	
Chinese - Macau SAR	zh	zh-mo	5124	1404	
Chinese - Hong Kong SAR	zh	zh-hk	3076		
Romanian - Romania	ro	ro	1048	418	1250
Albanian	sq	sq	1052		1250
Polish	pl	pl	1045	415	1250
Hungarian	hu	hu	1038		1250
Serbian - Latin	sr	sr-sp	2074		1250
Slovenian	sl	sl	1060	424	1250
Czech	cs	cs	1029	405	1250
Croatian	hr	hr	1050		1250
Slovak	sk	sk	1051		1250
Kyrgyz - Cyrillic			1088	440	1251
Azeri - Cyrillic	az	az-az	2092		1251
Russian	ru	ru	1049	419	1251
Kazakh	kk	kk	1087		1251
Ukrainian	uk	uk	1058	422	1251
Tatar	tt	tt	1092	444	1251
Serbian - Cyrillic	sr	sr-sp	3098		1251
Belarusian	be	be	1059	423	1251
Uzbek - Cyrillic	uz	uz-uz	2115	843	1251
Mongolian	mn	mn	1104	450	1251
Bulgarian	bg	bg	1026	402	1251
FYRO Macedonia	mk	mk	1071		1251
Afrikaans	af	af	1078	436	1252
Faroese	fo	fo	1080	438	1252
Swedish - Sweden	sv	sv-se	1053		1252
Malay - Malaysia	ms	ms-my	1086		1252
Swahili	sw	sw	1089	441	1252
Spanish - Paraguay	es	es-py	15370		1252
Spanish - Uruguay	es	es-uy	14346		1252
English - Trinidad	en	en-tt	11273		1252
English - Phillippines	en	en-ph	13321	3409	1252
Spanish - Bolivia	es	es-bo	16394		1252
Spanish - Nicaragua	es	es-ni	19466		1252
Catalan	ca	ca	1027	403	1252
Danish	da	da	1030	406	1252
German - Germany	de	de-de	1031	407	1252
English - United States	en	en-us	1033	409	1252
Spanish - Spain (Traditional)	es	es-es	1034		1252
Finnish	fi	fi	1035		1252
French - France	fr	fr-fr	1036		1252
Indonesian	id	id	1057	421	1252
Italian - Italy	it	it-it	1040	410	1252
Basque	eu	eu	1069		1252
Dutch - Netherlands	nl	nl-nl	1043	413	1252
Norwegian - Bokml	nb	no-no	1044	414	1252
Portuguese - Brazil	pt	pt-br	1046	416	1252
Spanish - Chile	es	es-cl	13322		1252
Spanish - Honduras	es	es-hn	18442		1252
Galician	gl		1110	456	1252
Spanish - El Salvador	es	es-sv	17418		1252
Icelandic	is	is	1039		1252
English - Australia	en	en-au	3081		1252
Spanish - Dominican Republic	es	es-do	7178		1252
English - Southern Africa	en	en-za	7177		1252
German - Austria	de	de-at	3079		1252
French - Monaco	fr		6156		1252
Spanish - Panama	es	es-pa	6154		1252
English - Ireland	en	en-ie	6153	1809	1252
Spanish - Guatemala	es	es-gt	4106		1252
Spanish - Costa Rica	es	es-cr	5130		1252
Portuguese - Portugal	pt	pt-pt	2070	816	1252
French - Canada	fr	fr-ca	3084		1252
English - New Zealand	en	en-nz	5129	1409	1252
Spanish - Ecuador	es	es-ec	12298		1252
German - Liechtenstein	de	de-li	5127	1407	1252
French - Switzerland	fr	fr-ch	4108		1252
German - Luxembourg	de	de-lu	4103	1007	1252
English - Canada	en	en-ca	4105	1009	1252
French - Luxembourg	fr	fr-lu	5132		1252
Spanish - Venezuela	es	es-ve	8202		1252
English - Zimbabwe	en		12297	3009	1252
Spanish - Peru	es	es-pe	10250		1252
English - Belize	en	en-bz	10249	2809	1252
Spanish - Colombia	es	es-co	9226		1252
Spanish - Puerto Rico	es	es-pr	20490		1252
English - Caribbean	en	en-cb	9225	2409	1252
Malay - Brunei	ms	ms-bn	2110		1252
English - Great Britain	en	en-gb	2057	809	1252
Swedish - Finland	sv	sv-fi	2077		1252
Spanish - Mexico	es	es-mx	2058		1252
French - Belgium	fr	fr-be	2060		1252
Italian - Switzerland	it	it-ch	2064	810	1252
Dutch - Belgium	nl	nl-be	2067	813	1252
English - Jamaica	en	en-jm	8201	2009	1252
Norwegian - Nynorsk	nn	no-no	2068	814	1252
Spanish - Argentina	es	es-ar	11274		1252
German - Switzerland	de	de-ch	2055	807	1252
Greek	el	el	1032	408	1253
Turkish	tr	tr	1055		1254
Uzbek - Latin	uz	uz-uz	1091	443	1254
Azeri - Latin	az	az-az	1068		1254
Hebrew	he	he	1037		1255
Arabic - Saudi Arabia	ar	ar-sa	1025	401	1256
Arabic - Jordan	ar	ar-jo	11265		1256
Arabic - Kuwait	ar	ar-kw	13313	3401	1256
Arabic - Syria	ar	ar-sy	10241	2801	1256
Arabic - Lebanon	ar	ar-lb	12289	3001	1256
Arabic - Iraq	ar	ar-iq	2049	801	1256
Arabic - Bahrain	ar	ar-bh	15361		1256
Arabic - Yemen	ar	ar-ye	9217	2401	1256
Arabic - Qatar	ar	ar-qa	16385	4001	1256
Urdu	ur	ur	1056	420	1256
Arabic - Egypt	ar	ar-eg	3073		1256
Arabic - United Arab Emirates	ar	ar-ae	14337	3801	1256
Arabic - Tunisia	ar	ar-tn	7169		1256
Farsi - Persian	fa	fa	1065	429	1256
Arabic - Morocco	ar	ar-ma	6145	1801	1256
Arabic - Libya	ar	ar-ly	4097	1001	1256
Arabic - Algeria	ar	ar-dz	5121	1401	1256
Arabic - Oman	ar	ar-om	8193	2001	1256
Lithuanian	lt	lt	1063	427	1257
Latvian	lv	lv	1062	426	1257
Estonian	et	et	1061	425	1257
Vietnamese	vi	vi	1066		1258
Unicode		UTF-8	0		65001

         
         */

        #endregion
        #endregion
    }
}
