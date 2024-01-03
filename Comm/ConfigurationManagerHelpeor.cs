using System.Collections.Generic;
using System.Configuration;

namespace 移动家客WinApp.Comm
{
    internal class ConfigurationManagerHelpeor
    {
        public static Dictionary<string, string> ReadAllSettings()
        {
            var result = new Dictionary<string, string>();

            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count == 0)
            {
                return result;
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    if (!result.ContainsKey(key))
                    {
                        result.Add(key, appSettings[key]);
                    }
                }
            }
            return result;
        }

        public static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "";
            return result;
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}