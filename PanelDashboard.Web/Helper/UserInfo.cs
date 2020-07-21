using Newtonsoft.Json;
using PanelDashboard.Repo.Entities.Response;
using System.Security.Principal;

namespace PanelDashboard.Web
{
    public class UserInfo
    {
        public static AuthentiocationResponse Indentity(IPrincipal principal)
        {
            return JsonConvert.DeserializeObject<AuthentiocationResponse>(principal.Identity.Name);
        }
    }
}
