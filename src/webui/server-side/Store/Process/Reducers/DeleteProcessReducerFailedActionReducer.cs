using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class DeleteProcessReducerFailedActionReducer : Reducer<ProcessState, DeleteProcessFailedAction>
  {
    public override ProcessState Reduce(ProcessState state, DeleteProcessFailedAction action)
    {
      return new ProcessState(
        state.ProcessList,
        action.ErrorMessage,
        state.IsLoading,
        state.CrRecoLastProcess,
        state.CrRecoMaxProcess,
        state.CrRecoLastProcess,
        state.CrRecoMaxProcess,
        state.MayaLastProcess,
        state.MayaMaxProcess,
        state.UnityLastProcess,
        state.UnityMaxProcess
      );
    }
  }
}