using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFailuresFolderListEffect : Effect<FetchReconstructionFailureFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchReconstructionFailuresFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchReconstructionFailureFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetReconstructionFailedFolderList();
        dispatcher.Dispatch(new FetchFailedFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}