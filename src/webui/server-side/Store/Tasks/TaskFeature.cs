using System.Collections.Generic;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Store.Tasks
{
  public class TaskFeature : Feature<TaskState>
  {
    public override string GetName() => "Task";

    protected override TaskState GetInitialState() => new TaskState(
      new List<TaskItemDto>(), 
      "",
      true,
      null
      );
  }
}