using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Retexturing;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Retexturing
{
  public class FetchRetexturingFolderListEffect : Effect<FetchRetexturingFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchRetexturingFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchRetexturingFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetRetexturingFolderList();
        dispatcher.Dispatch(new FetchRetexturingFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}