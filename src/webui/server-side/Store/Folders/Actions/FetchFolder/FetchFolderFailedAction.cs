namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder
{
  public class FetchFolderFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchFolderFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}