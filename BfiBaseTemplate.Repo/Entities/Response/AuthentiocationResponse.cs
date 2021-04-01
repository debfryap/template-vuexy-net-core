using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BfiBaseTemplate.Repo.Entities.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AuthentiocationResponse
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDemo { get; set; }
        public string TypeUser { get; set; }
        public string Username { get; set; }
    }
}
