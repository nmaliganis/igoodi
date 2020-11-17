using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchFolder
{
  public class FetchFolderEffect : Effect<FetchFolderAction>
  {
    public IFolderService FolderDataService { get; set; }
    public FetchFolderEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(FetchFolderAction action, IDispatcher dispatcher)
    {
      try
      {
        var folder = await FolderDataService.GetFolder(action.Name);
        dispatcher.Dispatch(new FetchFolderSuccessAction(folder));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderFailedAction(e.Message));
      }     
    }
  }
}