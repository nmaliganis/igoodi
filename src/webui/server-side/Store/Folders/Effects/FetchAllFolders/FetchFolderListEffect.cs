using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders
{
  public class FetchFolderListEffect : Effect<FetchFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetFolderList();
        dispatcher.Dispatch(new FetchFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}