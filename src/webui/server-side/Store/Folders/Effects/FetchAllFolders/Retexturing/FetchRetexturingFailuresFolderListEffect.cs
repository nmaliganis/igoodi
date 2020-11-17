using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Retexturing;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Retexturing
{
  public class FetchRetexturingFailuresFolderListEffect : Effect<FetchRetexturingFailureFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchRetexturingFailuresFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchRetexturingFailureFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetRetexturingFailedFolderList();
        dispatcher.Dispatch(new FetchFailedFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}