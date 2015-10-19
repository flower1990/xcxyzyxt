using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Configuration;

namespace ComputerExam.Util
{
    public class UserConfigSettings
    {
        public static readonly UserConfigSettings Instance = new UserConfigSettings();
        private string filePath = string.Empty;

        private UserConfigSettings()
        {
            filePath = GetConfigFilePath();
        }

        public string ReadSetting(string key)
        {
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = filePath;
            Configuration appConf = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            if (appConf.AppSettings.Settings[key] != null)
                return appConf.AppSettings.Settings[key].Value;
            else
                return string.Empty;
        }

        public void WriteSetting(string key, string value)
        {
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = filePath;
            Configuration appConf = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            if (appConf.AppSettings.Settings[key] != null)
                appConf.AppSettings.Settings.Remove(key);
            appConf.AppSettings.Settings.Add(key, value);
            appConf.Save(ConfigurationSaveMode.Modified);
        }

        public void RemoveSetting(string key)
        {
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = filePath;
            Configuration appConf = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            if (appConf.AppSettings.Settings[key] != null)
            {
                appConf.AppSettings.Settings.Remove(key);
                appConf.Save(ConfigurationSaveMode.Modified);
            }
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config\\UserConfigSettings.config");
        }
    }
}
