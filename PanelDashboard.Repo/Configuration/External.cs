using PanelDashboard.Repo.Models;
using Newtonsoft.Json;
using System.IO;

namespace PanelDashboard.Repo.Configuration
{
    public class External
    {
        private const string URL_CONFIGURATION = @"C:\application_config\panel-dashboard\config.json";
        public static ConfigurationModel Read()
        {
            var myJsonString = File.ReadAllText(URL_CONFIGURATION);
            return JsonConvert.DeserializeObject<ConfigurationModel>(myJsonString);
        }
    }
}
