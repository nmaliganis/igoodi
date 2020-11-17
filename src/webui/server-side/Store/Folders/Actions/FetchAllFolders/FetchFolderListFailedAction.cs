namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders
{
  public class FetchFolderListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchFolderListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}