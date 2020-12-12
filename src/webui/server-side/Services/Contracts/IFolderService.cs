using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Models.DTOs.Folders;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Services.Contracts
{
  public interface IFolderService
  {
    Task<List<FolderDto>> GetFolderList();
    Task<List<FolderDto>> GetReconstructionFolderList();
    Task<List<FolderDto>> GetReconstructionFailedFolderList();
    Task<List<FolderDto>> GetRetexturingFolderList();
    Task<List<FolderDto>> GetRetexturingFailedFolderList();

    Task<List<FolderDto>> GetMayaFolderList();
    Task<List<FolderDto>> GetMayaFailedFolderList();

    Task<List<FolderDto>> GetUnityFolderList();
    Task<List<FolderDto>> GetUnityFailedFolderList();

    Task<FolderDto> GetFolder(string name);
    Task<ProcessDto> ProcessReconstructionScanFolder(string name, string destination);
    Task<ProcessDto> ProcessRetexturingScanFolder(string name, string destination);
    Task<ProcessDto> ProcessMayaScanFolder(string name, string destination);
    Task<ProcessDto> ProcessUnityScanFolder(string name, string destination);

    Task CreateFolders(int processors, string folderReconstruction);

    Task<bool> ProcessReconstructionDelete(string name);
    Task<bool> ProcessRetexturingDelete(string name);
    Task<bool>ProcessMayaDelete(string name);
    Task<bool> ProcessUnityDelete(string name);

    Task ProcessReconstructionFailed();
    Task ProcessRetexturingFailed();
    Task ProcessMayaFailed();
    Task ProcessUnityFailed();
  }
}