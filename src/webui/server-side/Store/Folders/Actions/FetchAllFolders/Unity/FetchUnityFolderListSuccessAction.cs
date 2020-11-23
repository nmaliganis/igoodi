using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity
{
  public class FetchUnityFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchUnityFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}