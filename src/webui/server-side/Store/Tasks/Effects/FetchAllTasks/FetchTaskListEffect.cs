using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Tasks;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks;

namespace igoodi.receiver360.webui.Store.Tasks.Effects.FetchAllTasks
{
  public class FetchTaskListEffect : Effect<FetchTaskListAction>
  {
    public ITaskService TaskDataService { get; set; }
    public FetchTaskListEffect(ITaskService taskDataService)
    {
      TaskDataService = taskDataService;
    }

    protected override async Task HandleAsync(FetchTaskListAction action, IDispatcher dispatcher)
    {
      try
      {
        var tasks = await TaskDataService.GetTaskList();
        List<TaskItemDto>  taskList = new List<TaskItemDto>();
        foreach (var task in tasks.Items)
        {
          taskList.Add(new TaskItemDto()
          {
            Id = task.Id,
            Voucher = task.Voucher.VoucherCode,
            Type = task.ScanProcessType.Code
          });
        }

        dispatcher.Dispatch(new FetchTaskListSuccessAction(taskList));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchTaskListFailedAction(e.Message));
      }      
    }
  }
}