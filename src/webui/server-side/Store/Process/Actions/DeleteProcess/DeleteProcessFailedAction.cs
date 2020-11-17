namespace igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess
{
  public class DeleteProcessFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteProcessFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}