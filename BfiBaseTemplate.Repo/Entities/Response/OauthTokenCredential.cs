using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BfiBaseTemplate.Repo.Entities.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OauthTokenCredential
    {
        public string IssuedAt { get; set; }
        public string AccessToken { get; set; }
        public string Scope { get; set; }
        public string ExpiresIn { get; set; }

        public bool HasExpired()
        {
            if (string.IsNullOrEmpty(ExpiresIn)) return true;

            var maxTokenTime = DateTime.Parse(ExpiresIn);
            return DateTime.Now > maxTokenTime;
        }
    }
}
