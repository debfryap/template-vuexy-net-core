using Newtonsoft.Json;
using BfiBaseTemplate.Repo.Entities.Response;
using System.Security.Principal;

namespace BfiBaseTemplate.Web
{
    public class UserInfo
    {
        public static AuthentiocationResponse Indentity(IPrincipal principal)
        {
            return JsonConvert.DeserializeObject<AuthentiocationResponse>(principal.Identity.Name);
        }
    }
}
