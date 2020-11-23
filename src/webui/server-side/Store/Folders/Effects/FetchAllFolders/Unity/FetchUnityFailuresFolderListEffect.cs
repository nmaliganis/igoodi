using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Unity
{
  public class FetchUnityFailuresFolderListEffect : Effect<FetchUnityFailureFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchUnityFailuresFolderListEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchUnityFailureFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var folders = await FolderDataService.GetUnityFailedFolderList();
        dispatcher.Dispatch(new FetchFailedFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}