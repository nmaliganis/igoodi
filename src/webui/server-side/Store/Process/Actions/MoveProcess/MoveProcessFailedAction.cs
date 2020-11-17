namespace igoodi.receiver360.webui.Store.Process.Actions.MoveProcess
{
  public class MoveProcessFailedAction
  {
    public string ErrorMessage { get; private set; }
    public MoveProcessFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}