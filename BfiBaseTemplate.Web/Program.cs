using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace BfiBaseTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                /* buka semua comment pada code dibawah ini ketika file config.json sudah ada */


                //string Config = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\app-name\config.json";

                logger.Info("Application Start !!");
                //if (!System.IO.File.Exists(Config))
                //{
                //    throw new ArgumentException(Config + "Not Found");
                //}

                //logger.Info("Read config from " + Config);
                CreateWebHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, "Error in init");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                .UseNLog();
    }
}
