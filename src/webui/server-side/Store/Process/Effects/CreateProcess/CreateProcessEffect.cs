using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Effects.CreateProcess
{
  public class CreateProcessEffect : Effect<CreateProcessAction>
  {
    public IFolderService FolderDataService { get; set; }
    public CreateProcessEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(CreateProcessAction action, IDispatcher dispatcher)
    {
      try
      {
        var processContained = action.ProcessList.Where(x => x.Name.Contains(action.Name));
        if(processContained.Any())
          return;

        if (action.Step == ProcessStep.Reconstruction)
        {
          var processRec =
            await FolderDataService.ProcessReconstructionScanFolder(action.Name, action.CurrentProcess.ToString());
          if(processRec != null)
            dispatcher.Dispatch(new CreateProcessSuccessAction(processRec));
        }
        if (action.Step == ProcessStep.Retexturing)
        {
          var processTex =
            await FolderDataService.ProcessRetexturingScanFolder(action.Name, action.CurrentProcess.ToString());
          if(processTex != null)
            dispatcher.Dispatch(new CreateProcessSuccessAction(processTex));
        }
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new CreateProcessFailedAction(e.Message));
      }     
    }
  }
}