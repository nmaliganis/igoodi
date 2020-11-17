using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders
{
  public class FetchFailedFolderListSuccessAction
  {
  public List<FolderDto> FolderList { get; private set; }

  public FetchFailedFolderListSuccessAction(List<FolderDto> folderList)
  {
    FolderList = folderList;
  }
  }
}