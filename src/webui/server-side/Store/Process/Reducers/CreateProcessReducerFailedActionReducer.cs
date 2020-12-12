using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class CreateProcessReducerFailedActionReducer : Reducer<ProcessState, CreateProcessFailedAction>
  {
    public override ProcessState Reduce(ProcessState state, CreateProcessFailedAction action)
    {
      return new ProcessState(
        state.ProcessList,
        action.ErrorMessage,
        state.IsLoading,
        state.CrRecoLastProcess,
        state.CrRecoMaxProcess,
        state.CrTextLastProcess,
        state.CrTextMaxProcess,
        state.MayaLastProcess,
        state.MayaMaxProcess,
        state.UnityLastProcess,
        state.UnityMaxProcess
      );
    }
  }
}