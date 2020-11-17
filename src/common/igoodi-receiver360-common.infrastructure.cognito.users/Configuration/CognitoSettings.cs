using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Configuration
{
    public class CognitoSettings
    {
        public static void AddJsonFile(string configFile)
        {
            JsonConfigFile = configFile;
        }

        private static string JsonConfigFile { get; set; } = "/appsettings.json";

        public static void ConfigureServices(IServiceCollection services)
        {
          services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
              options.Audience = CognitoSettings.Values.UserPoolClientId;
              options.Authority =
                $"https://cognito-idp.{CognitoSettings.Values.Region}.amazonaws.com/{CognitoSettings.Values.UserPoolId}";
            });
        }

        private static object lockObject = new object();

        public static CognitoSettingValues Values
        { get
            {
                lock (lockObject)
                {
                    if (_cognitoSettings == null)
                    {
                        GetConfiguration();
                    }
                }
                return _cognitoSettings;
            }
        }

        private static CognitoSettingValues _cognitoSettings = null;

        private static void GetConfiguration()
        {
            string baseDir = Directory.GetCurrentDirectory();

            IConfiguration configuration = new ConfigurationBuilder()
              .SetBasePath(baseDir)
              .AddJsonFile(baseDir + JsonConfigFile, optional: true)
              .Build();

            _cognitoSettings = configuration.GetSection("AWS").Get<CognitoSettingValues>();
        }

    }
}
