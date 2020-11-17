using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using igoodi.receiver360.webui.Helpers.Loggings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Events;

namespace igoodi.receiver360.webui
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true"); 
          webBuilder.UseStartup<Startup>();
          webBuilder.UseUrls("http://0.0.0.0:3800");
          webBuilder.UseSerilog((provider, context, loggerConfiguration) =>
          {
            var name = Assembly.GetExecutingAssembly().GetName();

            loggerConfiguration
              .MinimumLevel.Debug()
              .MinimumLevel.Override("igoodi.receiver360.webui", LogEventLevel.Information)
              .Enrich.WithAspnetcoreHttpcontext(provider,
                customMethod: CustomEnricherLogic)
              .Enrich.FromLogContext()
              .Enrich.WithMachineName()
              .Enrich.WithProperty("Assembly", $"{name.Name}")
              .Enrich.WithProperty("Revision", $"{name.Version}")
              .WriteTo.RollingFile($@"./Logs/igoodi.receiver360.webui.txt",
                LogEventLevel.Information, retainedFileCountLimit: 7)
              .WriteTo.Debug(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{HttpContext} {NewLine}{Exception}");
          });
        });

    private static LoggingModel CustomEnricherLogic(IHttpContextAccessor ctx)
    {
      var context = ctx.HttpContext;
      if (context == null) return null;

      var loggingInfo = new LoggingModel
      {
        Path = context.Request.Path.ToString(),
        Host = context.Request.Host.ToString(),
        Method = context.Request.Method
      };

      var user = context.User;
      if (user?.Identity != null && user.Identity.IsAuthenticated)
      {
        loggingInfo.UserClaims =
          user.Claims.Select(a => new KeyValuePair<string, string>(a.Type, a.Value)).ToList();
      }
      return loggingInfo;
    }
  }
}