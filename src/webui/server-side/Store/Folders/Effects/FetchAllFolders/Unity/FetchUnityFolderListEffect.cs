using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Unity
{
  public class FetchUnityFolderListEffect : Effect<FetchUnityFolderListAction>
  {
    public IConfiguration Configuration { get; set; }
    public IFolderService FolderDataService { get; set; }
    public FetchUnityFolderListEffect(IFolderService folderDataService, IConfiguration configuration)
    {
      FolderDataService = folderDataService;
      Configuration = configuration;
    }

    protected override async Task HandleAsync(FetchUnityFolderListAction action, IDispatcher dispatcher)
    {
      try
      {
        var indexForUnity =
          Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:unity").Value);

        var folderUnity= Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
          .Value;

        await FolderDataService.CreateFolders(indexForUnity, folderUnity);

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