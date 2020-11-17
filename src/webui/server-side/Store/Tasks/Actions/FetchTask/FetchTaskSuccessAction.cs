using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask
{
  public class FetchTaskSuccessAction
  {
    public TaskDto Task { get; private set; }

    public FetchTaskSuccessAction(TaskDto task)
    {
      Task = task;
    }
  }
}