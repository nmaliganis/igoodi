using System;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace igoodi.receiver360.webui.Proxies
{
  public class FolderMoverConfiguration : IFolderMoverConfiguration, IScannedDetectionActionListener
  {
    public IConfiguration Configuration { get; }
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IServiceProvider _service;

    public FolderMoverConfiguration(IConfiguration configuration, 
      IServiceScopeFactory scopeFactory, IServiceProvider service)
    {
      Configuration = configuration;
      _scopeFactory = scopeFactory;
      _service = service;
    }
    public void EstablishConnection()
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
    }
    public void Update(object sender, ScannedDetectionEventArgs e)
    {
      //Todo: Check for Movements
    }
  }
}