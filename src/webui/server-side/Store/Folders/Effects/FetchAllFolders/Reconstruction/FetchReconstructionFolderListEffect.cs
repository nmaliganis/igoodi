using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFolderListEffect : Effect<FetchReconstructionFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchReconstructionFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchReconstructionFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetReconstructionFolderList();
        dispatcher.Dispatch(new FetchReconstructionFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}