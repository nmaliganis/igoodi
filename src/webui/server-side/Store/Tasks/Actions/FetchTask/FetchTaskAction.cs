using System;

namespace igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask
{
  public class FetchTaskAction
  {
    public Guid TaskId { get; private set; }
    public FetchTaskAction(Guid idTask)
    {
      TaskId = idTask;
    }
  }
}