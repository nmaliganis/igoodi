using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Maya
{
  public class FetchMayaFailuresFolderListEffect : Effect<FetchMayaFailureFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchMayaFailuresFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchMayaFailureFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetMayaFailedFolderList();
        dispatcher.Dispatch(new FetchFailedFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}