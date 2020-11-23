using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya
{
  public class FetchMayaFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchMayaFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}