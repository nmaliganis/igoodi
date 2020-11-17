using Amazon;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Configuration
{
  public class CognitoSettingValues
  {
    public string UserPoolId { get; set; }
    public string UserPoolClientId { get; set; }

    public string Region { get; set; }

    public string UserPoolClientSecret { get; set; }

    public RegionEndpoint RegionEndpoint => RegionEndpoint.GetBySystemName(Region);
  }
}
