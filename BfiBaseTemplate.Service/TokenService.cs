using System;
using System.Collections.Generic;
using System.Text;

namespace BfiBaseTemplate.Service
{
    public class TokenService
    {
        readonly CrypetoBase64Service crypetoBase64Service = new CrypetoBase64Service();
        public string Token(string email, int expiredTimeInMinutes = 180)
        {
            /* tambahkan timestamp untuk expired token */
            string rawToken = "paneld4shb0ard|" + email + "|" + DateTime.Now.AddMinutes(expiredTimeInMinutes);
            string encryptedStr = crypetoBase64Service.Encode(rawToken);
            return encryptedStr;
        }

        public bool IsTokenValid(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token)) return false;
            string rawToken = crypetoBase64Service.Decode(token);
            string[] tokenParts = rawToken.Split('|');
            string emailPart = tokenParts[1];
            DateTime expTime = Convert.ToDateTime(tokenParts[2]);

            return tokenParts[0] == "paneld4shb0ard" && emailPart == email && expTime > DateTime.Now;
        }
    }
}
