using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders
{
  public class FolderState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<FolderDto> FolderList { get; private set; }
    public List<FolderDto> FailedFolderList { get; private set; }
    public List<FolderDto> ReconstructionFolderList { get; private set; }
    public List<FolderDto> RetexturingFolderList { get; private set; }
    public List<FolderDto> MayaFolderList { get; private set; }
    public List<FolderDto> UnityFolderList { get; private set; }
    public FolderDto Folder { get; private set; }

    public FolderState(
      List<FolderDto> folderList, 
      List<FolderDto> failedFolderList, 
      List<FolderDto> reconstructionFolderList, 
      List<FolderDto> retexturingFolderList, 
      List<FolderDto> mayaFolderList, 
      List<FolderDto> unityFolderList, 
      string errorMessage, 
      bool isLoading,
      FolderDto folder
    )
    {
      FolderList  = folderList;
      FailedFolderList  = failedFolderList;
      ReconstructionFolderList  = reconstructionFolderList;
      RetexturingFolderList  = retexturingFolderList;
      MayaFolderList  = mayaFolderList;
      UnityFolderList  = unityFolderList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Folder = folder;
    }
  }
}