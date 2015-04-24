using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LunaSoft.StampClient.Implement
{
    internal class ConfigValue
    {
        /// <summary>
        /// Obtiene informacion de la configuración StampClient.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string Get(string key)
        {
            try
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                path = System.IO.Path.GetDirectoryName(path);

                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                string exeConfigFileName = System.IO.Path.Combine(path, "StampClient.config");
                configMap.ExeConfigFilename = exeConfigFileName;

                System.Configuration.Configuration config =
                    System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);


                return config.AppSettings.Settings[key].Value;
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
