using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFolderListSuccessAction
  {
    public List<FolderDto> FolderList { get; private set; }

    public FetchReconstructionFolderListSuccessAction(List<FolderDto> folderList)
    {
      FolderList = folderList;
    }
  }
}