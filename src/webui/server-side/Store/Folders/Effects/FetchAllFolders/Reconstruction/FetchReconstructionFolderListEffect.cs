using System;
using System.Configuration;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Folders.Effects.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFolderListEffect : Effect<FetchReconstructionFolderListAction>
  {
    public IConfiguration Configuration { get; set; }
    public IFolderService FolderDataService { get; set; }
    public FetchReconstructionFolderListEffect(IFolderService folderDataService, IConfiguration configuration)
    {
      FolderDataService = folderDataService;
      Configuration = configuration;
    }

    protected override async Task HandleAsync(FetchReconstructionFolderListAction action, IDispatcher dispatcher)
    {
      try
      {     
        var indexForRecon =
          Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value);

        var folderReconstruction = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
          .Value;

        await FolderDataService.CreateFolders(indexForRecon, folderReconstruction);

        var folders = await FolderDataService.GetReconstructionFolderList();
        dispatcher.Dispatch(new FetchReconstructionFolderListSuccessAction(folders));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchFolderListFailedAction(e.Message));
      }      
    }
  }
}