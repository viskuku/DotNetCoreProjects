using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlogPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try {
                logger.Debug("Starting Host Builder");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex) {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging((hostingContext, logging) => {

                //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging")); //logging settings under appsettings.json
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConsole();
                logging.AddDebug();
            }).UseNLog();
    }
}
