using System;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Commanding.Servers;
using Quartz;

namespace igoodi.receiver360.webui.Schedulers
{
  public class EstablishCognitoInitializerJob : IJob
  {
    public Task Execute(IJobExecutionContext context)
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.RaiseCheckCognitoDetection($"Cognito:{DateTime.Now}");
      return Task.CompletedTask;
    }
  }
}