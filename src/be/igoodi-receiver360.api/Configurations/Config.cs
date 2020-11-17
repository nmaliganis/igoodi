using System;
using System.Reflection;
using AspNetCoreRateLimit;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using igoodi.receiver360.api.Helpers;
using igoodi.receiver360.common.infrastructure.Exceptions.Repositories;
using igoodi.receiver360.common.infrastructure.Helpers.Serializers;
using igoodi.receiver360.common.infrastructure.PropertyMappings;
using igoodi.receiver360.common.infrastructure.PropertyMappings.TypeHelpers;
using igoodi.receiver360.common.infrastructure.TypeMappings;
using igoodi.receiver360.common.infrastructure.UnitOfWorks;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.contracts.V1;
using igoodi.receiver360.repository.ContractRepositories;
using igoodi.receiver360.repository.Mappings.Assets;
using igoodi.receiver360.repository.NhUnitOfWork;
using igoodi.receiver360.repository.Repositories;
using igoodi.receiver360.services.Assets;
using igoodi.receiver360.services.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Spatial.Dialect;
using NHibernate.Spatial.Mapping;
using NHibernate.Spatial.Metadata;

namespace igoodi.receiver360.api.Configurations
{
  public static class Config
  {
    public static void ConfigureRepositories(IServiceCollection services)
    {
      services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
      services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
      services.AddScoped<IUrlHelper>(implementationFactory =>
      {
        var actionContext = implementationFactory.GetService<IActionContextAccessor>()
          .ActionContext;
        return new UrlHelper(actionContext);
      });

      services.AddScoped<IUrlHelper>(x =>
      {
        var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
        var factory = x.GetRequiredService<IUrlHelperFactory>();
        return factory.GetUrlHelper(actionContext);
      });

      services.AddSingleton<IPropertyMappingService, PropertyMappingService>();
      services.AddSingleton<ITypeHelperService, TypeHelperService>();

      services.AddTransient<IJsonSerializer, JSONSerializer>();

      services.AddScoped<IInquiryAssetProcessor, InquiryAssetProcessor>();
      services.AddScoped<IInquiryAllAssetsProcessor, InquiryAllAssetsProcessor>();
      services.AddScoped<ICreateAssetProcessor, CreateAssetProcessor>();
      services.AddScoped<IUpdateAssetProcessor, UpdateAssetProcessor>();
      services.AddScoped<IDeleteAssetProcessor, DeleteAssetProcessor>();
      services.AddScoped<IAssetRepository, AssetRepository>();
      services.AddScoped<IAssetsControllerDependencyBlock, AssetsControllerDependencyBlock>();
    }

    public static void ConfigureAutoMapper(IServiceCollection services)
    {
      services.AddSingleton<IAutoMapper, AutoMapperAdapter>();
    }

    public static void ConfigureNHibernate(IServiceCollection services, string connectionString)
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

      try
      {
        var cfg = Fluently.Configure()
          .Database(PostgreSQLConfiguration.PostgreSQL82
            .ConnectionString(connectionString)
            .Driver<NpgsqlDriver>()
            .Dialect<PostGis20Dialect>()
            .ShowSql()
            .MaxFetchDepth(5)
            .FormatSql()
            .Raw("transaction.use_connection_on_system_prepare", "true")
            .AdoNetBatchSize(100)
          )
          .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AssetMap>())
          .Cache(c => c.UseSecondLevelCache().UseQueryCache()
            .ProviderClass(typeof(NHibernate.Caches.RtMemoryCache.RtMemoryCacheProvider)
              .AssemblyQualifiedName)
          )
          .CurrentSessionContext("web")
          .BuildConfiguration();

        cfg.AddAssembly(Assembly.GetExecutingAssembly());
        cfg.AddAuxiliaryDatabaseObject(new SpatialAuxiliaryDatabaseObject(cfg));
        Metadata.AddMapping(cfg, MetadataClass.GeometryColumn);
        Metadata.AddMapping(cfg, MetadataClass.SpatialReferenceSystem);

        var sessionFactory = cfg.BuildSessionFactory();

        services.AddSingleton<ISessionFactory>(sessionFactory);

        services.AddScoped<ISession>((ctx) =>
        {
          var sf = ctx.GetRequiredService<ISessionFactory>();

          return sf.OpenSession();

        });

        services.AddScoped<IUnitOfWork, NhUnitOfWork>();
      }
      catch (Exception ex)
      {
        throw new NHibernateInitializationException(ex.Message, ex.InnerException?.Message);
      }
    }
  }
}
