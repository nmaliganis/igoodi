using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Retexturing
{
  public class FetchRetexturingFailuresFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchRetexturingFailuresFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}