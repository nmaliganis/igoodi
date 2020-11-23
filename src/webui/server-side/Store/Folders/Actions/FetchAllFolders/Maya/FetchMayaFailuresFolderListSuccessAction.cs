using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya
{
  public class FetchMayaFailuresFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchMayaFailuresFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}