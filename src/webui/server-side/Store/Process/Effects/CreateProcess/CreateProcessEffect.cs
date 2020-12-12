using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Process.Effects.CreateProcess
{
  public class CreateProcessEffect : Effect<CreateProcessAction>
  {
    public IFolderService FolderDataService { get; set; }
    public IConfiguration Configuration { get; set; }
    public CreateProcessEffect(IFolderService folderDataService, IConfiguration configuration)
    {
      FolderDataService = folderDataService;
      Configuration = configuration;
    }

    protected override async Task HandleAsync(CreateProcessAction action, IDispatcher dispatcher)
    {
      try
      {
        if (action.Step == ProcessStep.Reconstruction)
        {
          int index = action.CurrentProcess;
          var indexForRecon =
            Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value);

          var folderReconstruction = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
            .Value;

          await FolderDataService.CreateFolders(indexForRecon, folderReconstruction);

          for (int i = 1; i <= indexForRecon; i++)
          {
            var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
              .Value +"\\" + i;
            if (FileChecker.Checker.ExistFile(action.Name, destFile))
              return;
          }

          for (int i = 1; i <= indexForRecon; i++)
          {
            var processRec =
              await FolderDataService.ProcessReconstructionScanFolder(action.Name, i.ToString());
            if (processRec != null)
            {
              dispatcher.Dispatch(new ReconstructionSuccessAction(processRec, i,
                Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value)));
              break;
            }
            if (index < indexForRecon)
            {
              index += 1;
            }
            else
            {
              index = 1;
            }
          }
        }
        else if (action.Step == ProcessStep.Retexturing)
        {
          int index = action.CurrentProcess;
          var indexForText =
            Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value);

          var folderRetexturing = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_path")
            .Value;

          await FolderDataService.CreateFolders(indexForText, folderRetexturing);

          for (int i = 1; i <= indexForText; i++)
          {
            var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_path")
              .Value +"\\" + i;
            if (FileChecker.Checker.ExistFile(action.Name, destFile))
              return;
          }

          for (int i = 1; i <= indexForText; i++)
          {
            var processTex =
              await FolderDataService.ProcessRetexturingScanFolder(action.Name, i.ToString());
            if (processTex != null)
            {
              dispatcher.Dispatch(new RetexturingSuccessAction(processTex, i,
                Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:cr").Value)));
              break;
            }
            if (index < indexForText)
            {
              index += 1;
            }
            else
            {
              index = 1;
            }
          }
        }
        else if (action.Step == ProcessStep.Maya)
        {
          int index = action.CurrentProcess;
          var indexForMaya =
            Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:maya").Value);

          var folderMaya = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
            .Value;

          await FolderDataService.CreateFolders(indexForMaya, folderMaya);

          for (int i = 1; i <= indexForMaya; i++)
          {
            var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
              .Value +"\\" + i;
            if (FileChecker.Checker.ExistFile(action.Name, destFile))
              return;
          }

          for (int i = 1; i <= indexForMaya; i++)
          {
            var processMaya =
              await FolderDataService.ProcessMayaScanFolder(action.Name, i.ToString());
            if (processMaya != null)
            {
              dispatcher.Dispatch(new MayaSuccessAction(processMaya, i,
                Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:maya").Value)));
              break;
            }
            if (index < indexForMaya)
            {
              index += 1;
            }
            else
            {
              index = 1;
            }
          }
        }
        else if (action.Step == ProcessStep.Unity)
        {
          int index = action.CurrentProcess;
          var indexForUnity =
            Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:unity").Value);

          var folderUnity= Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
            .Value;

          await FolderDataService.CreateFolders(indexForUnity, folderUnity);

          for (int i = 1; i <= indexForUnity; i++)
          {
            var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
              .Value +"\\" + i;
            if (FileChecker.Checker.ExistFile(action.Name, destFile))
              return;
          }

          for (int i = 1; i <= indexForUnity; i++)
          {
            var processUnity =
              await FolderDataService.ProcessUnityScanFolder(action.Name, i.ToString());
            if (processUnity != null)
            {
              dispatcher.Dispatch(new UnitySuccessAction(processUnity, i,
                Int32.Parse(Configuration.GetSection($"{Configuration["env"]}:processors:unity").Value)));
              break;
            }
            if (index < indexForUnity)
            {
              index += 1;
            }
            else
            {
              index = 1;
            }
          }
        }
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new CreateProcessFailedAction(e.Message));
      }     
    }
  }
}