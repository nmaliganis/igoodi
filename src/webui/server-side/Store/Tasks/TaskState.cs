using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Store.Tasks
{
  public class TaskState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<TaskItemDto> TaskList { get; private set; }
    public TaskDto Task { get; private set; }

    public TaskState(
      List<TaskItemDto> taskList, 
      string errorMessage, 
      bool isLoading,
      TaskDto task
    )
    {
      TaskList  = taskList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Task = task;
    }
  }
}