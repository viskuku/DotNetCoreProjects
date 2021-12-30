# Nlogger
## Package References

    <PackageReference Include="Microsoft.Data.SqlClient" Version="4.0.0" />  //Add SqlClient to write logs to Database
    <PackageReference Include="NLog" Version="4.7.13" /> //Add NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
    <PackageReference Include="NLog.Extensions.Logging" Version="1.7.4" /> // Add logging.ClearProviders();logging.SetMinimumLevel(LogLevel.Trace);logging.AddConsole();         
    <PackageReference Include="NLog.Web.AspNetCore" Version="4.14.0" /> //Adds helpers and layout renderers(NLog.config) for websites and web applications.

## Summary

## ConfigureLogging(IHostBuilder extension method) in CreateHostBuilder() and add UseNLog()
## Add NLog config file and add add assembly, targets & rules
   ### Targets - Json, Database, File and Console
   ### Logging Paramteres - ${longdate}, ${level}, ${aspnet-item:variable=CorrelationId}, ${message}, ${stacktrace}, ${exception:format=toString}, ${mdlc:item=ActionKey},          ${callsite}, ${logger}, ${all-event-properties:separator=|}
   ### _logger.BeginScope(new Dictionary<string, object> { ["ActionKey"] = nameof(GetWeatherForecast) }
 
    
## Level	Typical Use
Fatal	Something bad happened; application is going down

Error	Something failed; application may or may not continue

Warn	Something unexpected; application will continue

Info	Normal behavior like mail sent, user updated profile etc.

Debug	For debugging; executed query, user authenticated, session expired

Trace	For trace debugging; begin method X, end method X

## Scoped item

The SetScoped method returns an IDisposable that removes the added item when disposed. It can be used in conjunction with the using statement to limit the scope during which the item will be present in the Http Context.

      using (MappedDiagnosticsLogicalContext.SetScoped("Property", "PropertyValue")) {
    // "Property" item is present in current context
} // "Property" item has been removed from current context




## Reference 
https://blog.elmah.io/nlog-tutorial-the-essential-guide-for-logging-from-csharp/

https://github.com/NLog/NLog/wiki/Mdlc-Layout-Renderer

https://nlog-project.org/config/?tab=layout-renderers&search=event

https://www.youtube.com/watch?v=hvbKB5wpLOc
