using System;
using igoodi.receiver360.common.infrastructure.cognito.users;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace igoodi.receiver360.webui.Proxies
{
  public class CognitoConfiguration : ICognitoConfiguration, ICheckCognitoDetectionActionListener
  {
    public IConfiguration Configuration { get; }
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IServiceProvider _service;
    public CognitoConfiguration(IConfiguration configuration, 
      IServiceScopeFactory scopeFactory, IServiceProvider service)
    {
      Configuration = configuration;
      _scopeFactory = scopeFactory;
      _service = service;
    }

    public void EstablishConnection()
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((ICheckCognitoDetectionActionListener) this);
    }

    public async void Update(object sender, CheckCognitoDetectionEventArgs e)
    {
      string email = "lorenzo.daneo@coolshop.it";
      string password = "Coolshop83-";

      CognitoUserManager cognito = new CognitoUserManager();
      var token = cognito.Login(email, password);
      if (token != null)
      {
      }
    }
  }
}