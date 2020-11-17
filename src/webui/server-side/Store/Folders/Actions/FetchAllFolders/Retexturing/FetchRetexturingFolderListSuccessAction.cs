using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders
{
  public class FetchRetexturingFolderListSuccessAction
  {
  public List<FolderDto> FolderList { get; private set; }

  public FetchRetexturingFolderListSuccessAction(List<FolderDto> folderList)
  {
    FolderList = folderList;
  }
  }
}