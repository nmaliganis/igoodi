namespace igoodi.receiver360.webui.Store.Process.Actions.CreateProcess
{
  public class CreateProcessFailedAction
  {
    public string ErrorMessage { get; private set; }
    public CreateProcessFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}