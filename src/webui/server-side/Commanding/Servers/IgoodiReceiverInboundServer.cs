using igoodi.receiver360.webui.Commanding.Servers.Base;

namespace igoodi.receiver360.webui.Commanding.Servers
{
  public sealed class IgoodiReceiverInboundServer : IIgoodiReceiverInboundServer
  {
    private IgoodiReceiverInboundServer()
    {
            
    }
    public static IgoodiReceiverInboundServer GetIgoodiReceiverInboundServer { get; } = new IgoodiReceiverInboundServer();
  }
}