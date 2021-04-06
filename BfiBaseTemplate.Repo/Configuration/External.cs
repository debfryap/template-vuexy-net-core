using BfiBaseTemplate.Repo.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BfiBaseTemplate.Repo.Configuration
{
    public class External
    {
        private const string URL_CONFIGURATION = @"\app-name\config.json";
        protected External()
        {
        }
        private static ConfigurationModel Config()
        {
            string HOME_DIRECTORY = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) : Environment.GetEnvironmentVariable("HOME");
            string URL_CONFIG = Path(HOME_DIRECTORY + URL_CONFIGURATION);
            var myJsonString = File.ReadAllText(URL_CONFIG);
            var result = JsonConvert.DeserializeObject<ConfigurationModel>(myJsonString);
            result.CredentialFilePath = Path(HOME_DIRECTORY + result.CredentialFilePath);

            return result;
        }
        private static string Path(string Path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Path.Replace(@"\", "/");
            }
            return Path;
        }

        public static readonly ConfigurationModel ConfigItem = Config();
    }
}
