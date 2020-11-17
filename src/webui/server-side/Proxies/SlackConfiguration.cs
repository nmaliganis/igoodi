
using System;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using igoodi.receiver360.webui.Slack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace igoodi.receiver360.webui.Proxies
{
  public class SlackConfiguration : ISlackConfiguration, IScannedDetectionActionListener
  {
    public IConfiguration Configuration { get; }
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IServiceProvider _service;
    private readonly ISlackMessageSender _slackService;

    public SlackConfiguration(IConfiguration configuration, 
      IServiceScopeFactory scopeFactory, IServiceProvider service, ISlackMessageSender slackService)
    {
      Configuration = configuration;
      _scopeFactory = scopeFactory;
      _service = service;

      _slackService = slackService;
    }

    public void EstablishConnection()
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
    }

    public void Update(object sender, ScannedDetectionEventArgs e)
    {
      _slackService.SendMessageOnRandomAsync($"New Scanned at:{DateTime.Now}");
    }
  }
}