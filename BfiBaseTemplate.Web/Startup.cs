using System;
using AutoMapper;
using BfiBaseTemplate.Web.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BfiBaseTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Register();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication("FiverSecurityScheme")
              .AddCookie("FiverSecurityScheme", options =>
              {
                  options.AccessDeniedPath = new PathString("/error/notauthorize");
                  options.LoginPath = "/auth/login";
                  options.LogoutPath = "/auth/logout";
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(180);
              });
            services.AddRouting(options => options.LowercaseUrls = true);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.CreateMissingTypeMaps = true;
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AllowAnonymousToPage("/auth/login");
            });
            services.ConfigureHealthCheck();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/notfound");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dashboard}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                  );
            });
            app.UseHealthCheck();
        }
    }
}
