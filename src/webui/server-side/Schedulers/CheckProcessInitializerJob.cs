using System;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Commanding.Servers;
using Quartz;

namespace igoodi.receiver360.webui.Schedulers
{
  public class CheckProcessInitializerJob : IJob
  {
    public Task Execute(IJobExecutionContext context)
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer
        .RaiseCheckProcessingDetection($"New Check for Income scanned:{DateTime.Now}", -1);
      return Task.CompletedTask;
    }
  }
}