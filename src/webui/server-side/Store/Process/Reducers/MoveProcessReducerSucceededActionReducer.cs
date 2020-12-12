using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.MoveProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class MoveProcessReducerSucceededActionReducer : Reducer<ProcessState, MoveProcessSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, MoveProcessSuccessAction action)
    {
      return new ProcessState(
        state.ProcessList,
        state.ErrorMessage,
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