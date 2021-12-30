using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NlogPractice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Unhandled exception get caught here
            app.UseExceptionHandler(appBuilder => {
                appBuilder.Run(async context => {
                    var logger = appBuilder.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                    var feature = context.Features.Get<IExceptionHandlerFeature>();

                    if (feature.Error != null) {
                        logger.LogError(feature.Error, "Exception Here!");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new {
                            error = "Something Went Wrong!",
                            detail = feature.Error.Message
                        }));
                    }
                });
            });

            app.UseLoggerMiddleware();

            if (env.IsDevelopment()) {
               // app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
