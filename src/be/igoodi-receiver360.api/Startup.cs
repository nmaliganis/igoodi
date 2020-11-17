using System;
using System.Reflection;
using System.Text;
using AspNetCoreRateLimit;
using Autofac;
using FluentValidation.AspNetCore;
using igoodi.receiver360.api.Configurations;
using igoodi.receiver360.api.Configurations.AutoMappingProfiles.Assets;
using igoodi.receiver360.api.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;

namespace igoodi.receiver360.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IHostingEnvironment hostEnv)
    {
      Configuration = configuration;
      HostEnv = hostEnv;
    }

    private const string CorsPolicyName = "AllowSpecificOrigins";

    public IConfiguration Configuration { get; }
    public IHostingEnvironment HostEnv { get; }
    public IContainer ApplicationContainer { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(CorsPolicyName,
          builderCors => { builderCors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      var name = Assembly.GetExecutingAssembly().GetName();

      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(Configuration)
        .MinimumLevel.Debug()
        .MinimumLevel.Override("igoodi-receiver360.api", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProperty("Assembly", $"{name.Name}")
        .Enrich.WithProperty("Revision", $"{name.Version}")
        .WriteTo.Debug(
          outputTemplate:
          "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{HttpContext} {NewLine}{Exception}")
        .WriteTo.RollingFile(HostEnv.WebRootPath + "//" + $"{DateTime.Now}.txt", Serilog.Events.LogEventLevel.Information,
          retainedFileCountLimit: 7)
        .CreateLogger();

      services.AddLogging(loggingBuilder =>
        loggingBuilder
          .AddSerilog(dispose: true));

      var key = Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value);
      services.AddAuthentication(x =>
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
          x.RequireHttpsMetadata = false;
          x.SaveToken = true;
          x.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
            ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
          };
        });


      services.AddMvc(
          options =>
          {
            options.EnableEndpointRouting = false;
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
          })
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(options =>
        {
          options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        })
        .AddFluentValidation();
      ;

      //NpgsqlConnection.GlobalTypeMapper.UseJsonNet(new[] {typeof(JsonbType)});

      services.AddResponseCaching();

      services.AddHttpCacheHeaders(
        (expirationModelOptions)
          =>
        {
          expirationModelOptions.MaxAge = 60;
          expirationModelOptions.SharedMaxAge = 30;
        },
        (validationModelOptions)
          =>
        {
          validationModelOptions.MustRevalidate = true;
          validationModelOptions.ProxyRevalidate = true;
        });

      services.AddMemoryCache();

      services.Configure<IpRateLimitOptions>((options) =>
      {
        options.GeneralRules = new System.Collections.Generic.List<RateLimitRule>()
        {
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 1000,
            Period = "5m"
          },
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 200,
            Period = "10s"
          }
        };
      });

      services.AddApiVersioning(o => o.ApiVersionReader = 
        new HeaderApiVersionReader("api-version"));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "igoodi-receiver360.api - HTTP API",
          Version = "v1",
          Description = "The Catalog Microservice HTTP API for igoodi-receiver360.api service",
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Description =
            "Authorization: Bearer {token}",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new string[] { }
          }
        });
      });

      Config.ConfigureRepositories(services);
      Config.ConfigureAutoMapper(services);
      Config.ConfigureNHibernate(services, Configuration.GetConnectionString("PostgreSqlDatabase"));

      services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));

      services.AddCors(options =>
      {
        options.AddPolicy(CorsPolicyName,
          builderCors => { builderCors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
      });


      services.AddSingleton<IRabbitMqttConfiguration, RabbitMqttConfiguration>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseSwagger()
        .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "igoodi-receiver360.api - API V1"); });

      app.UseCors(CorsPolicyName);
      app.UseResponseCaching();
      app.UseHttpCacheHeaders();
      app.UseCookiePolicy();
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();


      var serviceProvider = app.ApplicationServices;

      var serviceMqtt = (IRabbitMqttConfiguration) serviceProvider.GetService(typeof(IRabbitMqttConfiguration));

      serviceMqtt.EstablishConnection();

      AutoMapper.Mapper.Initialize(cfg =>
      {
        cfg.AddProfile<AssetForCreationΤοAssetEntityUiAutoMapperProfile>();
      });

      app.UseApiVersioning();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
