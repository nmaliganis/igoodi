using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks
{
  public class FetchTaskListSuccessAction
  {
    public List<TaskItemDto> TaskList { get; private set; }

    public FetchTaskListSuccessAction(List<TaskItemDto>  taskList)
    {
      TaskList  = taskList;
    }
  }
}