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
    Task<FolderDto> GetFolder(string name);
    Task<ProcessDto> ProcessReconstructionScanFolder(string name, string destination);
    Task<ProcessDto> ProcessRetexturingScanFolder(string name, string destination);

    Task ProcessReconstructionDelete(string name);
    Task ProcessRetexturingDelete(string name);

    Task ProcessReconstructionFailed();
    Task ProcessRetexturingFailed();
  }
}