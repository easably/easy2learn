using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public static class CF
    {
        public static readonly Color ExternalBorder = ColorTranslator.FromHtml("#EAEAEA"); // more light then Brushes.Gainsboro 
        static bool m_WasHadConfig;
        static bool WasHadConfig { get { return m_WasHadConfig; } }

        static Configuration m_Config = null;

        public static Configuration Config
        {
            get
            {
                if (m_Config == null)
                {
                    Configuration roamingConfig;
                    // old m_Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    // Get the roaming configuration 
                    // that applies to the current user.
                    try
                    {
                        roamingConfig =
                            ConfigurationManager.OpenExeConfiguration(System.Diagnostics.Debugger.IsAttached ? ConfigurationUserLevel.None : ConfigurationUserLevel.PerUserRoaming);
                    }
                    catch(ConfigurationErrorsException)
                    {
                        roamingConfig =
                            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    }
                    // Map the roaming configuration file. This
                    // enables the application to access 
                    // the configuration file using the
                    // System.Configuration.Configuration class
                    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                    configFileMap.ExeConfigFilename = roamingConfig.FilePath;

                    m_WasHadConfig = roamingConfig.HasFile;

                    // Get the mapped configuration file.
                    m_Config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);


                    // //m_Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    // string path = Path.Combine(Application.LocalUserAppDataPath, Path.GetFileName(Application.ExecutablePath) + ".config");
                    ////  m_Config = ConfigurationManager.OpenExeConfiguration(path);

                }
                return m_Config;
            }
        }

        #region Get
        public static string GetValue(string keyName, object defaultVal)
        {
            if (Config.AppSettings.Settings[keyName] != null)
                return Config.AppSettings.Settings[keyName].Value;
            else return defaultVal.ToString();
        }

        public static bool GetValue(string keyName, bool defaultVal)
        {
            bool ret = defaultVal;
            KeyValueConfigurationElement key = Config.AppSettings.Settings[keyName];
            if (key != null)
                bool.TryParse(key.Value, out ret);
            return ret;
        }

        public static int GetValue(string keyName, int defaultVal)
        {
            int ret = defaultVal;
            KeyValueConfigurationElement key = Config.AppSettings.Settings[keyName];
            if (key != null)
                int.TryParse(key.Value, out ret);
            return ret;
        }

        public static float GetValue(string keyName, float defaultVal)
        {
            float ret = defaultVal;
            KeyValueConfigurationElement key = Config.AppSettings.Settings[keyName];
            if (key != null)
                float.TryParse(key.Value, out ret);
            return ret;
        }

        public static double GetValue(string keyName, double defaultVal)
        {
            double ret = defaultVal;
            KeyValueConfigurationElement key = Config.AppSettings.Settings[keyName];
            if (key != null)
                double.TryParse(key.Value, out ret);
            return ret;
        }

        public static void AssignValues(string key, Form form, Point defPos, Size defSize)
        {
            int iX = 0;
            int iY = 0;
            int iW, iH;
            KeyValueConfigurationElement key1 = Config.AppSettings.Settings[key + "_X"];
            KeyValueConfigurationElement key2 = Config.AppSettings.Settings[key + "_Y"];
            if (key1 != null && key2 != null)
            {
                if (int.TryParse(key1.Value, out iX) && int.TryParse(key2.Value, out iY))
                    if (iX > 0 && iY > 0) // т.к. однажды записалось -32000
                        form.Location = new Point(iX, iY);
                    else
                        form.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (!CF.WasHadConfig)
            {
                form.Location = defPos;
            }
            else // значит просто настройки слетели
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }


            key1 = Config.AppSettings.Settings[key + "_Width"];
            key2 = Config.AppSettings.Settings[key + "_Height"];
            if (key1 != null && key2 != null)
            {
                if (int.TryParse(key1.Value, out iW) && int.TryParse(key2.Value, out iH))
                {
                    if (iW > 0 && iH > 0)
                    {
                        // при минусовых значениях размеры формы не восcтанавливаем, значение -32000 при FormWindowState.Minimized
                        if (iX != -32000 && iY != -32000)
                            form.Size = new Size(iW, iH);
                    }
                    else
                    {
                        form.WindowState = FormWindowState.Maximized;
                        return;
                    }
                }
            }
            else if (!CF.WasHadConfig)
            {
                form.Size = defSize;
            }
        }
        #endregion

        #region Set
        public static void SetValue(string key, string value)
        {
            if (Config.AppSettings.Settings[key] != null)
                Config.AppSettings.Settings[key].Value = value;
            else Config.AppSettings.Settings.Add(key, value);
        }

        public static void SetValue(string key, object value)
        {
            SetValue(key, value.ToString());
        }

        public static void SetValue(string key, Form form)
        {
            SetValue(key + "_X", form.Location.X.ToString());
            SetValue(key + "_Y", form.Location.Y.ToString());

            if (form.WindowState == FormWindowState.Maximized)
            {
                SetValue(key + "_Height", "-1");
                SetValue(key + "_Width", "-1");
            }
            else
            {
                SetValue(key + "_Height", form.Size.Height.ToString());
                SetValue(key + "_Width", form.Size.Width.ToString());
            }
        }
        #endregion

        static string m_AdvertLinkWasShown = "AdvertLinkWasShown";
        public static bool AdvertLinkWasShown
        {
            get
            {
                if (CF.GetValue(m_AdvertLinkWasShown, "0") == "1")
                    return true;
                else return false;
            }
            set
            {
                if (value == true)
                {
                    CF.SetValue(m_AdvertLinkWasShown, "1");
                    CF.Config.Save();
                }
            }
        }

        static string m_AgreeFormWasShown = "AgreeFormWasShown";
        public static bool AgreeFormWasShown
        {
            get
            {
                if (CF.GetValue(m_AgreeFormWasShown, "0") == "1")
                    return true;
                else return false;
            }
            set
            {
                if (value == true)
                {
                    CF.SetValue(m_AgreeFormWasShown, "1");
                    CF.Config.Save();
                }
            }
        }


        public const string AppNameService = "Easy4Learn";
        //      public const string AppNameService = "Easy.for.Learn";

        public static string GetFolderForUserFiles()
        {
            // old return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ForceMem\\";
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + CF.AppNameService;
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            return folder;
        }

        public const string timeshift_video = "timeshift.video";
        public const string installation_date = "installation.date";

    }
}