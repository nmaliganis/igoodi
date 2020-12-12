using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Process.Effects.DeleteProcess
{
  public class DeleteProcessEffect : Effect<DeleteProcessAction>
  {
    public IFolderService FolderDataService { get; set; }
    public IConfiguration Configuration { get; set; }

    public DeleteProcessEffect(IFolderService folderDataService, IConfiguration configuration)
    {
      FolderDataService = folderDataService;
      Configuration = configuration;
    }

    protected override async Task HandleAsync(DeleteProcessAction action, IDispatcher dispatcher)
    {
      try
      {
        if (action.Step == ProcessStep.Reconstruction)
        {
            var list = FolderDataService.GetReconstructionFolderList().Result;

            foreach (var folderDto in list)
            {
              var indexForRecon =
                Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value);

              for (int i = 1; i <= indexForRecon; i++)
              {
                var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
                  .Value + "\\" + i;
                if (FileChecker.Checker.ExistFile(folderDto.Name, destFile))
                {
                  bool result = await FolderDataService.ProcessReconstructionDelete(folderDto.Name);
                  if (result)
                    dispatcher.Dispatch(new DeleteProcessSuccessAction(folderDto.Name));
                  return;
                }
              }
            }
        }
        else if (action.Step == ProcessStep.Retexturing)
        {
          var list = FolderDataService.GetRetexturingFolderList().Result;

          foreach (var folderDto in list)
          {
            var indexForText =
              Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value);

            for (int i = 1; i <= indexForText; i++)
            {
              var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_path")
                .Value + "\\" + i;
              if (FileChecker.Checker.ExistFile(folderDto.Name, destFile))
              {
                bool result = await FolderDataService.ProcessRetexturingDelete(folderDto.Name);
                if (result)
                  dispatcher.Dispatch(new DeleteProcessSuccessAction(folderDto.Name));
                return;
              }
            }
          }
        }
        else if (action.Step == ProcessStep.Maya)
        {
          var list = FolderDataService.GetMayaFolderList().Result;

          foreach (var folderDto in list)
          {
            var indexForMaya =
              Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:maya").Value);

            for (int i = 1; i <= indexForMaya; i++)
            {
              var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
                .Value + "\\" + i;
              if (FileChecker.Checker.ExistFile(folderDto.Name, destFile))
              {
                bool result = await FolderDataService.ProcessMayaDelete(folderDto.Name);
                if (result)
                  dispatcher.Dispatch(new DeleteProcessSuccessAction(folderDto.Name));
                return;
              }
            }
          }
        }
        else if (action.Step == ProcessStep.Unity)
        {
          var list = FolderDataService.GetUnityFolderList().Result;

          foreach (var folderDto in list)
          {
            var indexForUnity =
              Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:unity").Value);

            for (int i = 1; i <= indexForUnity; i++)
            {
              var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
                .Value + "\\" + i;
              if (FileChecker.Checker.ExistFile(folderDto.Name, destFile))
              {
                bool result = await FolderDataService.ProcessUnityDelete(folderDto.Name);
                if (result)
                  dispatcher.Dispatch(new DeleteProcessSuccessAction(folderDto.Name));
                return;
              }
            }
          }
        }
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new DeleteProcessFailedAction(e.Message));
      }
    }
  }
}