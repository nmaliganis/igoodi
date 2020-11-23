using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Maya
{
  public class FetchMayaFolderListEffect : Effect<FetchMayaFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchMayaFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchMayaFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetMayaFolderList();
        dispatcher.Dispatch(new FetchMayaFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}