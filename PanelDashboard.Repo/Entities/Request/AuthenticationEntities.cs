using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PanelDashboard.Repo.Entities.Request
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AuthenticationEntities
    {
        [Required(ErrorMessage = "{0} harus diisi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} harus diisi")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
