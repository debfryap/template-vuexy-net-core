using BfiBaseTemplate.Repo.Configuration;
using BfiBaseTemplate.Repo.Entities.Response;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BfiBaseTemplate.Repo.Proxy
{
    public class BaseProxy
    {
        private readonly string CREDENTIAL_FILE_PATH = External.ConfigItem.CredentialFilePath;
        public readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        public BaseProxy()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected string SetCredential()
        {
            OauthTokenCredential tokenCredential = ReadCredentialFromFile();
            if (tokenCredential == null)
            {
                tokenCredential = RequestToken() ?? new OauthTokenCredential();
            }

            return tokenCredential.AccessToken;
        }
        private void WriteCredentialToFile(OauthTokenCredential credential)
        {
            string credentialString = string.Empty;
            if (credential != null)
            {
                credentialString = JsonConvert.SerializeObject(credential);
            }
            ExistDirectory();
            using (var file = File.Create(CREDENTIAL_FILE_PATH))
            {
                byte[] strBytes = Encoding.UTF8.GetBytes(credentialString);
                file.Write(strBytes, 0, strBytes.Length);
            }
        }
        private void ExistDirectory()
        {
            if (!File.Exists(CREDENTIAL_FILE_PATH))
            {
                Path.GetDirectoryName(CREDENTIAL_FILE_PATH);
            }
        }
        private OauthTokenCredential ReadCredentialFromFile()
        {
            OauthTokenCredential credential = null;
            try
            {
                string credentialString = File.ReadAllText(CREDENTIAL_FILE_PATH).Trim();
                if (!string.IsNullOrEmpty(credentialString))
                {
                    credential = JsonConvert.DeserializeObject<OauthTokenCredential>(credentialString);
                    if (credential.HasExpired())
                    {
                        credential = null;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error("error at read token api  : statusCode : - message : " + e.Message);
                credential = null;
            }
            return credential;
        }
        protected OauthTokenCredential RequestToken()
        {
            string plainBasicAuth = External.ConfigItem.OauthApi.ApiKeyName + ":" + External.ConfigItem.OauthApi.ApiKeyValue;
            string base64BasicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainBasicAuth));
            var client = new RestClient(External.ConfigItem.OauthApi.Url);
            client.Timeout = -1;
            var request = new RestRequest("client_credentials/token?grant_type=client_credentials", Method.POST);
            request.AddHeader("Authorization", "Basic " + base64BasicAuth);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                _logger.Info("request token api success");
                var tokenCredential = JsonConvert.DeserializeObject<OauthTokenCredential>(response.Content);

                var expiredInSeconds = Convert.ToDouble(tokenCredential.ExpiresIn) - 60;
                tokenCredential.ExpiresIn = DateTime.Now.AddSeconds(expiredInSeconds).ToString("yyyy-MM-dd HH:mm:ss");
                WriteCredentialToFile(tokenCredential);
                return tokenCredential;
            }
            _logger.Error("error at request token api  : statusCode : - message : " + response.ErrorMessage);
            return null;
        }
    }
}
