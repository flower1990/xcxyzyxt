using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ComputerExam.Util
{
    public static class AppConfigHelper
    {
        /// <summary>
        /// 获得服务器地址
        /// </summary>
        /// <returns>服务器地址</returns>
        public static string GetServerAddress()
        {
            string serverAddress = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = "Constant.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

                //方法一：
                //AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                //serverAddress = section.Settings["ServerAddress"].Value;
                //方法二：
                serverAddress = config.AppSettings.Settings["ServerAddress"].Value;
            }
            catch { }

            return serverAddress;
        }

        /// <summary>
        /// 修改服务器地址
        /// </summary>
        /// <param name="serverAddress">服务器地址</param>
        public static void ChangeServerAddress(string serverAddress)
        {
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = "Constant.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

                //方法一：
                //AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                //section.Settings["ServerAddress"].Value = serverAddress;
                //方法二：
                config.AppSettings.Settings["ServerAddress"].Value = serverAddress;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

            }
            catch { }
        }



    }
}
