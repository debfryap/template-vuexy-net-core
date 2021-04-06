using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfiBaseTemplate.Web.Extentions
{
    public static class RegisterClasses
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<Service.LoginService>();
            services.AddTransient<Service.NotificationService>();
            //services.AddTransient<Service.DetailPartnerService>();
            //services.AddTransient<Repo.LoginRepo>();
            //services.AddTransient<Repo.DigitalPartnerRepo>();

        }
    }
}
