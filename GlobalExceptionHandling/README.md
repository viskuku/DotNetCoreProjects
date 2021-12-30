# Global Exception Handling 

### using Microsoft.AspNetCore.Diagnostics; - IExceptionHandlerFeature

    //Unhandled exception get caught here

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

