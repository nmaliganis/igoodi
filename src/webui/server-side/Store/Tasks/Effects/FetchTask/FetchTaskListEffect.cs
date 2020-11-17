using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask;

namespace igoodi.receiver360.webui.Store.Tasks.Effects.FetchTask
{
  public class FetchTaskEffect : Effect<FetchTaskAction>
  {
    public ITaskService TaskDataService { get; set; }
    public FetchTaskEffect(ITaskService taskDataService)
    {
      TaskDataService = taskDataService;
    }

    protected override async Task HandleAsync(FetchTaskAction action, IDispatcher dispatcher)
    {
      try
      {
        var task = await TaskDataService.GetTask(action.TaskId);
        dispatcher.Dispatch(new FetchTaskSuccessAction(task));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchTaskFailedAction(e.Message));
      }     
    }
  }
}