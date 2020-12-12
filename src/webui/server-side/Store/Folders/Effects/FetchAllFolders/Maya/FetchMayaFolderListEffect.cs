using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Maya
{
  public class FetchMayaFolderListEffect : Effect<FetchMayaFolderListAction>
  {
    public IFolderService FolderDataService { get; set; }
    public IConfiguration Configuration { get; set; }
    public FetchMayaFolderListEffect(IFolderService folderDataService, IConfiguration configuration)
    {
      FolderDataService = folderDataService;
      Configuration = configuration;
    }

    protected override async Task HandleAsync(FetchMayaFolderListAction action, IDispatcher dispatcher)
    {
      try
      {

        var indexForMaya =
          Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:maya").Value);

        var folderMaya = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
          .Value;

        await FolderDataService.CreateFolders(indexForMaya, folderMaya);

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