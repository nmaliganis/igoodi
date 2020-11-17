using System;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Commanding.Servers;
using Quartz;

namespace igoodi.receiver360.webui.Schedulers
{
  public class CheckIncomingInitializerJob : IJob
  {
    public Task Execute(IJobExecutionContext context)
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.RaiseScannedDetection($"New Check for Income scanned:{DateTime.Now}");
      return Task.CompletedTask;
    }
  }
}