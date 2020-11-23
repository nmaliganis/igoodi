using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;
using igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess;

namespace igoodi.receiver360.webui.Store.Process.Effects.DeleteProcess
{
  public class DeleteProcessEffect : Effect<DeleteProcessAction>
  {
    public IFolderService FolderDataService { get; set; }
    public DeleteProcessEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(DeleteProcessAction action, IDispatcher dispatcher)
    {
      try
      {
        if (action.Step == ProcessStep.Reconstruction)
        {
            await FolderDataService.ProcessReconstructionDelete(action.Name);
            dispatcher.Dispatch(new DeleteProcessSuccessAction(action.Name));
        }
        else if (action.Step == ProcessStep.Retexturing)
        {
            await FolderDataService.ProcessRetexturingDelete(action.Name);
            dispatcher.Dispatch(new DeleteProcessSuccessAction(action.Name));
        }
        else if (action.Step == ProcessStep.Maya)
        {
          await FolderDataService.ProcessMayaDelete(action.Name);
          dispatcher.Dispatch(new DeleteProcessSuccessAction(action.Name));
        }
        else if (action.Step == ProcessStep.Unity)
        {
          await FolderDataService.ProcessUnityDelete(action.Name);
          dispatcher.Dispatch(new DeleteProcessSuccessAction(action.Name));
        }
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new DeleteProcessFailedAction(e.Message));
      }     
    }
  }
}