using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Unity
{
  public class FetchUnityFolderListEffect : Effect<FetchUnityFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchUnityFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchUnityFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetUnityFolderList();
        dispatcher.Dispatch(new FetchUnityFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}