using BfiBaseTemplate.Repo.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BfiBaseTemplate.Web.Extentions
{
    public static class HealthCheckExtention
    {
        public static void ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddUrlGroup(new Uri("https://apiname.bfi.co.id/api/v1/ping"), "Panel Dashboard API", HealthStatus.Degraded);

        }
        public static void UseHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/utilities/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonConvert.SerializeObject(
                        new
                        {
                            status = report.Status.ToString(),
                            item_check = report.Entries.Select(e => new
                            {
                                api_name = e.Key,
                                description = e.Value.Description,
                                duration = e.Value.Duration.TotalMilliseconds + " ms",
                                status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                            })
                        });
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                },
            });
        }
    }
}
