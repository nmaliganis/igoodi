using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFailuresFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchReconstructionFailuresFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}