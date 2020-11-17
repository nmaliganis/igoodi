using igoodi.receiver360.webui.Models.DTOs.Folders;
using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder
{
  public class FetchFolderSuccessAction
  {
    public FolderDto Folder { get; private set; }

    public FetchFolderSuccessAction(FolderDto folder)
    {
      Folder = folder;
    }
  }
}