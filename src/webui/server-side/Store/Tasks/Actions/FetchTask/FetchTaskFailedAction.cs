namespace igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask
{
  public class FetchTaskFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchTaskFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}