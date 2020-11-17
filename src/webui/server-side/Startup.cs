using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Fluxor;
using igoodi.receiver360.webui.DataRetrieval;
using igoodi.receiver360.webui.Proxies;
using igoodi.receiver360.webui.Schedulers;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Services.Impls;
using igoodi.receiver360.webui.Slack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Westwind.AspNetCore.LiveReload;

namespace igoodi.receiver360.webui
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
          services.AddRazorPages();
          services.AddServerSideBlazor();
          services.AddSingleton<IssuesGenerator>();
          services.AddTelerikBlazor();

          services.AddFluxor(options =>
          {
            options.ScanAssemblies(typeof(Startup).Assembly);
            options.UseRouting();
          });

          services.AddHttpClient<ISlackMessageSender, SlackMessageSender>(c =>
          {
            c.BaseAddress = new Uri("https://hooks.slack.com");
          });

          services.AddBlazoredLocalStorage();
          services.AddBlazoredLocalStorage(config =>
            config.JsonSerializerOptions.WriteIndented = true);

          services.AddScoped<ITaskService, TaskService>();
          services.AddScoped<IFolderService, FolderService>();
          services.AddSingleton<ISlackConfiguration, SlackConfiguration>();
          services.AddSingleton<ICognitoConfiguration, CognitoConfiguration>();
          services.AddSingleton<IFolderMoverConfiguration, FolderMoverConfiguration>();

          services.AddLiveReload(config =>
          {
            config.LiveReloadEnabled = true;
            config.ClientFileExtensions = ".css,.js,.htm,.html";
            config.FolderToMonitor = "~/../";
          });

          services.AddSingleton<IJobFactory, JobFactory>();
          services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
          services.AddHostedService<QuartzHostedService>();

          services.AddSingleton<CheckIncomingInitializerJob>();
          services.AddSingleton<CheckProcessInitializerJob>();
          services.AddSingleton<CheckProcessFailuresInitializerJob>();
          services.AddSingleton<EstablishCognitoInitializerJob>();

          services.AddSingleton(new JobSchedule(
            jobType: typeof(CheckIncomingInitializerJob),
            cronExpression: "0/30 * * * * ?")); // run every 30 seconds

          services.AddSingleton(new JobSchedule(
            jobType: typeof(CheckProcessFailuresInitializerJob),
            cronExpression: "0/20 * * * * ?")); // run every 20 seconds
            //cronExpression: "30 0/1 * * * ?")); //(i.e. 10:00:30 am, 10:01:30 am, etc.).


          services.AddSingleton(new JobSchedule(
            jobType: typeof(CheckProcessInitializerJob),
            //cronExpression: "0/20 * * * * ?")); // run every 20 seconds
            cronExpression: "15 0/1 * * * ?")); //(i.e. 10:00:15 am, 10:01:15 am, etc.).

          //services.AddSingleton(new JobSchedule(
          //  jobType: typeof(EstablishCognitoInitializerJob),
          //  cronExpression: "30 0/1 * * * ?")); //(i.e. 10:00:30 am, 10:01:30 am, etc.).
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            var serviceProvider = app.ApplicationServices;
            var serviceFolderMover = (IFolderMoverConfiguration) serviceProvider.GetService(typeof(IFolderMoverConfiguration));

            serviceFolderMover.EstablishConnection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
