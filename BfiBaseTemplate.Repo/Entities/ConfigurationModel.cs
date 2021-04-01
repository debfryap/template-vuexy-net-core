
namespace BfiBaseTemplate.Repo.Models
{
    public class ConfigurationModel
    {
        public string ConnectionString { get; set; }
        public string CredentialFilePath { get; set; }
        public string UrlBfiBaseTemplateApi { get; set; }
        public ApiAttibute OauthApi { get; set; }
    }
    public class ApiAttibute
    {
        public string Url { get; set; }
        public string ApiKeyName { get; set; }
        public string ApiKeyValue { get; set; }
    }
}
