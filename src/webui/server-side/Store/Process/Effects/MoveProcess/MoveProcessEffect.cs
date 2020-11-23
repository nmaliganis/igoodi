using System;
using System.Threading.Tasks;
using Fluxor;
using igoodi.receiver360.webui.Services.Contracts;
using igoodi.receiver360.webui.Store.Process.Actions.MoveProcess;

namespace igoodi.receiver360.webui.Store.Process.Effects.MoveProcess
{
  public class MoveProcessEffect : Effect<MoveProcessAction>
  {
    public IFolderService FolderDataService { get; set; }

    public MoveProcessEffect(IFolderService folderDataService)
    {
      FolderDataService = folderDataService;
    }

    protected override async Task HandleAsync(MoveProcessAction action, IDispatcher dispatcher)
    {
      try
      {
        await FolderDataService.ProcessReconstructionFailed();
        await FolderDataService.ProcessRetexturingFailed();
        await FolderDataService.ProcessMayaFailed();
        await FolderDataService.ProcessUnityFailed();
        dispatcher.Dispatch(new MoveProcessSuccessAction());
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new MoveProcessFailedAction(e.Message));
      }
    }
  }
}