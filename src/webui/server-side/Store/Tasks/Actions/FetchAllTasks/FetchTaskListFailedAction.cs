namespace igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks
{
  public class FetchTaskListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchTaskListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}