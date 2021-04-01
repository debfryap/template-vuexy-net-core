using System;
using System.Collections.Generic;
using System;
using BfiBaseTemplate.Repo;
using System.IO;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using BfiBaseTemplate.Repo.Entities.Response;
using System.Linq;

namespace BfiBaseTemplate.Service
{
    public class LoginService
    {
        private NotificationService notificationService;
        private ClaimsIdentity claimsIdentity;
        public LoginService(NotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public ClaimsIdentity Authorize(string Username, string Password)
        {
            External(Username, Password);
            return claimsIdentity;
        }
        public void External(string Username, string Password)
        {
            var detailUser = new List<AuthentiocationResponse>();
            detailUser.Add(new AuthentiocationResponse
            {
                UserID = "1911NC0004",
                Password = "123456",
                IsActive = true,
                IsDemo = true,
                TypeUser = "demo",
                Username = "Partner Demo"
            });
            detailUser.Add(new AuthentiocationResponse
            {
                UserID = "1911NC0000",
                Password = "123456",
                IsActive = true,
                IsDemo = false,
                TypeUser = "commercial",
                Username = "Partner"
            });

            var temp = detailUser.SingleOrDefault(x => x.UserID == Username);
            if (temp != null && temp.Password == Password)
            {
                CredentialToken(temp);
            }
        }
        private void CredentialToken(AuthentiocationResponse result)
        {
            var credential = new
            {
                username = result.Username,
                type_user = result.TypeUser,
                User_id = result.UserID,
                is_active = result.IsActive,
                is_demo = result.IsDemo
            };

            string Token = JsonConvert.SerializeObject(credential);
            claimsIdentity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, Token),
                    new Claim(ClaimTypes.Role, result.TypeUser),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

        }
        
    }
}
