using System;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Commanding.Servers;
using Quartz;

namespace igoodi.receiver360.webui.Schedulers
{
  public class CheckProcessFailuresInitializerJob : IJob
  {
    public Task Execute(IJobExecutionContext context)
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer
        .RaiseCheckFailureProcessingDetection($"New Check for Income scanned:{DateTime.Now}", -1);
      return Task.CompletedTask;
    }
  }
}