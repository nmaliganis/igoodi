using System.Collections.Generic;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Folders;

namespace igoodi.receiver360.webui.Store.Folders
{
  public class FolderFeature : Feature<FolderState>
  {
    public override string GetName() => "Folder";

    protected override FolderState GetInitialState() => new FolderState(
      new List<FolderDto>(), 
      new List<FolderDto>(), 
      new List<FolderDto>(), 
      new List<FolderDto>(), 
      new List<FolderDto>(), 
      new List<FolderDto>(), 
      "",
      true,
      null
      );
  }
}